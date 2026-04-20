using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class SanPhamService
    {
        private readonly CoreLogic_Kho _coreKho = new CoreLogic_Kho();
        // 1. Lấy tất cả món (Cho sếp xem cả món Đang bán lẫn Ngừng kinh doanh)
        public List<SanPham> LayDanhSachMonAn()
        {
            using (var db = new DataSqlContext())
            {
                return db.SanPhams.OrderByDescending(s => s.MaSp).ToList();
            }
        }

        // 2. Lấy danh sách nguyên liệu để chọn (delegate sang CoreLogic_Kho — tránh duplicate với KhoService)
        public List<NguyenLieu> LayDanhSachNguyenLieu()
        {
            return _coreKho.LayNguyenLieuDangKinhDoanh();
        }

        // 3. Lấy danh sách loại món
        public List<string> LayDanhSachLoaiMon()
        {
            using (var db = new DataSqlContext())
            {
                return db.SanPhams
                         .Where(sp => !string.IsNullOrEmpty(sp.LoaiSp))
                         .Select(sp => sp.LoaiSp)
                         .Distinct()
                         .ToList();
            }
        }

        // 4. Lấy công thức (Định lượng) của 1 món cụ thể
        public List<CongThucHienThi> LayCongThucTheoMon(int maSp)
        {
            using (var db = new DataSqlContext())
            {
                var query = from dl in db.DinhLuongs
                            join nl in db.NguyenLieus on dl.MaNl equals nl.MaNl
                            where dl.MaSp == maSp
                            select new CongThucHienThi
                            {
                                MaNL = nl.MaNl,
                                TenNL = nl.TenNl,
                                SoLuong = (decimal)dl.SoLuongCan,
                                DonViTinh = nl.DonViTinh
                            };
                return query.ToList();
            }
        }

        // 5. THÊM MỚI SẢN PHẨM & CÔNG THỨC
        public bool ThemMonMoi(SanPham sp, List<CongThucHienThi> congThuc)
        {
            using (var db = new DataSqlContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.SanPhams.Add(sp);
                        db.SaveChanges(); // Lưu để EF Core sinh ra MaSp mới

                        // Lưu công thức (nếu có)
                        if (congThuc != null && congThuc.Count > 0)
                        {
                            foreach (var ct in congThuc)
                            {
                                db.DinhLuongs.Add(new DinhLuong
                                {
                                    MaSp = sp.MaSp,
                                    MaNl = ct.MaNL,
                                    SoLuongCan = (decimal)ct.SoLuong
                                });
                            }
                            db.SaveChanges();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        // 6. CẬP NHẬT SẢN PHẨM & CÔNG THỨC
        public bool CapNhatMon(SanPham spMoi, List<CongThucHienThi> congThucMoi)
        {
            using (var db = new DataSqlContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var spCu = db.SanPhams.Find(spMoi.MaSp);
                        if (spCu == null) return false;

                        spCu.TenSp = spMoi.TenSp;
                        spCu.LoaiSp = spMoi.LoaiSp;
                        spCu.DonGia = spMoi.DonGia; // Đã đổi thành DonGia
                        spCu.TrangThai = spMoi.TrangThai;

                        // Xóa sạch công thức cũ
                        var dinhLuongCu = db.DinhLuongs.Where(dl => dl.MaSp == spMoi.MaSp);
                        db.DinhLuongs.RemoveRange(dinhLuongCu);

                        // Lưu công thức mới
                        if (congThucMoi != null && congThucMoi.Count > 0)
                        {
                            foreach (var ct in congThucMoi)
                            {
                                db.DinhLuongs.Add(new DinhLuong
                                {
                                    MaSp = spMoi.MaSp,
                                    MaNl = ct.MaNL,
                                    SoLuongCan = (decimal)ct.SoLuong
                                });
                            }
                        }

                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }

    // Class phụ trợ để truyền data lên giao diện
    public class CongThucHienThi
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public decimal SoLuong { get; set; }
        public string DonViTinh { get; set; }
    }
}