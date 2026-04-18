using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class TongQuanService
    {
        // 1. Hàm tính 5 con số tổng quan
        public dynamic LaySoLieuTongQuan(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new DataSqlContext())
            {
                var start = tuNgay.Date;
                var end = denNgay.Date.AddDays(1).AddTicks(-1);

                // Lấy danh sách các đơn hàng trong khoảng thời gian
                var listDonHang = db.DonHangs
                                    .Where(dh => dh.NgayLap >= start && dh.NgayLap <= end)
                                    .Select(dh => new { dh.MaDh, dh.TongTien })
                                    .ToList();

                var listMaDh = listDonHang.Select(dh => dh.MaDh).ToList();

                // Tính DOANH SỐ (Tổng tiền gốc từ chi tiết đơn hàng: Số lượng * Đơn giá)
                decimal doanhSo = 0;
                if (listMaDh.Count > 0)
                {
                    doanhSo = db.ChiTietDonHangs
                                .Where(ct => listMaDh.Contains(ct.MaDh))
                                .Sum(ct => (decimal?)(ct.SoLuong * ct.DonGia)) ?? 0;
                }

                // Tính DOANH THU THUẦN (Tiền thực thu vào két sau khi đã trừ khuyến mãi)
                decimal doanhThuThuan = listDonHang.Sum(dh => (decimal?)dh.TongTien ?? 0);

                // Tính GIẢM GIÁ (Doanh số gốc - Doanh thu thuần)
                decimal giamGia = doanhSo - doanhThuThuan;
                if (giamGia < 0) giamGia = 0;

                // Tính TỔNG CHI (Từ bảng PhieuChi)
                decimal tongChi = db.PhieuChis
                                    .Where(c => c.NgayChi >= start && c.NgayChi <= end)
                                    .Sum(c => (decimal?)c.SoTien) ?? 0;

                // Tính LỢI NHUẬN
                decimal loiNhuan = doanhThuThuan - tongChi;

                return new
                {
                    DoanhSo = doanhSo,
                    GiamGia = giamGia,
                    DoanhThuThuan = doanhThuThuan,
                    TongChi = tongChi,
                    LoiNhuan = loiNhuan
                };
            }
        }

        // 2. Hàm gom nhóm doanh thu theo từng ngày để vẽ Biểu đồ
        public Dictionary<string, decimal> LayDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new DataSqlContext())
            {
                var start = tuNgay.Date;
                var end = denNgay.Date.AddDays(1).AddTicks(-1);

                var listDonHang = db.DonHangs
                                    .Where(h => h.NgayLap >= start && h.NgayLap <= end)
                                    .Select(h => new { h.NgayLap, h.TongTien })
                                    .ToList();

                var dict = listDonHang
                            .Where(h => h.NgayLap.HasValue) // Lọc bỏ null
                            .GroupBy(h => h.NgayLap.Value.Date)
                            .ToDictionary(
                                g => g.Key.ToString("dd/MM"),
                                g => g.Sum(h => (decimal?)h.TongTien ?? 0)
                            );

                return dict;
            }
        }

        // Hàm gom nhóm doanh thu theo từng KHUNG GIỜ (Ví dụ: 6:00, 7:00...)
        public Dictionary<string, decimal> LayDoanhThuTheoGio(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new DataSqlContext())
            {
                var start = tuNgay.Date;
                var end = denNgay.Date.AddDays(1).AddTicks(-1);

                // Lấy các đơn hàng trong khoảng thời gian
                var listDonHang = db.DonHangs
                                    .Where(h => h.NgayLap >= start && h.NgayLap <= end)
                                    .Select(h => new { h.NgayLap, h.TongTien })
                                    .ToList();

                // Gom nhóm theo Giờ (Hour)
                var groupedByHour = listDonHang
                            .Where(h => h.NgayLap.HasValue)
                            .GroupBy(h => h.NgayLap.Value.Hour)
                            .ToDictionary(g => g.Key, g => g.Sum(h => (decimal?)h.TongTien) ?? 0);

                var dict = new Dictionary<string, decimal>();

                // Quán cà phê thường hoạt động từ 6h sáng đến 22h đêm (Bro có thể chỉnh lại số 6 và 22 theo ý muốn)
                for (int i = 6; i <= 22; i++)
                {
                    string gio = i.ToString("00") + ":00"; // Format thành "06:00", "07:00"...

                    // Giờ nào có doanh thu thì gán, không có thì bằng 0
                    dict.Add(gio, groupedByHour.ContainsKey(i) ? groupedByHour[i] : 0);
                }

                return dict;
            }
        }

        public Dictionary<string, decimal> LayDuLieuBieuDoThongMinh(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new DataSqlContext())
            {
                var start = tuNgay.Date;
                var end = denNgay.Date.AddDays(1).AddTicks(-1);

                // Lấy dữ liệu từ bảng DonHang dựa trên thuộc tính NgayLap
                var query = db.DonHangs
                              .Where(dh => dh.NgayLap >= start && dh.NgayLap <= end && dh.NgayLap.HasValue)
                              .Select(dh => new { dh.NgayLap, dh.TongTien })
                              .ToList();

                if (tuNgay.Date == denNgay.Date)
                {
                    // Chế độ: TRONG NGÀY -> Nhóm theo GIỜ (00h - 23h)
                    var dict = query.GroupBy(dh => dh.NgayLap.Value.Hour)
                                    .ToDictionary(g => g.Key.ToString("D2") + "h", g => (decimal?)g.Sum(dh => dh.TongTien) ?? 0);

                    // Đảm bảo hiện đủ 24 giờ cho đẹp biểu đồ
                    for (int i = 0; i < 24; i++)
                    {
                        string key = i.ToString("D2") + "h";
                        if (!dict.ContainsKey(key)) dict[key] = 0;
                    }
                    return dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                }
                else
                {
                    // Chế độ: NHIỀU NGÀY -> Nhóm theo NGÀY (dd/MM)
                    return query.GroupBy(dh => dh.NgayLap.Value.Date)
                                .OrderBy(g => g.Key)
                                .ToDictionary(g => g.Key.ToString("dd/MM"), g => (decimal?)g.Sum(dh => dh.TongTien) ?? 0);
                }
            }
        }
    }
}