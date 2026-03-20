using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{

    public class NhanVienService

    {
        // 1. Lấy danh sách nhân viên
        public dynamic LayDanhSachNhanVienDayDu()
        {
            using (var db = new DataSqlContext())
            {
                // Kỹ thuật LEFT JOIN: Lấy tất cả nhân viên, kể cả người chưa có tài khoản
                var query = from nv in db.NhanViens
                            join tk in db.TaiKhoans on nv.MaNv equals tk.MaNv into tks
                            from subTk in tks.DefaultIfEmpty() // Nếu không có tài khoản thì subTk = null
                            orderby nv.MaNv descending
                            select new
                            {
                                MaNv = nv.MaNv,
                                TenNv = nv.TenNv,
                                SoDienThoai = nv.SoDienThoai,
                                ChucVu = nv.ChucVu,
                                NgayVaoLam = nv.NgayVaoLam,
                                // Cột quan trọng: Nếu subTk null thì ghi "Chưa cấp", ngược lại lấy tên đăng nhập
                                TaiKhoan = subTk != null ? subTk.TenDangNhap : "NO ACCOUNT",
                                QuyenHan = subTk != null ? subTk.MaVaiTro : 0,
                                TrangThaiTK = (subTk != null && subTk.TrangThai == true) ? "Hoạt động" : (subTk == null ? "" : "Đã khóa")
                            };

                return query.ToList();
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
                catch
                {
                    return false;
                }
            }
        }

        // 3. Sửa nhân viên
        public bool SuaNhanVien(NhanVien nvMoi)
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

        // 4. Xóa nhân viên (Cẩn thận: Nếu nhân viên đã bán hàng thì không xóa được do ràng buộc khóa ngoại)
        public string XoaNhanVien(int maNV)
        {
            using (var db = new DataSqlContext())
            {
                var nv = db.NhanViens.Find(maNV);
                if (nv == null) return "Không tìm thấy nhân viên";

                // Kiểm tra ràng buộc (Ví dụ: Đã có tài khoản, đã lập phiếu kho...)
                bool coTaiKhoan = db.TaiKhoans.Any(tk => tk.MaNv == maNV);
                bool coDonHang = db.DonHangs.Any(dh => dh.MaNv == maNV);
                bool coPhieuKho = db.PhieuKhos.Any(pk => pk.MaNv == maNV);

                if (coTaiKhoan || coDonHang || coPhieuKho)
                {
                    return "Không thể xóa: Nhân viên này đã có dữ liệu liên quan (Đơn hàng/Tài khoản).";
                }

                try
                {
                    db.NhanViens.Remove(nv);
                    db.SaveChanges();
                    return "Xóa thành công!";
                }
                catch (Exception ex)
                {
                    return "Lỗi: " + ex.Message;
                }
            }
        }
    }
}