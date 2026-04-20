using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.EntityFrameworkCore; // Nhớ có dòng này để dùng .Include()
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class GiaoDichThuChi
    {
        public DateTime ThoiGian { get; set; }
        public string LoaiGiaoDich { get; set; }
        public decimal SoTien { get; set; }
        public string NoiDung { get; set; }
        public string NguoiLap { get; set; }
    }

    public class SoQuyService
    {
        public List<GiaoDichThuChi> LayDanhSachSoQuy(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new DataSqlContext())
            {
                var start = tuNgay.Date;
                var end = denNgay.Date.AddDays(1).AddTicks(-1);

                // 1. Dữ liệu THU (Lấy từ Đơn Hàng)
                var listThu = db.DonHangs
                    .Include(dh => dh.MaNvNavigation)
                    .Where(dh => dh.TrangThai == "Đã thanh toán" && dh.NgayLap >= start && dh.NgayLap <= end && dh.NgayLap.HasValue)
                    .Select(dh => new GiaoDichThuChi
                    {
                        ThoiGian = dh.NgayLap.Value,
                        LoaiGiaoDich = "THU",
                        SoTien = dh.TongTien ?? 0,
                        NoiDung = "Thu tiền bán hàng - Hóa đơn #" + dh.MaDh,
                        NguoiLap = dh.MaNvNavigation != null ? dh.MaNvNavigation.TenNv : "Hệ thống"
                    }).ToList();

                // 2. Dữ liệu CHI (Bây giờ PhieuChi ĐÃ CÓ MaNvNavigation, gọi .Include() vô tư)
                var listChi = db.PhieuChis
                    .Include(pc => pc.MaNvNavigation)
                    .Where(pc => pc.NgayChi >= start && pc.NgayChi <= end)
                    .Select(pc => new GiaoDichThuChi
                    {
                        ThoiGian = pc.NgayChi,
                        LoaiGiaoDich = "CHI",
                        SoTien = -pc.SoTien,
                        NoiDung = "Chi (" + pc.LoaiChi + "): " + pc.GhiChu,
                        NguoiLap = pc.MaNvNavigation != null ? pc.MaNvNavigation.TenNv : "Hệ thống"
                    }).ToList();

                // 3. Gộp lại
                return listThu.Concat(listChi).OrderByDescending(x => x.ThoiGian).ToList();
            }
        }

        // Tạo phiếu chi thủ công: mã NV dưới dạng string đồng bộ với kiểu NVARCHAR của DB
        public bool TaoPhieuChiThuCong(string loaiChi, decimal soTien, string hinhThuc, string ghiChu, string maNVLap)
        {
            using (var db = new DataSqlContext())
            {
                var pc = new PhieuChi
                {
                    NgayChi  = DateTime.Now,
                    LoaiChi  = loaiChi,
                    SoTien   = soTien,
                    HinhThuc = hinhThuc,
                    GhiChu   = ghiChu,
                    MaNv     = string.IsNullOrEmpty(maNVLap) ? null : maNVLap, // null-safe
                };
                db.PhieuChis.Add(pc);
                db.SaveChanges();
                return true;
            }
        }
    }
}