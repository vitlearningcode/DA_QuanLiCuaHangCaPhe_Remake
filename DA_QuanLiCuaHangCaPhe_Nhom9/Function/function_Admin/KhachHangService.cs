using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class KhachHangService
    {
        public List<KhachHang> LayDanhSachKhachHang(string tuKhoa = "")
        {
            using (var db = new DataSqlContext())
            {
                var query = db.KhachHangs.AsQueryable();
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    query = query.Where(kh => kh.TenKh.Contains(tuKhoa) || kh.SoDienThoai.Contains(tuKhoa));
                }
                return query.OrderByDescending(kh => kh.DiemTichLuy).ToList();
            }
        }

        public bool ThemKhachHang(string tenKh, string sdt)
        {
            using (var db = new DataSqlContext())
            {
                if (db.KhachHangs.Any(kh => kh.SoDienThoai == sdt))
                    throw new Exception("Số điện thoại này đã tồn tại trong hệ thống!");

                var kh = new KhachHang
                {
                    TenKh = tenKh,
                    SoDienThoai = sdt,
                    DiemTichLuy = 0,
                    LoaiKh = "Thuong"
                };
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return true;
            }
        }

        public bool SuaKhachHang(int maKh, string tenKh, string sdt, int diem, string loai)
        {
            using (var db = new DataSqlContext())
            {
                var kh = db.KhachHangs.Find(maKh);
                if (kh == null) return false;

                if (db.KhachHangs.Any(x => x.SoDienThoai == sdt && x.MaKh != maKh))
                    throw new Exception("Số điện thoại bị trùng với khách hàng khác!");

                kh.TenKh = tenKh;
                kh.SoDienThoai = sdt;
                kh.DiemTichLuy = diem;
                kh.LoaiKh = loai;
                db.SaveChanges();
                return true;
            }
        }

        public bool XoaKhachHang(int maKh)
        {
            using (var db = new DataSqlContext())
            {
                var kh = db.KhachHangs.Find(maKh);
                if (kh == null) return false;

                // Kiểm tra nếu khách đã có đơn hàng thì không cho xóa để bảo toàn dữ liệu
                if (db.DonHangs.Any(dh => dh.MaKh == maKh))
                    throw new Exception("Khách hàng đã có lịch sử mua hàng, không thể xóa!");

                db.KhachHangs.Remove(kh);
                db.SaveChanges();
                return true;
            }
        }
    }
}