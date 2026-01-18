using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_Kho : UserControl
    {
        private readonly KhoService _service = new KhoService();
        private int _maNLDangChon = -1; // Biến lưu ID nguyên liệu đang chọn để sửa/xóa

        public UC_Kho()
        {
            InitializeComponent();
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void UC_Kho_Load(object sender, EventArgs e)
        {
            TaiDanhSachKho();
        }

        private void TaiDanhSachKho()
        {
            var listNL = _service.LayDanhSachNguyenLieu();
            dgvNguyenLieu.DataSource = listNL;

            // Định dạng lưới cho đẹp
            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvNguyenLieu.Columns["MaNl"] != null) dgvNguyenLieu.Columns["MaNl"].Visible = false;
            if (dgvNguyenLieu.Columns["TrangThai"] != null) dgvNguyenLieu.Columns["TrangThai"].Visible = false;

            // Đặt tên cột tiếng Việt
            if (dgvNguyenLieu.Columns["TenNl"] != null) dgvNguyenLieu.Columns["TenNl"].HeaderText = "Tên Nguyên Liệu";
            if (dgvNguyenLieu.Columns["SoLuongTon"] != null) dgvNguyenLieu.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
            if (dgvNguyenLieu.Columns["DonViTinh"] != null) dgvNguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn Vị";
           
        }

        // --- TÍNH NĂNG 1: TÔ MÀU CẢNH BÁO SẮP HẾT HÀNG ---
        // (Bạn nhớ chọn dgvNguyenLieu -> Events -> CellFormatting để gắn hàm này)
        private void dgvNguyenLieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra cột "SoLuongTon"
            if (dgvNguyenLieu.Columns[e.ColumnIndex].Name == "SoLuongTon" && e.Value != null)
            {
                decimal tonKho;
                if (decimal.TryParse(e.Value.ToString(), out tonKho))
                {
                    if (tonKho < 5) // NGƯỠNG CẢNH BÁO: Dưới 5 là báo động
                    {
                        // Tô màu nền đỏ, chữ trắng cho cả dòng
                        dgvNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                        dgvNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        // --- TÍNH NĂNG 2: BẤM VÀO LƯỚI -> HIỆN LÊN Ô NHẬP ---
        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguyenLieu.Rows[e.RowIndex];

                // Lấy dữ liệu từ dòng chọn
                _maNLDangChon = Convert.ToInt32(row.Cells["MaNl"].Value);
                txtTenNL.Text = row.Cells["TenNl"].Value.ToString();
                txtDonVi.Text = row.Cells["DonViTinh"].Value.ToString();

                // Đổi trạng thái nút
                btnThemNL.Enabled = false; // Đang chọn sửa thì khóa nút thêm
                btnSuaNL.Enabled = true;
                btnXoaNL.Enabled = true;
            }
        }

        // Nút LÀM MỚI (Để hủy chọn và nhập mới)
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void ResetInput()
        {
            txtTenNL.Clear();
            txtDonVi.Clear();
            _maNLDangChon = -1;
            btnThemNL.Enabled = true;
            btnSuaNL.Enabled = false;
            btnXoaNL.Enabled = false;
            TaiDanhSachKho();
        }

        // --- CÁC NÚT THAO TÁC (CRUD) ---

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNL.Text)) return;

            decimal giaNhap = 0;
            decimal.TryParse(txtDonGia.Text, out giaNhap);

            if (_service.ThemNguyenLieu(txtTenNL.Text, txtDonVi.Text))
            {
                MessageBox.Show("Thêm mới thành công!");
                ResetInput();
            }
            else
            {
                MessageBox.Show("Lỗi: Tên nguyên liệu có thể đã tồn tại!");
            }
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            if (_maNLDangChon == -1) return;
                      
            _service.SuaNguyenLieu(_maNLDangChon, txtTenNL.Text, txtDonVi.Text);
            MessageBox.Show("Cập nhật thành công!");
            ResetInput();
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (_maNLDangChon == -1) return;

            if (MessageBox.Show("Bạn chắc chắn muốn xóa nguyên liệu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _service.XoaNguyenLieu(_maNLDangChon);
                MessageBox.Show("Đã xóa!");
                ResetInput();
            }
        }
    }
}