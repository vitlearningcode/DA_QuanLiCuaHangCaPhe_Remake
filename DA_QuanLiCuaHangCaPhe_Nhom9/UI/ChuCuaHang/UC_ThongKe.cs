using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Thư viện vẽ biểu đồ
using Microsoft.Reporting.WinForms;
using System.IO;
namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_ThongKe : UserControl
    {
        private readonly ThongKeService _service = new ThongKeService();
        private ReportViewer reportViewer1;

        public UC_ThongKe()
        {
            InitializeComponent();
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            // Tự động tạo và nhét ReportViewer vào cái Panel bro vừa kéo thả
            reportViewer1 = new ReportViewer();
            reportViewer1.Dock = DockStyle.Fill;
            pnlBaoCao.Controls.Add(reportViewer1);

            // Tải dữ liệu Tab 1 
            LoadTab1_Dashboard();
            LoadTab2_BaoCao();
        }

        private void LoadTab1_Dashboard()
        {
            // 1. TÍNH TOÁN CÁC CON SỐ TỔNG QUAN
            DateTime homNay = DateTime.Today;
            DateTime dauThang = new DateTime(homNay.Year, homNay.Month, 1);

            decimal dtHomNay = _service.LayDoanhThu(homNay, homNay);
            int soDonHomNay = _service.LaySoDonHang(homNay, homNay);
            decimal dtThangNay = _service.LayDoanhThu(dauThang, homNay);

            // Gán lên giao diện (Format định dạng tiền tệ VNĐ)
            lblDoanhThuHomNay.Text = dtHomNay.ToString("N0") + " đ";
            lblSoDonHomNay.Text = soDonHomNay.ToString();
            lblDoanhThuThang.Text = dtThangNay.ToString("N0") + " đ";

            // 2. VẼ BIỂU ĐỒ DOANH THU 7 NGÀY
            VeBieuDo7Ngay();
        }

        private void VeBieuDo7Ngay()
        {
            // Lấy dữ liệu
            Dictionary<string, decimal> duLieu7Ngay = _service.LayDoanhThu7NgayQua();

            // Xóa biểu đồ cũ nếu có (để tránh bị đè khi reload)
            pnlBieuDo.Controls.Clear();

            // Tạo biểu đồ mới bằng Code
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Cấu hình vùng vẽ (ChartArea)
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Ngày";
            chartArea.AxisY.Title = "Doanh thu (VNĐ)";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas.Add(chartArea);

            // Cấu hình series (Cột dữ liệu)
            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column; // Biểu đồ cột
            series.Color = Color.DodgerBlue;
            series.IsValueShownAsLabel = true; // Hiện số tiền trên đỉnh cột
            series.LabelFormat = "N0"; // Format tiền
            chart.Series.Add(series);

            // Nạp dữ liệu vào biểu đồ
            foreach (var item in duLieu7Ngay)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            // Thêm biểu đồ vào Panel
            pnlBieuDo.Controls.Add(chart);
        }

        private void LoadTab2_BaoCao()
        {

            // Nạp danh sách tùy chọn vào ComboBox
            cboLocNhanh.Items.Clear();
            cboLocNhanh.Items.AddRange(new string[] {
                "Tùy chọn (Tự chọn ngày)",
                "Hôm nay",
                "Tuần này",
                "Tháng này",
                "Chọn theo Quý",  // Sửa thành tên này
                "Chọn theo Năm"   // Sửa thành tên này
            });

            // 2. Nạp danh sách Quý
            cboQuy.Items.Clear();
            cboQuy.Items.AddRange(new string[] { "Quý 1", "Quý 2", "Quý 3", "Quý 4" });
            cboQuy.SelectedIndex = 0; // Mặc định Quý 1

            // 3. Nạp danh sách Năm (Lấy từ 5 năm trước đến hiện tại)
            cboNam.Items.Clear();
            int namHienTai = DateTime.Now.Year;
            for (int i = namHienTai - 5; i <= namHienTai; i++)
            {
                cboNam.Items.Add(i.ToString());
            }
            cboNam.SelectedItem = namHienTai.ToString(); // Mặc định chọn năm hiện tại

            // Mặc định chọn "Tháng này" cho Lọc nhanh
            cboLocNhanh.SelectedIndex = 3;
        }

        private void cboLocNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cheDoLoc = cboLocNhanh.Text;
            DateTime today = DateTime.Today;

            // --- ĐÓNG/MỞ CÁC COMBOBOX PHỤ ---
            if (cheDoLoc == "Chọn theo Quý")
            {
                cboQuy.Enabled = true;  // Sáng lên
                cboNam.Enabled = true;  // Sáng lên
                TinhNgayTheoQuyNam();   // Gọi hàm tự tính ngày
            }
            else if (cheDoLoc == "Chọn theo Năm")
            {
                cboQuy.Enabled = false; // Xám màu
                cboNam.Enabled = true;  // Sáng lên
                TinhNgayTheoQuyNam();   // Gọi hàm tự tính ngày
            }
            else
            {
                // Các case khác thì xám màu cả 2
                cboQuy.Enabled = false;
                cboNam.Enabled = false;

                // Xử lý nhảy ngày cho các case cơ bản
                switch (cheDoLoc)
                {
                    case "Hôm nay":
                        dtpTuNgay.Value = today;
                        dtpDenNgay.Value = today;
                        break;
                    case "Tuần này":
                        int offset = today.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)today.DayOfWeek - 1;
                        dtpTuNgay.Value = today.AddDays(-offset);
                        dtpDenNgay.Value = dtpTuNgay.Value.AddDays(6);
                        break;
                    case "Tháng này":
                        dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
                        dtpDenNgay.Value = dtpTuNgay.Value.AddMonths(1).AddDays(-1);
                        break;
                }
            }
        }
        // 1. Hàm tính toán trung tâm
        private void TinhNgayTheoQuyNam()
        {
            // Kiểm tra xem đã load xong dữ liệu chưa để tránh lỗi
            if (cboNam.SelectedItem == null || cboQuy.SelectedItem == null) return;

            int nam = int.Parse(cboNam.SelectedItem.ToString());

            if (cboLocNhanh.Text == "Chọn theo Quý")
            {
                int quy = cboQuy.SelectedIndex + 1; // Index 0 là Quý 1 => +1 thành 1
                dtpTuNgay.Value = new DateTime(nam, (quy - 1) * 3 + 1, 1);
                dtpDenNgay.Value = dtpTuNgay.Value.AddMonths(3).AddDays(-1);
            }
            else if (cboLocNhanh.Text == "Chọn theo Năm")
            {
                dtpTuNgay.Value = new DateTime(nam, 1, 1);
                dtpDenNgay.Value = new DateTime(nam, 12, 31);
            }
        }

        // 2. Sự kiện khi người dùng đổi Quý
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhNgayTheoQuyNam();
        }

        // 3. Sự kiện khi người dùng đổi Năm
        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhNgayTheoQuyNam();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                var data = _service.LayChiTietDoanhThu(dtpTuNgay.Value, dtpDenNgay.Value);

                if (data == null || data.Count == 0)
                {
                    MessageBox.Show("Không có doanh thu!"); return;
                }

                reportViewer1.LocalReport.DataSources.Clear();
                string reportPath = Path.Combine(Application.StartupPath, @"Report\rptDoanhThu.rdlc");
                reportViewer1.LocalReport.ReportPath = reportPath;

                // --- ĐOẠN MỚI: TRUYỀN THAM SỐ VÀO BÁO CÁO ---
                // Mã báo cáo tự sinh (VD: BC-1504-0930)
                string maBaoCao = "BC-" + DateTime.Now.ToString("ddMM-HHmm");

                // Tên người lập: Hiện tại fix cứng là Chủ Cửa Hàng, 
                // sau này bro có thể lấy từ biến Session chứa Tên nhân viên đang đăng nhập!
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
                // ---------------------------------------------

                ReportDataSource rds = new ReportDataSource("DataSet_DoanhThu", data);
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                string loiThatSu = ex.Message;
                // Thêm đoạn này để moi móc cái lỗi ẩn bên trong ra
                if (ex.InnerException != null)
                {
                    loiThatSu += "\nChi tiết lỗi thực sự: " + ex.InnerException.Message;
                }
                MessageBox.Show("Lỗi: " + loiThatSu, "Bắt bệnh RDLC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}