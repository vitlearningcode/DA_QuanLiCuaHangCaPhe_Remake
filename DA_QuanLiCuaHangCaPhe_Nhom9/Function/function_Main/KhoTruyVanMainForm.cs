using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main {

    /// Lớp này dùng để trả về nhiều danh sách
    /// từ hàm LayDuLieuSanPham()

    public class DuLieuSanPham {
        public List<SanPham> TatCaSanPham { get; set; }    // Sản phẩm đang kinh doanh
        public List<DinhLuong> AllDinhLuong { get; set; } // Toàn bộ công thức
        public List<NguyenLieu> AllNguyenLieu { get; set; } // Nguyên liệu đang kinh doanh
    }


    /// Dùng để chuyển thông tin giỏ hàng từ MainForm sang KhoTruyVan

    public class ChiTietGioHang {
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }


    /// Lớp này chịu trách nhiệm truy vấn CSDL
    /// cho các nhu cầu của MainForm.
    /// Đã chuyển sang LINQ EF Core.

    public class KhoTruyVanMainForm {

        /// Lấy danh sách tên các Loại Sản Phẩm (không trùng lặp) bằng LINQ

        public List<string> TaiLoaiSanPham() {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Where lọc null/empty, Select lấy tên, Distinct loại bỏ trùng
                    return db.SanPhams
                        .Where(sp => sp.LoaiSp != null && sp.LoaiSp != "")
                        .Select(sp => sp.LoaiSp)
                        .Distinct()
                        .ToList();
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi tải loại sản phẩm: " + ex.InnerException?.Message ?? ex.Message);
                return new List<string>();
            }
        }


        /// Lấy tất cả dữ liệu thô cần thiết để hiển thị sản phẩm bằng LINQ

        public DuLieuSanPham LayDuLieuSanPham() {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Lọc trực tiếp trên DB, không tải toàn bộ bảng rồi lọc sau
                    var tatCaSanPham = db.SanPhams
                        .Where(sp => sp.TrangThai == "Còn bán")
                        .ToList();

                    var allNguyenLieu = db.NguyenLieus
                        .Where(nl => nl.TrangThai == "Đang kinh doanh")
                        .ToList();

                    var allDinhLuong = db.DinhLuongs.ToList();

                    return new DuLieuSanPham {
                        TatCaSanPham  = tatCaSanPham,
                        AllDinhLuong  = allDinhLuong,
                        AllNguyenLieu = allNguyenLieu
                    };
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message);
                return new DuLieuSanPham {
                    TatCaSanPham  = new List<SanPham>(),
                    AllDinhLuong  = new List<DinhLuong>(),
                    AllNguyenLieu = new List<NguyenLieu>()
                };
            }
        }


        /// Tìm một khách hàng bằng SĐT bằng LINQ

        public KhachHang SearchKhachHangBySDT(string sdt) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // FirstOrDefault thay cho foreach + if + break
                    return db.KhachHangs
                        .FirstOrDefault(kh => kh.SoDienThoai == sdt);
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi tìm khách hàng: " + ex.Message);
                return null;
            }
        }


        /// Lấy KM Hóa Đơn tốt nhất bằng LINQ

        public KhuyenMai LayKhuyenMaiHoaDon() {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    DateOnly now = DateOnly.FromDateTime(DateTime.Now);

                    // Where lọc điều kiện, OrderByDescending chọn KM có GiaTri lớn nhất
                    return db.KhuyenMais
                        .Where(km => km.LoaiKm == "HoaDon" &&
                                     km.TrangThai == "Đang áp dụng" &&
                                     km.NgayBatDau <= now &&
                                     km.NgayKetThuc >= now)
                        .OrderByDescending(km => km.GiaTri)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi lấy KM hóa đơn: " + ex.Message);
                return null;
            }
        }


        /// Lưu đơn hàng tạm, trừ kho nguyên liệu (trong transaction).
        /// Trả về MaDH mới, hoặc -1 nếu lỗi.

        public int LuuDonHangTam(List<ChiTietGioHang> gioHang, decimal tongTien, string maNV, int? maKH) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    using (var transaction = db.Database.BeginTransaction()) {
                        try {
                            // Bước 1: Tạo DonHang mới
                            var donHangMoi = new DonHang {
                                NgayLap  = DateTime.Now,
                                MaNv     = maNV,
                                TrangThai = "Đang xử lý",
                                TongTien  = tongTien,
                                MaKh      = maKH
                            };

                            // Bước 2: Tạo ChiTietDonHang bằng LINQ Select
                            var listChiTiet = gioHang.Select(item => new ChiTietDonHang {
                                MaDhNavigation = donHangMoi,
                                MaSp           = item.MaSP,
                                SoLuong        = item.SoLuong,
                                DonGia         = item.DonGia
                            }).ToList();

                            // Bước 3: Tạo record ThanhToan
                            var thanhToanMoi = new Models.ThanhToan {
                                MaDhNavigation = donHangMoi,
                                HinhThuc       = null,
                                SoTien         = tongTien,
                                TrangThai      = "Chưa thanh toán"
                            };

                            // Bước 4: Add vào DbContext
                            db.DonHangs.Add(donHangMoi);
                            db.ChiTietDonHangs.AddRange(listChiTiet);
                            db.ThanhToans.Add(thanhToanMoi);

                            // Bước 5: Trừ kho — tải 1 lần rồi dùng LINQ to Objects
                            var allCongThuc   = db.DinhLuongs.ToList();
                            var allNguyenLieu = db.NguyenLieus.ToList();

                            foreach (var monAn in listChiTiet) {
                                // Lọc công thức của món bằng LINQ to Objects
                                var congThucCuaMon = allCongThuc
                                    .Where(dl => dl.MaSp == monAn.MaSp)
                                    .ToList();

                                foreach (var nguyenLieuCan in congThucCuaMon) {
                                    // Tìm nguyên liệu trong kho bằng LINQ to Objects
                                    var nguyenLieuTrongKho = allNguyenLieu
                                        .FirstOrDefault(nl => nl.MaNl == nguyenLieuCan.MaNl);

                                    if (nguyenLieuTrongKho != null) {
                                        decimal luongCanTru = nguyenLieuCan.SoLuongCan * monAn.SoLuong;
                                        nguyenLieuTrongKho.SoLuongTon -= luongCanTru;
                                        db.Update(nguyenLieuTrongKho);
                                    }
                                }
                            }

                            // Bước 6: Lưu và commit
                            db.SaveChanges();
                            transaction.Commit();

                            // Bước 7: Trả về MaDH mới (EF đã gán sau SaveChanges)
                            return donHangMoi.MaDh;
                        }
                        catch (Exception ex_inner) {
                            Console.WriteLine("Lỗi trong transaction LuuDonHangTam: " + ex_inner.Message);
                            transaction.Rollback();
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi lưu tạm đơn hàng: " + ex.InnerException?.Message ?? ex.Message);
                return -1;
            }
        }


        /// Thêm một khách hàng mới vào CSDL.
        /// Trả về true nếu thành công, false nếu thất bại.

        public bool ThemKhachHangMoi(KhachHang khachHangMoi) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    db.KhachHangs.Add(khachHangMoi);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi lưu khách hàng: " + ex.InnerException?.Message ?? ex.Message);
                return false;
            }
        }
    }
}