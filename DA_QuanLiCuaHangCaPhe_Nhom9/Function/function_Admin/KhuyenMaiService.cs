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
                // Chỉ lấy những KM KHÁC trạng thái "Đã ẩn"
                return db.KhuyenMais
                         .Include(km => km.MaSps)
                         .Where(km => km.TrangThai != "Đã ẩn")
                         .ToList();
            }
        }

        public bool ThemKhuyenMai(KhuyenMai km, List<int> danhSachMaSp)
        {
            using (var db = new DataSqlContext())
            {
                try
                {
                    // 1. KHỞI TẠO BỘ NHỚ CHO DANH SÁCH MÓN ĂN (Tránh lỗi mất Tracking)
                    km.MaSps = new List<SanPham>();

                    // 2. NẾU CÓ CHỌN MÓN (Là loại KM Sản phẩm)
                    if (danhSachMaSp != null && danhSachMaSp.Count > 0)
                    {
                        var sanPhams = db.SanPhams.Where(sp => danhSachMaSp.Contains(sp.MaSp)).ToList();
                        foreach (var sp in sanPhams)
                        {
                            km.MaSps.Add(sp); // Add từng món vào
                        }
                    }

                    db.KhuyenMais.Add(km);
                    db.SaveChanges(); // EF Core sẽ tự động INSERT vào bảng trung gian
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
                    // Lệnh Include quan trọng để moi dữ liệu cũ lên
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

                        // Quét sạch danh sách cũ
                        kmDb.MaSps.Clear();

                        // Nạp danh sách mới
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
                // Lấy KM lên, kèm theo danh sách Món ăn (MaSps) và Hóa đơn (DonHangs)
                var km = db.KhuyenMais
                           .Include(x => x.MaSps)
                           .Include(x => x.DonHangs) // Cần có dòng này để check
                           .FirstOrDefault(x => x.MaKm == maKm);

                if (km == null) return "Không tìm thấy khuyến mãi!";
                try
                { // Kiểm tra xem đã có hóa đơn nào xài KM này chưa?
                    if (km.DonHangs.Any())
                    {
                        // Đã có hóa đơn xài -> KHÔNG THỂ XÓA THẬT. Chuyển sang XÓA MỀM (Ẩn đi)
                        km.TrangThai = "Đã ẩn";
                        db.SaveChanges();
                        return "Khuyến mãi này đã có lịch sử hóa đơn. Hệ thống sẽ tự động ẨN nó khỏi danh sách thay vì xóa vĩnh viễn để bảo toàn doanh thu!";
                    }
                    else
                    {
                        // Chưa có hóa đơn nào xài -> XÓA THẬT 100%
                        km.MaSps.Clear(); // Cắt đứt liên kết với các món ăn trước
                        db.KhuyenMais.Remove(km); // Trảm!
                        db.SaveChanges();
                        return "Đã xóa vĩnh viễn khuyến mãi khỏi hệ thống!";
                    }
                }catch (Exception ex)
                {
                    return "Lỗi Database: " + (ex.InnerException?.Message ?? ex.Message);
                }
               
            }
        }
    }
}