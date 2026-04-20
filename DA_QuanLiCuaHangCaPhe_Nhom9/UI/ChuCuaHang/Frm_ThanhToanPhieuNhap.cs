using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class Frm_ThanhToanPhieuNhap : Form
    {
        #region Khai báo biến & thuộc tính trả kết quả

        // Kết quả được UC_Kho lấy sau khi ShowDialog() == OK
        public decimal SoTienTra          { get; private set; }
        public string  HinhThucThanhToan  { get; private set; }

        // Dữ liệu công nợ được truyền vào từ UC_Kho
        private readonly CongNo _congNo;

        #endregion

        #region Khởi tạo & Load

        // Nhận thông tin công nợ từ UC_Kho để hiển thị và validate
        public Frm_ThanhToanPhieuNhap(CongNo cn)
        {
            InitializeComponent();
            _congNo = cn;
        }

        // Load: hiển thị số liệu công nợ, gợi ý sẵn số tiền còn nợ vào ô nhập
        private void Frm_ThanhToanPhieuNhap_Load(object sender, EventArgs e)
        {
            decimal conNo = _congNo.TongTien - _congNo.DaTra;

            lblTitle.Text       = "THANH TOÁN PHIẾU: " + _congNo.MaPhieu;
            lblTongTien.Text    = $"Tổng tiền hóa đơn: {_congNo.TongTien:N0} VNĐ";
            lblDaThanhToan.Text = $"Đã thanh toán: {_congNo.DaTra:N0} VNĐ";
            lblConNo.Text       = $"CÒN NỢ LẠI: {conNo:N0} VNĐ";

            // Gợi ý sẵn số tiền cần trả = số còn nợ
            txtSoTienTra.Text = conNo.ToString("0");
            cboHinhThuc.SelectedIndex = 0;
        }

        #endregion

        #region Sự kiện — Xác nhận / Hủy

        // XÁC NHẬN: Validate số tiền → gán kết quả vào thuộc tính → đóng OK
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            decimal conNo = _congNo.TongTien - _congNo.DaTra;

            // Số tiền trả phải > 0 và <= số còn nợ
            if (!decimal.TryParse(txtSoTienTra.Text, out decimal tienTra) || tienTra <= 0 || tienTra > conNo)
            {
                MessageBox.Show("Số tiền trả không hợp lệ!", "Thông báo");
                return;
            }

            // Trả kết quả về cho form gọi qua thuộc tính public
            this.SoTienTra         = tienTra;
            this.HinhThucThanhToan = cboHinhThuc.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // HỦY: Đóng form không lưu gì
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}