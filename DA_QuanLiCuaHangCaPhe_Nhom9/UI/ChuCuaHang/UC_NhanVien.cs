using System;
using System.Drawing;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_NhanVien : UserControl
    {
        #region Khai báo service & biến trạng thái

        // CoreLogic dùng chung: thêm/sửa/lấy danh sách (không cần quyền đặc biệt)
        private readonly CoreLogic_NhanVien _coreLogic = new CoreLogic_NhanVien();

        // Service Admin đặc quyền: xóa nhân viên, cấp tài khoản (chỉ Admin mới dùng được)
        private readonly NhanVienService    _nvAdminService = new NhanVienService();
        private readonly TaiKhoanService    _tkService      = new TaiKhoanService();

        // Mã nhân viên đang được chọn trên lưới (string NVARCHAR(20), ví dụ "NV001")
        private string _maNVDangChon = "";

        #endregion

        #region Khởi tạo & Load

        public UC_NhanVien()
        {
            InitializeComponent();
        }

        // Load: thiết lập lưới, nạp ComboBox chức vụ / quyền, tải danh sách và reset form
        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            ThietLapLuoi();

            // Nạp danh sách chức vụ cố định vào ComboBox
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new string[] { "Quản lý", "Thu ngân", "Order", "Pha chế", "Bảo vệ" });

            // Nạp danh sách vai trò từ DB vào ComboBox quyền (DisplayMember = TenVaiTro, ValueMember = MaVaiTro)
            var dsVaiTro = _tkService.LayDanhSachVaiTro();
            cboQuyen.DataSource     = dsVaiTro;
            cboQuyen.DisplayMember  = "TenVaiTro";
            cboQuyen.ValueMember    = "MaVaiTro";

            LoadDanhSach();
            ResetForm();
        }

        #endregion

        #region Hàm nội bộ — Thiết lập lưới & tải dữ liệu

        // Cấu hình DataGridView: ẩn cột mã, hiển thị tên / SĐT / chức vụ / ngày vào làm
        private void ThietLapLuoi()
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Clear();

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNv",         DataPropertyName = "MaNv",         Visible = false });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNv",         HeaderText = "Họ Tên",            DataPropertyName = "TenNv" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai",   HeaderText = "SĐT",              DataPropertyName = "SoDienThoai",  Width = 120 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "ChucVu",         HeaderText = "Chức Vụ",          DataPropertyName = "ChucVu",       Width = 150 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayVaoLam",     HeaderText = "Ngày Vào Làm",     DataPropertyName = "NgayVaoLam",   Width = 150 });
        }

        // Tải / làm mới danh sách nhân viên từ CoreLogic
        private void LoadDanhSach()
        {
            dgvNhanVien.DataSource = _coreLogic.LayDanhSachNhanVienDayDu();
        }

        // Load thông tin tài khoản của NV đang chọn (nếu có) vào group box bên dưới
        private void LoadThongTinTaiKhoan(string maNv)
        {
            var tk = _tkService.LayTaiKhoanTheoMaNV(maNv);
            if (tk != null)
            {
                // Đã có tài khoản → hiển thị và chỉ cho cập nhật quyền
                txtUsername.Text     = tk.TenDangNhap;
                txtUsername.ReadOnly = true;
                txtPassword.Text     = "********"; // Không hiển thị mật khẩu thật
                txtPassword.ReadOnly = true;
                cboQuyen.SelectedValue = tk.MaVaiTro;

                btnLuuTaiKhoan.Text     = "CẬP NHẬT QUYỀN";
                btnResetMatKhau.Enabled = true;
            }
            else
            {
                // Chưa có tài khoản → cho phép tạo mới
                txtUsername.Clear();
                txtUsername.ReadOnly = false;
                txtPassword.Clear();
                txtPassword.ReadOnly = false;
                cboQuyen.SelectedIndex = -1;

                btnLuuTaiKhoan.Text     = "CẤP TÀI KHOẢN";
                btnResetMatKhau.Enabled = false;
            }
        }

        // Reset toàn bộ form về trạng thái ban đầu (chưa chọn NV nào)
        private void ResetForm()
        {
            _maNVDangChon = "";

            txtTenNV.Clear();
            txtSDT.Clear();
            cboChucVu.SelectedIndex   = -1;
            dtpNgayVaoLam.Value       = DateTime.Now;

            txtUsername.Clear();
            txtPassword.Clear();
            cboQuyen.SelectedIndex    = -1;
            gb_ThongTinDangNhap.Enabled = false;

            // Trạng thái nút: chỉ Thêm được bật khi chưa chọn ai
            btnThem.Enabled = true;
            btnSua.Enabled  = false;
            btnXoa.Enabled  = false;

            dgvNhanVien.ClearSelection();
        }

        #endregion

        #region Sự kiện lưới — Chọn dòng để điền form

        // Khi click vào dòng lưới → nạp thông tin NV vào form để sửa/xóa
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

            // Lấy mã NV dạng string (NVARCHAR(20))
            _maNVDangChon    = row.Cells["MaNv"].Value.ToString();

            txtTenNV.Text    = row.Cells["TenNv"].Value?.ToString();
            txtSDT.Text      = row.Cells["SoDienThoai"].Value?.ToString();
            cboChucVu.Text   = row.Cells["ChucVu"].Value?.ToString();

            // Mở group box tài khoản và tải thông tin
            gb_ThongTinDangNhap.Enabled = true;
            LoadThongTinTaiKhoan(_maNVDangChon);

            // Khi đã chọn NV: chỉ Thêm bị tắt, Sửa/Xóa mở
            btnThem.Enabled = false;
            btnSua.Enabled  = true;
            btnXoa.Enabled  = true;
        }

        #endregion

        #region Sự kiện CRUD nhân viên — Thêm / Sửa / Xóa / Làm mới

        // Nút Làm Mới → reset form về trạng thái trống
        private void btnLamMoi_Click(object sender, EventArgs e) => ResetForm();

        // THÊM: Tạo NV mới với mã tự động (CoreLogic_NhanVien.SinhMaNhanVienTuDong)
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên!", "Cảnh báo");
                return;
            }

            NhanVien nv = new NhanVien
            {
                MaNv          = _coreLogic.SinhMaNhanVienTuDong(), // Sinh mã NV001 tự động
                TenNv         = txtTenNV.Text.Trim(),
                SoDienThoai   = txtSDT.Text.Trim(),
                ChucVu        = cboChucVu.Text,
                NgayVaoLam    = DateOnly.FromDateTime(dtpNgayVaoLam.Value),
                TrangThai     = "Đang làm việc"
            };

            if (_coreLogic.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                LoadDanhSach();
                ResetForm();
            }
        }

        // SỬA: Cập nhật thông tin NV đang chọn (không sửa ngày vào làm)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNVDangChon)) return;

            NhanVien nv = new NhanVien
            {
                MaNv         = _maNVDangChon,
                TenNv        = txtTenNV.Text.Trim(),
                SoDienThoai  = txtSDT.Text.Trim(),
                ChucVu       = cboChucVu.Text
            };

            if (_coreLogic.CapNhatNhanVien(nv))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                LoadDanhSach();
            }
        }

        // XÓA: Đặc quyền Admin — hỏi xác nhận trước khi xóa vĩnh viễn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNVDangChon)) return;

            if (MessageBox.Show(
                "Bạn có chắc chắn muốn cho nhân viên này nghỉ việc và xóa dữ liệu?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string ketQua = _nvAdminService.XoaNhanVien(_maNVDangChon); // Đặc quyền Admin
                MessageBox.Show(ketQua, "Thông báo");
                LoadDanhSach();
                ResetForm();
            }
        }

        #endregion

        #region Sự kiện quản lý tài khoản — Cấp / Cập nhật / Reset mật khẩu

        // CẤP HOẶC CẬP NHẬT TÀI KHOẢN tùy theo trạng thái của btnLuuTaiKhoan.Text
        private void btnLuuTaiKhoan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNVDangChon)) return;
            if (cboQuyen.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Quyền!"); return; }

            int    maVaiTro = Convert.ToInt32(cboQuyen.SelectedValue);
            string user     = txtUsername.Text.Trim();

            if (btnLuuTaiKhoan.Text == "CẤP TÀI KHOẢN")
            {
                // Tạo tài khoản mới: cần đủ username + password
                string pass = txtPassword.Text.Trim();
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Nhập Username và Password!"); return;
                }

                if (_tkService.TaoTaiKhoan(user, pass, _maNVDangChon, maVaiTro))
                {
                    MessageBox.Show("Cấp tài khoản thành công!", "Thông báo");
                    LoadThongTinTaiKhoan(_maNVDangChon); // Reload lại để chuyển sang chế độ CẬP NHẬT
                }
            }
            else
            {
                // Chỉ cập nhật quyền (không đổi password)
                if (_tkService.SuaTaiKhoan(user, "", maVaiTro))
                    MessageBox.Show("Cập nhật quyền thành công!", "Thông báo");
            }
        }

        // RESET MẬT KHẨU: Đặt về "1" (mật khẩu tạm thời mặc định)
        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNVDangChon)) return;

            string user = txtUsername.Text.Trim();
            if (MessageBox.Show("Reset mật khẩu về '1'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_tkService.ResetMatKhau(user))
                    MessageBox.Show("Reset mật khẩu thành công!", "Thông báo");
            }
        }

        #endregion
    }
}