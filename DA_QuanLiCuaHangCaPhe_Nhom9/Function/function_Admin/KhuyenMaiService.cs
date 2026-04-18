using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class KhuyenMaiService
    {
        // 1. Lấy danh sách Khuyến Mãi (KÈM THEO danh sách sản phẩm của nó)
        public List<KhuyenMai> LayDanhSachKhuyenMai()
        {
            using (var db = new DataSqlContext())
            {
                // Lấy danh sách chưa bị ẩn
                var danhSach = db.KhuyenMais
                                 .Include(km => km.MaSps)                                
                                 .ToList();

                // NÂNG CẤP: Tự động quét và cập nhật trạng thái dựa vào ngày hiện tại
                var homNay = DateOnly.FromDateTime(DateTime.Now);
                bool isChanged = false;

                foreach (var km in danhSach)
                {
                    string ttMoi = km.TrangThai;
                    if (km.NgayKetThuc < homNay) ttMoi = "Đã kết thúc";
                    else if (km.NgayBatDau > homNay) ttMoi = "Sắp diễn ra";
                    else ttMoi = "Đang áp dụng";

                    if (km.TrangThai != ttMoi)
                    {
                        km.TrangThai = ttMoi;
                        isChanged = true;
                    }
                }

                if (isChanged) db.SaveChanges();

                return danhSach.OrderByDescending(x => x.NgayBatDau).ToList();
            }
        }

        public bool ThemKhuyenMai(KhuyenMai km, List<int> danhSachMaSp)
        {
            using (var db = new DataSqlContext())
            {
                try
                {
                    km.MaSps = new List<SanPham>();

                    if (danhSachMaSp != null && danhSachMaSp.Count > 0)
                    {
                        var sanPhams = db.SanPhams.Where(sp => danhSachMaSp.Contains(sp.MaSp)).ToList();
                        foreach (var sp in sanPhams)
                        {
                            km.MaSps.Add(sp);
                        }
                    }

                    db.KhuyenMais.Add(km);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi DB Thêm: " + (ex.InnerException?.Message ?? ex.Message));
                    return false;
                }
            }
        }

        public bool CapNhatKhuyenMai(KhuyenMai kmChinhSua, List<int> danhSachMaSpMoi)
        {
            using (var db = new DataSqlContext())
            {
                try
                {
                    var kmDb = db.KhuyenMais.Include(x => x.MaSps).FirstOrDefault(x => x.MaKm == kmChinhSua.MaKm);
                    if (kmDb != null)
                    {
                        kmDb.TenKm = kmChinhSua.TenKm;
                        kmDb.MoTa = kmChinhSua.MoTa;
                        kmDb.LoaiKm = kmChinhSua.LoaiKm;
                        kmDb.GiaTri = kmChinhSua.GiaTri;
                        kmDb.NgayBatDau = kmChinhSua.NgayBatDau;
                        kmDb.NgayKetThuc = kmChinhSua.NgayKetThuc;
                        kmDb.TrangThai = kmChinhSua.TrangThai;
                        kmDb.DoiTuongApDung = kmChinhSua.DoiTuongApDung;

                        kmDb.MaSps.Clear();

                        if (danhSachMaSpMoi != null && danhSachMaSpMoi.Count > 0)
                        {
                            var sanPhamsMoi = db.SanPhams.Where(sp => danhSachMaSpMoi.Contains(sp.MaSp)).ToList();
                            foreach (var sp in sanPhamsMoi)
                            {
                                kmDb.MaSps.Add(sp);
                            }
                        }

                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi DB Sửa: " + (ex.InnerException?.Message ?? ex.Message));
                    return false;
                }
            }
        }

        public string XoaKhuyenMaiAnToan(int maKm)
        {
            using (var db = new DataSqlContext())
            {
                var km = db.KhuyenMais
                           .Include(x => x.MaSps)
                           .Include(x => x.DonHangs)
                           .FirstOrDefault(x => x.MaKm == maKm);

                if (km == null) return "Không tìm thấy khuyến mãi!";
                try
                {
                    if (km.DonHangs.Any())
                    {
                        km.TrangThai = "Đã ẩn";
                        db.SaveChanges();
                        return "Khuyến mãi này đã có lịch sử hóa đơn. Hệ thống sẽ tự động ẨN nó khỏi danh sách thay vì xóa vĩnh viễn để bảo toàn doanh thu!";
                    }
                    else
                    {
                        km.MaSps.Clear();
                        db.KhuyenMais.Remove(km);
                        db.SaveChanges();
                        return "Đã xóa vĩnh viễn khuyến mãi khỏi hệ thống!";
                    }
                }
                catch (Exception ex)
                {
                    return "Lỗi Database: " + (ex.InnerException?.Message ?? ex.Message);
                }
            }
        }
    }
}