using System;
using System.Drawing;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    public partial class UC_QL_BaoCao : UserControl
    {
        private readonly QuanLi_BaoCaoService _bcService = new QuanLi_BaoCaoService();

        public UC_QL_BaoCao()
        {
            InitializeComponent();
        }

        private void UC_Load(object sender, EventArgs e)
        {
            LoadThongKeNhanh();
            LoadTopMon();
            LoadDoanhThu7Ngay();
            LoadKhoBaoDong();
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
            foreach (DataGridViewColumn col in dgvKhoBaoDong.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "MaNl": col.Visible = false; break;
                    case "TenNl": col.HeaderText = "Tên Nguyên Liệu"; break;
                    case "DonViTinh": col.HeaderText = "ĐVT"; break;
                    case "SoLuongTon": col.HeaderText = "Còn Lại"; break;
                    case "NguongCanhBao": col.HeaderText = "Mức Báo Động"; break;
                    case "TrangThai": col.Visible = false; break; // Ẩn bớt cho gọn
                }
            }
            dgvKhoBaoDong.ClearSelection();
        }

        // Ép bôi đỏ nguyên grid Kho Báo Động để thu hút sự chú ý
        private void DgvKhoBaoDong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 235, 238); // Hồng nhạt
                e.CellStyle.ForeColor = Color.FromArgb(211, 47, 47);   // Đỏ gắt
                e.CellStyle.Font = new Font(dgvKhoBaoDong.Font, FontStyle.Bold);
            }
        }
    }
}