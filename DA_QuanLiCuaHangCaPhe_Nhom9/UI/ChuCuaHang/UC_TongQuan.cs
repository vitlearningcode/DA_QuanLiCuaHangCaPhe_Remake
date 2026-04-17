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

            HienThiDuLieu();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            HienThiDuLieu();
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
            var dict = _service.LayDoanhThuTheoNgay(tuNgay, denNgay);

            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("BIỂU ĐỒ DOANH THU THEO NGÀY");
            chartDoanhThu.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);

            Series s = new Series("Doanh Thu");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            s.LabelFormat = "N0";
            s.Color = Color.DodgerBlue;

            foreach (var item in dict)
            {
                s.Points.AddXY(item.Key, item.Value);
            }

            chartDoanhThu.Series.Add(s);
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
        }
    }
}