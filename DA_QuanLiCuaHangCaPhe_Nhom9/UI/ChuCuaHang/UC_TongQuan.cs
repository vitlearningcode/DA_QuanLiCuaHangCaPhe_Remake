using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_TongQuan : UserControl
    {
        private readonly TongQuanService _service = new TongQuanService();

        public UC_TongQuan()
        {
            InitializeComponent();
        }

        private void UC_TongQuan_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định: Từ đầu tháng đến hôm nay
            DateTime today = DateTime.Today;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = today;
            cboLoaiBieuDo.SelectedIndex = 0;
            HienThiDuLieu();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void cboLoaiBieuDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDuLieu(); // Gọi lại hàm hiển thị để vẽ lại biểu đồ
        }

        private void HienThiDuLieu()
        {
            var tuNgay = dtpTuNgay.Value;
            var denNgay = dtpDenNgay.Value;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo");
                return;
            }

            // 1. Đổ dữ liệu vào các nhãn (Labels)
            var data = _service.LaySoLieuTongQuan(tuNgay, denNgay);

            lblDoanhSo.Text = string.Format("{0:N0} đ", data.DoanhSo);
            lblGiamGia.Text = string.Format("{0:N0} đ", data.GiamGia);
            lblDoanhThuThuan.Text = string.Format("{0:N0} đ", data.DoanhThuThuan);
            lblTongChi.Text = string.Format("{0:N0} đ", data.TongChi);
            lblLoiNhuan.Text = string.Format("{0:N0} đ", data.LoiNhuan);

            // Đổi màu lợi nhuận nếu âm
            lblLoiNhuan.ForeColor = data.LoiNhuan < 0 ? Color.Yellow : Color.White;

            // 2. Vẽ biểu đồ
            VeBieuDo(tuNgay, denNgay);
        }

        private void VeBieuDo(DateTime tuNgay, DateTime denNgay)
        {
            var dict = _service.LayDoanhThuTheoGio(tuNgay, denNgay); // Lấy dữ liệu theo giờ từ service

            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("BIỂU ĐỒ BIẾN ĐỘNG DOANH THU");
            chartDoanhThu.Titles[0].Font = new Font("Segoe UI", 14, FontStyle.Bold);

            Series s = new Series("DoanhThu");

            // --- LOGIC CHUYỂN ĐỔI DỰA TRÊN COMBOBOX ---
            switch (cboLoaiBieuDo.SelectedIndex)
            {
                case 0: // Biểu đồ Cột
                    s.ChartType = SeriesChartType.Column;
                    s.Color = Color.DodgerBlue;
                    break;
                case 1: // Biểu đồ Đường
                    s.ChartType = SeriesChartType.Spline;
                    s.Color = Color.MediumSeaGreen;
                    s.BorderWidth = 4;
                    break;
                case 2: // Biểu đồ Miền
                    s.ChartType = SeriesChartType.SplineArea;
                    s.Color = Color.FromArgb(120, Color.MediumOrchid); // Màu tím trong suốt
                    s.BorderColor = Color.MediumOrchid;
                    s.BorderWidth = 2;
                    break;
            }

            // Cấu hình chung giúp biểu đồ đẹp hơn (Giống UC_ThongKe)
            s.IsValueShownAsLabel = true;
            s.LabelFormat = "N0";
            s.IsXValueIndexed = true;
            s.MarkerStyle = MarkerStyle.Circle;
            s.MarkerSize = 8;
            s.MarkerColor = Color.White;

            foreach (var item in dict)
            {
                int i = s.Points.AddXY(item.Key, item.Value);
                if (item.Value == 0) s.Points[i].IsValueShownAsLabel = false; // Ẩn số 0 cho đỡ rối
            }

            chartDoanhThu.Series.Add(s);

            // Tinh chỉnh trục X và lưới (Grid)
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
            chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartDoanhThu.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }   
    }
}