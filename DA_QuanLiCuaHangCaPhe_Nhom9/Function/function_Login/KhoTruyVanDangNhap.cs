using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Login
{
    /// <summary>DTO trả về sau khi xác thực đăng nhập thành công</summary>
    public class ThongTinTaiKhoan
    {
        public string TenDangNhap  { get; set; } = "";
        public string MaNv         { get; set; } = "";
        public string TenNhanVien  { get; set; } = "";
        public string TenVaiTro    { get; set; } = "";
        public bool   TrangThai    { get; set; }
    }

    /// <summary>Service xác thực đăng nhập — join TaiKhoan + NhanVien + VaiTro</summary>
    public class KhoTruyVanDangNhap
    {
        /// <summary>
        /// Trả về ThongTinTaiKhoan nếu đúng username+password, null nếu sai.
        /// </summary>
        public ThongTinTaiKhoan? XacThuc(string username, string password)
        {
            using var db = new DataSqlContext();

            var result = (from tk in db.TaiKhoans
                          join nv in db.NhanViens on tk.MaNv equals nv.MaNv
                          join vt in db.VaiTros    on tk.MaVaiTro equals vt.MaVaiTro
                          where tk.TenDangNhap == username.Trim()
                                && tk.MatKhau  == password
                                && tk.TrangThai != false   // tài khoản không bị khoá
                          select new ThongTinTaiKhoan
                          {
                              TenDangNhap = tk.TenDangNhap,
                              MaNv        = tk.MaNv,
                              TenNhanVien = nv.TenNv,
                              TenVaiTro   = vt.TenVaiTro,
                              TrangThai   = tk.TrangThai ?? true
                          }).FirstOrDefault();

            return result;
        }
    }
}
