using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_TongQuan : UserControl
    {
        #region Khai báo service

        // Service tổng quan: lấy số liệu KPI và dữ liệu biểu đồ doanh thu
        private readonly TongQuanService _service = new TongQuanService();

        #endregion

        #region Khởi tạo & Load

        public UC_TongQuan()
        {
            InitializeComponent();
        }

        // Load: mặc định xem hôm nay, loại biểu đồ = Cột, hiển thị số liệu ngay
        private void UC_TongQuan_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value  = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            cboLoaiBieuDo.SelectedIndex = 0; // Mặc định: Biểu đồ Cột
            HienThiDuLieu();
        }

        #endregion

        #region Sự kiện bộ lọc & loại biểu đồ

        // Nút Lọc → cập nhật dữ liệu theo khoảng thời gian đã chọn
        private void btnLoc_Click(object sender, EventArgs e) => HienThiDuLieu();

        // Đổi loại biểu đồ (Cột / Đường / Miền) → vẽ lại ngay lập tức
        private void cboLoaiBieuDo_SelectedIndexChanged(object sender, EventArgs e) => HienThiDuLieu();

        #endregion

        #region Hàm logic — Hiển thị số liệu KPI & vẽ biểu đồ

        // Tổng hợp: validate ngày, đổ số liệu lên label, vẽ biểu đồ
        private void HienThiDuLieu()
        {
            var tuNgay  = dtpTuNgay.Value;
            var denNgay = dtpDenNgay.Value;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo");
                return;
            }

            // --- Đổ số liệu KPI vào các Label ---
            var data = _service.LaySoLieuTongQuan(tuNgay, denNgay);

            lblDoanhSo.Text        = $"{data.DoanhSo:N0} đ";
            lblGiamGia.Text        = $"{data.GiamGia:N0} đ";
            lblDoanhThuThuan.Text  = $"{data.DoanhThuThuan:N0} đ";
            lblTongChi.Text        = $"{data.TongChi:N0} đ";
            lblLoiNhuan.Text       = $"{data.LoiNhuan:N0} đ";

            // Lợi nhuận âm → chữ vàng cảnh báo; dương → trắng bình thường
            lblLoiNhuan.ForeColor = data.LoiNhuan < 0 ? Color.Yellow : Color.White;

            // --- Vẽ biểu đồ ---
            VeBieuDo(tuNgay, denNgay);
        }

        // Lấy dữ liệu chuỗi thời gian và vẽ biểu đồ theo loại đã chọn (Cột / Đường / Miền)
        private void VeBieuDo(DateTime tuNgay, DateTime denNgay)
        {
            var dict = _service.LayDuLieuBieuDoThongMinh(tuNgay, denNgay);

            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Legends.Clear(); // Tắt bảng chú thích lơ lửng

            // Tiêu đề biểu đồ
            chartDoanhThu.Titles.Add("BIỂU ĐỒ BIẾN ĐỘNG DOANH THU");
            chartDoanhThu.Titles[0].Font = new Font("Segoe UI", 14, FontStyle.Bold);

            Series s = new Series("DoanhThu");

            // Cấu hình loại biểu đồ theo ComboBox
            switch (cboLoaiBieuDo.SelectedIndex)
            {
                case 0: // Biểu đồ Cột
                    s.ChartType = SeriesChartType.Column;
                    s.Color     = Color.DodgerBlue;
                    break;
                case 1: // Biểu đồ Đường
                    s.ChartType   = SeriesChartType.Spline;
                    s.Color       = Color.MediumSeaGreen;
                    s.BorderWidth = 4;
                    break;
                case 2: // Biểu đồ Miền (Area)
                    s.ChartType   = SeriesChartType.SplineArea;
                    s.Color       = Color.FromArgb(120, Color.MediumOrchid);
                    s.BorderColor = Color.MediumOrchid;
                    s.BorderWidth = 2;
                    break;
            }

            // Cấu hình chung: hiện nhãn giá trị, đánh dấu điểm dữ liệu
            s.IsValueShownAsLabel = true;
            s.LabelFormat         = "N0";
            s.IsXValueIndexed     = true;
            s.MarkerStyle         = MarkerStyle.Circle;
            s.MarkerSize          = 8;
            s.MarkerColor         = Color.White;

            foreach (var item in dict)
            {
                int i = s.Points.AddXY(item.Key, item.Value);
                if (item.Value == 0) s.Points[i].IsValueShownAsLabel = false; // Ẩn nhãn "0" tránh rối mắt
            }

            chartDoanhThu.Series.Add(s);

            // Cấu hình trục X và Y
            var area = chartDoanhThu.ChartAreas[0];
            area.AxisX.Interval            = 1;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.Title               = "Doanh thu (VNĐ)";
            area.AxisY.TitleFont           = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisX.Title               = "Thời gian";
            area.AxisX.TitleFont           = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        #endregion
    }
}