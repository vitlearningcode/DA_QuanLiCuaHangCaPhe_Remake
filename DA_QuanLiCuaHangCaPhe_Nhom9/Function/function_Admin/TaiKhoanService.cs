// Function/function_Admin/TaiKhoanService.cs
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class TaiKhoanService
    {
        // Lấy danh sách Vai Trò (Admin, Thu ngân...)
        public List<VaiTro> LayDanhSachVaiTro()
        {
            using (var db = new DataSqlContext())
            {
                return db.VaiTros.ToList();
            }
        }

        // 1. Hàm TẠO TÀI KHOẢN (Cho trường hợp txtUsername.Enabled == true)
        public bool TaoTaiKhoan(string username, string password, string maNV, int role)
        {
            using (var db = new DataSqlContext())
            {
                if (db.TaiKhoans.Any(t => t.TenDangNhap == username))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo");
                    return false;
                }

                var tk = new TaiKhoan
                {
                    TenDangNhap = username,
                    MatKhau = password,
                    MaNv = maNV, // Gán string bình thường
                    MaVaiTro = role,
                    TrangThai = true
                };
                db.TaiKhoans.Add(tk);
                db.SaveChanges();
                return true;
            }
        }

        // 2. Hàm SỬA TÀI KHOẢN (Cho trường hợp else)
        public bool SuaTaiKhoan(string username, string password, int role)
        {
            using (var db = new DataSqlContext())
            {
                // Tìm tài khoản theo username (vì username là khóa chính/không đổi được)
                var tk = db.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == username);
                if (tk == null) return false;

                // Cập nhật quyền
                tk.MaVaiTro = role;
               

                // Nếu có nhập mật khẩu mới thì đổi, bỏ trống thì giữ nguyên
                if (!string.IsNullOrEmpty(password))
                {
                    tk.MatKhau = password;
                }

                db.SaveChanges();
                return true;
            }
        }

       
        // Reset mật khẩu về mặc định (Ví dụ: 1)
        public bool ResetMatKhau(string username)
        {
            using (var db = new DataSqlContext())
            {
                var tk = db.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == username);
                if (tk != null)
                {
                    tk.MatKhau = "1";
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public TaiKhoan LayTaiKhoanTheoMaNV(string maNV)
        {
            using (var db = new DataSqlContext())
            {
                return db.TaiKhoans.FirstOrDefault(t => t.MaNv == maNV);
            }
        }
    }
}