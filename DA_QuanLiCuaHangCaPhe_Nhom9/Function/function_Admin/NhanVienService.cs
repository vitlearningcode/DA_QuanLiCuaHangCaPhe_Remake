using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class NhanVienService
    {
        // ADMIN CHỈ GIỮ LẠI HÀM XÓA (Các hàm khác xài chung ở CoreLogic)
        // Đã cập nhật maNV thành string
        public string XoaNhanVien(string maNV)
        {
            using (var db = new DataSqlContext())
            {
                var nv = db.NhanViens.Find(maNV);
                if (nv == null) return "Không tìm thấy nhân viên!";

                // Kiểm tra xem có tài khoản không, nếu có thì phải xóa tài khoản trước
                var tk = db.TaiKhoans.FirstOrDefault(t => t.MaNv == maNV);
                if (tk != null)
                {
                    db.TaiKhoans.Remove(tk);
                }

                db.NhanViens.Remove(nv);
                db.SaveChanges();
                return "Cho nghỉ việc & Xóa dữ liệu thành công!";
            }
        }
    }
}