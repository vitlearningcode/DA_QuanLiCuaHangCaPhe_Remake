using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class frm_ThemPhieuChi : Form
    {
        #region Khai báo service & thuộc tính kết quả

        // Service sổ quỹ: lập phiếu chi thủ công
        private readonly SoQuyService _service = new SoQuyService();

        // Kết quả được UC_SoQuy kiểm tra sau ShowDialog()
        // true = lưu thành công → UC_SoQuy sẽ reload lưới
        public bool IsSuccess { get; private set; } = false;

        // Mã NV lập phiếu — nhận từ UC_SoQuy (Admin đăng nhập)
        private readonly string _maNVLap;

        #endregion

        #region Khởi tạo & Load

        public frm_ThemPhieuChi(string maNV = "")
        {
            InitializeComponent();
            _maNVLap = maNV;
        }

        // Load: chọn sẵn hạng mục đầu tiên trong ComboBox
        private void frm_ThemPhieuChi_Load(object sender, EventArgs e)
        {
            cboHạngMuc.SelectedIndex = 0;
        }

        #endregion

        #region Sự kiện — Lưu / Hủy

        // LƯU: Validate số tiền → gọi service ghi phiếu chi → đặt cờ IsSuccess → đóng
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate: không để trống và phải là số > 0
            if (string.IsNullOrWhiteSpace(txtSoTien.Text)) { MessageBox.Show("Vui lòng nhập số tiền chi!", "Thông báo"); return; }
            if (!decimal.TryParse(txtSoTien.Text, out decimal soTien) || soTien <= 0) { MessageBox.Show("Số tiền không hợp lệ!", "Thông báo"); return; }

            // TODO: nếu `_maNVLap` rỗng (chưa truyền) sẽ lưu cỗi nội bộ không gán NV — SERVICE xử lý null-safe
            try
            {
                bool ok = _service.TaoPhieuChiThuCong(cboHạngMuc.Text, soTien, "Tiền mặt", txtGhiChu.Text, _maNVLap);
                if (ok)
                {
                    MessageBox.Show("Lập phiếu chi thành công!", "Thông báo");
                    IsSuccess = true;
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // HỦY: Đóng form không lưu
        private void btnHuy_Click(object sender, EventArgs e) => this.Close();

        #endregion
    }
}