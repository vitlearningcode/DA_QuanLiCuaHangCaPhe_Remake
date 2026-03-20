using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class KhoService
    {
        // Lấy danh sách Nhà Cung Cấp (để chọn khi nhập)
        public List<NhaCungCap> LayDanhSachNhaCungCap()
        {
            using (var db = new DataSqlContext())
            {
                return db.NhaCungCaps.ToList();
            }
        }

        //  Hàm Nhập Kho "Chuẩn Com-lê" (Lưu Phiếu + Chi Tiết + Tăng Tồn Kho)
        public bool NhapKhoChinhThuc(PhieuKho phieu, List<ChiTietPhieuKho> listChiTiet)
        {
            using (var db = new DataSqlContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Lưu Phiếu Kho
                        db.PhieuKhos.Add(phieu);
                        db.SaveChanges(); // Lưu để SQL tự sinh MaPhieu

                        // 2. Lưu từng Chi Tiết Phiếu
                        foreach (var item in listChiTiet)
                        {
                            item.MaPhieu = phieu.MaPhieu; // Gán mã phiếu vừa sinh                                                        
                            db.ChiTietPhieuKhos.Add(item);

                            // 3. Cộng dồn số lượng vào kho (Bảng NguyenLieu)
                            var nl = db.NguyenLieus.Find(item.MaNl);
                            if (nl != null)
                            {
                                // Kiểm tra null để tránh lỗi nếu SoLuongTon đang null
                                decimal tonHienTai = nl.SoLuongTon ?? 0;
                                nl.SoLuongTon = tonHienTai + item.SoLuong;
                            }
                        }

                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Bạn có thể log lỗi ex.Message ra để kiểm tra nếu cần
                        return false;
                    }
                }
            }
        }

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

        // Thêm hàm này vào KhoService.cs
        public void NhapHangVaoKho(int maNL, decimal soLuongThem)
        {
            using (var db = new DataSqlContext())
            {
                var nl = db.NguyenLieus.Find(maNL);
                if (nl != null)
                {
                    // Cộng dồn số lượng nhập vào số lượng đang có
                    nl.SoLuongTon += soLuongThem;
                    db.SaveChanges();
                }
            }
        }
    }
}