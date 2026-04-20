using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
// UI chỉ được phép giao tiếp với tầng Service của Quản Lý — không vượt rào sang Admin
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    public partial class UC_QL_NhanVienCaLam : UserControl
    {
        #region Khai báo service & biến trạng thái

        // Service nhân viên: lấy danh sách, thêm, sửa hồ sơ (phân quyền QuanLi)
        private readonly QuanLi_NhanVienService _nvService    = new QuanLi_NhanVienService();
        // Service ca làm: xếp ca, chốt lịch, tính lương dự kiến
        private readonly QuanLi_CaLamService    _caLamService = new QuanLi_CaLamService();

        // Trạng thái form: true = đang sửa, false = đang thêm mới
        private bool _isEditMode = false;

        // Cờ khóa để chống lag khi đang vẽ lại ma trận lịch làm
        private bool _isMatrixLoading = false;

        // Cache danh sách ca làm thực tế từ DB — dùng để map row <-> MaCa chính xác
        private List<CaLamViec> _danhSachCaLamThucTe;

        #endregion

        #region Khởi tạo & Load

        public UC_QL_NhanVienCaLam()
        {
            InitializeComponent();
            // Lưu ý: các sự kiện Click, TextChanged, Load... được gắn trong file Designer
        }

        // Load: thiết lập 2 tab (Hồ Sơ + Xếp Ca) và tải dữ liệu ban đầu
        private void UC_Load(object sender, EventArgs e)
        {
            // === Tab 1: Hồ Sơ Nhân Sự ===
            cboChucVu.Items.AddRange(new string[] { "Thu ngân", "Order", "Pha chế", "Bảo vệ", "Phục vụ" });
            ThietLapLuoi();
            LoadDanhSach();
            LamMoiForm();

            // === Tab 2: Xếp Ca ===
            ThietLapMaTranXepCa();
            _danhSachCaLamThucTe = _caLamService.LayDanhSachCaLamThucTe();

            // Nạp danh sách NV vào ComboBox chọn khi xếp ca
            cboNhanVienXepCa.DataSource    = _caLamService.LayDanhSachNhanVienDeXepCa();
            cboNhanVienXepCa.DisplayMember = "TenNv";
            cboNhanVienXepCa.ValueMember   = "MaNv";
        }

        #endregion

        #region Logic điều hướng Tab — Hồ Sơ / Xếp Ca

        // Toggle hiển thị 2 panel (pnlHoSo / pnlXepCa) và đổi màu nút tab đang chọn
        private void SwitchTab_Click(object sender, EventArgs e)
        {
            bool isHoSo = ((Button)sender).Name == "btnTabHoSo";

            btnTabHoSo.BackColor  = isHoSo ? Color.FromArgb(45, 64, 89) : Color.White;
            btnTabHoSo.ForeColor  = isHoSo ? Color.White : Color.DimGray;
            btnTabXepCa.BackColor = isHoSo ? Color.White : Color.FromArgb(45, 64, 89);
            btnTabXepCa.ForeColor = isHoSo ? Color.DimGray : Color.White;

            pnlHoSo.Visible  = isHoSo;
            pnlXepCa.Visible = !isHoSo;
        }

        #endregion

        #region Tab 1 — Hồ Sơ Nhân Sự (CRUD nhân viên mức Quản Lý)

        // Cấu hình cột lưới nhân viên
        private void ThietLapLuoi()
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNv",         HeaderText = "Mã NV",       DataPropertyName = "MaNv",         Width = 120 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNv",         HeaderText = "Họ Tên",      DataPropertyName = "TenNv" });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai",   HeaderText = "SĐT",        DataPropertyName = "SoDienThoai",  Width = 150 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "ChucVu",         HeaderText = "Vị trí",     DataPropertyName = "ChucVu",       Width = 150 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai",      HeaderText = "Trạng thái", DataPropertyName = "TrangThai",    Width = 150 });
        }

        // Tải danh sách nhân viên qua Service trung gian (không gọi thẳng DB)
        private void LoadDanhSach() => dgvNhanVien.DataSource = _nvService.LayDanhSachHienThi();

        // Reset form về trạng thái "Thêm mới" — tự động sinh mã NV mới
        private void LamMoiForm()
        {
            _isEditMode = false;
            txtTenNV.Clear();
            txtSDT.Clear();
            cboChucVu.SelectedIndex = -1;
            txtMaNV.Text            = _nvService.LayMaNhanVienMoi(); // Auto-gen mã NV mới
            btnThem.Enabled         = true;
            btnSua.Enabled          = false;
        }

        // Nút Làm Mới → reset form
        private void BtnLamMoi_Click(object sender, EventArgs e) => LamMoiForm();

        // Click dòng lưới → nạp thông tin NV vào form để sửa
        private void DgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row       = dgvNhanVien.Rows[e.RowIndex];
            txtMaNV.Text  = row.Cells["MaNv"].Value.ToString();
            txtTenNV.Text = row.Cells["TenNv"].Value?.ToString();
            txtSDT.Text   = row.Cells["SoDienThoai"].Value?.ToString();
            cboChucVu.Text= row.Cells["ChucVu"].Value?.ToString();

            _isEditMode       = true;
            btnThem.Enabled   = false;
            btnSua.Enabled    = true;
        }

        // THÊM nhân viên mới qua Service trung gian
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text)) { MessageBox.Show("Vui lòng nhập Tên Nhân Viên!", "Thông báo"); return; }

            NhanVien nv = new NhanVien
            {
                MaNv         = txtMaNV.Text,
                TenNv        = txtTenNV.Text.Trim(),
                SoDienThoai  = txtSDT.Text.Trim(),
                ChucVu       = cboChucVu.Text,
                NgayVaoLam   = DateOnly.FromDateTime(DateTime.Now),
                TrangThai    = "Đang làm việc"
            };

            if (_nvService.TaoMoiNhanSu(nv)) { MessageBox.Show("Thêm nhân sự mới thành công!", "Thành công"); LoadDanhSach(); LamMoiForm(); }
        }

        // SỬA hồ sơ nhân viên đang chọn
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (!_isEditMode) return;

            NhanVien nv = new NhanVien
            {
                MaNv        = txtMaNV.Text,
                TenNv       = txtTenNV.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                ChucVu      = cboChucVu.Text
            };

            if (_nvService.CapNhatHoSo(nv)) { MessageBox.Show("Cập nhật thông tin thành công!", "Thành công"); LoadDanhSach(); LamMoiForm(); }
        }

        #endregion

        #region Tab 2 — Ma trận xếp ca tuần

        // Thiết lập lưới ma trận lịch làm: cột CA LÀM + 7 ngày trong tuần
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

            // Cột đầu (tên ca) là read-only, màu nền xám nhạt
            dgvLichLam.Columns[0].ReadOnly                       = true;
            dgvLichLam.Columns[0].DefaultCellStyle.BackColor     = Color.FromArgb(240, 242, 245);
            dgvLichLam.Columns[0].DefaultCellStyle.ForeColor     = Color.Black;
        }

        // Tính ngày Thứ 2 đầu tuần của ngày bất kỳ
        private DateTime TinhNgayDauTuan(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-diff).Date;
        }

        // Sự kiện đổi NV hoặc tuần → vẽ lại ma trận (bỏ qua nếu đang loading)
        private void FilterLichLam_Changed(object sender, EventArgs e)
        {
            if (!_isMatrixLoading) LoadLichLenMaTran();
        }

        // Vẽ lịch làm của NV đang chọn trong tuần lên ma trận
        private void LoadLichLenMaTran()
        {
            if (cboNhanVienXepCa.SelectedValue == null || _danhSachCaLamThucTe == null) return;

            _isMatrixLoading = true;
            dgvLichLam.Rows.Clear();

            // Tạo dòng động dựa theo số ca thực tế trong DB (không hardcode Sáng/Chiều/Tối)
            foreach (var ca in _danhSachCaLamThucTe)
            {
                string caHienThi = $"{ca.TenCa.ToUpper()}\n({ca.GioBatDau:hh\\:mm} - {ca.GioKetThuc:hh\\:mm})";
                dgvLichLam.Rows.Add(caHienThi, "❌", "❌", "❌", "❌", "❌", "❌", "❌");
            }

            // Tô màu xám nhạt mặc định cho tất cả ô (❌ = chưa xếp ca)
            for (int r = 0; r < _danhSachCaLamThucTe.Count; r++)
                for (int c = 1; c <= 7; c++)
                    dgvLichLam.Rows[r].Cells[c].Style.ForeColor = Color.LightGray;

            // Tải lịch cũ đã chốt lên và tô xanh
            string maNV        = cboNhanVienXepCa.SelectedValue.ToString();
            DateTime dauTuan   = TinhNgayDauTuan(dtpTuan.Value);
            var lichCu         = _caLamService.KiemTraLichCu(maNV, dauTuan);

            if (lichCu != null)
            {
                foreach (var lich in lichCu)
                {
                    int rowIdx = _danhSachCaLamThucTe.FindIndex(c => c.MaCa == lich.MaCa);
                    int colIdx = lich.NgayLam.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)lich.NgayLam.DayOfWeek;

                    if (rowIdx >= 0)
                    {
                        dgvLichLam.Rows[rowIdx].Cells[colIdx].Value            = "✅ LÀM";
                        dgvLichLam.Rows[rowIdx].Cells[colIdx].Style.ForeColor  = Color.FromArgb(40, 167, 69);
                    }
                }
            }

            TinhTongTienDuKien();
            _isMatrixLoading = false;
        }

        // Click ô ma trận → toggle ❌ / ✅ LÀM và tính lại tổng lương dự kiến
        private void DgvLichLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            var cell = dgvLichLam.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value.ToString() == "❌")
            {
                cell.Value            = "✅ LÀM";
                cell.Style.ForeColor  = Color.FromArgb(40, 167, 69);
            }
            else
            {
                cell.Value            = "❌";
                cell.Style.ForeColor  = Color.LightGray;
            }

            dgvLichLam.ClearSelection();
            TinhTongTienDuKien();
        }

        // Cộng tổng lương dự kiến dựa vào số ô "✅ LÀM" × LuongTheoCa của từng ca
        private void TinhTongTienDuKien()
        {
            decimal tongTien = 0;
            for (int r = 0; r < _danhSachCaLamThucTe.Count; r++)
            {
                decimal luongCa = _danhSachCaLamThucTe[r].LuongTheoCa;
                for (int c = 1; c <= 7; c++)
                {
                    if (dgvLichLam.Rows[r].Cells[c].Value.ToString() == "✅ LÀM")
                        tongTien += luongCa;
                }
            }
            lblTongLuong.Text = $"Dự toán chi phí tuần: {tongTien:N0} VNĐ";
        }

        // Chốt lịch làm: thu thập các ô ✅ → lưu vào DB theo MaCa thực tế
        private void BtnLuuLich_Click(object sender, EventArgs e)
        {
            if (cboNhanVienXepCa.SelectedValue == null) return;

            string   maNV      = cboNhanVienXepCa.SelectedValue.ToString();
            DateTime dauTuan   = TinhNgayDauTuan(dtpTuan.Value);

            var danhSachCa  = new List<int>();
            var danhSachNgay= new List<DateTime>();

            for (int c = 1; c <= 7; c++)
            {
                DateTime ngayHienTai = dauTuan.AddDays(c - 1);
                for (int r = 0; r < _danhSachCaLamThucTe.Count; r++)
                {
                    if (dgvLichLam.Rows[r].Cells[c].Value.ToString() == "✅ LÀM")
                    {
                        danhSachCa.Add(_danhSachCaLamThucTe[r].MaCa); // MaCa chuẩn xác từ DB
                        danhSachNgay.Add(ngayHienTai);
                    }
                }
            }

            if (_caLamService.ChotLichLamViec(maNV, dauTuan, danhSachCa, danhSachNgay))
                MessageBox.Show("Chốt ca thành công! Hệ thống đã ghi nhận lịch làm việc.", "Thành công");
            else
                MessageBox.Show("Lỗi khi lưu dữ liệu!", "Cảnh báo");
        }

        #endregion
    }
}