using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class KhoService
    {
        // 1. Lấy toàn bộ danh sách nguyên liệu (để hiện lên lưới)
        public List<NguyenLieu> LayDanhSachNguyenLieu()
        {
            using (var db = new DataSqlContext())
            {
                // Chỉ lấy những cái đang kinh doanh
                return db.NguyenLieus.Where(nl => nl.TrangThai == "Đang kinh doanh")
                                     .OrderBy(nl => nl.TenNl)
                                     .ToList();
            }
        }

        public bool ThemNguyenLieu(string ten, string donVi)
        {
            using (var db = new DataSqlContext())
            {
                if (db.NguyenLieus.Any(n => n.TenNl == ten && n.TrangThai == "Đang kinh doanh"))
                    return false;

                var nl = new NguyenLieu
                {
                    TenNl = ten,
                    DonViTinh = donVi,
                    SoLuongTon = 0,
                    TrangThai = "Đang kinh doanh"
                    // Đã xóa dòng GiaNhap = ... vì DB không có
                };
                db.NguyenLieus.Add(nl);
                db.SaveChanges();
                return true;
            }
        }

        // 3. Sửa (ĐÃ SỬA: Bỏ tham số giaNhap)
        public void SuaNguyenLieu(int maNL, string tenMoi, string donViMoi)
        {
            using (var db = new DataSqlContext())
            {
                var nl = db.NguyenLieus.Find(maNL);
                if (nl != null)
                {
                    nl.TenNl = tenMoi;
                    nl.DonViTinh = donViMoi;
                    // Đã xóa dòng GiaNhap = ...
                    db.SaveChanges();
                }
            }
        }

        // 4. Xóa nguyên liệu (Thực chất là đổi trạng thái để không mất lịch sử nhập xuất)
        public void XoaNguyenLieu(int maNL)
        {
            using (var db = new DataSqlContext())
            {
                var nl = db.NguyenLieus.Find(maNL);
                if (nl != null)
                {
                    nl.TrangThai = "Ngừng kinh doanh";
                    db.SaveChanges();
                }
            }
        }
    }
}