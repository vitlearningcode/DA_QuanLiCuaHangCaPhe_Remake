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
        #region Khai báo service & biến

        // Service sổ quỹ: lấy danh sách giao dịch thu/chi theo khoảng thời gian
        private readonly SoQuyService _service = new SoQuyService();

        // Cache dữ liệu gốc để lọc phía client (tránh query DB nhiều lần)
        private List<GiaoDichThuChi> _dataGoc = new List<GiaoDichThuChi>();

        // Mã NV đang mở sổ quỹ — ghi vào phiếu chi khi Admin thêm mới
        private readonly string _maNVAdmin;

        #endregion

        #region Khởi tạo & Load

        public UC_SoQuy(string maNV = "")
        {
            InitializeComponent();
            _maNVAdmin = maNV;
        }

        // Load: mặc định xem từ đầu tháng đến hôm nay, lọc "Tất cả"
        private void UC_SoQuy_Load(object sender, EventArgs e)
        {
            DateTime today   = DateTime.Today;
            dtpTuNgay.Value  = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = today;
            cboLocThuChi.SelectedIndex = 0; // Mặc định: Tất cả

            LoadData();
        }

        #endregion

        #region Hàm nội bộ — Tải & hiển thị dữ liệu

        // Tải dữ liệu từ DB theo khoảng ngày, rồi hiển thị (validate ngày trước)
        private void LoadData()
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value) return; // Ngày không hợp lệ

            _dataGoc = _service.LayDanhSachSoQuy(dtpTuNgay.Value, dtpDenNgay.Value);
            HienThiDuLieu();
        }

        // Lọc _dataGoc theo ComboBox → đổ vào lưới → cập nhật tổng kết
        private void HienThiDuLieu()
        {
            if (_dataGoc == null) return;

            // Lọc phía client theo loại giao dịch
            var listLoc = cboLocThuChi.SelectedIndex switch
            {
                1 => _dataGoc.Where(x => x.LoaiGiaoDich == "THU").ToList(), // Chỉ Thu
                2 => _dataGoc.Where(x => x.LoaiGiaoDich == "CHI").ToList(), // Chỉ Chi
                _ => _dataGoc                                                // Tất cả
            };

            dgvSoQuy.DataSource = listLoc.ToList();

            // Việt hóa tiêu đề cột và format thời gian
            if (dgvSoQuy.Columns.Count > 0)
            {
                dgvSoQuy.Columns["ThoiGian"].HeaderText                          = "Thời gian";
                dgvSoQuy.Columns["ThoiGian"].DefaultCellStyle.Format             = "dd/MM/yyyy HH:mm";
                dgvSoQuy.Columns["LoaiGiaoDich"].HeaderText                      = "Loại";
                dgvSoQuy.Columns["SoTien"].HeaderText                            = "Số tiền";
                dgvSoQuy.Columns["NoiDung"].HeaderText                           = "Nội dung";
                dgvSoQuy.Columns["NguoiLap"].HeaderText                          = "Người lập";
            }

            // Tổng kết từ _dataGoc (không bị ảnh hưởng bởi bộ lọc)
            decimal tongThu = _dataGoc.Where(x => x.SoTien > 0).Sum(x => x.SoTien);
            decimal tongChi = _dataGoc.Where(x => x.SoTien < 0).Sum(x => Math.Abs(x.SoTien));

            lblTongThu.Text = $"{tongThu:N0} đ";
            lblTongChi.Text = $"{tongChi:N0} đ";
            lblTonQuy.Text  = $"{tongThu - tongChi:N0} đ";
        }

        #endregion

        #region Sự kiện lưới — Tô màu số tiền (Xanh = THU, Đỏ = CHI)

        private void dgvSoQuy_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSoQuy.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                decimal val = Convert.ToDecimal(e.Value);
                e.CellStyle.ForeColor = val > 0 ? Color.DarkGreen : Color.Red;
                e.CellStyle.Font      = new Font(dgvSoQuy.Font, FontStyle.Bold);
                e.Value               = Math.Abs(val).ToString("N0"); // Luôn hiện số dương
                e.FormattingApplied   = true;
            }
        }

        #endregion

        #region Sự kiện — Lọc, tạo phiếu chi

        // Nút Lọc → tải lại dữ liệu theo khoảng ngày mới
        private void btnLoc_Click(object sender, EventArgs e) => LoadData();

        // Đổi loại lọc (Tất cả / Thu / Chi) → hiển thị lại không cần query DB
        private void cboLocThuChi_SelectedIndexChanged(object sender, EventArgs e) => HienThiDuLieu();

        // Mở form thêm phiếu chi → nếu lưu thành công thì reload lưới
        private void btnTaoPhieuChi_Click(object sender, EventArgs e)
        {
            frm_ThemPhieuChi frm = new frm_ThemPhieuChi(_maNVAdmin);
            frm.ShowDialog();
            if (frm.IsSuccess) LoadData(); // Refresh sau khi thêm phiếu mới
        }

        #endregion
    }
}