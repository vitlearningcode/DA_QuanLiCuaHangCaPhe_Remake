using System;
using System.Drawing;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic; // IMPORT CORE LOGIC
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_NhanVien : UserControl
    {
        // 1. GỌI CORE LOGIC CHO CÁC VIỆC CHUNG (Thêm, Sửa, Lấy List)
        private readonly CoreLogic_NhanVien _coreLogic = new CoreLogic_NhanVien();

        // 2. GỌI SERVICE ADMIN CHO ĐẶC QUYỀN RIÊNG (Xóa NV, Cấp Tài Khoản)
        private readonly NhanVienService _nvAdminService = new NhanVienService();
        private readonly TaiKhoanService _tkService = new TaiKhoanService();

        // FIX LỖI: Chuyển int thành string
        private string _maNVDangChon = "";

        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            ThietLapLuoi();

            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new string[] { "Quản lý", "Thu ngân", "Order", "Pha chế", "Bảo vệ" });

            var dsVaiTro = _tkService.LayDanhSachVaiTro();
            cboQuyen.DataSource = dsVaiTro;
            cboQuyen.DisplayMember = "TenVaiTro";
            cboQuyen.ValueMember = "MaVaiTro";

            LoadDanhSach();
            ResetForm();
        }

        private void ThietLapLuoi()
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Clear();

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNv", DataPropertyName = "MaNv", Visible = false });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNv", HeaderText = "Họ Tên", DataPropertyName = "TenNv" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai", HeaderText = "SĐT", DataPropertyName = "SoDienThoai", Width = 120 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "ChucVu", HeaderText = "Chức Vụ", DataPropertyName = "ChucVu", Width = 150 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayVaoLam", HeaderText = "Ngày Vào Làm", DataPropertyName = "NgayVaoLam", Width = 150 });
        }

        private void LoadDanhSach()
        {
            // DÙNG CORE LOGIC lấy danh sách
            dgvNhanVien.DataSource = _coreLogic.LayDanhSachNhanVienDayDu();
        }

        private void ResetForm()
        {
            _maNVDangChon = ""; // Reset string rỗng

            txtTenNV.Clear();
            txtSDT.Clear();
            cboChucVu.SelectedIndex = -1;
            dtpNgayVaoLam.Value = DateTime.Now;

            txtUsername.Clear();
            txtPassword.Clear();
            cboQuyen.SelectedIndex = -1;
            gb_ThongTinDangNhap.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvNhanVien.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ResetForm();

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // FIX LỖI: Lấy mã NV kiểu string
                _maNVDangChon = row.Cells["MaNv"].Value.ToString();

                txtTenNV.Text = row.Cells["TenNv"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                cboChucVu.Text = row.Cells["ChucVu"].Value?.ToString();

                gb_ThongTinDangNhap.Enabled = true;
                LoadThongTinTaiKhoan(_maNVDangChon); // Truyền string

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void LoadThongTinTaiKhoan(string maNv)
        {
            var tk = _tkService.LayTaiKhoanTheoMaNV(maNv);
            if (tk != null)
            {
                txtUsername.Text = tk.TenDangNhap;
                txtUsername.ReadOnly = true;
                txtPassword.Text = "********";
                txtPassword.ReadOnly = true;
                cboQuyen.SelectedValue = tk.MaVaiTro;

                btnLuuTaiKhoan.Text = "CẬP NHẬT QUYỀN";
                btnResetMatKhau.Enabled = true;
            }
            else
            {
                txtUsername.Clear();
                txtUsername.ReadOnly = false;
                txtPassword.Clear();
                txtPassword.ReadOnly = false;
                cboQuyen.SelectedIndex = -1;

                btnLuuTaiKhoan.Text = "CẤP TÀI KHOẢN";
                btnResetMatKhau.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text)) { MessageBox.Show("Vui lòng nhập Tên!", "Cảnh báo"); return; }

            NhanVien nv = new NhanVien
            {
                MaNv = _coreLogic.SinhMaNhanVienTuDong(), // ỨNG DỤNG CORE LOGIC SINH MÃ (NV26001)
                TenNv = txtTenNV.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                ChucVu = cboChucVu.Text,
                NgayVaoLam = DateOnly.FromDateTime(dtpNgayVaoLam.Value),
                TrangThai = "Đang làm việc"
            };

            if (_coreLogic.ThemNhanVien(nv))
            { // GỌI CORE LOGIC
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                LoadDanhSach();
                ResetForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNVDangChon)) return;

            NhanVien nv = new NhanVien
            {
                MaNv = _maNVDangChon,
                TenNv = txtTenNV.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                ChucVu = cboChucVu.Text
                // Bỏ qua ngày vào làm vì thường không sửa ngày này
            };

            if (_coreLogic.CapNhatNhanVien(nv))
            { // GỌI CORE LOGIC
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                LoadDanhSach();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNVDangChon)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn cho nhân viên này nghỉ việc và xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // ĐẶC QUYỀN ADMIN: GỌI SERVICE ADMIN
                string res = _nvAdminService.XoaNhanVien(_maNVDangChon);
                MessageBox.Show(res, "Thông báo");
                LoadDanhSach();
                ResetForm();
            }
        }

        // ================= XỬ LÝ TÀI KHOẢN =================
        private void btnLuuTaiKhoan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNVDangChon)) return;
            if (cboQuyen.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Quyền!"); return; }

            int maVaiTro = Convert.ToInt32(cboQuyen.SelectedValue);
            string user = txtUsername.Text.Trim();

            if (btnLuuTaiKhoan.Text == "CẤP TÀI KHOẢN")
            {
                string pass = txtPassword.Text.Trim();
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Nhập Username và Password!"); return;
                }

                if (_tkService.TaoTaiKhoan(user, pass, _maNVDangChon, maVaiTro))
                {
                    MessageBox.Show("Cấp tài khoản thành công!", "Thông báo");
                    LoadThongTinTaiKhoan(_maNVDangChon);
                }
            }
            else
            {
                if (_tkService.SuaTaiKhoan(user, "", maVaiTro))
                {
                    MessageBox.Show("Cập nhật quyền thành công!", "Thông báo");
                }
            }
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNVDangChon)) return;
            string user = txtUsername.Text.Trim();

            if (MessageBox.Show("Reset mật khẩu về '1'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_tkService.ResetMatKhau(user))
                {
                    MessageBox.Show("Reset mật khẩu thành công!", "Thông báo");
                }
            }
        }
    }
}