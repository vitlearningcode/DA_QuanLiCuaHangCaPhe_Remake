using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_NhanVien : UserControl
    {
        private readonly NhanVienService _service = new NhanVienService();
        private readonly TaiKhoanService _tkService = new TaiKhoanService();

        private int _maNVDangChon = -1;

        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            ThietLapLuoi();

            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new string[] { "Chủ cửa hàng", "Quản lý", "Thu ngân", "Order", "Pha chế" });

            // Đổ danh sách Vai Trò từ DB của bro vào ComboBox
            var dsVaiTro = _tkService.LayDanhSachVaiTro();
            cboQuyen.DataSource = dsVaiTro;
            cboQuyen.DisplayMember = "TenVaiTro"; // Đổi thành tên cột của bro nếu trong DB viết khác (VD: TenVT)
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
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayVaoLam",
                HeaderText = "Ngày Vào Làm",
                DataPropertyName = "NgayVaoLam",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 120
            });
        }

        private void LoadDanhSach()
        {
            dgvNhanVien.DataSource = _service.LayDanhSachNhanVien();
        }

        private void ResetForm()
        {
            _maNVDangChon = -1;

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
                _maNVDangChon = Convert.ToInt32(row.Cells["MaNv"].Value);

                txtTenNV.Text = row.Cells["TenNv"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                cboChucVu.Text = row.Cells["ChucVu"].Value?.ToString();

                if (row.Cells["NgayVaoLam"].Value is DateOnly ngayLam)
                {
                    dtpNgayVaoLam.Value = ngayLam.ToDateTime(TimeOnly.MinValue);
                }

                gb_ThongTinDangNhap.Enabled = true;
                LoadThongTinTaiKhoan(_maNVDangChon);

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void LoadThongTinTaiKhoan(int maNv)
        {
            var tk = _tkService.LayTaiKhoanTheoMaNV(maNv);
            if (tk != null)
            {
                txtUsername.Text = tk.TenDangNhap;
                txtUsername.ReadOnly = true;
                txtPassword.Text = "********";
                txtPassword.ReadOnly = true;
                cboQuyen.SelectedValue = tk.MaVaiTro; // Map đúng Value của VaiTro

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
            if (string.IsNullOrWhiteSpace(txtTenNV.Text) || string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và SĐT!", "Cảnh báo"); return;
            }

            NhanVien nv = new NhanVien
            {
                TenNv = txtTenNV.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                ChucVu = cboChucVu.Text,
                NgayVaoLam = DateOnly.FromDateTime(dtpNgayVaoLam.Value)
            };

            if (_service.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                LoadDanhSach();
                ResetForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maNVDangChon == -1) return;

            NhanVien nv = new NhanVien
            {
                MaNv = _maNVDangChon,
                TenNv = txtTenNV.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                ChucVu = cboChucVu.Text,
                NgayVaoLam = DateOnly.FromDateTime(dtpNgayVaoLam.Value)
            };

            if (_service.CapNhatNhanVien(nv))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                LoadDanhSach();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maNVDangChon == -1) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn cho nhân viên này nghỉ việc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string res = _service.XoaNhanVien(_maNVDangChon);
                MessageBox.Show(res, "Thông báo");
                LoadDanhSach();
                ResetForm();
            }
        }

        // ================= XỬ LÝ TÀI KHOẢN =================
        private void btnLuuTaiKhoan_Click(object sender, EventArgs e)
        {
            if (_maNVDangChon == -1) return;
            if (cboQuyen.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Quyền hạn!"); return; }

            int maVaiTro = Convert.ToInt32(cboQuyen.SelectedValue);
            string user = txtUsername.Text.Trim();

            if (btnLuuTaiKhoan.Text == "CẤP TÀI KHOẢN")
            {
                string pass = txtPassword.Text.Trim();
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Vui lòng nhập Username và Password để cấp mới!"); return;
                }

                // Khớp tham số: username, password, maNV, role
                if (_tkService.TaoTaiKhoan(user, pass, _maNVDangChon, maVaiTro))
                {
                    MessageBox.Show("Đã cấp tài khoản thành công!", "Thông báo");
                    LoadThongTinTaiKhoan(_maNVDangChon);
                }
            }
            else // CẬP NHẬT QUYỀN
            {
                // Khớp tham số: username, password (để trống vì không đổi), role
                if (_tkService.SuaTaiKhoan(user, "", maVaiTro))
                {
                    MessageBox.Show("Cập nhật quyền hạn thành công!", "Thông báo");
                }
            }
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (_maNVDangChon == -1) return;
            string user = txtUsername.Text.Trim();

            if (MessageBox.Show("Đặt lại mật khẩu của nhân viên này về mặc định là '1'?", "Xác nhận Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Khớp tham số: username
                if (_tkService.ResetMatKhau(user))
                {
                    MessageBox.Show("Reset mật khẩu thành công! Hãy báo nhân viên đăng nhập bằng mật khẩu '1'.", "Thông báo");
                }
            }
        }
    }
}