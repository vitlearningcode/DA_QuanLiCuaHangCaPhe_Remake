using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_SoQuy : UserControl
    {
        private readonly SoQuyService _service = new SoQuyService();
        private List<GiaoDichThuChi> _dataGoc = new List<GiaoDichThuChi>();

        public UC_SoQuy()
        {
            InitializeComponent();
        }

        private void UC_SoQuy_Load(object sender, EventArgs e)
        {
            // Mặc định xem sổ quỹ từ đầu tháng
            DateTime today = DateTime.Today;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = today;
            cboLocThuChi.SelectedIndex = 0;

            LoadData();
        }

        private void btnLoc_Click(object sender, EventArgs e) => LoadData();

        private void cboLocThuChi_SelectedIndexChanged(object sender, EventArgs e) => HienThiDuLieu();

        private void LoadData()
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value) return;

            // Lấy data từ Service
            _dataGoc = _service.LayDanhSachSoQuy(dtpTuNgay.Value, dtpDenNgay.Value);
            HienThiDuLieu();
        }

        private void HienThiDuLieu()
        {
            if (_dataGoc == null) return;

            // 1. Lọc dữ liệu theo ComboBox
            var listLoc = _dataGoc;
            if (cboLocThuChi.SelectedIndex == 1) // Chỉ phiếu Thu
                listLoc = _dataGoc.Where(x => x.LoaiGiaoDich == "THU").ToList();
            else if (cboLocThuChi.SelectedIndex == 2) // Chỉ phiếu Chi
                listLoc = _dataGoc.Where(x => x.LoaiGiaoDich == "CHI").ToList();

            dgvSoQuy.DataSource = listLoc.ToList();



            // 2. Định dạng cột
            if (dgvSoQuy.Columns.Count > 0)
            {
                dgvSoQuy.Columns["ThoiGian"].HeaderText = "Thời gian";
                dgvSoQuy.Columns["ThoiGian"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvSoQuy.Columns["LoaiGiaoDich"].HeaderText = "Loại";
                dgvSoQuy.Columns["SoTien"].HeaderText = "Số tiền";
                dgvSoQuy.Columns["NoiDung"].HeaderText = "Nội dung";
                dgvSoQuy.Columns["NguoiLap"].HeaderText = "Người lập";
            }

            // 3. Tính toán tổng kết cho các Panel
            decimal tongThu = _dataGoc.Where(x => x.SoTien > 0).Sum(x => x.SoTien);
            decimal tongChi = _dataGoc.Where(x => x.SoTien < 0).Sum(x => Math.Abs(x.SoTien));

            //lblTongThu.Text = string.Format("{0:N0} đ", tongThu);
            lblTongThu.Text = tongThu.ToString("N0")+ " đ";
            lblTongChi.Text = string.Format("{0:N0} đ", tongChi);
            lblTonQuy.Text = string.Format("{0:N0} đ", tongThu - tongChi);
        }

        private void dgvSoQuy_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSoQuy.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                decimal val = Convert.ToDecimal(e.Value);
                if (val > 0)
                {                    
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.Font = new Font(dgvSoQuy.Font, FontStyle.Bold);
                    e.Value = Math.Abs(val).ToString("N0");
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvSoQuy.Font, FontStyle.Bold);
                    e.Value = Math.Abs(val).ToString("N0"); // Hiển thị số dương cho dễ nhìn
                }
            }
        }

        private void btnTaoPhieuChi_Click(object sender, EventArgs e)
        {
            frm_ThemPhieuChi frm = new frm_ThemPhieuChi();
            frm.ShowDialog();

            // Nếu lưu thành công thì load lại lưới
            if (frm.IsSuccess)
            {
                LoadData();
            }
        }
    }
}