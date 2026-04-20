using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.POS
{
    public partial class ThanhToan : Form
    {
        #region Khai báo service & biến nghiệp vụ

        // Service xử lý thanh toán — tải thông tin, xác nhận, ghi CSDL
        private readonly DichVuThanhToan _dichVuThanhToan;

        // ReportViewer tạo động để render hóa đơn RDLC
        private ReportViewer rpvHoaDon;

        // Dữ liệu đơn hàng và thanh toán tải từ DB
        private DonHang              _donHangCanThanhToan;
        private Models.ThanhToan     _thanhToanCanCapNhat;

        // Dữ liệu được truyền vào từ MainForm khi mở form này
        private readonly int     _maDonHangChon;
        private decimal          _tongTien;              // Số tiền khách phải trả (sau tất cả giảm)
        private decimal          _tongTienGoc_passed;    // Tổng giá gốc các món (trước giảm)
        private decimal          _soTienGiam_passed;     // Số tiền được giảm (KM + điểm)
        private readonly int     _diemSuDungThucTe;      // Điểm khách dùng để đổi (từ MainForm)
        private readonly decimal _tienGiamTuDiemThucTe;  // Tiền tương ứng với điểm đó

        // Tên khách hàng để in lên hóa đơn (mặc định = "Khách vãng lai")
        private string _tenKhachHang = "Khách vãng lai";

        #endregion

        #region Khởi tạo — Nhận tham số từ MainForm

        // Tất cả tham số tính toán (giảm giá, điểm) đã xử lý ở MainForm trước khi mở form này
        public ThanhToan(int maDonHangChon, decimal tongGoc, decimal soTienGiam, int diemSuDung = 0, decimal tienGiamTuDiem = 0)
        {
            InitializeComponent();
            _dichVuThanhToan       = new DichVuThanhToan();
            _maDonHangChon         = maDonHangChon;
            _tongTienGoc_passed    = tongGoc;
            _soTienGiam_passed     = soTienGiam;
            _diemSuDungThucTe      = diemSuDung;
            _tienGiamTuDiemThucTe  = tienGiamTuDiem;
        }

        #endregion

        #region Khởi tạo & Load

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            rpvHoaDon = new ReportViewer();

            try
            {
                // 1. Gọi service tải thông tin đơn hàng + thanh toán chờ
                var ketQua = _dichVuThanhToan.TaiThongTinThanhToan(_maDonHangChon);

                if (ketQua == null)
                {
                    MessageBox.Show("Lỗi: Không tìm thấy đơn hàng hoặc thanh toán chờ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // 2. Gán dữ liệu từ kết quả service
                _donHangCanThanhToan  = ketQua.DonHang;
                _thanhToanCanCapNhat  = ketQua.ThanhToan;
                _tongTien             = _donHangCanThanhToan.TongTien ?? 0;

                if (ketQua.KhachHang != null)
                    _tenKhachHang = ketQua.KhachHang.TenKh;

                // 3. Đổ chi tiết vào ListView và tính lại tổng gốc chính xác
                lvChiTietBill.Items.Clear();
                decimal tongGocMoi = 0;

                foreach (var ct in ketQua.ChiTiet)
                {
                    string tenSP = ketQua.SanPhams.FirstOrDefault(sp => sp.MaSp == ct.MaSp)?.TenSp ?? "Không tìm thấy SP";
                    decimal thanhTienGoc = ct.SoLuong * ct.DonGia;

                    ListViewItem lvi = new ListViewItem(tenSP);
                    lvi.SubItems.Add(ct.SoLuong.ToString());
                    lvi.SubItems.Add(ct.DonGia.ToString("N0"));
                    lvi.SubItems.Add(thanhTienGoc.ToString("N0"));
                    lvChiTietBill.Items.Add(lvi);
                }

                // Tính lại bằng LINQ Sum để đảm bảo chính xác
                tongGocMoi          = ketQua.ChiTiet.Sum(ct => ct.SoLuong * ct.DonGia);
                _tongTienGoc_passed = tongGocMoi;
                _soTienGiam_passed  = tongGocMoi - _tongTien;

                // 4. Áp dụng giảm từ điểm tích lũy (nếu có)
                if (_tienGiamTuDiemThucTe > 0)
                {
                    _tongTien          -= _tienGiamTuDiemThucTe;
                    _soTienGiam_passed += _tienGiamTuDiemThucTe;
                }

                // 5. Cấu hình UI ban đầu
                lblTongCongBill.Text = $"{_tongTien:N0} đ";
                txtKhachDua.Text     = _tongTien.ToString("N0");
                lblTienDu.Text       = "0 đ";
                rbTienMat.Checked    = true;

                // 6. Vẽ hóa đơn xem trước (RDLC)
                if (this.Controls.Find("panelBillPreview", true).FirstOrDefault() is Panel panelBillPreview)
                {
                    pbQR_InBill.Visible = false;
                    HienThiBillPreview(panelBillPreview);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin thanh toán: " + ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        #endregion

        #region Hóa đơn xem trước — Render RDLC

        // Chuẩn bị DataTable + Parameters → đổ vào RDLC → RefreshReport
        private void HienThiBillPreview(Panel panelBillPreview)
        {
            try
            {
                rpvHoaDon.Dock  = DockStyle.Fill;
                panelBillPreview.Controls.Clear();
                panelBillPreview.Controls.Add(rpvHoaDon);

                rpvHoaDon.LocalReport.DataSources.Clear();
                rpvHoaDon.LocalReport.ReportPath            = Path.Combine(Application.StartupPath, @"Report\rptHoaDon.rdlc");
                rpvHoaDon.LocalReport.EnableExternalImages  = true; // Cho phép ảnh QR từ URL ngoài

                // Xây DataTable khớp với Schema trong RDLC
                DataTable dt = new DataTable();
                dt.Columns.Add("TenMon",    typeof(string));
                dt.Columns.Add("SoLuong",   typeof(int));
                dt.Columns.Add("DonGia",    typeof(decimal));
                dt.Columns.Add("ThanhTien", typeof(decimal));

                foreach (ListViewItem item in lvChiTietBill.Items)
                {
                    dt.Rows.Add(
                        item.SubItems[0].Text,
                        int.Parse(item.SubItems[1].Text),
                        decimal.Parse(item.SubItems[2].Text.Replace(",", "").Replace(".", "")),
                        decimal.Parse(item.SubItems[3].Text.Replace(",", "").Replace(".", ""))
                    );
                }

                rpvHoaDon.LocalReport.DataSources.Add(new ReportDataSource("HoaDon", dt));

                DateTime ngayLap  = _donHangCanThanhToan.NgayLap ?? DateTime.Now;
                string hinhThuc   = rbTienMat.Checked ? "Tiền mặt" : "Chuyển khoản QR";

                // URL QR thanh toán (dùng ảnh trong suốt nếu không chọn QR để tránh crash RDLC)
                string qrUrl = rbQR.Checked
                    ? $"https://api.vietqr.io/image/970436-0909090909-snt03N5.jpg?accountName=TEST&amount={_tongTien}"
                    : "https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif";

                rpvHoaDon.LocalReport.SetParameters(new ReportParameter[]
                {
                    new ReportParameter("p_SoHoaDon",               _donHangCanThanhToan.MaDh.ToString()),
                    new ReportParameter("p_MaHoaDon",               "HD" + _donHangCanThanhToan.MaDh.ToString("D5")),
                    new ReportParameter("p_KhachHang",              _tenKhachHang),
                    new ReportParameter("p_NhanVien",               _donHangCanThanhToan.MaNv ?? "N/A"),
                    new ReportParameter("p_Gio",                    ngayLap.ToString("HH:mm")),
                    new ReportParameter("p_Ngay",                   ngayLap.ToString("dd/MM/yyyy")),
                    new ReportParameter("p_TienGiam",               $"{_soTienGiam_passed:N0} đ"),
                    new ReportParameter("p_TongTien",               $"{_tongTien:N0} đ"),
                    new ReportParameter("p_HinhThucThanhToan",      hinhThuc),
                    new ReportParameter("p_QR",                     qrUrl)
                });

                rpvHoaDon.RefreshReport();
            }
            catch (Exception ex)
            {
                // Lột trần toàn bộ lớp lỗi từ ngoài vào sâu nhất
                string loiChiTiet = ex.Message;
                Exception inner   = ex.InnerException;
                while (inner != null) { loiChiTiet += "\n-> Lớp trong: " + inner.Message; inner = inner.InnerException; }
                MessageBox.Show("Tìm Lỗi Tận Gốc:\n" + loiChiTiet, "Kính Hiển Vi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Sự kiện UI — Tính tiền dư & đổi hình thức thanh toán

        // Tính tiền thừa khi khách đưa thay đổi
        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(txtKhachDua.Text.Replace(".", ""), out decimal khachDua);
            lblTienDu.Text = $"{(khachDua - _tongTien):N0} đ";
        }

        // Chuyển hình thức thanh toán → ẩn/hiện ô tiền mặt, vẽ lại bill preview
        private void rbQR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQR.Checked)
            {
                txtKhachDua.Enabled = false;
                lblTienDu.Text      = "0 đ";
            }
            else if (rbTienMat.Checked)
            {
                txtKhachDua.Enabled = true;
                txtKhachDua_TextChanged(sender, e); // Tính lại tiền dư ngay
            }

            // Vẽ lại bill preview (để hiện/ẩn mã QR)
            if (this.Controls.Find("panelBillPreview", true).FirstOrDefault() is Panel panelBillPreview)
                HienThiBillPreview(panelBillPreview);
        }

        // Sự kiện placeholder cho nút QR ảnh (không dùng)
        private void pbQR_InBill_Click(object sender, EventArgs e) { }

        #endregion

        #region Xác nhận thanh toán — Lưu CSDL & đóng form

        // Validate tiền mặt → gọi service xác nhận (trừ điểm, ghi DB) → đóng OK
        private void btn_inhoadon_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra tiền mặt đủ chưa
            if (rbTienMat.Checked)
            {
                decimal.TryParse(txtKhachDua.Text.Replace(".", ""), out decimal khachDua);
                if (khachDua < _tongTien) { MessageBox.Show("Số tiền khách đưa không đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }

            // 2. Ghi vào CSDL (bao gồm trừ điểm, cộng điểm tích lũy, đổi trạng thái đơn)
            try
            {
                string hinhThuc = rbTienMat.Checked ? "Tiền mặt" : "Chuyển khoản QR";
                bool success    = _dichVuThanhToan.XacNhanThanhToan(_maDonHangChon, hinhThuc, _diemSuDungThucTe, _tienGiamTuDiemThucTe);

                if (success)
                {
                    MessageBox.Show($"Đã thanh toán thành công {_tongTien:N0} đ", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Lỗi khi lưu đơn hàng: Không tìm thấy đơn hàng hoặc thanh toán.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        #endregion
    }
}