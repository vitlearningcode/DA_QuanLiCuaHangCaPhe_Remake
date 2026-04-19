using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.Reporting.WinForms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9
{
    public partial class ThanhToan : Form
    {
        private ReportViewer rpvHoaDon;
        // Biến (fields) để lưu dữ liệu
        private decimal _tongTien;
        private int _maDonHangChon;
        private DonHang _donHangCanThanhToan;
        private Models.ThanhToan _thanhToanCanCapNhat;
        private string _tenKhachHang = "Khách vãng lai";
        private decimal _tongTienGoc_passed;
        private decimal _soTienGiam_passed;

        // --- BỔ SUNG: Biến lưu trữ điểm sử dụng ---
        private int _diemSuDungThucTe = 0;
        private decimal _tienGiamTuDiemThucTe = 0;
        // ------------------------------------------

        // *** THAY ĐỔI: Khai báo Dịch Vụ ***
        private readonly DichVuThanhToan _dichVuThanhToan;
        #region KHỞI TẠO VÀ TẢI DỮ LIỆU
        // diemSuDung, tienGiamTuDiem: đã xử lý ở MainForm trước khi mở form này
        public ThanhToan(int maDonHangChon, decimal tongGoc, decimal soTienGiam, int diemSuDung = 0, decimal tienGiamTuDiem = 0)
        {
            InitializeComponent();
            _maDonHangChon = maDonHangChon;
            _tongTienGoc_passed = tongGoc;
            _soTienGiam_passed = soTienGiam;
            _diemSuDungThucTe = diemSuDung;       // đã được nhân viên chọn ở MainForm
            _tienGiamTuDiemThucTe = tienGiamTuDiem;   // đã được tính ở MainForm

            // *** THAY ĐỖI: Khởi tạo Dịch Vụ ***
            _dichVuThanhToan = new DichVuThanhToan();
        }


        private void ThanhToan_Load(object sender, EventArgs e)
        {
            rpvHoaDon = new ReportViewer();
            try
            {
                // 1. Gọi Dịch Vụ để tải thông tin
                var ketQua = _dichVuThanhToan.TaiThongTinThanhToan(_maDonHangChon);

                // 2. Kiểm tra lỗi
                if (ketQua == null)
                {
                    MessageBox.Show("Lỗi: Không tìm thấy đơn hàng hoặc thanh toán chờ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // 3. Gán dữ liệu vào các biến
                _donHangCanThanhToan = ketQua.DonHang;
                _thanhToanCanCapNhat = ketQua.ThanhToan;
                _tongTien = _donHangCanThanhToan.TongTien ?? 0; // <-- Lấy 36.000 (ĐÚNG)

                if (ketQua.KhachHang != null)
                {
                    _tenKhachHang = ketQua.KhachHang.TenKh;
                }

                var chiTietDonHang = ketQua.ChiTiet;
                var allSanPham = ketQua.SanPhams;

                // 4. Cấu hình giao diện
                lblTongCongBill.Text = _tongTien.ToString("N0") + " đ";
                txtKhachDua.Text = _tongTien.ToString("N0");
                lblTienDu.Text = "0 đ";


                // Chúng ta sẽ tính lại tổng gốc (Tiền trước giảm)
                // ngay tại đây để đảm bảo nó luôn đúng,
                // bất kể MainForm truyền gì sang.

                decimal tongGocMoi = 0;

                // 5. Đổ danh sách món ăn vào ListView VÀ TÍNH LẠI TỔNG GỐC
                lvChiTietBill.Items.Clear();
                foreach (var ct in chiTietDonHang)
                {
                    string tenSP = "Không tìm thấy SP";
                    // LINQ to Objects: FirstOrDefault thay nested foreach (Join thủ công)
                    var spTimDuoc = allSanPham.FirstOrDefault(sp => sp.MaSp == ct.MaSp);
                    if (spTimDuoc != null) tenSP = spTimDuoc.TenSp;

                    // Tính thành tiền của món này (ct.DonGia là giá gốc)
                    decimal thanhTienGoc = ct.SoLuong * ct.DonGia;

                    ListViewItem lvi = new ListViewItem(tenSP);
                    lvi.SubItems.Add(ct.SoLuong.ToString());
                    lvi.SubItems.Add(ct.DonGia.ToString("N0"));
                    lvi.SubItems.Add(thanhTienGoc.ToString("N0"));
                    lvChiTietBill.Items.Add(lvi);
                }

                // Cộng dồn vào tổng gốc mới bằng LINQ Sum (thay foreach riêng)
                tongGocMoi = chiTietDonHang.Sum(ct => ct.SoLuong * ct.DonGia); // <-- Sẽ tính ra 45.000

                // 6. GHI ĐÈ CÁC BIẾN _passed BẰNG GIÁ TRỊ ĐÃ TÍNH LẠI
                _tongTienGoc_passed = tongGocMoi; // <-- Ghi đè thành 45.000
                _soTienGiam_passed = tongGocMoi - _tongTien; // <-- Ghi đè thành (45.000 - 36.000) = 9.000

                // --- ÁP DỤNG GIẢM TỪ ĐIỂM (đã được chọn ở MainForm trước khi mở form này) ---
                if (_tienGiamTuDiemThucTe > 0)
                {
                    _tongTien -= _tienGiamTuDiemThucTe; // áp vào số tiền phải trả
                    _soTienGiam_passed += _tienGiamTuDiemThucTe; // cộng vào tổng giảm trên bill preview
                    // Cập nhật lại UI
                    lblTongCongBill.Text = _tongTien.ToString("N0") + " đ";
                    txtKhachDua.Text = _tongTien.ToString("N0");
                }
                // -----------------------------------------------------------------------

                // --- KẾT THÚC SỬA LỖI ---


                // 7. Cấu hình thanh toán (trước đây là bước 6)
                rbTienMat.Checked = true;
                if (this.Controls.Find("panelBillPreview", true).FirstOrDefault() is Panel panelBillPreview)
                {
                    pbQR_InBill.Visible = false;
                    // Giờ hàm này sẽ dùng _tongTienGoc_passed = 45.000 và _soTienGiam_passed = 9.000
                    HienThiBillPreview(panelBillPreview); // Vẽ hóa đơn
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

        #region HÓA ĐƠN XEM TRƯỚC (Giữ nguyên logic)

        private Label AddLabelToBill(string text, int verticalPosition, float fontSize, FontStyle fontStyle = FontStyle.Regular, int horizontalPosition = -1)
        {
            Label lbl = new Label(); lbl.Text = text; lbl.Font = new Font("Segoe UI", fontSize, fontStyle); lbl.AutoSize = true; lbl.BackColor = Color.Transparent; int xPosition = horizontalPosition; if (xPosition == -1) { xPosition = (panelBillPreview.Width - TextRenderer.MeasureText(text, lbl.Font).Width) / 2; }
            lbl.Location = new Point(xPosition, verticalPosition); panelBillPreview.Controls.Add(lbl); return lbl;
        }
        private void HienThiBillPreview(Panel panelBillPreview)
        {
            try
            {

                rpvHoaDon.Dock = DockStyle.Fill;
                panelBillPreview.Controls.Clear();
                panelBillPreview.Controls.Add(rpvHoaDon);
                // 1. Chỉ định file RDLC (Nhớ kiểm tra lại đường dẫn xem đúng folder Report chưa nha)
                // rpvHoaDon.LocalReport.ReportEmbeddedResource = "DA_QuanLiCuaHangCaPhe_Nhom9.Report.rptHoaDon.rdlc";
                rpvHoaDon.LocalReport.DataSources.Clear();
                string reportPath = Path.Combine(Application.StartupPath, @"Report\rptHoaDon.rdlc");
                rpvHoaDon.LocalReport.ReportPath = reportPath;  


                // CHO PHÉP HIỂN THỊ ẢNH TỪ LINK EXTERNAL (Dành cho mã QR)
                rpvHoaDon.LocalReport.EnableExternalImages = true;

                // 2. Tạo DataTable ảo y chang cái DataSet fen đã nặn
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("TenMon", typeof(string));
                dt.Columns.Add("SoLuong", typeof(int));
                dt.Columns.Add("DonGia", typeof(decimal));
                dt.Columns.Add("ThanhTien", typeof(decimal));

                // 3. Đổ dữ liệu từ lưới ListView vào DataTable
                foreach (ListViewItem item in lvChiTietBill.Items)
                {
                    dt.Rows.Add(
                        item.SubItems[0].Text,
                        int.Parse(item.SubItems[1].Text),
                        decimal.Parse(item.SubItems[2].Text.Replace(",", "").Replace(".", "")),
                        decimal.Parse(item.SubItems[3].Text.Replace(",", "").Replace(".", ""))
                    );
                }

                // 4. Móc DataSource (Tên "HoaDon" phải ĐÚNG Y CHANG tên Dataset trong report nha)
                ReportDataSource rds = new ReportDataSource("HoaDon", dt);
                rpvHoaDon.LocalReport.DataSources.Add(rds);

                // 5. Chuẩn bị số liệu cho Parameters
                DateTime ngayLap = _donHangCanThanhToan.NgayLap ?? DateTime.Now;
                string hinhThuc = rbTienMat.Checked ? "Tiền mặt" : "Chuyển khoản QR";

                // Link QR (Chỉ tạo link nếu đang chọn QR)
                // Link QR (Dùng ảnh trong suốt nếu không có QR để RDLC không bị crash)
string qrUrl = rbQR.Checked
    ? $"https://api.vietqr.io/image/970436-0909090909-snt03N5.jpg?accountName=TEST&amount={_tongTien}"
    : "https://upload.wikimedia.org/wikipedia/commons/c/ce/Transparent.gif";

                // 6. Bơm toàn bộ Parameters vào Report theo đúng tên fen đã đặt
                ReportParameter[] p = new ReportParameter[] {
            new ReportParameter("p_SoHoaDon", _donHangCanThanhToan.MaDh.ToString()),
            new ReportParameter("p_MaHoaDon", "HD" + _donHangCanThanhToan.MaDh.ToString("D5")), // Thêm HD cho ngầu
            new ReportParameter("p_KhachHang", _tenKhachHang),
            new ReportParameter("p_NhanVien", _donHangCanThanhToan.MaNv ?? "N/A"),
            new ReportParameter("p_Gio", ngayLap.ToString("HH:mm")),
            new ReportParameter("p_Ngay", ngayLap.ToString("dd/MM/yyyy")),
            new ReportParameter("p_TienGiam", _soTienGiam_passed.ToString("N0") + " đ"),
            new ReportParameter("p_TongTien", _tongTien.ToString("N0") + " đ"),
            new ReportParameter("p_HinhThucThanhToan", hinhThuc),
            new ReportParameter("p_QR", qrUrl)
        };
                rpvHoaDon.LocalReport.SetParameters(p);

                // 7. Refresh để xuất hóa đơn!
                rpvHoaDon.RefreshReport();
            }
            catch (Exception ex)
            {
                string loiChiTiet = ex.Message;
                Exception inner = ex.InnerException;

                // Vòng lặp này sẽ lột trần mọi lớp lỗi cho đến tận cùng
                while (inner != null)
                {
                    loiChiTiet += "\n-> Lớp trong: " + inner.Message;
                    inner = inner.InnerException;
                }

                MessageBox.Show("Tìm Lỗi Tận Gốc:\n" + loiChiTiet, "Kính Hiển Vi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region XỬ LÝ SỰ KIỆN (Thay đổi btn_inhoadon_Click)


        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            decimal khachDua = 0;
            decimal.TryParse(txtKhachDua.Text.Replace(".", ""), out khachDua);
            decimal tienDu = khachDua - _tongTien;
            lblTienDu.Text = tienDu.ToString("N0") + " đ";
        }


        private void rbQR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQR.Checked)
            {
                txtKhachDua.Enabled = false;
                lblTienDu.Text = "0 đ";
            }
            else if (rbTienMat.Checked)
            {
                txtKhachDua.Enabled = true;
                txtKhachDua_TextChanged(sender, e);
            }

            // --- CẬP NHẬT LẠI BILL ĐỂ HIỆN/ẨN MÃ QR ---
            if (this.Controls.Find("panelBillPreview", true).FirstOrDefault() is Panel panelBillPreview)
            {
                HienThiBillPreview(panelBillPreview);
            }
        }

        // *** ĐÃ THAY ĐỔI: Gọi DichVuThanhToan CÓ TRUYỀN SỐ ĐIỂM ***
        private void btn_inhoadon_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra tiền mặt (Giữ nguyên)
            if (rbTienMat.Checked)
            {
                decimal khachDua = 0;
                decimal.TryParse(txtKhachDua.Text.Replace(".", ""), out khachDua);
                if (khachDua < _tongTien)
                {
                    MessageBox.Show("Số tiền khách đưa không đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 2. LƯU CSDL (*** THAY ĐỔI ***)
            try
            {
                string hinhThucThanhToan = rbTienMat.Checked ? "Tiền mặt" : "Chuyển khoản QR";

                // --- BỔ SUNG: Truyền tham số điểm vào hàm XacNhanThanhToan ---
                bool success = _dichVuThanhToan.XacNhanThanhToan(_maDonHangChon, hinhThucThanhToan, _diemSuDungThucTe, _tienGiamTuDiemThucTe);

                if (success)
                {
                    MessageBox.Show($"Đã thanh toán thành công {_tongTien.ToString("N0")} đ", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu đơn hàng: Không tìm thấy đơn hàng hoặc thanh toán.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.InnerException?.Message ?? ex.Message);
            }
        }

        #endregion
        private void pbQR_InBill_Click(object sender, EventArgs e)
        {

        }

        // Phương thức HienThiHoiDiem đã được chuyển sang MainForm (bên cấu hỏi gợi ý trước khi mở form này)
    }
}