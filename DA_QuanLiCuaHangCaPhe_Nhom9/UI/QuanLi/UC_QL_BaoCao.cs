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
        private readonly QuanLi_BaoCaoService _bcService = new QuanLi_BaoCaoService();
        private ReportViewer rptDoanhThu_QL;

        // --- 1. THÊM BIẾN LƯU TÊN NHÂN VIÊN ---
        private string _tenNhanVienDangNhap;

        // --- 2. SỬA HÀM KHỞI TẠO ĐỂ NHẬN TÊN TỪ FORM CHÍNH TRUYỀN SANG ---
        public UC_QL_BaoCao(string tenNhanVien = "Admin")
        {
            InitializeComponent();
            _tenNhanVienDangNhap = tenNhanVien; // Lưu lại để lát nhét vào báo cáo
        }

        private void UC_Load(object sender, EventArgs e)
        {
            // 1. SETUP LƯỚI KHU CẢNH BÁO
            dgvKhoBaoDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoBaoDong.MultiSelect = false;
            dgvKhoBaoDong.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
            dgvKhoBaoDong.DefaultCellStyle.SelectionForeColor = Color.White;

            LoadThongKeNhanh();
            LoadTopMon();
            LoadDoanhThu7Ngay();
            LoadKhoBaoDong();

            // 2. SETUP MÁY CHIẾU REPORT
            if (rptDoanhThu_QL == null)
            {
                rptDoanhThu_QL = new ReportViewer();
                rptDoanhThu_QL.Dock = DockStyle.Fill;
                pnlReportViewerContainer.Controls.Add(rptDoanhThu_QL);
            }
        }

        private void LoadThongKeNhanh()
        {
            var thongKe = _bcService.ThongKeNhanhHomNay();
            lblDoanhThuSo.Text = thongKe.DoanhThu.ToString("N0") + " VNĐ";
            lblDonHangSo.Text = thongKe.SoDon.ToString("N0") + " Đơn";
        }

        private void LoadTopMon()
        {
            dgvTopMon.DataSource = _bcService.LayTop5MonBanChay();

            foreach (DataGridViewColumn col in dgvTopMon.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "MaSP": col.Visible = false; break;
                    case "TenSP": col.HeaderText = "Tên Đồ Uống"; break;
                    case "TongSoLuong": col.HeaderText = "Đã Bán (Ly)"; break;
                    case "TongDoanhThu":
                        col.HeaderText = "Mang Lại (VNĐ)";
                        col.DefaultCellStyle.Format = "N0";
                        break;
                }
            }
            dgvTopMon.ClearSelection();
        }

        private void LoadDoanhThu7Ngay()
        {
            dgvDoanhThu7Ngay.DataSource = _bcService.LayBieuDo7Ngay();
            foreach (DataGridViewColumn col in dgvDoanhThu7Ngay.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "Ngay":
                        col.HeaderText = "Ngày";
                        col.DefaultCellStyle.Format = "dd/MM/yyyy";
                        break;
                    case "DoanhThu":
                        col.HeaderText = "Tổng Thu (VNĐ)";
                        col.DefaultCellStyle.Format = "N0";
                        break;
                }
            }
            dgvDoanhThu7Ngay.ClearSelection();
        }

        private void LoadKhoBaoDong()
        {
            dgvKhoBaoDong.DataSource = _bcService.LayKhoBaoDong();

            if (dgvKhoBaoDong.Columns["ChiTietPhieuKhos"] != null) dgvKhoBaoDong.Columns["ChiTietPhieuKhos"].Visible = false;
            if (dgvKhoBaoDong.Columns["DinhLuongs"] != null) dgvKhoBaoDong.Columns["DinhLuongs"].Visible = false;

            foreach (DataGridViewColumn col in dgvKhoBaoDong.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "MaNl": col.Visible = false; break;
                    case "TenNl": col.HeaderText = "Tên Nguyên Liệu"; break;
                    case "DonViTinh": col.HeaderText = "ĐVT"; break;
                    case "SoLuongTon": col.HeaderText = "Còn Lại"; break;
                    case "NguongCanhBao": col.HeaderText = "Mức Báo Động"; break;
                    case "TrangThai": col.Visible = false; break;
                }
            }
            dgvKhoBaoDong.ClearSelection();
        }

        private void DgvKhoBaoDong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 235, 238);
                e.CellStyle.ForeColor = Color.FromArgb(211, 47, 47);
                e.CellStyle.Font = new Font(dgvKhoBaoDong.Font, FontStyle.Bold);
            }
        }

        // ==============================================================
        // SỰ KIỆN XUẤT BÁO CÁO DOANH THU 
        // ==============================================================
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

                using (var db = new DataSqlContext())
                {
                    var lstDonHang = db.DonHangs
                        .Where(d => d.TrangThai == "Đã thanh toán" && d.NgayLap >= tuNgay && d.NgayLap <= denNgay)
                        .ToList();

                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("MaHD", typeof(string));
                    dt.Columns.Add("NgayLap", typeof(string));
                    dt.Columns.Add("TenNV", typeof(string));
                    dt.Columns.Add("TongTien", typeof(decimal));

                    decimal tongDoanhThu = 0;

                    foreach (var dh in lstDonHang)
                    {
                        dt.Rows.Add(
                            "HD" + dh.MaDh.ToString("D5"),
                            dh.NgayLap?.ToString("dd/MM/yyyy HH:mm"),
                            dh.MaNv ?? _tenNhanVienDangNhap, // Nếu trong database rỗng, lấy người xuất báo cáo
                            dh.TongTien ?? 0
                        );
                        tongDoanhThu += dh.TongTien ?? 0;
                    }

                    rptDoanhThu_QL.LocalReport.ReportEmbeddedResource = "DA_QuanLiCuaHangCaPhe_Nhom9.Report.rptDoanhThu_QL.rdlc";
                    rptDoanhThu_QL.LocalReport.DataSources.Clear();

                    ReportDataSource rds = new ReportDataSource("QL_BCDT", dt);
                    rptDoanhThu_QL.LocalReport.DataSources.Add(rds);

                    // --- 3. BƠM BIẾN VÀO PARAMETER Ở ĐÂY ---
                    ReportParameter[] p = new ReportParameter[] {
                        new ReportParameter("p_TuNgay", tuNgay.ToString("dd/MM/yyyy")),
                        new ReportParameter("p_DenNgay", denNgay.ToString("dd/MM/yyyy")),
                        
                        // Lôi biến ra xài
                        new ReportParameter("p_NguoiLapPhieu", _tenNhanVienDangNhap),

                        new ReportParameter("p_MaBaoCao", "BC" + DateTime.Now.ToString("yyyyMMddHHmm"))
                    };

                    rptDoanhThu_QL.LocalReport.SetParameters(p);
                    rptDoanhThu_QL.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                string loi = ex.Message;
                if (ex.InnerException != null) loi += "\nLỗi gốc: " + ex.InnerException.Message;
                MessageBox.Show("Lỗi hiển thị báo cáo:\n" + loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}