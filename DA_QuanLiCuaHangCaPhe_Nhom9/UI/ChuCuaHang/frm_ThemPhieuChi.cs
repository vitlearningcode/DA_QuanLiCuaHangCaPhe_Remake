using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class frm_ThemPhieuChi : Form
    {
        private readonly SoQuyService _service = new SoQuyService();
        public bool IsSuccess { get; set; } = false; // Biến kiểm tra lưu thành công để UC load lại

        public frm_ThemPhieuChi()
        {
            InitializeComponent();
        }

        private void frm_ThemPhieuChi_Load(object sender, EventArgs e)
        {
            cboHạngMuc.SelectedIndex = 0; // Mặc định chọn hạng mục đầu tiên
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền chi!", "Thông báo");
                return;
            }

            if (!decimal.TryParse(txtSoTien.Text, out decimal soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Thông báo");
                return;
            }

            // 2. Gọi Service lưu vào DB
            // Lưu ý: Số 1 là mã NV mặc định (Admin). Sau này bro truyền mã NV đăng nhập vào nhé.
            string loaiChi = cboHạngMuc.Text;
            string ghiChu = txtGhiChu.Text;

            try
            {
                bool result = _service.TaoPhieuChiThuCong(loaiChi, soTien, "Tiền mặt", ghiChu, 1);
                if (result)
                {
                    MessageBox.Show("Lập phiếu chi thành công!", "Thông báo");
                    this.IsSuccess = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}