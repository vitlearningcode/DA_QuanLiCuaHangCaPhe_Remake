using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main {

    /// Lớp này dùng để trả về nhiều danh sách
    /// từ hàm LayDuLieuSanPham()

    public class DuLieuSanPham {
        public List<SanPham> TatCaSanPham { get; set; }    // Sản phẩm đang kinh doanh
        public List<DinhLuong> AllDinhLuong { get; set; } // Toàn bộ công thức
        public List<NguyenLieu> AllNguyenLieu { get; set; } // Nguyên liệu đang kinh doanh
    }


    /// Dùng để chuyển thông tin giỏ hàng từ
    /// MainForm sang KhoTruyVan

    public class ChiTietGioHang {
        public int MaSP { get; set; }   // mã sản phẩm
        public int SoLuong { get; set; } // số lượng
        public decimal DonGia { get; set; } // giá gốc lưu vào CSDL
    }



    /// Lớp này chịu trách nhiệm truy vấn CSDL
    /// cho các nhu cầu của MainForm.
    /// (ĐÃ CHUYỂN SANG LINQ EF CORE)

    public class KhoTruyVanMainForm {

        /// Lấy danh sách tên các Loại Sản Phẩm (không trùng lặp)

        public List<string> TaiLoaiSanPham() {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Thu thập các LoaiSp không null/empty, loại bỏ trùng lặp bằng Distinct
                    return db.SanPhams
                        .Where(sp => sp.LoaiSp != null && sp.LoaiSp != "")
                        .Select(sp => sp.LoaiSp)
                        .Distinct()
                        .ToList();
                }
            }
            catch (Exception ex) {
                // Log lỗi và trả list rỗng để UI không crash
                Console.WriteLine("Lỗi khi tải loại sản phẩm: " + ex.InnerException?.Message ?? ex.Message);
                return new List<string>();
            }
        }


        /// Lấy tất cả dữ liệu thô cần thiết để hiển thị sản phẩm

        public DuLieuSanPham LayDuLieuSanPham() {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Lọc chỉ những SP đang kinh doanh (Where trực tiếp trên DB, thay foreach+if)
                    var tatCaSanPham_filter = db.SanPhams
                        .Where(sp => sp.TrangThai == "Còn bán")
                        .ToList();

                    // Lọc nguyên liệu đang kinh doanh (Where trực tiếp trên DB, thay foreach+if)
                    var allNguyenLieu_filter = db.NguyenLieus
                        .Where(nl => nl.TrangThai == "Đang kinh doanh")
                        .ToList();

                    var allDinhLuong = db.DinhLuongs.ToList();

                    // Trả về container chứa 3 danh sách để MainForm dùng
                    return new DuLieuSanPham {
                        TatCaSanPham = tatCaSanPham_filter,
                        AllDinhLuong = allDinhLuong,
                        AllNguyenLieu = allNguyenLieu_filter
                    };
                }
            }
            catch (Exception ex) {
                // Nếu lỗi, trả về container rỗng để UI xử lý an toàn
                Console.WriteLine("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message);
                return new DuLieuSanPham {
                    TatCaSanPham = new List<SanPham>(),
                    AllDinhLuong = new List<DinhLuong>(),
                    AllNguyenLieu = new List<NguyenLieu>()
                };
            }
        }


        /// Tìm một khách hàng bằng SĐT

        public KhachHang SearchKhachHangBySDT(string sdt) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Dùng FirstOrDefault thay foreach+if+return (trả về khi tìm thấy)
                    return db.KhachHangs
                        .FirstOrDefault(kh => kh.SoDienThoai == sdt);
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi tìm khách hàng: " + ex.Message);
                return null;
            }
        }


        /// Lấy KM Hóa Đơn tốt nhất

        public KhuyenMai LayKhuyenMaiHoaDon() {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    DateOnly now = DateOnly.FromDateTime(DateTime.Now);

                    // Duyệt tất cả khuyến mãi, chọn KM loại HoaDon đang áp dụng và có giá trị lớn nhất
                    // OrderByDescending thay logic tay if (kmHoaDon == null || km.GiaTri > kmHoaDon.GiaTri)
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


        /// Lưu đơn hàng tạm, trừ kho (Logic gốc từ ThucHienLuuTam)

        /// <returns>MaDH mới, hoặc -1 nếu lỗi</returns>
        public int LuuDonHangTam(List<ChiTietGioHang> gioHang, decimal tongTien, string maNV, int? maKH) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    using (var transaction = db.Database.BeginTransaction()) {
                        try {
                            // Bước 1: Tạo DonHang mới (chưa lưu vào DB cho đến SaveChanges)
                            var donHangMoi = new DonHang {
                                NgayLap = DateTime.Now,
                                MaNv = maNV,
                                TrangThai = "Đang xử lý",
                                TongTien = tongTien,
                                MaKh = maKH
                            };

                            // Bước 2: Tạo danh sách ChiTietDonHang dựa trên input gioHang
                            // (Select thay foreach+Add, kết quả tương đương)
                            var listChiTiet = gioHang.Select(item => new ChiTietDonHang {
                                MaDhNavigation = donHangMoi, // Gắn navigation để EF hiểu quan hệ
                                MaSp = item.MaSP,
                                SoLuong = item.SoLuong,
                                DonGia = item.DonGia
                            }).ToList();

                            // Bước 3: Tạo record ThanhToan liên quan (chưa thanh toán)
                            var thanhToanMoi = new Models.ThanhToan {
                                MaDhNavigation = donHangMoi,
                                HinhThuc = null,
                                SoTien = tongTien,
                                TrangThai = "Chưa thanh toán"
                            };

                            // Bước 4: Add vào DbContext (EF sẽ xử lý insert theo quan hệ)
                            db.DonHangs.Add(donHangMoi);
                            db.ChiTietDonHangs.AddRange(listChiTiet);
                            db.ThanhToans.Add(thanhToanMoi);

                            // Bước 5: Trừ kho: tải công thức và nguyên liệu 1 lần rồi xử lý
                            var allCongThuc = db.DinhLuongs.ToList();
                            var allNguyenLieu = db.NguyenLieus.ToList(); // Tải 1 lần

                            foreach (var monAn in listChiTiet) {
                                // Tìm công thức của món (LINQ to Objects thay foreach+if+Add)
                                var congThuc_filter = allCongThuc
                                    .Where(dl => dl.MaSp == monAn.MaSp)
                                    .ToList();

                                if (congThuc_filter.Count > 0) {
                                    // Với mỗi dòng công thức, tìm nguyên liệu tương ứng và trừ SoLuongTon
                                    foreach (var nguyenLieuCan in congThuc_filter) {
                                        // Tìm nguyên liệu tương ứng trong kho (LINQ to Objects thay foreach+break)
                                        NguyenLieu nguyenLieuTrongKho = allNguyenLieu
                                            .FirstOrDefault(nl => nl.MaNl == nguyenLieuCan.MaNl);

                                        if (nguyenLieuTrongKho != null) {
                                            // Trừ số lượng cần thiết (SoLuongCan * số lượng món)
                                            decimal luongCanTru = nguyenLieuCan.SoLuongCan * monAn.SoLuong;
                                            nguyenLieuTrongKho.SoLuongTon -= luongCanTru;
                                            db.Update(nguyenLieuTrongKho); // Đánh dấu entity đã thay đổi
                                        }
                                    }
                                }
                            }

                            // Bước 6: Lưu CSDL và commit transaction
                            db.SaveChanges();
                            transaction.Commit();

                            // Bước 7: Sau SaveChanges, donHangMoi.MaDh được EF gán -> trả về MaDH mới
                            return donHangMoi.MaDh;
                        }
                        catch (Exception ex_inner) {
                            // Nếu xảy ra lỗi trong transaction -> rollback và trả -1
                            Console.WriteLine("Lỗi trong transaction LuuDonHangTam: " + ex_inner.Message);
                            transaction.Rollback(); // Hoàn tác nếu có lỗi
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex) {
                // Lỗi không mong muốn khi mở DB/transaction -> log và trả -1
                Console.WriteLine("Lỗi khi lưu tạm đơn hàng: " + ex.InnerException?.Message ?? ex.Message);
                return -1;
            }
        }


        /// Thêm một khách hàng mới vào CSDL.
        /// Trả về true nếu thành công, false nếu thất bại.

        public bool ThemKhachHangMoi(KhachHang khachHangMoi) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    db.KhachHangs.Add(khachHangMoi); // thêm entity mới
                    db.SaveChanges(); // lưu vào DB
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