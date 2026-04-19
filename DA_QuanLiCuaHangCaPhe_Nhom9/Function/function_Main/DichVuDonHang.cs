using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.EntityFrameworkCore;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main {

    /// Lớp này chứa các logic nghiệp vụ (business logic)
    /// liên quan đến việc bán hàng, tách biệt khỏi MainForm.
    /// (Tương đương OrderService)

    public class DichVuDonHang {

        /// Trạng thái kiểm tra tồn kho (thay thế cho chuỗi "DU_HANG")

        public enum TrangThaiKho {
            DuHang,  // Đủ hàng
            SapHet,  // Sắp hết (dưới ngưỡng)
            HetHang  // Hết hàng
        }


        /// Lớp này dùng để trả về kết quả chi tiết
        /// từ hàm KiemTraSoLuongTonThucTe
        /// (Tương đương InventoryCheckResult)

        public class KetQuaKiemKho {
            public bool DuHang { get; set; } // Đủ hàng hay không? (thay cho IsSufficient)
            public string ThongBao { get; set; } // Thông báo lỗi (nếu có) (thay cho Message)
        }



        /// Kiểm tra trạng thái tồn kho (Đủ, Sắp hết, Hết)
        /// (Dùng để tô màu nút sản phẩm)

        public TrangThaiKho KiemTraDuNguyenLieu(int maSP, List<DinhLuong> allDinhLuong, List<NguyenLieu> allNguyenLieu) {
            // 1. Lấy công thức từ List tạm (LINQ to Objects thay foreach+Add)
            var congThuc = allDinhLuong.Where(dl => dl.MaSp == maSP).ToList();

            if (congThuc.Count == 0) {
                return TrangThaiKho.DuHang; // Không có công thức = Luôn đủ
            }

            TrangThaiKho trangThaiTongQuat = TrangThaiKho.DuHang;

            // 3. Lặp qua TỪNG NGUYÊN LIỆU trong công thức
            foreach (var nguyenLieuCan in congThuc) {
                // 4. Lấy nguyên liệu trong kho từ List tạm (LINQ to Objects thay foreach+break)
                NguyenLieu nguyenLieuTrongKho = allNguyenLieu
                    .FirstOrDefault(nl => nl.MaNl == nguyenLieuCan.MaNl);

                if (nguyenLieuTrongKho == null) {
                    return TrangThaiKho.HetHang; // Lỗi CSDL, coi như hết
                }

                // 5.1. KIỂM TRA HẾT HẲN (<= 0)
                if (nguyenLieuTrongKho.SoLuongTon <= 0) {
                    return TrangThaiKho.HetHang; // Hết hẳn
                }

                // 5.2. KIỂM TRA SẮP HẾT (dưới ngưỡng)
                if (nguyenLieuTrongKho.SoLuongTon <= nguyenLieuTrongKho.NguongCanhBao) {
                    trangThaiTongQuat = TrangThaiKho.SapHet;
                }
            }

            return trangThaiTongQuat;
        }


        /// Lấy giá bán cuối cùng của 1 sản phẩm (đã trừ KM 'SanPham' nếu có)

        public decimal GetGiaBan(int maSanPham, decimal giaGoc) {
            try {
                // Mở kết nối CSDL
                using (DataSqlContext db = new DataSqlContext()) {
                    // --- BƯỚC 1: LẤY HẾT DỮ LIỆU CẦN THIẾT TỪ CSDL ---
                    DateOnly homNay = DateOnly.FromDateTime(DateTime.Now);

                    // 2. Lấy TẤT CẢ các khuyến mãi 'SanPham' đang hoạt động (LINQ thay foreach+if)
                    var dsKMDangChay_SP = db.KhuyenMais
                        .Where(km => km.LoaiKm == "SanPham" &&
                                     km.TrangThai == "Đang áp dụng" &&
                                     km.NgayBatDau <= homNay &&
                                     km.NgayKetThuc >= homNay)
                        .ToList();

                    if (dsKMDangChay_SP.Count == 0) {
                        return giaGoc;
                    }

                    // 3. Tải TẤT CẢ sản phẩm và "liên kết" khuyến mãi
                    var dsSanPham_va_KM = db.SanPhams.Include(sp => sp.MaKms).ToList();

                    // --- BƯỚC 2: LỌC BẰNG LINQ ---

                    // 4. Tìm sản phẩm ta cần (LINQ thay foreach+break)
                    SanPham sanPhamCuaToi = dsSanPham_va_KM
                        .FirstOrDefault(sp => sp.MaSp == maSanPham);

                    if (sanPhamCuaToi == null) {
                        return giaGoc;
                    }

                    // 5. Tìm khuyến mãi tốt nhất cho sản phẩm này
                    // Lặp qua các "liên kết" KM CỦA RIÊNG sản phẩm này,
                    // chỉ lấy những KM khớp với danh sách đang chạy, chọn GiaTri lớn nhất
                    KhuyenMai kmTotNhat = sanPhamCuaToi.MaKms
                        .Where(kmCuaSP => dsKMDangChay_SP.Any(kmDangChay => kmDangChay.MaKm == kmCuaSP.MaKm))
                        .Select(kmCuaSP => dsKMDangChay_SP.First(kmDangChay => kmDangChay.MaKm == kmCuaSP.MaKm))
                        .OrderByDescending(km => km.GiaTri)
                        .FirstOrDefault();

                    // --- BƯỚC 3: TÍNH GIÁ CUỐI CÙNG ---
                    if (kmTotNhat != null) {
                        decimal phanTramGiam = kmTotNhat.GiaTri / 100;
                        return giaGoc - (giaGoc * phanTramGiam);
                    }

                    return giaGoc;
                }
            }
            catch (Exception ex) {
                // Thay vì MessageBox, chúng ta ghi lỗi ra Console
                // (Vì lớp service không nên chứa UI)
                Console.WriteLine("Lỗi khi lấy giá khuyến mãi: " + ex.Message);
                return giaGoc; // Nếu lỗi, trả về giá gốc
            }
        }


        /// Kiểm tra xem kho có đủ nguyên liệu không.
        /// (Dùng khi thêm vào giỏ hàng)

        /// <returns>Một đối tượng KetQuaKiemKho.</returns>
        public KetQuaKiemKho KiemTraSoLuongTonThucTe(int maSP, int soLuongMuonKiemTra) {
            // Mở CSDL (chỉ để kiểm tra)
            using (DataSqlContext db = new DataSqlContext()) {
                // 1. Lấy công thức
                var congThuc = db.DinhLuongs
                                 .Where(dl => dl.MaSp == maSP)
                                 .ToList();

                if (congThuc.Count == 0) {
                    // Không có công thức, luôn đủ
                    return new KetQuaKiemKho { DuHang = true };
                }

                // 2. Lặp qua công thức
                foreach (var nguyenLieuCan in congThuc) {
                    // 3. Lấy NL trong kho
                    var nguyenLieuTrongKho = db.NguyenLieus
                                               .FirstOrDefault(nl => nl.MaNl == nguyenLieuCan.MaNl && nl.TrangThai == "Đang kinh doanh");

                    if (nguyenLieuTrongKho == null) {
                        return new KetQuaKiemKho {
                            DuHang = false,
                            ThongBao = $"Lỗi CSDL: Không tìm thấy nguyên liệu '{nguyenLieuCan.MaNl}'"
                        };
                    }

                    // 4. Tính toán
                    decimal tongNguyenLieuCan = nguyenLieuCan.SoLuongCan * soLuongMuonKiemTra;

                    // 5. KIỂM TRA
                    if (nguyenLieuTrongKho.SoLuongTon < tongNguyenLieuCan) {
                        // KHÔNG ĐỦ
                        string message = $"Không đủ hàng trong kho cho {soLuongMuonKiemTra} ly!\n\n" +
                                         $"Nguyên liệu: {nguyenLieuTrongKho.TenNl}\n" +
                                         $"Chỉ còn: {nguyenLieuTrongKho.SoLuongTon}\n" +
                                         $"Cần: {tongNguyenLieuCan}";

                        return new KetQuaKiemKho {
                            DuHang = false,
                            ThongBao = message
                        };
                    }
                }

                // TẤT CẢ ĐỀU ĐỦ
                return new KetQuaKiemKho { DuHang = true };
            }
        }
    }
}