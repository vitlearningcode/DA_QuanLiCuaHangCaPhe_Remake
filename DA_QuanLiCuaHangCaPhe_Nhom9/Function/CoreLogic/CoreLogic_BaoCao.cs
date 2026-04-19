using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic
{
    public class CoreLogic_BaoCao
    {
        // 1. Lấy Doanh thu và Số đơn trong ngày 
        public (decimal TongDoanhThu, int SoDon) ThongKeHomNay()
        {
            using (var db = new DataSqlContext())
            {
                DateTime startOfDay = DateTime.Now.Date;
                DateTime endOfDay = startOfDay.AddDays(1);

                var query = db.DonHangs.Where(dh => dh.TrangThai == "Hoàn thành" && dh.NgayLap >= startOfDay && dh.NgayLap < endOfDay);

                // ĐÃ FIX: Thêm chữ 'm' vào sau số 0 (0m)
                decimal doanhThu = query.Sum(dh => (decimal?)dh.TongTien) ?? 0m;
                int soDon = query.Count();

                return (doanhThu, soDon);
            }
        }

        // 2. Lấy Top 5 món bán chạy nhất
        public List<TopSanPhamView> LayTopSanPhamBanChay(int top)
        {
            using (var db = new DataSqlContext())
            {
                var dsDonHoanThanh = db.DonHangs.Where(dh => dh.TrangThai == "Hoàn thành").Select(dh => dh.MaDh).ToList();

                return db.ChiTietDonHangs
                    .Where(ct => dsDonHoanThanh.Contains(ct.MaDh))
                    .GroupBy(ct => ct.MaSp)
                    .Select(g => new TopSanPhamView
                    {
                        MaSP = g.Key,
                        TenSP = db.SanPhams.FirstOrDefault(sp => sp.MaSp == g.Key).TenSp,
                        TongSoLuong = g.Sum(ct => ct.SoLuong),
                        // ĐÃ FIX: Thêm chữ 'm' vào sau số 0
                        TongDoanhThu = g.Sum(ct => ct.SoLuong * ct.DonGia)
                    })
                    .OrderByDescending(x => x.TongSoLuong)
                    .Take(top).ToList();
            }
        }

        // 3. Cảnh báo Nguyên liệu sắp hết
        public List<NguyenLieu> LayNguyenLieuBaoDong()
        {
            using (var db = new DataSqlContext())
            {
                return db.NguyenLieus
                    .Where(nl => nl.SoLuongTon <= nl.NguongCanhBao && nl.TrangThai == "Đang kinh doanh")
                    .OrderBy(nl => nl.SoLuongTon)
                    .ToList();
            }
        }

        // 4. Doanh thu 7 ngày qua
        public List<DoanhThuNgayView> LayDoanhThu7Ngay()
        {
            using (var db = new DataSqlContext())
            {
                DateTime homNay = DateTime.Now.Date;
                DateTime ngayBatDau = homNay.AddDays(-6);
                DateTime endOfToday = homNay.AddDays(1);

                var data = db.DonHangs
                    .Where(dh => dh.TrangThai == "Hoàn thành" && dh.NgayLap >= ngayBatDau && dh.NgayLap < endOfToday)
                    .ToList()
                    .GroupBy(dh => dh.NgayLap.Value.Date)
                    // ĐÃ FIX: Thêm chữ 'm'
                    .Select(g => new { Ngay = g.Key, DoanhThu = g.Sum(dh => dh.TongTien ?? 0m) })
                    .ToList();

                var result = new List<DoanhThuNgayView>();
                for (int i = 0; i < 7; i++)
                {
                    DateTime date = ngayBatDau.AddDays(i);
                    var item = data.FirstOrDefault(x => x.Ngay == date);
                    // ĐÃ FIX: Thêm chữ 'm'
                    result.Add(new DoanhThuNgayView { Ngay = date, DoanhThu = item?.DoanhThu ?? 0m });
                }
                return result;
            }
        }
    }

    public class TopSanPhamView
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int TongSoLuong { get; set; }
        public decimal TongDoanhThu { get; set; }
    }

    public class DoanhThuNgayView
    {
        public DateTime Ngay { get; set; }
        public decimal DoanhThu { get; set; }
    }
}