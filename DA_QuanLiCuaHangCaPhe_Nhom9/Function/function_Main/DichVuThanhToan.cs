using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.EntityFrameworkCore;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main
{
    // DTO trả về toàn bộ dữ liệu cần cho form ThanhToan
    public class ThongTinDonHangDayDu
    {
        // DonHang: đối tượng chính của đơn
        public DonHang DonHang { get; set; }

        // Chi tiết các mặt hàng trong đơn (ChiTietDonHang)
        public List<ChiTietDonHang> ChiTiet { get; set; }

        // Bản ghi ThanhToan liên quan (trạng thái "Chưa thanh toán" khi tải)
        public Models.ThanhToan ThanhToan { get; set; }

        // Danh sách sản phẩm toàn bộ (dùng join thủ công để lấy tên)
        public List<SanPham> SanPhams { get; set; } // Danh sách SP để lấy tên

        public KhachHang KhachHang { get; set; }
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

        /// Tải tất cả thông tin cần thiết cho Form ThanhToan
        /// - Tìm DonHang theo maDonHangChon
        /// - Tìm các ChiTietDonHang của đơn đó
        /// - Lấy record ThanhToan có trạng thái "Chưa thanh toán"
        /// - Lấy danh sách tất cả SanPham để map tên khi hiển thị
        /// Trả về null nếu không tìm thấy DonHang hoặc ThanhToan chưa thanh toán.

        public ThongTinDonHangDayDu TaiThongTinThanhToan(int maDonHangChon) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    var ketQua = new ThongTinDonHangDayDu();

                    // 1. Tải Đơn Hàng: dùng FirstOrDefault thay foreach+break
                    ketQua.DonHang = db.DonHangs
                        .FirstOrDefault(dh => dh.MaDh == maDonHangChon);

                    // 2. Tải Chi Tiết Đơn Hàng: dùng Where thay foreach+if+Add
                    ketQua.ChiTiet = db.ChiTietDonHangs
                        .Where(ct => ct.MaDh == maDonHangChon)
                        .ToList();

                    // 3. Tải Thanh Toán: tìm record thanh toán chưa thanh toán của đơn này
                    ketQua.ThanhToan = db.ThanhToans
                        .FirstOrDefault(tt => tt.MaDh == maDonHangChon && tt.TrangThai == "Chưa thanh toán");

                    // 4. Tải Sản Phẩm (để lấy tên khi render hóa đơn)
                    ketQua.SanPhams = db.SanPhams.ToList();

                    // Nếu không có DonHang hoặc ThanhToan (chưa thanh toán) -> trả null để UI xử lý
                    if (ketQua.DonHang == null || ketQua.ThanhToan == null) {
                        return null;
                    }

                    if (ketQua.DonHang.MaKh.HasValue)
                    {
                        ketQua.KhachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKh == ketQua.DonHang.MaKh.Value);
                    }
                    return ketQua;
                }
            }
            catch (Exception ex) {
                // Ghi log ra console (dùng khi debug). UI sẽ nhận null.
                Console.WriteLine("Lỗi khi tải thông tin thanh toán: " + ex.Message);
                return null;
            }
        }


        /// Xác nhận thanh toán:
        /// - Tìm DonHang và ThanhToan đang chờ
        /// - Cập nhật trạng thái thành "Đã thanh toán"
        /// - Ghi HinhThuc (Tiền mặt / QR)
        /// - Lưu thay đổi và trả về true/false

        public bool XacNhanThanhToan(int maDonHang, string hinhThuc, int diemSuDung = 0, decimal tienGiamTuDiem = 0) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Tìm DonHang bằng FirstOrDefault thay foreach+break
                    DonHang donHang = db.DonHangs
                        .FirstOrDefault(dh => dh.MaDh == maDonHang);

                    // Tìm record ThanhToan liên quan đang ở trạng thái "Chưa thanh toán"
                    Models.ThanhToan thanhToan = db.ThanhToans
                        .FirstOrDefault(tt => tt.MaDh == maDonHang && tt.TrangThai == "Chưa thanh toán");


                    // Nếu không tìm thấy -> trả về false cho caller
                    if (donHang == null || thanhToan == null) {
                        return false;
                    }

                    // Cập nhật trạng thái và phương thức thanh toán, lưu
                    donHang.TrangThai = "Đã thanh toán";
                    thanhToan.TrangThai = "Đã thanh toán";
                    thanhToan.HinhThuc = hinhThuc;

                    thanhToan.DiemSuDung = diemSuDung;
                    thanhToan.TienGiamTuDiem = tienGiamTuDiem;

                    if (donHang.MaKh.HasValue)
                    {
                        KhachHang kh = db.KhachHangs.FirstOrDefault(k => k.MaKh == donHang.MaKh.Value);
                        if (kh != null)
                        {
                            // 1. Trừ điểm khách đã dùng cho đơn này
                            kh.DiemTichLuy -= diemSuDung;
                            if (kh.DiemTichLuy < 0) kh.DiemTichLuy = 0;

                            // 2. Tích điểm cộng thêm từ số tiền THỰC TRẢ (10.000đ = 1 điểm)
                            decimal tienThucTra = (thanhToan.SoTien ?? 0) - tienGiamTuDiem;
                            if (tienThucTra > 0)
                            {
                                int diemCongMoi = (int)(tienThucTra / 10000m);
                                kh.DiemTichLuy += diemCongMoi;
                            }
                        }
                    }

                    // Lưu thay đổi vào DB
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi xác nhận thanh toán: " + ex.Message);
                return false;
            }
        }

        /// Chỉ trừ điểm khi Khách đổi điểm nhưng đơn được Lưu Tạm (chưa thanh toán ngay).
        /// Không cộng điểm mới vì chưa thu tiền; điểm sẽ được cộng khi XacNhanThanhToan.
        public bool TruDiemKhachHangLuuTam(int maKhachHang, int diemTru)
        {
            if (diemTru <= 0) return true; // không có gì để trừ
            try
            {
                using (DataSqlContext db = new DataSqlContext())
                {
                    var kh = db.KhachHangs.FirstOrDefault(k => k.MaKh == maKhachHang);
                    if (kh != null)
                    {
                        kh.DiemTichLuy -= diemTru;
                        if (kh.DiemTichLuy < 0) kh.DiemTichLuy = 0;
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi trừ điểm (lưu tạm): " + ex.Message);
                return false;
            }
        }

        // --- LOGIC CHO CHONDONHANGCHO.CS ---


        /// Tải danh sách DonHang đang ở trạng thái "Đang xử lý"
        /// - Lấy all DonHang, lọc theo TrangThai
        /// - Map MaKh -> TenKH bằng navigation property MaKhNavigation
        /// - Trả về list DuLieuDonHangCho đã format để hiển thị

        public List<DuLieuDonHangCho> TaiDanhSachDonHangCho() {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Lọc các đơn có TrangThai == "Đang xử lý", sắp theo NgayLap tăng dần
                    // Dùng navigation property MaKhNavigation để resolve tên KH (thay join thủ công)
                    var ketQua = db.DonHangs
                        .Where(dh => dh.TrangThai == "Đang xử lý")
                        .OrderBy(dh => dh.NgayLap)
                        .Select(dh => new DuLieuDonHangCho {
                            MaDh    = dh.MaDh,
                            TenKH   = dh.MaKhNavigation != null ? dh.MaKhNavigation.TenKh : "Khách vãng lai",
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


        /// Lấy chi tiết DonHang gốc (cần khi tính lại tiền gốc hoặc hiển thị chi tiết)
        /// - Tìm DonHang theo maDH
        /// - Đính kèm ChiTietDonHangs của đơn đó (dùng Include thay nested foreach)

        public DonHang LayChiTietDonHangGoc(int maDH) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    // Include để eager-load ChiTietDonHangs trong cùng 1 query (thay nested foreach)
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


        /// Hủy đơn hàng chờ và hoàn kho nguyên liệu:
        /// - Tìm DonHang và ThanhToan liên quan
        /// - Lấy chi tiết đơn, tính lượng nguyên liệu cần hoàn trả theo DinhLuongs
        /// - Cộng lại SoLuongTon của các NguyenLieu tương ứng
        /// - Cập nhật trạng thái DonHang/ThanhToan = "Đã huỷ"
        /// - Toàn bộ trong transaction; rollback khi có lỗi

        public bool HuyDonHangCho(int maDHCanHuy) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    using (var transaction = db.Database.BeginTransaction()) {
                        try {
                            // Tìm DonHang (FirstOrDefault thay foreach+break)
                            DonHang donHang = db.DonHangs
                                .FirstOrDefault(dh => dh.MaDh == maDHCanHuy);

                            // Tìm thanh toán chưa thanh toán tương ứng
                            Models.ThanhToan thanhToan = db.ThanhToans
                                .FirstOrDefault(tt => tt.MaDh == maDHCanHuy && tt.TrangThai == "Chưa thanh toán");

                            // Lấy chi tiết đơn để hoàn kho (Where thay foreach+if)
                            var chiTiet = db.ChiTietDonHangs
                                .Where(ct => ct.MaDh == maDHCanHuy)
                                .ToList();

                            // Nếu thiếu DonHang hoặc ThanhToan -> rollback và trả false
                            if (donHang == null || thanhToan == null) {
                                transaction.Rollback();
                                return false;
                            }

                            // --- HOÀN KHO ---
                            // Tải một lần toàn bộ công thức và nguyên liệu để xử lý bằng LINQ to Objects
                            var allCongThuc = db.DinhLuongs.ToList();
                            var allNguyenLieu = db.NguyenLieus.ToList();

                            // Với mỗi món trong chi tiết, tìm công thức và cộng trả nguyên liệu về kho
                            foreach (var monAn in chiTiet) {
                                // LINQ to Objects: lọc công thức của món (thay foreach+if+Add)
                                var congThucCuaMon = allCongThuc
                                    .Where(dl => dl.MaSp == monAn.MaSp)
                                    .ToList();

                                if (congThucCuaMon.Count > 0) {
                                    foreach (var nguyenLieuCan in congThucCuaMon) {
                                        // LINQ to Objects: tìm nguyên liệu trong kho (thay foreach+break)
                                        NguyenLieu nguyenLieuTrongKho = allNguyenLieu
                                            .FirstOrDefault(nl => nl.MaNl == nguyenLieuCan.MaNl);

                                        if (nguyenLieuTrongKho != null) {
                                            // Cộng lượng tương ứng = SoLuongCan * SoLuong món
                                            decimal luongCanCong = nguyenLieuCan.SoLuongCan * monAn.SoLuong;
                                            nguyenLieuTrongKho.SoLuongTon += luongCanCong;
                                            db.Update(nguyenLieuTrongKho); // Đánh dấu entity đã thay đổi
                                        }
                                    }
                                }
                            }

                            // --- CẬP NHẬT TRẠNG THÁI ĐƠN ---
                            donHang.TrangThai = "Đã huỷ";
                            thanhToan.TrangThai = "Đã huỷ";
                            db.Update(donHang);
                            db.Update(thanhToan);

                            // Lưu và commit transaction
                            db.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex_inner) {
                            // Log lỗi inner, rollback và trả false
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