using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    public partial class UC_QL_SanPham : UserControl
    {
        private readonly QuanLi_SanPhamService _spService = new QuanLi_SanPhamService();

        // Bộ nhớ lưu danh sách gốc để Lọc cực nhanh trên RAM
        private List<SanPhamView> _danhSachGoc = new List<SanPhamView>();

        // Cờ lưu Mã SP ẩn, vì trên UI ta đã giấu Mã đi cho sạch
        private int _maSPDangChon = -1;

        public UC_QL_SanPham()
        {
            InitializeComponent();

            this.Load += UC_Load;
            dgvSanPham.CellFormatting += DgvSanPham_CellFormatting;
            dgvSanPham.CellClick += DgvSanPham_CellClick;
            btnDoiTrangThai.Click += BtnDoiTrangThai_Click;

            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            cboLocLoai.SelectedIndexChanged += CboLocLoai_SelectedIndexChanged;
        }

        private void UC_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            _danhSachGoc = _spService.LayDanhSachMenu();

            // Tự động load danh sách Nhóm SP vào ComboBox
            if (cboLocLoai.Items.Count == 0 && _danhSachGoc.Count > 0)
            {
                var dsLoai = _danhSachGoc.Select(x => x.LoaiSP).Distinct().ToList();
                dsLoai.Insert(0, "-- Tất cả nhóm --");
                cboLocLoai.DataSource = dsLoai;
            }

            ThucThiLocDuLieu();
        }

        // ================= LOGIC TÌM KIẾM & LỌC =================
        private void TxtTimKiem_TextChanged(object sender, EventArgs e) => ThucThiLocDuLieu();
        private void CboLocLoai_SelectedIndexChanged(object sender, EventArgs e) => ThucThiLocDuLieu();

        private void ThucThiLocDuLieu()
        {
            if (_danhSachGoc == null || _danhSachGoc.Count == 0) return;

            string tuKhoa = txtTimKiem.Text.ToLower().Trim();
            string nhomLoai = cboLocLoai.Text;

            var ketQuaLoc = _danhSachGoc.Where(sp =>
                (nhomLoai == "-- Tất cả nhóm --" || sp.LoaiSP == nhomLoai) &&
                (sp.TenSP.ToLower().Contains(tuKhoa) || sp.MaSP.ToString().Contains(tuKhoa))
            ).ToList();

            dgvSanPham.DataSource = ketQuaLoc;
            DinhDangLuoi();
            dgvSanPham.ClearSelection();
            LamMoiTrangThaiLui();
        }

        private void LamMoiTrangThaiLui()
        {
            _maSPDangChon = -1;
            txtTenSP.Clear(); txtLoai.Clear(); txtGiaBan.Clear();
            btnDoiTrangThai.Text = "CHỌN MÓN ĐỂ THAO TÁC";
            btnDoiTrangThai.BackColor = Color.Gray;
        }

        // ================= FORMAT & CLICK =================
        private void DinhDangLuoi()
        {
            foreach (DataGridViewColumn col in dgvSanPham.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "MaSP":
                        col.Visible = false; // 🛑 ẨN CỘT MÃ ĐI KHỎI LƯỚI
                        break;
                    case "TenSP":
                        col.HeaderText = "Tên Món / Đồ Uống";
                        break;
                    case "LoaiSP":
                        col.HeaderText = "Nhóm (Category)";
                        break;
                    case "DonGia":
                        col.HeaderText = "Giá Bán";
                        col.DefaultCellStyle.Format = "N0";
                        break;
                    case "TrangThai":
                        col.HeaderText = "Tình Trạng";
                        break;
                }
            }
        }

        private void DgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSanPham.Rows[e.RowIndex].DataBoundItem is SanPhamView sp)
            {
                if (sp.TrangThai == "Ngừng bán")
                {
                    // Fomat tinh tế: Chữ xám nhạt và in nghiêng, nền giữ nguyên màu sáng để không bị rối mắt
                    e.CellStyle.ForeColor = Color.Gray;
                    e.CellStyle.Font = new Font(dgvSanPham.Font, FontStyle.Italic);
                    e.CellStyle.BackColor = Color.WhiteSmoke;
                }
                else if (sp.TrangThai == "Còn bán")
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void DgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSanPham.Rows[e.RowIndex];

                // Lấy Mã ngầm dưới Data
                _maSPDangChon = Convert.ToInt32(row.Cells["MaSP"].Value);

                txtTenSP.Text = row.Cells["TenSP"].Value?.ToString();
                txtLoai.Text = row.Cells["LoaiSP"].Value?.ToString();

                decimal gia = Convert.ToDecimal(row.Cells["DonGia"].Value ?? 0);
                txtGiaBan.Text = gia.ToString("N0");

                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                if (trangThai == "Ngừng bán")
                {
                    btnDoiTrangThai.Text = "✅ BÁN TRỞ LẠI";
                    btnDoiTrangThai.BackColor = Color.FromArgb(40, 167, 69);
                }
                else
                {
                    btnDoiTrangThai.Text = "🛑 BÁO NGƯNG BÁN";
                    btnDoiTrangThai.BackColor = Color.FromArgb(220, 53, 69);
                }
            }
        }

        // ================= XÁC NHẬN THAO TÁC =================
        private void BtnDoiTrangThai_Click(object sender, EventArgs e)
        {
            if (_maSPDangChon == -1)
            {
                MessageBox.Show("Vui lòng click chọn một món trên danh sách để thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string hanhDong = btnDoiTrangThai.Text == "🛑 BÁO NGƯNG BÁN" ?  "Ngừng Bán" : "Bán Trở Lại";
            string msg = $"Bạn có chắc chắn muốn chuyển món [{txtTenSP.Text}] sang trạng thái {hanhDong} không?";

            // Hộp thoại xác nhận (Yes/No)
            if (MessageBox.Show(msg, "Xác nhận thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (hanhDong == "Ngừng Bán")
                {
                    if (_spService.BaoNgungBan(_maSPDangChon)) LoadDanhSach();
                }
                else
                {
                    if (_spService.MoBanLai(_maSPDangChon)) LoadDanhSach();
                }
            }
        }
    }
}