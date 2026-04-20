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
        #region Khai báo service & biến trạng thái

        // Service sản phẩm module QuanLi: chỉ xem menu và bật/tắt trạng thái bán
        private readonly QuanLi_SanPhamService _spService = new QuanLi_SanPhamService();

        // Cache danh sách gốc để lọc nhanh phía client (không query DB mỗi lần gõ)
        private List<SanPhamView> _danhSachGoc = new List<SanPhamView>();

        // Mã SP đang chọn (-1 = chưa chọn)
        private int _maSPDangChon = -1;

        #endregion

        #region Khởi tạo & Đăng ký sự kiện

        public UC_QL_SanPham()
        {
            InitializeComponent();

            // Đăng ký sự kiện tập trung — dễ tìm kiếm và theo dõi
            this.Load                           += UC_Load;
            dgvSanPham.CellFormatting           += DgvSanPham_CellFormatting;
            dgvSanPham.CellClick                += DgvSanPham_CellClick;
            btnDoiTrangThai.Click               += BtnDoiTrangThai_Click;
            txtTimKiem.TextChanged              += TxtTimKiem_TextChanged;
            cboLocLoai.SelectedIndexChanged     += CboLocLoai_SelectedIndexChanged;
        }

        // Load: tải toàn bộ menu → bộ lọc tự khởi tạo từ dữ liệu
        private void UC_Load(object sender, EventArgs e) => LoadDanhSach();

        #endregion

        #region Hàm nội bộ — Tải & lọc dữ liệu

        // Tải toàn bộ menu từ DB, tự tạo danh sách nhóm loại vào ComboBox
        private void LoadDanhSach()
        {
            _danhSachGoc = _spService.LayDanhSachMenu();

            // Lần đầu load: tự populate ComboBox nhóm loại từ dữ liệu thực tế
            if (cboLocLoai.Items.Count == 0 && _danhSachGoc.Count > 0)
            {
                var dsLoai = _danhSachGoc.Select(x => x.LoaiSP).Distinct().ToList();
                dsLoai.Insert(0, "-- Tất cả nhóm --");
                cboLocLoai.DataSource = dsLoai;
            }

            ThucThiLocDuLieu();
        }

        // Lọc _danhSachGoc theo từ khóa và nhóm loại → đổ vào lưới + format cột
        private void ThucThiLocDuLieu()
        {
            if (_danhSachGoc == null || _danhSachGoc.Count == 0) return;

            string tuKhoa  = txtTimKiem.Text.ToLower().Trim();
            string nhomLoai= cboLocLoai.Text;

            var ketQua = _danhSachGoc.Where(sp =>
                (nhomLoai == "-- Tất cả nhóm --" || sp.LoaiSP == nhomLoai) &&
                (sp.TenSP.ToLower().Contains(tuKhoa) || sp.MaSP.ToString().Contains(tuKhoa))
            ).ToList();

            dgvSanPham.DataSource = ketQua;
            DinhDangLuoi();
            dgvSanPham.ClearSelection();
            LamMoiTrangThaiLui(); // Reset form detail về trạng thái chờ chọn
        }

        // Cấu hình tên cột và format giá (tái sử dụng mỗi khi lọc)
        private void DinhDangLuoi()
        {
            foreach (DataGridViewColumn col in dgvSanPham.Columns)
            {
                switch (col.DataPropertyName)
                {
                    case "MaSP":       col.Visible = false; break;      // Ẩn mã nội bộ
                    case "TenSP":      col.HeaderText = "Tên Món / Đồ Uống"; break;
                    case "LoaiSP":     col.HeaderText = "Nhóm (Category)"; break;
                    case "DonGia":
                        col.HeaderText                = "Giá Bán";
                        col.DefaultCellStyle.Format   = "N0";
                        break;
                    case "TrangThai":  col.HeaderText = "Tình Trạng"; break;
                }
            }
        }

        // Reset form detail và nút thao tác về trạng thái "chưa chọn món nào"
        private void LamMoiTrangThaiLui()
        {
            _maSPDangChon         = -1;
            txtTenSP.Clear(); txtLoai.Clear(); txtGiaBan.Clear();
            btnDoiTrangThai.Text      = "CHỌN MÓN ĐỂ THAO TÁC";
            btnDoiTrangThai.BackColor = Color.Gray;
        }

        #endregion

        #region Sự kiện lưới — Tô màu & chọn dòng

        // Tô màu xám/nghiêng cho món "Ngừng bán", giữ nguyên cho "Còn bán"
        private void DgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSanPham.Rows[e.RowIndex].DataBoundItem is SanPhamView sp)
            {
                if (sp.TrangThai == "Ngừng bán")
                {
                    e.CellStyle.ForeColor = Color.Gray;
                    e.CellStyle.Font      = new Font(dgvSanPham.Font, FontStyle.Italic);
                    e.CellStyle.BackColor = Color.WhiteSmoke;
                }
                else e.CellStyle.ForeColor = Color.Black;
            }
        }

        // Click dòng lưới → nạp thông tin SP, cập nhật text nút Ngừng/Mở lại
        private void DgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row          = dgvSanPham.Rows[e.RowIndex];
            _maSPDangChon    = Convert.ToInt32(row.Cells["MaSP"].Value); // Dùng cột ẩn MaSP

            txtTenSP.Text    = row.Cells["TenSP"].Value?.ToString();
            txtLoai.Text     = row.Cells["LoaiSP"].Value?.ToString();
            txtGiaBan.Text   = Convert.ToDecimal(row.Cells["DonGia"].Value ?? 0).ToString("N0");

            bool dangNgung = row.Cells["TrangThai"].Value?.ToString() == "Ngừng bán";
            btnDoiTrangThai.Text      = dangNgung ? "✅ BÁN TRỞ LẠI" : "🛑 BÁO NGƯNG BÁN";
            btnDoiTrangThai.BackColor = dangNgung ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69);
        }

        #endregion

        #region Sự kiện tìm kiếm & lọc

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)    => ThucThiLocDuLieu();
        private void CboLocLoai_SelectedIndexChanged(object sender, EventArgs e) => ThucThiLocDuLieu();

        #endregion

        #region Sự kiện thao tác — Ngừng bán / Bán trở lại

        // Hỏi xác nhận → gọi service tương ứng → reload danh sách
        private void BtnDoiTrangThai_Click(object sender, EventArgs e)
        {
            if (_maSPDangChon == -1) { MessageBox.Show("Vui lòng click chọn một món trên danh sách để thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            string hanhDong = btnDoiTrangThai.Text == "🛑 BÁO NGƯNG BÁN" ? "Ngừng Bán" : "Bán Trở Lại";
            string msg      = $"Bạn có chắc chắn muốn chuyển món [{txtTenSP.Text}] sang trạng thái {hanhDong} không?";

            if (MessageBox.Show(msg, "Xác nhận thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool ok = hanhDong == "Ngừng Bán" ? _spService.BaoNgungBan(_maSPDangChon) : _spService.MoBanLai(_maSPDangChon);
                if (ok) LoadDanhSach();
            }
        }

        #endregion
    }
}