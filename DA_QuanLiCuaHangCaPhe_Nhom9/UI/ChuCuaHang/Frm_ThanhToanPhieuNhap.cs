using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class Frm_ThanhToanPhieuNhap : Form
    {
        // Các biến để hứng dữ liệu
        public decimal SoTienTra { get; set; }
        public string HinhThucThanhToan { get; set; }

        private CongNo _congNo;

        public Frm_ThanhToanPhieuNhap(CongNo cn)
        {
            InitializeComponent();
            _congNo = cn;
        }

        private void Frm_ThanhToanPhieuNhap_Load(object sender, EventArgs e)
        {
            // Hiển thị số liệu lên các Label
            lblTitle.Text = "THANH TOÁN PHIẾU: " + _congNo.MaPhieu;
            lblTongTien.Text = $"Tổng tiền hóa đơn: {_congNo.TongTien:N0} VNĐ";
            lblDaThanhToan.Text = $"Đã thanh toán: {_congNo.DaTra:N0} VNĐ";

            decimal conNo = _congNo.TongTien - _congNo.DaTra;
            lblConNo.Text = $"CÒN NỢ LẠI: {conNo:N0} VNĐ";

            // Gợi ý luôn số tiền cần trả là số tiền còn nợ
            txtSoTienTra.Text = conNo.ToString("0");
            cboHinhThuc.SelectedIndex = 0;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            decimal tienTra;
            decimal conNo = _congNo.TongTien - _congNo.DaTra;

            if (!decimal.TryParse(txtSoTienTra.Text, out tienTra) || tienTra <= 0 || tienTra > conNo)
            {
                MessageBox.Show("Số tiền trả không hợp lệ!", "Thông báo");
                return;
            }

            // Gán giá trị vào thuộc tính để Form cha lấy ra xài
            this.SoTienTra = tienTra;
            this.HinhThucThanhToan = cboHinhThuc.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}