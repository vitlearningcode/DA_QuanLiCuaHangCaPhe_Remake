using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class SanPhamService
    {
        // Hàm lấy danh sách món để tạo Button
        public List<SanPham> LayDanhSachMonAn()
        {
            using (var db = new DataSqlContext())
            {
                return db.SanPhams.Where(s => s.TrangThai == "Còn bán").ToList();
            }
        }

        //Lấy danh sách nguyên liệu để nạp vào ComboBox chọn
        public List<NguyenLieu> LayDanhSachNguyenLieu()
        {
            using (var db = new DataSqlContext())
            {
                return db.NguyenLieus.Where(nl => nl.TrangThai == "Đang kinh doanh").ToList();
            }
        }

        // Lấy danh sách Loại món tự động từ DB (Không trùng lặp)
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

        // Lấy danh sách Đơn vị tính tự động từ DB (Không trùng lặp)
        public List<string> LayDanhSachDonVi()
        {
            using (var db = new DataSqlContext())
            {
                return db.SanPhams
                         .Where(sp => !string.IsNullOrEmpty(sp.DonVi))
                         .Select(sp => sp.DonVi)
                         .Distinct()
                         .ToList();
            }
        }

        // Hàm lấy chi tiết công thức của 1 món
        public List<CongThucHienThi> LayCongThucMon(int maSp)
        {
            using (var db = new DataSqlContext())
            {
                var list = from dl in db.DinhLuongs
                           join nl in db.NguyenLieus on dl.MaNl equals nl.MaNl
                           where dl.MaSp == maSp
                           select new CongThucHienThi
                           {
                               MaNL = nl.MaNl,
                               TenNL = nl.TenNl,
                               SoLuong = dl.SoLuongCan,
                               DonViTinh = nl.DonViTinh
                           };
                return list.ToList();
            }
        }

        // Thêm hàm này vào trong class SanPhamService
        public bool CapNhatSanPhamVaCongThuc(SanPham sp, List<CongThucHienThi> listCongThuc)
        {
            using (var db = new DataSqlContext())
            {
                // Dùng Transaction để đảm bảo tính toàn vẹn dữ liệu
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Cập nhật thông tin cơ bản của Sản phẩm
                        var spDb = db.SanPhams.Find(sp.MaSp);
                        if (spDb != null)
                        {
                            spDb.TenSp = sp.TenSp;
                            spDb.DonGia = sp.DonGia;
                            spDb.LoaiSp = sp.LoaiSp;
                            spDb.DonVi = sp.DonVi;
                        }

                        // 2. Xóa toàn bộ công thức cũ của món này
                        var congThucCu = db.DinhLuongs.Where(d => d.MaSp == sp.MaSp).ToList();
                        db.DinhLuongs.RemoveRange(congThucCu);

                        // 3. Thêm công thức mới vào
                        foreach (var item in listCongThuc)
                        {
                            var dlMoi = new DinhLuong
                            {
                                MaSp = sp.MaSp,
                                MaNl = item.MaNL,
                                SoLuongCan = item.SoLuong
                            };
                            db.DinhLuongs.Add(dlMoi);
                        }

                        db.SaveChanges();
                        transaction.Commit(); // Chốt lưu
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback(); // Có lỗi thì hoàn tác
                        return false;
                    }
                }
            }
        }

        // Hàm THÊM SẢN PHẨM MỚI VÀ CÔNG THỨC
        public bool ThemSanPhamMoi(SanPham spMoi, List<CongThucHienThi> listCongThuc)
        {
            using (var db = new DataSqlContext())
            {
                // Sử dụng Transaction để đảm bảo an toàn dữ liệu
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Thêm sản phẩm mới vào DB
                        db.SanPhams.Add(spMoi);

                        // Lưu lần 1 để DB tự động cấp phát mã Sản Phẩm (MaSp) mới
                        db.SaveChanges();

                        // 2. Thêm công thức cho sản phẩm vừa tạo
                        if (listCongThuc != null && listCongThuc.Count > 0)
                        {
                            foreach (var item in listCongThuc)
                            {
                                var dlMoi = new DinhLuong
                                {
                                    MaSp = spMoi.MaSp, // Lấy mã món vừa được tạo ở trên
                                    MaNl = item.MaNL,
                                    SoLuongCan = item.SoLuong
                                };
                                db.DinhLuongs.Add(dlMoi);
                            }

                            // Lưu lần 2 cho bảng DinhLuong (Công thức)
                            db.SaveChanges();
                        }

                        // Chốt giao dịch thành công
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        // Nếu có bất kỳ lỗi gì xảy ra, quay xe (Rollback) xóa hết những gì vừa làm
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }

    // Class DTO để hiển thị công thức
    public class CongThucHienThi
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public decimal SoLuong { get; set; }
        public string DonViTinh { get; set; }
    }




}