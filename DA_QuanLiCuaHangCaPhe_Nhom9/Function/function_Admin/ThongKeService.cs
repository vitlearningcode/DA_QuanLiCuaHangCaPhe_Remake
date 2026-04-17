using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class ThongKeService
    {
        // 1. Lấy tổng doanh thu trong 1 khoảng thời gian
        public decimal LayDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new DataSqlContext())
            {
                return db.DonHangs
                    // Chỉ tính đơn đã thanh toán
                    .Where(x => x.TrangThai == "Đã thanh toán" && x.NgayLap >= tuNgay.Date && x.NgayLap <= denNgay.Date.AddDays(1).AddTicks(-1))
                    .Sum(x => x.TongTien) ?? 0;
            }
        }

        // 2. Lấy tổng số đơn hàng
        public int LaySoDonHang(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new DataSqlContext())
            {
                return db.DonHangs
                    .Count(x => x.TrangThai == "Đã thanh toán" && x.NgayLap >= tuNgay.Date && x.NgayLap <= denNgay.Date.AddDays(1).AddTicks(-1));
            }
        }

        // 3. Lấy doanh thu 7 ngày qua để vẽ biểu đồ
        public Dictionary<string, decimal> LayDoanhThu7NgayQua()
        {
            using (var db = new DataSqlContext())
            {
                DateTime bayNgayTruoc = DateTime.Today.AddDays(-6); // Bao gồm cả hôm nay là 7 ngày
                DateTime cuoiNgayHomNay = DateTime.Today.AddDays(1).AddTicks(-1);

                var duLieuDB = db.DonHangs
                    .Where(x => x.TrangThai == "Đã thanh toán" && x.NgayLap >= bayNgayTruoc && x.NgayLap <= cuoiNgayHomNay)
                    .ToList();

                // Tạo khung 7 ngày (để những ngày không bán được gì vẫn hiện mức 0đ)
                var ketQua = new Dictionary<string, decimal>();
                for (int i = 0; i < 7; i++)
                {
                    DateTime ngay = bayNgayTruoc.AddDays(i);
                    // Tính tổng tiền của ngày đó
                    decimal tongTienNgay = duLieuDB
                        .Where(x => x.NgayLap.HasValue && x.NgayLap.Value.Date == ngay.Date)
                        .Sum(x => x.TongTien) ?? 0;

                    ketQua.Add(ngay.ToString("dd/MM"), tongTienNgay);
                }

                return ketQua;
            }
        }

        

        // Chỉ là một class rỗng để chứa dữ liệu in báo cáo (Không dính dáng gì 3 lớp nhé)
        public class DuLieuInBaoCao
        {
            public int MaDh { get; set; }
            public DateTime NgayLap { get; set; }
            public string TenNv { get; set; }
            public string TenKm { get; set; }
            public decimal TongTien { get; set; }
        }

        // 4. Hàm lấy dữ liệu
        public List<DuLieuInBaoCao> LayChiTietDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new DataSqlContext())
            {
                DateTime start = tuNgay.Date;
                DateTime end = denNgay.Date.AddDays(1).AddTicks(-1);

                return db.DonHangs
                    .Include(x => x.MaNvNavigation) // Móc qua bảng Nhân Viên
                    .Include(x => x.MaKmNavigation) // Móc qua bảng Khuyến Mãi
                    .Where(x => x.TrangThai == "Đã thanh toán" && x.NgayLap >= start && x.NgayLap <= end)
                    .Select(x => new DuLieuInBaoCao // Đổ dữ liệu vào cái "vỏ" vừa tạo
                    {
                        MaDh = x.MaDh,
                        NgayLap = x.NgayLap ?? DateTime.Now,
                        TenNv = x.MaNvNavigation != null ? x.MaNvNavigation.TenNv : "Không xác định",
                        TenKm = x.MaKmNavigation != null ? x.MaKmNavigation.TenKm : "Không áp dụng",
                        TongTien = x.TongTien ?? 0
                    })
                    .OrderByDescending(x => x.NgayLap)
                    .ToList();
            }
        }

    }



}