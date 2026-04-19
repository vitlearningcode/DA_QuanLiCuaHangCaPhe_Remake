using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic
{
    public class CoreLogic_NhanVien
    {
        // 1. Sinh mã tự động (NV26001)
        public string SinhMaNhanVienTuDong()
        {
            using (var db = new DataSqlContext())
            {
                string namHienTai = DateTime.Now.ToString("yy");
                string tienTo = "NV" + namHienTai;

                var nhanVienCuoiCung = db.NhanViens
                                         .Where(nv => nv.MaNv.StartsWith(tienTo))
                                         .OrderByDescending(nv => nv.MaNv)
                                         .Select(nv => nv.MaNv)
                                         .FirstOrDefault();

                if (string.IsNullOrEmpty(nhanVienCuoiCung)) return tienTo + "001";

                string baSoCuoi = nhanVienCuoiCung.Substring(4);
                if (int.TryParse(baSoCuoi, out int soThuTu))
                {
                    soThuTu++;
                    return tienTo + soThuTu.ToString("D3");
                }
                return tienTo + "999";
            }
        }

        // 2. Lấy danh sách dùng chung cho cả Admin & Quản lý
        public dynamic LayDanhSachNhanVienDayDu()
        {
            using (var db = new DataSqlContext())
            {
                var query = from nv in db.NhanViens
                            join tk in db.TaiKhoans on nv.MaNv equals tk.MaNv into tks
                            from subTk in tks.DefaultIfEmpty()
                            orderby nv.MaNv descending
                            select new
                            {
                                MaNv = nv.MaNv, // Giờ là string
                                TenNv = nv.TenNv,
                                SoDienThoai = nv.SoDienThoai,
                                ChucVu = nv.ChucVu,
                                NgayVaoLam = nv.NgayVaoLam,
                                TaiKhoan = subTk != null ? subTk.TenDangNhap : "NO ACCOUNT",
                                QuyenHan = subTk != null ? subTk.MaVaiTro : 0,
                                TrangThai = nv.TrangThai
                            };

                return query.ToList();
            }
        }

        // 3. Thêm Nhân viên
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
                catch { return false; }
            }
        }

        // 4. Cập nhật Nhân viên
        public bool CapNhatNhanVien(NhanVien nvMoi)
        {
            using (var db = new DataSqlContext())
            {
                var nvCu = db.NhanViens.Find(nvMoi.MaNv);
                if (nvCu == null) return false;

                nvCu.TenNv = nvMoi.TenNv;
                nvCu.SoDienThoai = nvMoi.SoDienThoai;
                nvCu.ChucVu = nvMoi.ChucVu;
                // nvCu.TrangThai = nvMoi.TrangThai; // Cập nhật cả trạng thái nếu cần

                db.SaveChanges();
                return true;
            }
        }
    }
}