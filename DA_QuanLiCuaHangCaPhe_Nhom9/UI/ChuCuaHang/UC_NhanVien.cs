using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_NhanVien : UserControl
    {
        private readonly NhanVienService _service = new NhanVienService();
        TaiKhoanService _tkService = new TaiKhoanService();
        private int _maNVDangChon = -1; // Lưu mã NV đang chọn để sửa

        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {// 1. Cập nhật danh sách chức vụ theo ý bạn (Thêm Order)
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new string[] {
                                                   "Chủ cửa hàng",
                                                   "Quản lý",
                                                   "Thu ngân",
                                                   "Order",        // <-- Mới thêm
                                                   "Phục vụ",      // <-- Có thể giữ hoặc bỏ
                                                   "Pha chế"       // <-- Thêm thoải mái sau này
                                                    });
            cboChucVu.SelectedIndex = -1;

            // 2. Load danh sách Quyền hạn (Giữ nguyên)
            cboQuyen.DataSource = _tkService.LayDanhSachVaiTro();
            cboQuyen.DisplayMember = "TenVaiTro";
            cboQuyen.ValueMember = "MaVaiTro";
            cboQuyen.SelectedIndex = -1;

            btnResetMatKhau.Enabled = false;
            TaiDanhSach();

        }

        // Hàm trả về Mã Vai Trò dựa trên Tên Chức Vụ
        private int GetMaVaiTroTuChucVu(string chucVu)
        {
            if (string.IsNullOrEmpty(chucVu)) return 3; // Mặc định là Nhân viên

            string s = chucVu.ToLower().Trim();

            if (s.Contains("chủ") || s.Contains("admin")) return 1; // 1: Chủ cửa hàng
            if (s.Contains("quản lý") || s.Contains("manager")) return 2; // 2: Quản lý

            // Còn lại (Thu ngân, Phục vụ, Pha chế...) đều về nhóm 3: Nhân viên
            return 3;
        }

        private void TaiDanhSach()
        {
            dgvNhanVien.DataSource = _service.LayDanhSachNhanVienDayDu();

            // Ẩn cột không cần thiết (Ví dụ: ICollection DonHangs...)
            // Entity Framework thường sinh ra các cột quan hệ ảo, nên ẩn chúng đi
            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
                if (col.Name.Contains("DonHangs") || col.Name.Contains("PhieuKhos") || col.Name == ("QuyenHan"))
                    col.Visible = false;


            // Đặt tên tiếng Việt
            if (dgvNhanVien.Columns["MaNv"] != null) dgvNhanVien.Columns["MaNv"].HeaderText = "Mã NV";
            if (dgvNhanVien.Columns["TenNv"] != null) dgvNhanVien.Columns["TenNv"].HeaderText = "Họ Tên";
            if (dgvNhanVien.Columns["SoDienThoai"] != null) dgvNhanVien.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (dgvNhanVien.Columns["ChucVu"] != null) dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ";
            if (dgvNhanVien.Columns["NgayVaoLam"] != null) dgvNhanVien.Columns["NgayVaoLam"].HeaderText = "Ngày Vào Làm";
            if (dgvNhanVien.Columns["TrangThai"] != null) dgvNhanVien.Columns["TrangThai"].HeaderText = "Trạng thái";

            //// Cột TTTK (Trạng thái tài khoản)
            //if (dgvNhanVien.Columns["TrangThaiTK"] != null)
            //{
            //    dgvNhanVien.Columns["TrangThaiTK"].HeaderText = "TTTK";
            //    dgvNhanVien.Columns["TrangThaiTK"].Visible = false; // Tạm ẩn cột trạng thái đi cho gọn, vì mình đã tô màu chữ rồi
            //}

            // 4. QUAN TRỌNG: Cấu hình cột Tài Khoản
            if (dgvNhanVien.Columns["TaiKhoan"] != null)
            {
                //dgvNhanVien.Columns["TaiKhoan"].Visible = true; // Đảm bảo nó hiện
                dgvNhanVien.Columns["TaiKhoan"].HeaderText = "Tài Khoản (User)";
            }
        }




        // Bấm vào lưới đổ dữ liệu lên ô nhập
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNhanVien.Rows[e.RowIndex];
                _maNVDangChon = Convert.ToInt32(row.Cells["MaNv"].Value);

                // --- Load thông tin nhân viên
                string chucVuHienTai = row.Cells["ChucVu"].Value?.ToString(); // Lấy chức vụ
                txtTenNV.Text = row.Cells["TenNv"].Value?.ToString();

                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                cboChucVu.Text = chucVuHienTai;

                if (row.Cells["NgayVaoLam"].Value != null)
                {
                    //dtpNgayVaoLam.Value = (DateTime)row.Cells["NgayVaoLam"].Value;
                    DateOnly ngayVao = (DateOnly)row.Cells["NgayVaoLam"].Value;

                    // Chuyển sang DateTime để gán vào DateTimePicker (Gán giờ là 00:00)
                    dtpNgayVaoLam.Value = ngayVao.ToDateTime(TimeOnly.MinValue);
                }

                // --- Load thông tin Tài Khoản
                string taiKhoan = row.Cells["TaiKhoan"].Value?.ToString();
                // int quyenHan = Convert.ToInt32(row.Cells["QuyenHan"].Value ?? 0);

                // Lấy Quyền Hạn từ cột ẨN (QuyenHan)
                int quyenHienTai = 0;
                if (dgvNhanVien.Columns.Contains("QuyenHan") && row.Cells["QuyenHan"].Value != null)
                {
                    quyenHienTai = Convert.ToInt32(row.Cells["QuyenHan"].Value);
                }

                if (taiKhoan == "NO ACCOUNT")
                {
                    // Chế độ: CẤP MỚI
                    gb_ThongTinDangNhap.Text = "Cấp Tài Khoản Mới";
                    txtUsername.Enabled = true;
                    txtUsername.Clear();
                    txtPassword.Enabled = true;
                    txtPassword.Clear();
                    txtPassword.PlaceholderText = " ";

                    cboQuyen.SelectedValue = GetMaVaiTroTuChucVu(chucVuHienTai);

                    btnLuuTaiKhoan.Text = "Cấp Tài Khoản";
                    btnResetMatKhau.Enabled = false;
                }
                else
                {
                    // Chế độ: ĐÃ CÓ (Chỉ cho xem hoặc đổi quyền)
                    gb_ThongTinDangNhap.Text = "Thông tin Tài Khoản";
                    txtUsername.Text = taiKhoan;
                    txtUsername.Enabled = false; // Không cho sửa tên đăng nhập
                    txtPassword.Clear();

                    if (row.Cells["QuyenHan"].Value != null)
                    {
                        cboQuyen.SelectedValue = Convert.ToInt32(row.Cells["QuyenHan"].Value);
                    }

                    cboQuyen.SelectedValue = quyenHienTai;

                    txtPassword.PlaceholderText = "Nhập để đổi MK"; // Gợi ý (nếu dùng .NET mới)
                    btnLuuTaiKhoan.Text = "Cập nhật MK/Quyền";
                    btnResetMatKhau.Enabled = true;
                }
                // Khóa nút Thêm, mở nút Sửa/Xóa
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        //Sự kiện CellFormatting(Để tô màu chữ "Chưa cấp" cho nổi bật)
        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TaiKhoan")
            {
                if (e.Value != null && e.Value.ToString().Contains("NO ACCOUNT"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.DeepSkyBlue;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
        }

        private void btnLuuTaiKhoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn nhân viên chưa
            if (_maNVDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cấp/sửa tài khoản!");
                return;
            }

            if (cboQuyen.SelectedValue == null) { MessageBox.Show("Chưa chọn quyền!"); return; }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            int role = (int)cboQuyen.SelectedValue;

            //// Kiểm tra xem có chọn quyền chưa
            //if (cboQuyen.SelectedValue == null)
            //{
            //    MessageBox.Show("Vui lòng chọn quyền hạn!");
            //    return;
            //}
            //int maVaiTro = (int)cboQuyen.SelectedValue;

            // --- TRƯỜNG HỢP 1: CẤP MỚI (Username đang mở) ---
            if (txtUsername.Enabled == true)
            {
                // Validate bắt buộc nhập đủ
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu!");
                    return;
                }

                // Gọi hàm Tạo
                if (_tkService.TaoTaiKhoan(username, password, _maNVDangChon, role))
                {
                    MessageBox.Show("Cấp tài khoản thành công!");
                    TaiDanhSach(); // Load lại để cập nhật trạng thái trên lưới
                    ResetForm();   // Xóa trắng form
                }
                else
                {
                    MessageBox.Show("Lỗi: Tên đăng nhập đã tồn tại hoặc có lỗi hệ thống!");
                }
            }
            // --- TRƯỜNG HỢP 2: CẬP NHẬT (Username đang khóa) ---
            else
            {
                // Gọi hàm Sửa
                if (_tkService.SuaTaiKhoan(username, password, role))
                {
                    string msg = string.IsNullOrEmpty(password)
                        ? "Cập nhật quyền hạn thành công!"
                        : "Cập nhật quyền và mật khẩu thành công!";

                    MessageBox.Show(msg);
                    TaiDanhSach();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy tài khoản để sửa!");
                }
            }
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text)) { MessageBox.Show("Chưa nhập tên!"); return; }

            var nv = new NhanVien
            {
                TenNv = txtTenNV.Text,
                SoDienThoai = txtSDT.Text,
                ChucVu = cboChucVu.Text,
                NgayVaoLam = DateOnly.FromDateTime(dtpNgayVaoLam.Value)
            };

            if (_service.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm thành công!");
                ResetForm();
            }
            else MessageBox.Show("Lỗi khi thêm!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maNVDangChon == -1) return;

            var nv = new NhanVien
            {
                MaNv = _maNVDangChon,
                TenNv = txtTenNV.Text,
                SoDienThoai = txtSDT.Text,
                ChucVu = cboChucVu.Text,
                NgayVaoLam = DateOnly.FromDateTime(dtpNgayVaoLam.Value)
            };

            if (_service.SuaNhanVien(nv))
            {
                MessageBox.Show("Sửa thành công!");
                ResetForm();
            }
            else MessageBox.Show("Lỗi khi sửa!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maNVDangChon == -1) return;
            if (MessageBox.Show("Xác nhận xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ketQua = _service.XoaNhanVien(_maNVDangChon);
                MessageBox.Show(ketQua);
                if (ketQua.Contains("thành công")) ResetForm();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ResetForm();

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
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            TaiDanhSach();
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đặt lại mật khẩu về '1'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _tkService.ResetMatKhau(txtUsername.Text);
                MessageBox.Show("Đã reset mật khẩu thành công!");
            }
        }
    }
}