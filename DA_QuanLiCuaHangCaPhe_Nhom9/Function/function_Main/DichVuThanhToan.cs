using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.EntityFrameworkCore;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main {
    // DTO trả về toàn bộ dữ liệu cần cho form ThanhToan
    public class ThongTinDonHangDayDu {
        public DonHang DonHang { get; set; }
        public List<ChiTietDonHang> ChiTiet { get; set; }
        public Models.ThanhToan ThanhToan { get; set; }
        public List<SanPham> SanPhams { get; set; }
    }

    // DTO dùng để hiển thị preview (không thay đổi DB)
    public class DuLieuHoaDonPreview {
        public string TenMon { get; set; }
        public string SoLuong { get; set; }
        public string DonGia { get; set; }
        public string ThanhTien { get; set; }
    }

    // DTO cho danh sách DonHang "Đang xử lý"
    public class DuLieuDonHangCho {
        public int MaDh { get; set; }
        public string TenKH { get; set; }
        public DateTime? NgayLap { get; set; }
        public decimal TongTien { get; set; }
    }


    /// Lớp này chịu trách nhiệm truy vấn CSDL cho ThanhToan và ChonDonHangCho.
    /// Đã chuyển sang LINQ EF Core.

    public class DichVuThanhToan {
        // --- LOGIC CHO ThanhToan.cs ---

        /// Tải tất cả thông tin cần thiết cho Form ThanhToan.
        /// Trả về null nếu không tìm thấy DonHang hoặc ThanhToan chưa thanh toán.

        public ThongTinDonHangDayDu TaiThongTinThanhToan(int maDonHangChon) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Tìm DonHang theo khóa chính bằng FirstOrDefault
                    var donHang = db.DonHangs
                        .FirstOrDefault(dh => dh.MaDh == maDonHangChon);

                    // Lấy tất cả ChiTietDonHang của đơn này bằng Where
                    var chiTiet = db.ChiTietDonHangs
                        .Where(ct => ct.MaDh == maDonHangChon)
                        .ToList();

                    // Tìm bản ghi ThanhToan chưa thanh toán của đơn này
                    var thanhToan = db.ThanhToans
                        .FirstOrDefault(tt => tt.MaDh == maDonHangChon &&
                                              tt.TrangThai == "Chưa thanh toán");

                    // Nếu thiếu DonHang hoặc ThanhToan -> trả null để UI xử lý
                    if (donHang == null || thanhToan == null) {
                        return null;
                    }

                    // Tải danh sách SanPham để map tên khi render hóa đơn
                    var sanPhams = db.SanPhams.ToList();

                    return new ThongTinDonHangDayDu {
                        DonHang  = donHang,
                        ChiTiet  = chiTiet,
                        ThanhToan = thanhToan,
                        SanPhams = sanPhams
                    };
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi tải thông tin thanh toán: " + ex.Message);
                return null;
            }
        }


        /// Xác nhận thanh toán: cập nhật trạng thái DonHang và ThanhToan, lưu DB.

        public bool XacNhanThanhToan(int maDonHang, string hinhThuc) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Dùng FirstOrDefault thay cho foreach + break
                    var donHang = db.DonHangs
                        .FirstOrDefault(dh => dh.MaDh == maDonHang);

                    var thanhToan = db.ThanhToans
                        .FirstOrDefault(tt => tt.MaDh == maDonHang &&
                                              tt.TrangThai == "Chưa thanh toán");

                    if (donHang == null || thanhToan == null) {
                        return false;
                    }

                    donHang.TrangThai  = "Đã thanh toán";
                    thanhToan.TrangThai = "Đã thanh toán";
                    thanhToan.HinhThuc  = hinhThuc;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi xác nhận thanh toán: " + ex.Message);
                return false;
            }
        }

        // --- LOGIC CHO ChonDonHangCho.cs ---

        /// Tải danh sách DonHang đang "Đang xử lý", join với KhachHang để lấy tên,
        /// sắp xếp theo NgayLap, trả về List<DuLieuDonHangCho>.

        public List<DuLieuDonHangCho> TaiDanhSachDonHangCho() {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // LINQ EF: lọc + left join với KhachHang + sắp xếp + project thành DTO
                    var ketQua = db.DonHangs
                        .Where(dh => dh.TrangThai == "Đang xử lý")
                        .OrderBy(dh => dh.NgayLap)
                        .Select(dh => new DuLieuDonHangCho {
                            MaDh    = dh.MaDh,
                            TenKH   = dh.MaKhNavigation != null
                                          ? dh.MaKhNavigation.TenKh
                                          : "Khách vãng lai",
                            NgayLap  = dh.NgayLap,
                            TongTien = dh.TongTien ?? 0
                        })
                        .ToList();

                    return ketQua;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi tải danh sách đơn chờ: " + ex.Message);
                return new List<DuLieuDonHangCho>();
            }
        }


        /// Lấy chi tiết DonHang gốc kèm ChiTietDonHangs (dùng Include, 1 query).

        public DonHang LayChiTietDonHangGoc(int maDH) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Include để eager-load ChiTietDonHangs trong cùng 1 truy vấn
                    return db.DonHangs
                        .Include(dh => dh.ChiTietDonHangs)
                        .FirstOrDefault(dh => dh.MaDh == maDH);
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi tải chi tiết đơn hàng: " + ex.Message);
                return null;
            }
        }


        /// Hủy đơn hàng chờ và hoàn kho nguyên liệu.
        /// Toàn bộ trong transaction; rollback khi có lỗi.

        public bool HuyDonHangCho(int maDHCanHuy) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    using (var transaction = db.Database.BeginTransaction()) {
                        try {
                            // Dùng FirstOrDefault thay cho foreach + break
                            var donHang = db.DonHangs
                                .FirstOrDefault(dh => dh.MaDh == maDHCanHuy);

                            var thanhToan = db.ThanhToans
                                .FirstOrDefault(tt => tt.MaDh == maDHCanHuy &&
                                                      tt.TrangThai == "Chưa thanh toán");

                            if (donHang == null || thanhToan == null) {
                                transaction.Rollback();
                                return false;
                            }

                            // Lấy chi tiết đơn bằng Where
                            var chiTiet = db.ChiTietDonHangs
                                .Where(ct => ct.MaDh == maDHCanHuy)
                                .ToList();

                            // Tải công thức và nguyên liệu 1 lần để xử lý in-memory
                            var allCongThuc  = db.DinhLuongs.ToList();
                            var allNguyenLieu = db.NguyenLieus.ToList();

                            // --- HOÀN KHO dùng LINQ to Objects ---
                            foreach (var monAn in chiTiet) {
                                // Lọc công thức của món này
                                var congThucCuaMon = allCongThuc
                                    .Where(dl => dl.MaSp == monAn.MaSp)
                                    .ToList();

                                foreach (var nguyenLieuCan in congThucCuaMon) {
                                    // Tìm nguyên liệu trong kho
                                    var nguyenLieuTrongKho = allNguyenLieu
                                        .FirstOrDefault(nl => nl.MaNl == nguyenLieuCan.MaNl);

                                    if (nguyenLieuTrongKho != null) {
                                        decimal luongCanCong = nguyenLieuCan.SoLuongCan * monAn.SoLuong;
                                        nguyenLieuTrongKho.SoLuongTon += luongCanCong;
                                        db.Update(nguyenLieuTrongKho);
                                    }
                                }
                            }

                            // Cập nhật trạng thái đơn
                            donHang.TrangThai  = "Đã huỷ";
                            thanhToan.TrangThai = "Đã huỷ";
                            db.Update(donHang);
                            db.Update(thanhToan);

                            db.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex_inner) {
                            Console.WriteLine("Lỗi trong transaction: " + ex_inner.Message);
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi nghiêm trọng khi hủy đơn hàng: " + ex.Message);
                return false;
            }
        }
    }
}