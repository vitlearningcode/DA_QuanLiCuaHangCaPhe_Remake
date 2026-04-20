using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.Reporting.WinForms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    public partial class UC_QL_BaoCao : UserControl
    {
        #region Khai báo service & biến

        // Service báo cáo của module Quản Lý (chỉ được đọc, không sửa dữ liệu)
        private readonly QuanLi_BaoCaoService _bcService = new QuanLi_BaoCaoService();

        // ReportViewer tạo động — nhét vào pnlReportViewerContainer khi Load
        private ReportViewer rptDoanhThu_QL;

        // Tên nhân viên đang đăng nhập — dùng để in vào tiêu đề báo cáo
        private readonly string _tenNhanVienDangNhap;

        #endregion

        #region Khởi tạo — Nhận tên NV từ form cha truyền sang

        // tenNhanVien được QuanLi.cs truyền vào khi khởi tạo UC này
        public UC_QL_BaoCao(string tenNhanVien = "Admin")
        {
            InitializeComponent();
            _tenNhanVienDangNhap = tenNhanVien;
        }

        #endregion

        #region Load form — Khởi tạo lưới, ReportViewer, và tải dữ liệu ban đầu

        private void UC_Load(object sender, EventArgs e)
        {
            // Cấu hình lưới cảnh báo kho: chọn toàn dòng, màu đỏ khi chọn
            dgvKhoBaoDong.SelectionMode                             = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoBaoDong.MultiSelect                              = false;
            dgvKhoBaoDong.DefaultCellStyle.SelectionBackColor      = Color.IndianRed;
            dgvKhoBaoDong.DefaultCellStyle.SelectionForeColor      = Color.White;

            // Tải dữ liệu 4 widget dashboard
            LoadThongKeNhanh();
            LoadTopMon();
            LoadDoanhThu7Ngay();
            LoadKhoBaoDong();

            // Tạo ReportViewer (tạo động để không bị lỗi khi thiếu thư viện ở máy khác)
            if (rptDoanhThu_QL == null)
            {
                rptDoanhThu_QL      = new ReportViewer();
                rptDoanhThu_QL.Dock = DockStyle.Fill;
                pnlReportViewerContainer.Controls.Add(rptDoanhThu_QL);
            }
        }

        #endregion

        #region Hàm nội bộ — Tải dữ liệu các widget dashboard

        // Widget 1: Doanh thu hôm nay và số đơn hàng hôm nay
        private void LoadThongKeNhanh()
        {
            var tk = _bcService.ThongKeNhanhHomNay();
            lblDoanhThuSo.Text = $"{tk.DoanhThu:N0} VNĐ";
            lblDonHangSo.Text  = $"{tk.SoDon:N0} Đơn";
        }

        // Widget 2: Top 5 món bán chạy (lưới có tên + số lượng + doanh thu)
        private void LoadTopMon()
        {
            dgvTopMon.DataSource = _bcService.LayTop5MonBanChay();

            foreach (DataGridViewColumn col in dgvTopMon.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "MaSP":           col.Visible = false; break;
                    case "TenSP":          col.HeaderText = "Tên Đồ Uống"; break;
                    case "TongSoLuong":    col.HeaderText = "Đã Bán (Ly)"; break;
                    case "TongDoanhThu":
                        col.HeaderText                    = "Mang Lại (VNĐ)";
                        col.DefaultCellStyle.Format       = "N0";
                        break;
                }
            }
            dgvTopMon.ClearSelection();
        }

        // Widget 3: Doanh thu theo ngày 7 ngày gần nhất
        private void LoadDoanhThu7Ngay()
        {
            dgvDoanhThu7Ngay.DataSource = _bcService.LayBieuDo7Ngay();

            foreach (DataGridViewColumn col in dgvDoanhThu7Ngay.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "Ngay":
                        col.HeaderText                    = "Ngày";
                        col.DefaultCellStyle.Format       = "dd/MM/yyyy";
                        break;
                    case "DoanhThu":
                        col.HeaderText                    = "Tổng Thu (VNĐ)";
                        col.DefaultCellStyle.Format       = "N0";
                        break;
                }
            }
            dgvDoanhThu7Ngay.ClearSelection();
        }

        // Widget 4: Danh sách nguyên liệu sắp hết (dưới ngưỡng cảnh báo)
        private void LoadKhoBaoDong()
        {
            dgvKhoBaoDong.DataSource = _bcService.LayKhoBaoDong();

            // Ẩn cột object navigation (EF navigation property)
            if (dgvKhoBaoDong.Columns["ChiTietPhieuKhos"] != null) dgvKhoBaoDong.Columns["ChiTietPhieuKhos"].Visible = false;
            if (dgvKhoBaoDong.Columns["DinhLuongs"]       != null) dgvKhoBaoDong.Columns["DinhLuongs"].Visible       = false;

            foreach (DataGridViewColumn col in dgvKhoBaoDong.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "MaNl":           col.Visible = false; break;
                    case "TenNl":          col.HeaderText = "Tên Nguyên Liệu"; break;
                    case "DonViTinh":      col.HeaderText = "ĐVT"; break;
                    case "SoLuongTon":     col.HeaderText = "Còn Lại"; break;
                    case "NguongCanhBao":  col.HeaderText = "Mức Báo Động"; break;
                    case "TrangThai":      col.Visible = false; break;
                }
            }
            dgvKhoBaoDong.ClearSelection();
        }

        // Tô toàn bộ dòng lưới cảnh báo kho bằng màu đỏ nhạt
        private void DgvKhoBaoDong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 235, 238);
                e.CellStyle.ForeColor = Color.FromArgb(211, 47, 47);
                e.CellStyle.Font      = new Font(dgvKhoBaoDong.Font, FontStyle.Bold);
            }
        }

        #endregion

        #region Xuất báo cáo doanh thu RDLC

        // Tạo DataTable từ DB → đổ vào RDLC → gắn parameters tên NV & khoảng ngày → render
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay  = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1); // Hết ngày cuối

                using var db = new DataSqlContext();
                var lstDonHang = db.DonHangs
                    .Where(d => d.TrangThai == "Đã thanh toán" && d.NgayLap >= tuNgay && d.NgayLap <= denNgay)
                    .ToList();

                // Xây DataTable khớp với Schema RDLC
                DataTable dt = new DataTable();
                dt.Columns.Add("MaHD",     typeof(string));
                dt.Columns.Add("NgayLap",  typeof(string));
                dt.Columns.Add("TenNV",    typeof(string));
                dt.Columns.Add("TongTien", typeof(decimal));

                foreach (var dh in lstDonHang)
                {
                    dt.Rows.Add(
                        "HD" + dh.MaDh.ToString("D5"),
                        dh.NgayLap?.ToString("dd/MM/yyyy HH:mm"),
                        dh.MaNv ?? _tenNhanVienDangNhap, // Fallback về tên người xuất BC nếu DB rỗng
                        dh.TongTien ?? 0
                    );
                }

                rptDoanhThu_QL.LocalReport.ReportEmbeddedResource = "DA_QuanLiCuaHangCaPhe_Nhom9.Report.rptDoanhThu_QL.rdlc";
                rptDoanhThu_QL.LocalReport.DataSources.Clear();
                rptDoanhThu_QL.LocalReport.DataSources.Add(new ReportDataSource("QL_BCDT", dt));
                rptDoanhThu_QL.LocalReport.SetParameters(new ReportParameter[]
                {
                    new ReportParameter("p_TuNgay",       tuNgay.ToString("dd/MM/yyyy")),
                    new ReportParameter("p_DenNgay",      denNgay.ToString("dd/MM/yyyy")),
                    new ReportParameter("p_NguoiLapPhieu",_tenNhanVienDangNhap),
                    new ReportParameter("p_MaBaoCao",     "BC" + DateTime.Now.ToString("yyyyMMddHHmm"))
                });
                rptDoanhThu_QL.RefreshReport();
            }
            catch (Exception ex)
            {
                string loi = ex.InnerException != null ? ex.Message + "\nLỗi gốc: " + ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi hiển thị báo cáo:\n" + loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}