using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_KhachHang : UserControl
    {
        private readonly KhachHangService _service = new KhachHangService();
        private int _selectedMaKH = 0;

        public UC_KhachHang()
        {
            InitializeComponent();
        }

        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            cboLoaiKH.SelectedIndex = 0;            
            LoadData();
        }

        private void LoadData(string keyword = "")
        {
            dgvKhachHang.DataSource = _service.LayDanhSachKhachHang(keyword);

            if (dgvKhachHang.Columns.Count > 0)
            {
                dgvKhachHang.Columns["MaKh"].Visible = false;
                dgvKhachHang.Columns["DonHangs"].Visible = false;
                dgvKhachHang.Columns["DiaChi"].Visible = false;
                dgvKhachHang.Columns["TenKh"].HeaderText = "Tên Khách Hàng";
                dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                dgvKhachHang.Columns["DiemTichLuy"].HeaderText = "Điểm Tích Lũy";
                dgvKhachHang.Columns["LoaiKh"].HeaderText = "Loại Khách";
            }
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaKH == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!"); return;
            }

            int diem = int.Parse(txtDiem.Text);
            try
            {
                if (_service.SuaKhachHang(_selectedMaKH, txtTenKH.Text.Trim(), txtSDT.Text.Trim(), diem, cboLoaiKH.Text))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData(txtTimKiem.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _selectedMaKH = 0;
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiem.Text = "0";
            cboLoaiKH.SelectedIndex = 0;
            txtTimKiem.Clear();
            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvKhachHang.Rows[e.RowIndex];
                _selectedMaKH = (int)row.Cells["MaKh"].Value;
                txtTenKH.Text = row.Cells["TenKh"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtDiem.Text = row.Cells["DiemTichLuy"].Value.ToString();
                cboLoaiKH.Text = row.Cells["LoaiKh"].Value.ToString();
            }
        }

        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhachHang.Columns[e.ColumnIndex].Name == "LoaiKh" && e.Value != null)
            {
                if (e.Value.ToString() == "VIP")
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                    e.CellStyle.Font = new Font(dgvKhachHang.Font, FontStyle.Bold);
                }
            }
        }
    }
}