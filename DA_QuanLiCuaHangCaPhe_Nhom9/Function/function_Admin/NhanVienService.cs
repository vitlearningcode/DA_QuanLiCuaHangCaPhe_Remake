using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class NhanVienService
    {
        // 1. Lấy danh sách nhân viên (Chỉ lấy những người đang làm việc)
        public List<NhanVien> LayDanhSachNhanVien()
        {
            using (var db = new DataSqlContext())
            {
                // Ẩn những người đã bị "xóa mềm" (Nghỉ việc) khỏi lưới
                return db.NhanViens
                         .Where(nv => nv.ChucVu != "Đã nghỉ việc")
                         .OrderByDescending(nv => nv.NgayVaoLam)
                         .ToList();
            }
        }

        // 2. Thêm nhân viên
        public bool ThemNhanVien(NhanVien nv)
        {
            using (var db = new DataSqlContext())
            {
                try
                {
                    db.NhanViens.Add(nv);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi thêm: " + ex.Message);
                    return false;
                }
            }
        }

        // 3. Cập nhật nhân viên (Khớp tên với UI mới)
        public bool CapNhatNhanVien(NhanVien nvMoi)
        {
            using (var db = new DataSqlContext())
            {
                var nvCu = db.NhanViens.Find(nvMoi.MaNv);
                if (nvCu == null) return false;

                nvCu.TenNv = nvMoi.TenNv;
                nvCu.SoDienThoai = nvMoi.SoDienThoai;
                nvCu.ChucVu = nvMoi.ChucVu;
                nvCu.NgayVaoLam = nvMoi.NgayVaoLam;

                db.SaveChanges();
                return true;
            }
        }

        // 4. XÓA NHÂN VIÊN (NÂNG CẤP: ÁP DỤNG XÓA MỀM AN TOÀN)
        public string XoaNhanVien(int maNV)
        {
            using (var db = new DataSqlContext())
            {
                var nv = db.NhanViens.Find(maNV);
                if (nv == null) return "Không tìm thấy nhân viên!";

                // Kiểm tra xem nhân viên này đã phát sinh dữ liệu (Đơn hàng, Phiếu kho) chưa
                bool daCoDuLieu = db.DonHangs.Any(dh => dh.MaNv == maNV) ||
                                  db.PhieuKhos.Any(pk => pk.MaNv == maNV) ||
                                  db.PhieuChis.Any(pc => pc.MaNv == maNV);

                try
                {
                    if (daCoDuLieu)
                    {
                        // TH1: Đã có dữ liệu -> XÓA MỀM
                        // Đổi trạng thái thành Đã nghỉ việc để ẩn khỏi danh sách
                        nv.ChucVu = "Đã nghỉ việc";

                        // Tìm và Khóa luôn tài khoản đăng nhập của người này (nếu có)
                        var tk = db.TaiKhoans.FirstOrDefault(t => t.MaNv == maNV);
                        if (tk != null)
                        {
                            tk.TrangThai = false;
                        }

                        db.SaveChanges();
                        return "Nhân viên đã có lịch sử làm việc. Hệ thống đã thực hiện XÓA MỀM (Chuyển thành 'Đã nghỉ việc' và Khóa tài khoản) để bảo toàn dữ liệu doanh thu!";
                    }
                    else
                    {
                        // TH2: Nhân viên mới thêm vào chưa làm gì cả -> XÓA CỨNG
                        // Xóa tài khoản trước (nếu lỡ tạo)
                        var tk = db.TaiKhoans.FirstOrDefault(t => t.MaNv == maNV);
                        if (tk != null) db.TaiKhoans.Remove(tk);

                        db.NhanViens.Remove(nv);
                        db.SaveChanges();
                        return "Xóa nhân viên thành công!";
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