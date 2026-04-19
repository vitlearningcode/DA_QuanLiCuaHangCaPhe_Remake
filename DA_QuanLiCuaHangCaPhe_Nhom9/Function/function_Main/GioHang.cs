using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main {

    /// Đại diện cho một món hàng trong giỏ.
    /// Chỉ lưu trữ dữ liệu, không có logic.

    public class GioHangItem {
        // Mã sản phẩm (primary key tham chiếu đến bảng SanPham)
        public int MaSp { get; set; }

        // Tên hiển thị của sản phẩm (để dễ render UI)
        public string TenSp { get; set; }

        // Số lượng hiện có trong giỏ
        public int SoLuong { get; set; }

        // Giá gốc của sản phẩm (trước khi áp dụng khuyến mãi)
        public decimal DonGiaGoc { get; set; }

        // Thành tiền tính theo DonGiaGoc * SoLuong
        public decimal ThanhTienGoc { get; set; }
    }


    /// Quản lý logic nghiệp vụ của giỏ hàng.
    /// Không tương tác trực tiếp với UI (ListView).
    /// Dùng LINQ to Objects vì _items là List in-memory, không phải EF DbSet.

    public class GioHang {
        // Danh sách các món đang có trong giỏ
        private List<GioHangItem> _items;

        // Dịch vụ dùng để kiểm tra tồn kho / giá bán khi thay đổi giỏ
        private readonly DichVuDonHang _dichVuDonHang;

        // Constructor nhận DichVuDonHang để thực hiện kiểm tra nghiệp vụ
        public GioHang(DichVuDonHang dichVu) {
            _items = new List<GioHangItem>();
            _dichVuDonHang = dichVu;
        }


        /// Thêm một sản phẩm vào giỏ hoặc tăng số lượng.
        /// <returns>Tuple (bool Success, string Message).</returns>
        public (bool Success, string Message) ThemMon(SanPham sp) {
            // LINQ to Objects: tìm item đã có trong giỏ theo MaSp
            var itemCoSan = _items.FirstOrDefault(item => item.MaSp == sp.MaSp);

            if (itemCoSan != null) {
                int soLuongMoi = itemCoSan.SoLuong + 1;

                var kiemTra = _dichVuDonHang.KiemTraSoLuongTonThucTe(sp.MaSp, soLuongMoi);
                if (!kiemTra.DuHang) {
                    return (false, kiemTra.ThongBao);
                }

                itemCoSan.SoLuong      = soLuongMoi;
                itemCoSan.ThanhTienGoc = soLuongMoi * itemCoSan.DonGiaGoc;
            }
            else {
                var kiemTra = _dichVuDonHang.KiemTraSoLuongTonThucTe(sp.MaSp, 1);
                if (!kiemTra.DuHang) {
                    return (false, kiemTra.ThongBao);
                }

                _items.Add(new GioHangItem {
                    MaSp         = sp.MaSp,
                    TenSp        = sp.TenSp,
                    SoLuong      = 1,
                    DonGiaGoc    = sp.DonGia,
                    ThanhTienGoc = sp.DonGia
                });
            }

            return (true, "OK");
        }


        /// Giảm số lượng của một món.
        /// <returns>True nếu món bị xóa (SL=0), False nếu chỉ giảm.</returns>
        public bool GiamSoLuong(int maSp) {
            // LINQ to Objects: tìm item cần giảm
            var itemCanGiam = _items.FirstOrDefault(item => item.MaSp == maSp);

            if (itemCanGiam == null) return false;

            if (itemCanGiam.SoLuong > 1) {
                itemCanGiam.SoLuong--;
                itemCanGiam.ThanhTienGoc = itemCanGiam.SoLuong * itemCanGiam.DonGiaGoc;
                return false;
            }
            else {
                _items.Remove(itemCanGiam);
                return true;
            }
        }


        /// Xóa hoàn toàn một món khỏi giỏ, bất kể số lượng.
        public void XoaMon(int maSp) {
            // LINQ to Objects: tìm và xóa item
            var itemCanXoa = _items.FirstOrDefault(item => item.MaSp == maSp);
            if (itemCanXoa != null) {
                _items.Remove(itemCanXoa);
            }
        }


        /// Xóa sạch giỏ hàng.
        public void XoaTatCa() {
            _items.Clear();
        }


        /// Lấy danh sách tất cả các món trong giỏ để hiển thị.
        public List<GioHangItem> LayTatCaMon() {
            return _items;
        }


        /// Lấy tổng tiền (chưa tính KM) bằng LINQ Sum.
        public decimal LayTongTienGoc() {
            // LINQ to Objects: Sum thay cho foreach cộng dồn
            return _items.Sum(item => item.ThanhTienGoc);
        }


        /// Đếm số lượng dòng (loại mặt hàng) trong giỏ.
        public int LaySoLuongMon() {
            return _items.Count;
        }
    }
}