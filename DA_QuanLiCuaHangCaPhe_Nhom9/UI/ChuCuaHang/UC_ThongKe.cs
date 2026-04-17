using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_ThongKe : UserControl
    {
        private readonly ThongKeService _service = new ThongKeService();
        private ReportViewer reportViewer1;
        private Chart chartSanPham;

        public UC_ThongKe()
        {
            InitializeComponent();
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            // Tự động tạo và nhét ReportViewer vào Tab 2
            reportViewer1 = new ReportViewer();
            reportViewer1.Dock = DockStyle.Fill;
            pnlBaoCao.Controls.Add(reportViewer1);

            // Tải dữ liệu 3 Tab
            LoadTab1_Dashboard();
            LoadTab2_BaoCao();
            LoadTab3_BieuDo();
        }

        #region ================= TAB 1: DASHBOARD =================
        private void LoadTab1_Dashboard()
        {
            DateTime homNay = DateTime.Today;
            DateTime dauThang = new DateTime(homNay.Year, homNay.Month, 1);

            decimal dtHomNay = _service.LayDoanhThu(homNay, homNay);
            int soDonHomNay = _service.LaySoDonHang(homNay, homNay);
            decimal dtThangNay = _service.LayDoanhThu(dauThang, homNay);

            lblDoanhThuHomNay.Text = dtHomNay.ToString("N0") + " đ";
            lblSoDonHomNay.Text = soDonHomNay.ToString();
            lblDoanhThuThang.Text = dtThangNay.ToString("N0") + " đ";

            VeBieuDo7Ngay();
        }

        private void VeBieuDo7Ngay()
        {
            Dictionary<string, decimal> duLieu7Ngay = _service.LayDoanhThu7NgayQua();
            pnlBieuDo.Controls.Clear();

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Ngày";
            chartArea.AxisY.Title = "Doanh thu (VNĐ)";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.Interval = 1; // Fix lỗi dồn cục
            chart.ChartAreas.Add(chartArea);

            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.DodgerBlue;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0";
            series.IsXValueIndexed = true; // Fix lỗi dồn cục

            chart.Series.Add(series);

            foreach (var item in duLieu7Ngay)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            pnlBieuDo.Controls.Add(chart);
        }
        #endregion

        #region ================= TAB 2 & TAB 3: HÀM LỌC DÙNG CHUNG =================
        // 1. Nạp danh sách ComboBox
        private void SetupBoLocThoiGian(ComboBox cboLoc, ComboBox cboQuy, ComboBox cboNam)
        {
            cboLoc.Items.Clear();
            cboLoc.Items.AddRange(new string[] { "Tùy chọn (Tự chọn ngày)", "Hôm nay", "Tuần này", "Tháng này", "Chọn theo Quý", "Chọn theo Năm" });

            cboQuy.Items.Clear();
            cboQuy.Items.AddRange(new string[] { "Quý 1", "Quý 2", "Quý 3", "Quý 4" });
            cboQuy.SelectedIndex = 0;

            cboNam.Items.Clear();
            int namHienTai = DateTime.Now.Year;
            for (int i = namHienTai - 5; i <= namHienTai; i++) cboNam.Items.Add(i.ToString());
            cboNam.SelectedItem = namHienTai.ToString();

            cboLoc.SelectedIndex = 3; // Mặc định: Tháng này
        }

        // 2. Xử lý Logic Ẩn/Hiện ComboBox phụ
        private void XuLyLocNhanhChanged(ComboBox cboLoc, ComboBox cboQuy, ComboBox cboNam, DateTimePicker dtpTu, DateTimePicker dtpDen)
        {
            string cheDoLoc = cboLoc.Text;
            DateTime today = DateTime.Today;

            if (cheDoLoc == "Chọn theo Quý" || cheDoLoc == "Chọn theo Năm")
            {
                cboQuy.Enabled = (cheDoLoc == "Chọn theo Quý");
                cboNam.Enabled = true;
                TinhNgayQuyNam(cboLoc, cboQuy, cboNam, dtpTu, dtpDen);
            }
            else
            {
                cboQuy.Enabled = false; cboNam.Enabled = false;
                switch (cheDoLoc)
                {
                    case "Hôm nay":
                        dtpTu.Value = today; dtpDen.Value = today; break;
                    case "Tuần này":
                        int offset = today.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)today.DayOfWeek - 1;
                        dtpTu.Value = today.AddDays(-offset); dtpDen.Value = dtpTu.Value.AddDays(6); break;
                    case "Tháng này":
                        dtpTu.Value = new DateTime(today.Year, today.Month, 1); dtpDen.Value = dtpTu.Value.AddMonths(1).AddDays(-1); break;
                }
            }
        }

        // 3. Logic tự động nhảy ngày theo Quý/Năm
        private void TinhNgayQuyNam(ComboBox cboLoc, ComboBox cboQuy, ComboBox cboNam, DateTimePicker dtpTu, DateTimePicker dtpDen)
        {
            if (cboNam.SelectedItem == null || cboQuy.SelectedItem == null) return;
            int nam = int.Parse(cboNam.SelectedItem.ToString());

            if (cboLoc.Text == "Chọn theo Quý")
            {
                int quy = cboQuy.SelectedIndex + 1;
                dtpTu.Value = new DateTime(nam, (quy - 1) * 3 + 1, 1);
                dtpDen.Value = dtpTu.Value.AddMonths(3).AddDays(-1);
            }
            else if (cboLoc.Text == "Chọn theo Năm")
            {
                dtpTu.Value = new DateTime(nam, 1, 1);
                dtpDen.Value = new DateTime(nam, 12, 31);
            }
        }
        #endregion

        #region ================= TAB 2: BÁO CÁO DOANH THU =================
        private void LoadTab2_BaoCao()
        {
            SetupBoLocThoiGian(cboLocNhanh, cboQuy, cboNam);
        }

        // Gọi hàm dùng chung bằng cú pháp mũi tên => cực gọn
        private void cboLocNhanh_SelectedIndexChanged(object sender, EventArgs e) => XuLyLocNhanhChanged(cboLocNhanh, cboQuy, cboNam, dtpTuNgay, dtpDenNgay);
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e) => TinhNgayQuyNam(cboLocNhanh, cboQuy, cboNam, dtpTuNgay, dtpDenNgay);
        private void cboNam_SelectedIndexChanged(object sender, EventArgs e) => TinhNgayQuyNam(cboLocNhanh, cboQuy, cboNam, dtpTuNgay, dtpDenNgay);

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                var data = _service.LayChiTietDoanhThu(dtpTuNgay.Value, dtpDenNgay.Value);
                if (data == null || data.Count == 0)
                {
                    MessageBox.Show("Không có doanh thu trong khoảng thời gian này!"); return;
                }

                reportViewer1.LocalReport.DataSources.Clear();
                string reportPath = Path.Combine(Application.StartupPath, @"Report\rptDoanhThu.rdlc");
                reportViewer1.LocalReport.ReportPath = reportPath;

                string maBaoCao = "BC-" + DateTime.Now.ToString("ddMM-HHmm");
                string nguoiLap = "Chủ Cửa Hàng (Admin)";
                string tuNgayStr = dtpTuNgay.Value.ToString("dd/MM/yyyy");
                string denNgayStr = dtpDenNgay.Value.ToString("dd/MM/yyyy");

                ReportParameter[] param = new ReportParameter[]
                {
                    new ReportParameter("p_MaBaoCao", maBaoCao),
                    new ReportParameter("p_NguoiLapPhieu", nguoiLap),
                    new ReportParameter("p_TuNgay", "Từ ngày " + tuNgayStr),
                    new ReportParameter("p_DenNgay", "đến ngày " + denNgayStr)
                };
                reportViewer1.LocalReport.SetParameters(param);

                ReportDataSource rds = new ReportDataSource("DataSet_DoanhThu", data);
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                string loiThatSu = ex.Message;
                if (ex.InnerException != null) loiThatSu += "\nChi tiết lỗi thực sự: " + ex.InnerException.Message;
                MessageBox.Show("Lỗi: " + loiThatSu, "Bắt bệnh RDLC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ================= TAB 3: THỐNG KÊ SẢN PHẨM =================
        public void LoadTab3_BieuDo()
        {
            SetupChart();
            // Nạp dữ liệu bộ lọc cho Tab 3
            SetupBoLocThoiGian(cboLocNhanhTab3, cboQuyTab3, cboNamTab3);
        
        }

        private void SetupChart()
        {
            chartSanPham = new Chart();
            chartSanPham.Dock = DockStyle.Fill;

            // 1. Đổi bảng màu cho sang trọng (Tránh mấy màu mặc định gắt gỏng)
            chartSanPham.Palette = ChartColorPalette.Pastel;

            // 2. Tạo vùng vẽ và BẬT HIỆU ỨNG 3D
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.Area3DStyle.Enable3D = true; // Phép thuật nằm ở đây
            chartArea.Area3DStyle.Inclination = 50; // Độ nghiêng của bánh
            chartSanPham.ChartAreas.Add(chartArea);

            // 3. Thêm Tiêu đề
            chartSanPham.Titles.Add("TOP 5 SẢN PHẨM BÁN CHẠY NHẤT");
            chartSanPham.Titles[0].Font = new Font("Arial", 15, FontStyle.Bold);

            // 4. THÊM BẢNG CHÚ THÍCH (Legend) NẰM BÊN PHẢI
            Legend legend = new Legend("Legend1");
            legend.Font = new Font("Arial", 11);
            legend.Docking = Docking.Right; // Đưa sang góc phải cho gọn
            chartSanPham.Legends.Add(legend);

            pnlBieuDoTron.Controls.Add(chartSanPham);
        }

        // Tương tự Tab 2, gọi hàm dùng chung
        private void cboLocNhanhTab3_SelectedIndexChanged(object sender, EventArgs e) => XuLyLocNhanhChanged(cboLocNhanhTab3, cboQuyTab3, cboNamTab3, dtpTuNgayTab3, dtpDenNgayTab3);
        private void cboQuyTab3_SelectedIndexChanged(object sender, EventArgs e) => TinhNgayQuyNam(cboLocNhanhTab3, cboQuyTab3, cboNamTab3, dtpTuNgayTab3, dtpDenNgayTab3);
        private void cboNamTab3_SelectedIndexChanged(object sender, EventArgs e) => TinhNgayQuyNam(cboLocNhanhTab3, cboQuyTab3, cboNamTab3, dtpTuNgayTab3, dtpDenNgayTab3);

        private void btnXemBieuDo_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu Top 5 món (Đảm bảo bro đã viết hàm này bên ThongKeService)
            var data = _service.GetTop5SanPhamBanChay(dtpTuNgayTab3.Value, dtpDenNgayTab3.Value);
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không có doanh thu trong khoảng thời gian này!"); return;
            }

            chartSanPham.Series.Clear();

            Series series = new Series("SanPham");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;

            series.Label = "#PERCENT{P0}";
            series.Font = new Font("Arial", 10, FontStyle.Bold);
            series.LabelForeColor = Color.White;
            series.LegendText = "#VALX: #VAL ly";

            foreach (var item in data)
            {
                series.Points.AddXY(item.TenSanPham, item.TongSoLuong);
            }

            chartSanPham.Series.Add(series);
        }

       
        #endregion
    }
}