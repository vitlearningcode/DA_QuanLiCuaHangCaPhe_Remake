using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Reporting.WinForms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_ThongKe : UserControl
    {
        #region Khai báo service & biến

        // Service thống kê: doanh thu theo ngày, Top 5 sản phẩm
        private readonly ThongKeService _service = new ThongKeService();

        // ReportViewer tạo động để hiển thị báo cáo RDLC (Tab 2)
        private ReportViewer reportViewer1;

        // Biểu đồ tròn Top 5 sản phẩm (Tab 3), tạo động
        private Chart chartSanPham;

        #endregion

        #region Khởi tạo & Load

        public UC_ThongKe()
        {
            InitializeComponent();
        }

        // Load: tạo ReportViewer, tải 3 tab song song
        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            // Tab 2 — ReportViewer tạo động và nhét vào panel chứa
            reportViewer1       = new ReportViewer();
            reportViewer1.Dock  = DockStyle.Fill;
            pnlBaoCao.Controls.Add(reportViewer1);

            LoadTab1_Dashboard();
            LoadTab2_BaoCao();
            LoadTab3_BieuDo();
        }

        #endregion

        #region Tab 1 — Dashboard KPI & Biểu đồ 7 ngày

        // Tải số liệu hôm nay / tháng này lên các label và vẽ biểu đồ cột 7 ngày
        private void LoadTab1_Dashboard()
        {
            DateTime homNay   = DateTime.Today;
            DateTime dauThang = new DateTime(homNay.Year, homNay.Month, 1);

            decimal dtHomNay    = _service.LayDoanhThu(homNay,   homNay);
            int     soDonHomNay = _service.LaySoDonHang(homNay,  homNay);
            decimal dtThangNay  = _service.LayDoanhThu(dauThang, homNay);

            lblDoanhThuHomNay.Text = $"{dtHomNay:N0} đ";
            lblSoDonHomNay.Text    = soDonHomNay.ToString();
            lblDoanhThuThang.Text  = $"{dtThangNay:N0} đ";

            VeBieuDo7Ngay();
        }

        // Vẽ biểu đồ cột doanh thu 7 ngày gần nhất vào pnlBieuDo
        private void VeBieuDo7Ngay()
        {
            var duLieu7Ngay = _service.LayDoanhThu7NgayQua();
            pnlBieuDo.Controls.Clear();

            Chart chart = new Chart { Dock = DockStyle.Fill };

            ChartArea area = new ChartArea("Main");
            area.AxisX.Title               = "Ngày";
            area.AxisY.Title               = "Doanh thu (VNĐ)";
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.Interval            = 1; // Tránh lỗi dồn nhãn
            chart.ChartAreas.Add(area);

            Series series = new Series("Doanh Thu")
            {
                ChartType            = SeriesChartType.Column,
                Color                = Color.DodgerBlue,
                IsValueShownAsLabel  = true,
                LabelFormat          = "N0",
                IsXValueIndexed      = true
            };
            chart.Series.Add(series);

            foreach (var item in duLieu7Ngay)
                series.Points.AddXY(item.Key, item.Value);

            pnlBieuDo.Controls.Add(chart);
        }

        #endregion

        #region Dùng chung — Bộ lọc thời gian (Tab 2 & Tab 3)

        // Nạp tùy chọn bộ lọc và danh sách quý/năm vào ComboBox
        private void SetupBoLocThoiGian(ComboBox cboLoc, ComboBox cboQuy, ComboBox cboNam)
        {
            cboLoc.Items.Clear();
            cboLoc.Items.AddRange(new string[] { "Tùy chọn (Tự chọn ngày)", "Hôm nay", "Tuần này", "Tháng này", "Chọn theo Quý", "Chọn theo Năm" });

            cboQuy.Items.Clear();
            cboQuy.Items.AddRange(new string[] { "Quý 1", "Quý 2", "Quý 3", "Quý 4" });
            cboQuy.SelectedIndex = 0;

            cboNam.Items.Clear();
            int namHT = DateTime.Now.Year;
            for (int i = namHT - 5; i <= namHT; i++) cboNam.Items.Add(i.ToString());
            cboNam.SelectedItem = namHT.ToString();

            cboLoc.SelectedIndex = 3; // Mặc định: Tháng này
        }

        // Xử lý khi thay đổi loại lọc nhanh: ẩn/hiện ComboBox phụ, tự nhảy ngày
        private void XuLyLocNhanhChanged(ComboBox cboLoc, ComboBox cboQuy, ComboBox cboNam, DateTimePicker dtpTu, DateTimePicker dtpDen)
        {
            string cheDo = cboLoc.Text;
            DateTime today = DateTime.Today;

            if (cheDo == "Chọn theo Quý" || cheDo == "Chọn theo Năm")
            {
                cboQuy.Enabled = cheDo == "Chọn theo Quý";
                cboNam.Enabled = true;
                TinhNgayQuyNam(cboLoc, cboQuy, cboNam, dtpTu, dtpDen);
            }
            else
            {
                cboQuy.Enabled = false;
                cboNam.Enabled = false;
                switch (cheDo)
                {
                    case "Hôm nay":
                        dtpTu.Value = dtpDen.Value = today; break;
                    case "Tuần này":
                        int offset = today.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)today.DayOfWeek - 1;
                        dtpTu.Value  = today.AddDays(-offset);
                        dtpDen.Value = dtpTu.Value.AddDays(6); break;
                    case "Tháng này":
                        dtpTu.Value  = new DateTime(today.Year, today.Month, 1);
                        dtpDen.Value = dtpTu.Value.AddMonths(1).AddDays(-1); break;
                }
            }
        }

        // Tính khoảng ngày theo Quý hoặc cả Năm rồi set vào DateTimePicker
        private void TinhNgayQuyNam(ComboBox cboLoc, ComboBox cboQuy, ComboBox cboNam, DateTimePicker dtpTu, DateTimePicker dtpDen)
        {
            if (cboNam.SelectedItem == null || cboQuy.SelectedItem == null) return;

            int nam = int.Parse(cboNam.SelectedItem.ToString());

            if (cboLoc.Text == "Chọn theo Quý")
            {
                int quy     = cboQuy.SelectedIndex + 1;
                dtpTu.Value  = new DateTime(nam, (quy - 1) * 3 + 1, 1);
                dtpDen.Value = dtpTu.Value.AddMonths(3).AddDays(-1);
            }
            else if (cboLoc.Text == "Chọn theo Năm")
            {
                dtpTu.Value  = new DateTime(nam, 1, 1);
                dtpDen.Value = new DateTime(nam, 12, 31);
            }
        }

        #endregion

        #region Tab 2 — Báo cáo doanh thu (RDLC)

        private void LoadTab2_BaoCao() => SetupBoLocThoiGian(cboLocNhanh, cboQuy, cboNam);

        // Event handlers bộ lọc Tab 2 — gọi hàm dùng chung
        private void cboLocNhanh_SelectedIndexChanged(object sender, EventArgs e) => XuLyLocNhanhChanged(cboLocNhanh, cboQuy, cboNam, dtpTuNgay, dtpDenNgay);
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)      => TinhNgayQuyNam(cboLocNhanh, cboQuy, cboNam, dtpTuNgay, dtpDenNgay);
        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)      => TinhNgayQuyNam(cboLocNhanh, cboQuy, cboNam, dtpTuNgay, dtpDenNgay);

        // Lấy dữ liệu → đổ vào RDLC Report → gọi RefreshReport()
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                var data = _service.LayChiTietDoanhThu(dtpTuNgay.Value, dtpDenNgay.Value);
                if (data == null || data.Count == 0) { MessageBox.Show("Không có doanh thu trong khoảng thời gian này!"); return; }

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, @"Report\rptDoanhThu.rdlc");
                reportViewer1.LocalReport.SetParameters(new ReportParameter[]
                {
                    new ReportParameter("p_MaBaoCao",     "BC-" + DateTime.Now.ToString("ddMM-HHmm")),
                    new ReportParameter("p_NguoiLapPhieu","Chủ Cửa Hàng (Admin)"),
                    new ReportParameter("p_TuNgay",       "Từ ngày " + dtpTuNgay.Value.ToString("dd/MM/yyyy")),
                    new ReportParameter("p_DenNgay",      "đến ngày " + dtpDenNgay.Value.ToString("dd/MM/yyyy"))
                });
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_DoanhThu", data));
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                string loiThatSu = ex.InnerException != null ? ex.Message + "\nChi tiết: " + ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi: " + loiThatSu, "Lỗi RDLC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Tab 3 — Thống kê sản phẩm (Biểu đồ tròn Top 5)

        // Khởi tạo biểu đồ tròn 3D và bộ lọc Tab 3
        public void LoadTab3_BieuDo()
        {
            SetupChart();
            SetupBoLocThoiGian(cboLocNhanhTab3, cboQuyTab3, cboNamTab3);
        }

        // Tạo chart tròn 3D, thêm vào pnlBieuDoTron
        private void SetupChart()
        {
            chartSanPham = new Chart { Dock = DockStyle.Fill };
            chartSanPham.Palette = ChartColorPalette.Pastel; // Màu pastel sang trọng

            ChartArea area = new ChartArea("Main");
            area.Area3DStyle.Enable3D    = true;
            area.Area3DStyle.Inclination = 50; // Độ nghiêng bánh
            chartSanPham.ChartAreas.Add(area);

            chartSanPham.Titles.Add("TOP 5 SẢN PHẨM BÁN CHẠY NHẤT");
            chartSanPham.Titles[0].Font = new Font("Arial", 15, FontStyle.Bold);

            Legend legend = new Legend("Legend1") { Font = new Font("Arial", 11), Docking = Docking.Right };
            chartSanPham.Legends.Add(legend);

            pnlBieuDoTron.Controls.Add(chartSanPham);
        }

        // Event handlers bộ lọc Tab 3 — gọi hàm dùng chung
        private void cboLocNhanhTab3_SelectedIndexChanged(object sender, EventArgs e) => XuLyLocNhanhChanged(cboLocNhanhTab3, cboQuyTab3, cboNamTab3, dtpTuNgayTab3, dtpDenNgayTab3);
        private void cboQuyTab3_SelectedIndexChanged(object sender, EventArgs e)      => TinhNgayQuyNam(cboLocNhanhTab3, cboQuyTab3, cboNamTab3, dtpTuNgayTab3, dtpDenNgayTab3);
        private void cboNamTab3_SelectedIndexChanged(object sender, EventArgs e)      => TinhNgayQuyNam(cboLocNhanhTab3, cboQuyTab3, cboNamTab3, dtpTuNgayTab3, dtpDenNgayTab3);

        // Vẽ biểu đồ tròn Top 5 sản phẩm bán chạy
        private void btnXemBieuDo_Click(object sender, EventArgs e)
        {
            var data = _service.GetTop5SanPhamBanChay(dtpTuNgayTab3.Value, dtpDenNgayTab3.Value);
            if (data == null || data.Count == 0) { MessageBox.Show("Không có doanh thu trong khoảng thời gian này!"); return; }

            chartSanPham.Series.Clear();

            Series series = new Series("SanPham")
            {
                ChartType            = SeriesChartType.Pie,
                IsValueShownAsLabel  = true,
                Label                = "#PERCENT{P0}",
                Font                 = new Font("Arial", 10, FontStyle.Bold),
                LabelForeColor       = Color.White,
                LegendText           = "#VALX: #VAL ly"
            };

            foreach (var item in data)
                series.Points.AddXY(item.TenSanPham, item.TongSoLuong);

            chartSanPham.Series.Add(series);
        }

        #endregion
    }
}