using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
// UI CHỈ ĐƯỢC PHÉP GIAO TIẾP VỚI TẦNG SERVICE CỦA QUẢN LÝ (KHÔNG VƯỢT RÀO)
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    public partial class UC_QL_NhanVienCaLam : UserControl
    {
        // 1. Sử dụng các Service trung gian
        private readonly QuanLi_NhanVienService _nvService = new QuanLi_NhanVienService();
        private readonly QuanLi_CaLamService _caLamService = new QuanLi_CaLamService();

        private bool _isEditMode = false;
        private bool _isMatrixLoading = false; // Cờ khóa để chống giật lag khi đang vẽ ma trận

        // ✅ THÊM BIẾN NÀY LÀM BỘ NHỚ LƯU CA LÀM THẬT:
        private List<CaLamViec> _danhSachCaLamThucTe;

        public UC_QL_NhanVienCaLam()
        {
            InitializeComponent();
            // Lưu ý: Các sự kiện Click, TextChanged, Load... đã được nhúng trong file Designer.
        }

        // ================== HÀM KHỞI TẠO (LOAD) ==================
        private void UC_Load(object sender, EventArgs e)
        {
            // Setup Tab Hồ Sơ
            cboChucVu.Items.AddRange(new string[] { "Thu ngân", "Order", "Pha chế", "Bảo vệ", "Phục vụ" });
            ThietLapLuoi();
            LoadDanhSach();
            LamMoiForm();

            ThietLapMaTranXepCa();
            _danhSachCaLamThucTe = _caLamService.LayDanhSachCaLamThucTe();

            // Setup Tab Xếp ca
            cboNhanVienXepCa.DataSource = _caLamService.LayDanhSachNhanVienDeXepCa();
            cboNhanVienXepCa.DisplayMember = "TenNv";
            cboNhanVienXepCa.ValueMember = "MaNv";

            //LoadLichLenMaTran(); // Gọi lần đầu để vẽ lịch
        }

        // ================== LOGIC ĐIỀU HƯỚNG TAB ==================
        private void SwitchTab_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == "btnTabHoSo")
            {
                btnTabHoSo.BackColor = Color.FromArgb(45, 64, 89);
                btnTabHoSo.ForeColor = Color.White;
                btnTabXepCa.BackColor = Color.White;
                btnTabXepCa.ForeColor = Color.DimGray;
                pnlHoSo.Visible = true;
                pnlXepCa.Visible = false;
            }
            else
            {
                btnTabXepCa.BackColor = Color.FromArgb(45, 64, 89);
                btnTabXepCa.ForeColor = Color.White;
                btnTabHoSo.BackColor = Color.White;
                btnTabHoSo.ForeColor = Color.DimGray;
                pnlXepCa.Visible = true;
                pnlHoSo.Visible = false;
            }
        }

        // ================== TAB 1: HỒ SƠ NHÂN SỰ ==================
        private void ThietLapLuoi()
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNv", HeaderText = "Mã NV", DataPropertyName = "MaNv", Width = 120 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNv", HeaderText = "Họ Tên", DataPropertyName = "TenNv" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai", HeaderText = "SĐT", DataPropertyName = "SoDienThoai", Width = 150 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "ChucVu", HeaderText = "Vị trí", DataPropertyName = "ChucVu", Width = 150 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 150 });
        }

        private void LoadDanhSach()
        {
            // Gọi qua Service trung gian
            dgvNhanVien.DataSource = _nvService.LayDanhSachHienThi();
        }

        private void LamMoiForm()
        {
            _isEditMode = false;
            txtTenNV.Clear();
            txtSDT.Clear();
            cboChucVu.SelectedIndex = -1;

            // Gọi qua Service trung gian để lấy mã mới
            txtMaNV.Text = _nvService.LayMaNhanVienMoi();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        private void BtnLamMoi_Click(object sender, EventArgs e) => LamMoiForm();

        private void DgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNv"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNv"].Value?.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                cboChucVu.Text = row.Cells["ChucVu"].Value?.ToString();

                _isEditMode = true;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Nhân Viên!", "Thông báo");
                return;
            }

            NhanVien nv = new NhanVien
            {
                MaNv = txtMaNV.Text,
                TenNv = txtTenNV.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                ChucVu = cboChucVu.Text,
                NgayVaoLam = DateOnly.FromDateTime(DateTime.Now),
                TrangThai = "Đang làm việc"
            };

            // Gọi qua Service trung gian
            if (_nvService.TaoMoiNhanSu(nv))
            {
                MessageBox.Show("Thêm nhân sự mới thành công!", "Thành công");
                LoadDanhSach();
                LamMoiForm();
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (!_isEditMode) return;

            NhanVien nv = new NhanVien
            {
                MaNv = txtMaNV.Text,
                TenNv = txtTenNV.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                ChucVu = cboChucVu.Text
            };

            // Gọi qua Service trung gian
            if (_nvService.CapNhatHoSo(nv))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công");
                LoadDanhSach();
                LamMoiForm();
            }
        }


        // ================== TAB 2: MA TRẬN XẾP CA ==================
        private void ThietLapMaTranXepCa()
        {
            dgvLichLam.Columns.Clear();
            dgvLichLam.Columns.Add("CaLam", "CA LÀM");
            dgvLichLam.Columns.Add("T2", "Thứ 2");
            dgvLichLam.Columns.Add("T3", "Thứ 3");
            dgvLichLam.Columns.Add("T4", "Thứ 4");
            dgvLichLam.Columns.Add("T5", "Thứ 5");
            dgvLichLam.Columns.Add("T6", "Thứ 6");
            dgvLichLam.Columns.Add("T7", "Thứ 7");
            dgvLichLam.Columns.Add("CN", "Chủ Nhật");

            dgvLichLam.Columns[0].ReadOnly = true;
            dgvLichLam.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvLichLam.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
        }

        // Logic tự động lùi về ngày Thứ 2 đầu tuần
        private DateTime TinhNgayDauTuan(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void FilterLichLam_Changed(object sender, EventArgs e)
        {
            if (!_isMatrixLoading) LoadLichLenMaTran();
        }

        private void LoadLichLenMaTran()
        {
            if (cboNhanVienXepCa.SelectedValue == null || _danhSachCaLamThucTe == null) return;

            _isMatrixLoading = true;
            dgvLichLam.Rows.Clear();

            // Động đẻ ra dòng dựa theo số ca thực tế trong DB
            foreach (var ca in _danhSachCaLamThucTe)
            {
                string caHienThi = $"{ca.TenCa.ToUpper()}\n({ca.GioBatDau:hh\\:mm} - {ca.GioKetThuc:hh\\:mm})";
                dgvLichLam.Rows.Add(caHienThi, "❌", "❌", "❌", "❌", "❌", "❌", "❌");
            }

            // Đổi màu nền mặc định xám
            for (int row = 0; row < _danhSachCaLamThucTe.Count; row++)
                for (int col = 1; col <= 7; col++)
                    dgvLichLam.Rows[row].Cells[col].Style.ForeColor = Color.LightGray;

            // Load Lịch Cũ lên
            string maNV = cboNhanVienXepCa.SelectedValue.ToString();
            DateTime ngayDauTuan = TinhNgayDauTuan(dtpTuan.Value);
            var lichCu = _caLamService.KiemTraLichCu(maNV, ngayDauTuan);

            if (lichCu != null)
            {
                foreach (var lich in lichCu)
                {
                    // Tìm đúng dòng (RowIndex) dựa vào MaCa thật từ DB
                    int rowIndex = _danhSachCaLamThucTe.FindIndex(c => c.MaCa == lich.MaCa);
                    int colIndex = lich.NgayLam.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)lich.NgayLam.DayOfWeek;

                    if (rowIndex >= 0)
                    {
                        dgvLichLam.Rows[rowIndex].Cells[colIndex].Value = "✅ LÀM";
                        dgvLichLam.Rows[rowIndex].Cells[colIndex].Style.ForeColor = Color.FromArgb(40, 167, 69);
                    }
                }
            }

            TinhTongTienDuKien();
            _isMatrixLoading = false;
        }

        private void DgvLichLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
            {
                var cell = dgvLichLam.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value.ToString() == "❌")
                {
                    cell.Value = "✅ LÀM";
                    cell.Style.ForeColor = Color.FromArgb(40, 167, 69);
                }
                else
                {
                    cell.Value = "❌";
                    cell.Style.ForeColor = Color.LightGray;
                }
                dgvLichLam.ClearSelection();
                TinhTongTienDuKien();
            }
        }

        private void TinhTongTienDuKien()
        {
            decimal tongTien = 0;

            // Duyệt qua từng dòng ca làm
            for (int row = 0; row < _danhSachCaLamThucTe.Count; row++)
            {
                decimal luongCaNay = _danhSachCaLamThucTe[row].LuongTheoCa; // Tiền thật từ DB

                for (int col = 1; col <= 7; col++)
                {
                    if (dgvLichLam.Rows[row].Cells[col].Value.ToString() == "✅ LÀM")
                    {
                        tongTien += luongCaNay;
                    }
                }
            }
            lblTongLuong.Text = $"Dự toán chi phí tuần: {tongTien:N0} VNĐ";
        }

        private void BtnLuuLich_Click(object sender, EventArgs e)
        {
            if (cboNhanVienXepCa.SelectedValue == null) return;

            string maNV = cboNhanVienXepCa.SelectedValue.ToString();
            DateTime ngayDauTuan = TinhNgayDauTuan(dtpTuan.Value);

            List<int> danhSachCa = new List<int>();
            List<DateTime> danhSachNgay = new List<DateTime>();

            // Duyệt động để lấy mã ca thực tế lưu xuống DB
            for (int col = 1; col <= 7; col++)
            {
                DateTime ngayHienTai = ngayDauTuan.AddDays(col - 1);

                for (int row = 0; row < _danhSachCaLamThucTe.Count; row++)
                {
                    if (dgvLichLam.Rows[row].Cells[col].Value.ToString() == "✅ LÀM")
                    {
                        // Lấy MaCa chuẩn xác tương ứng với dòng đó
                        danhSachCa.Add(_danhSachCaLamThucTe[row].MaCa);
                        danhSachNgay.Add(ngayHienTai);
                    }
                }
            }

            if (_caLamService.ChotLichLamViec(maNV, ngayDauTuan, danhSachCa, danhSachNgay))
                MessageBox.Show("Chốt ca thành công! Hệ thống đã ghi nhận lịch làm việc.", "Thành công");
            else
                MessageBox.Show("Lỗi khi lưu dữ liệu!", "Cảnh báo");
        }
    }
}