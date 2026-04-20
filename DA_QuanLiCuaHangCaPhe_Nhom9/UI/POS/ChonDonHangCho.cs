using System;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.POS
{
    public partial class ChonDonHangCho : Form
    {
        #region Khai báo service & thuộc tính

        // Service thanh toán — tải danh sách đơn chờ, hủy đơn
        private readonly DichVuThanhToan _dichVuThanhToan;

        // Mã đơn hàng được chọn để trả về cho form gọi (nếu cần)
        public int MaDonHangDaChon { get; private set; }

        #endregion

        #region Khởi tạo & Load

        public ChonDonHangCho()
        {
            InitializeComponent();
            _dichVuThanhToan = new DichVuThanhToan();
        }

        // Load: tải ngay danh sách đơn đang chờ thanh toán
        private void ChonDonHangCho_Load(object sender, EventArgs e) => TaiDanhSachDonHangCho();

        #endregion

        #region Hàm nội bộ — Tải danh sách đơn chờ

        // Lấy danh sách đơn chờ từ service → đổ vào ListView
        private void TaiDanhSachDonHangCho()
        {
            lvDonHangCho.Items.Clear();
            try
            {
                var donHangCho = _dichVuThanhToan.TaiDanhSachDonHangCho();
                foreach (var dh in donHangCho)
                {
                    ListViewItem lvi = new ListViewItem(dh.MaDh.ToString());
                    lvi.Tag = dh.MaDh; // Lưu mã ẩn để dùng khi chọn/hủy
                    lvi.SubItems.Add(dh.TenKH);
                    lvi.SubItems.Add(dh.NgayLap.HasValue ? dh.NgayLap.Value.ToString("HH:mm dd/MM/yy") : "N/A");
                    lvi.SubItems.Add($"{dh.TongTien:N0} đ");
                    lvDonHangCho.Items.Add(lvi);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải danh sách đơn chờ: " + ex.Message); }
        }

        #endregion

        #region Sự kiện — Tải lại / Chọn thanh toán / Hủy đơn

        // Nút Tải lại → refresh danh sách từ DB
        private void btnTaiLai_Click(object sender, EventArgs e) => TaiDanhSachDonHangCho();

        // Double-click vào dòng = tương đương bấm nút Chọn Thanh Toán
        private void lvDonHangCho_MouseDoubleClick(object sender, MouseEventArgs e) => btnChonThanhToan_Click(sender, e);

        // CHỌN THANH TOÁN: Tính tiền gốc/giảm → mở form ThanhToan → reload nếu thành công
        private void btnChonThanhToan_Click(object sender, EventArgs e)
        {
            if (lvDonHangCho.SelectedItems.Count == 0) { MessageBox.Show("Vui lòng chọn một đơn hàng để thanh toán."); return; }

            int maDH = (int)lvDonHangCho.SelectedItems[0].Tag;
            this.MaDonHangDaChon = maDH;

            decimal tongGoc = 0, soTienGiam = 0;
            try
            {
                // Lấy chi tiết đơn để tính tổng gốc và số tiền giảm
                var dh = _dichVuThanhToan.LayChiTietDonHangGoc(maDH);
                if (dh?.ChiTietDonHangs != null)
                {
                    tongGoc    = dh.ChiTietDonHangs.Sum(ct => ct.DonGia * ct.SoLuong);
                    decimal tt = dh.TongTien ?? tongGoc;
                    soTienGiam = tongGoc - tt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải chi tiết đơn hàng: " + ex.Message); }

            ThanhToan frmTT = new ThanhToan(maDH, tongGoc, soTienGiam);
            if (frmTT.ShowDialog() == DialogResult.OK)
                TaiDanhSachDonHangCho(); // Reload sau khi thanh toán thành công
        }

        // HỦY ĐƠN CHỜ: Hỏi xác nhận → gọi service hoàn nguyên liệu → reload
        private void btnHuyDonCho_Click(object sender, EventArgs e)
        {
            if (lvDonHangCho.SelectedItems.Count == 0) { MessageBox.Show("Vui lòng chọn một đơn hàng để HỦY."); return; }

            int maDH = (int)lvDonHangCho.SelectedItems[0].Tag;
            if (MessageBox.Show(
                $"Bạn có chắc muốn HỦY đơn hàng [MaDH: {maDH}]?\n\nHÀNH ĐỘNG NÀY SẼ HOÀN TRẢ NGUYÊN LIỆU VỀ KHO.",
                "Xác nhận Hủy Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            try
            {
                bool ok = _dichVuThanhToan.HuyDonHangCho(maDH);
                if (ok) { MessageBox.Show($"Đã hủy thành công đơn hàng {maDH}.\nĐã hoàn trả nguyên liệu về kho.", "Thông báo"); TaiDanhSachDonHangCho(); }
                else     MessageBox.Show("Lỗi: Không tìm thấy đơn hàng hoặc thanh toán để hủy. Giao dịch đã được Rollback.", "Lỗi Hủy Đơn");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi nghiêm trọng khi hủy đơn hàng: " + ex.Message); }
        }

        #endregion
    }
}