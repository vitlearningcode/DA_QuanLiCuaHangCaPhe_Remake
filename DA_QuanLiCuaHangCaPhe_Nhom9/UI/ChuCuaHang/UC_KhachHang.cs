using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_KhachHang : UserControl
    {
        #region Khai báo service & biến trạng thái

        // Service CRUD khách hàng (thêm, sửa, xóa, tìm kiếm)
        private readonly KhachHangService _service = new KhachHangService();

        // Mã KH đang được chọn trên lưới (0 = chưa chọn)
        private int _selectedMaKH = 0;

        #endregion

        #region Khởi tạo & Load

        public UC_KhachHang()
        {
            InitializeComponent();
        }

        // Load: mặc định chọn loại KH = "Thường", tải danh sách lên lưới
        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            cboLoaiKH.SelectedIndex = 0; // Mặc định: Thường
            LoadData();
        }

        #endregion

        #region Hàm nội bộ — Tải & cấu hình lưới dữ liệu

        // Tải danh sách khách hàng (có lọc theo từ khóa tìm kiếm nếu có)
        // Ẩn các cột không cần thiết, Việt hóa tiêu đề cột, tô màu VIP
        private void LoadData(string keyword = "")
        {
            dgvKhachHang.DataSource = _service.LayDanhSachKhachHang(keyword);

            if (dgvKhachHang.Columns.Count > 0)
            {
                // Ẩn cột nội bộ
                dgvKhachHang.Columns["MaKh"].Visible      = false;
                dgvKhachHang.Columns["DonHangs"].Visible  = false;
                dgvKhachHang.Columns["DiaChi"].Visible    = false;

                // Việt hóa tiêu đề cột
                dgvKhachHang.Columns["TenKh"].HeaderText          = "Tên Khách Hàng";
                dgvKhachHang.Columns["SoDienThoai"].HeaderText    = "Số Điện Thoại";
                dgvKhachHang.Columns["DiemTichLuy"].HeaderText    = "Điểm Tích Lũy";
                dgvKhachHang.Columns["LoaiKh"].HeaderText         = "Loại Khách";
            }
        }

        #endregion

        #region Sự kiện lưới — Chọn dòng & tô màu VIP

        // Click vào dòng lưới → nạp thông tin KH vào form để sửa
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvKhachHang.Rows[e.RowIndex];
            _selectedMaKH  = (int)row.Cells["MaKh"].Value;
            txtTenKH.Text  = row.Cells["TenKh"].Value.ToString();
            txtSDT.Text    = row.Cells["SoDienThoai"].Value.ToString();
            txtDiem.Text   = row.Cells["DiemTichLuy"].Value.ToString();
            cboLoaiKH.Text = row.Cells["LoaiKh"].Value.ToString();
        }

        // Tô màu đỏ + in đậm cho khách hàng VIP
        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhachHang.Columns[e.ColumnIndex].Name == "LoaiKh" && e.Value?.ToString() == "VIP")
            {
                e.CellStyle.ForeColor = Color.OrangeRed;
                e.CellStyle.Font      = new Font(dgvKhachHang.Font, FontStyle.Bold);
            }
        }

        #endregion

        #region Sự kiện tìm kiếm

        // Tìm kiếm real-time khi người dùng gõ vào ô tìm kiếm
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }

        #endregion

        #region Sự kiện CRUD — Thêm / Sửa / Xóa / Làm mới

        // THÊM: Tạo mới khách hàng với tên và số điện thoại
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) || string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên và SĐT!");
                return;
            }

            try
            {
                if (_service.ThemKhachHang(txtTenKH.Text.Trim(), txtSDT.Text.Trim()))
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                    btnLamMoi_Click(null, null);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // SỬA: Cập nhật thông tin KH đang chọn (tên, SĐT, điểm, loại)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaKH == 0) { MessageBox.Show("Vui lòng chọn khách hàng cần sửa!"); return; }

            int diem = int.Parse(txtDiem.Text);
            try
            {
                if (_service.SuaKhachHang(_selectedMaKH, txtTenKH.Text.Trim(), txtSDT.Text.Trim(), diem, cboLoaiKH.Text))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData(txtTimKiem.Text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // XÓA: Hỏi xác nhận trước khi xóa vĩnh viễn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaKH == 0) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (_service.XoaKhachHang(_selectedMaKH))
                    {
                        MessageBox.Show("Đã xóa khách hàng!");
                        btnLamMoi_Click(null, null);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        // LÀM MỚI: Reset form và tải lại danh sách từ DB
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _selectedMaKH           = 0;
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiem.Text            = "0";
            cboLoaiKH.SelectedIndex = 0;
            txtTimKiem.Clear();
            LoadData();
        }

        #endregion
    }
}