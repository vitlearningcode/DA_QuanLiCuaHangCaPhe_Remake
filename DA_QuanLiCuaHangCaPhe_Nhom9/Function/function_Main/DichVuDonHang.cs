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
        /// Nhận 2 List đã tải sẵn từ caller để tránh truy vấn DB lặp lại.
        /// Dùng LINQ to Objects (không phải EF query).

        public TrangThaiKho KiemTraDuNguyenLieu(int maSP, List<DinhLuong> allDinhLuong, List<NguyenLieu> allNguyenLieu) {
            // Lấy công thức của sản phẩm bằng LINQ to Objects
            var congThuc = allDinhLuong.Where(dl => dl.MaSp == maSP).ToList();

            if (congThuc.Count == 0) {
                return TrangThaiKho.DuHang; // Không có công thức = Luôn đủ
            }

            TrangThaiKho trangThaiTongQuat = TrangThaiKho.DuHang;

            // Lặp qua TỪNG NGUYÊN LIỆU trong công thức
            foreach (var nguyenLieuCan in congThuc) {
                // Tìm nguyên liệu trong kho bằng LINQ to Objects
                var nguyenLieuTrongKho = allNguyenLieu
                    .FirstOrDefault(nl => nl.MaNl == nguyenLieuCan.MaNl);

                if (nguyenLieuTrongKho == null) {
                    return TrangThaiKho.HetHang; // Lỗi CSDL, coi như hết
                }

                // Kiểm tra hết hẳn (<= 0)
                if (nguyenLieuTrongKho.SoLuongTon <= 0) {
                    return TrangThaiKho.HetHang;
                }

                // Kiểm tra sắp hết (dưới ngưỡng cảnh báo)
                if (nguyenLieuTrongKho.SoLuongTon <= nguyenLieuTrongKho.NguongCanhBao) {
                    trangThaiTongQuat = TrangThaiKho.SapHet;
                }
            }

            return trangThaiTongQuat;
        }


        /// Lấy giá bán cuối cùng của 1 sản phẩm (đã trừ KM 'SanPham' nếu có)

        public decimal GetGiaBan(int maSanPham, decimal giaGoc) {
            try {
                using (DataSqlContext db = new DataSqlContext()) {
                    DateOnly homNay = DateOnly.FromDateTime(DateTime.Now);

                    // Lấy sản phẩm kèm danh sách KM liên kết bằng Include (1 query)
                    var sanPhamCuaToi = db.SanPhams
                        .Include(sp => sp.MaKms)
                        .FirstOrDefault(sp => sp.MaSp == maSanPham);

                    if (sanPhamCuaToi == null) {
                        return giaGoc;
                    }

                    // Lấy KM loại 'SanPham' đang hoạt động, áp dụng cho SP này,
                    // chọn cái có GiaTri lớn nhất bằng LINQ
                    var kmTotNhat = sanPhamCuaToi.MaKms
                        .Where(km => km.LoaiKm == "SanPham" &&
                                     km.TrangThai == "Đang áp dụng" &&
                                     km.NgayBatDau <= homNay &&
                                     km.NgayKetThuc >= homNay)
                        .OrderByDescending(km => km.GiaTri)
                        .FirstOrDefault();

                    if (kmTotNhat != null) {
                        decimal phanTramGiam = kmTotNhat.GiaTri / 100;
                        return giaGoc - (giaGoc * phanTramGiam);
                    }

                    return giaGoc;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Lỗi khi lấy giá khuyến mãi: " + ex.Message);
                return giaGoc;
            }
        }


        /// Kiểm tra xem kho có đủ nguyên liệu không.
        /// (Dùng khi thêm vào giỏ hàng)

        /// <returns>Một đối tượng KetQuaKiemKho.</returns>
        public KetQuaKiemKho KiemTraSoLuongTonThucTe(int maSP, int soLuongMuonKiemTra) {
            using (DataSqlContext db = new DataSqlContext()) {
                // Lấy công thức của sản phẩm bằng LINQ EF
                var congThuc = db.DinhLuongs
                    .Where(dl => dl.MaSp == maSP)
                    .ToList();

                if (congThuc.Count == 0) {
                    return new KetQuaKiemKho { DuHang = true };
                }

                // Lặp qua công thức và kiểm tra từng nguyên liệu
                foreach (var nguyenLieuCan in congThuc) {
                    // Dùng FirstOrDefault thay cho foreach + break
                    var nguyenLieuTrongKho = db.NguyenLieus
                        .FirstOrDefault(nl => nl.MaNl == nguyenLieuCan.MaNl &&
                                              nl.TrangThai == "Đang kinh doanh");

                    if (nguyenLieuTrongKho == null) {
                        return new KetQuaKiemKho {
                            DuHang = false,
                            ThongBao = $"Lỗi CSDL: Không tìm thấy nguyên liệu '{nguyenLieuCan.MaNl}'"
                        };
                    }

                    decimal tongNguyenLieuCan = nguyenLieuCan.SoLuongCan * soLuongMuonKiemTra;

                    if (nguyenLieuTrongKho.SoLuongTon < tongNguyenLieuCan) {
                        string message = $"Không đủ hàng trong kho cho {soLuongMuonKiemTra} ly!\n\n" +
                                         $"Nguyên liệu: {nguyenLieuTrongKho.TenNl}\n" +
                                         $"Chỉ còn: {nguyenLieuTrongKho.SoLuongTon}\n" +
                                         $"Cần: {tongNguyenLieuCan}";

                        return new KetQuaKiemKho { DuHang = false, ThongBao = message };
                    }
                }

                return new KetQuaKiemKho { DuHang = true };
            }
        }
    }
}