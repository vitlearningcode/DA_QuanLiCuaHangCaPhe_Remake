using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_SanPham : UserControl
    {
        #region Khai báo service & biến trạng thái

        // Service CRUD sản phẩm, loại, công thức pha chế, nguyên liệu
        private readonly SanPhamService _service = new SanPhamService();

        // Danh sách công thức pha chế đang xây dựng trong RAM (chưa lưu DB)
        private List<CongThucHienThi> _listCongThucTam = new List<CongThucHienThi>();

        // Mã sản phẩm đang chọn (0 = chưa chọn = đang thêm mới)
        private int _maMonDangChon = 0;

        // Cờ bảo vệ dữ liệu: true = form có thay đổi chưa lưu
        private bool _coThayDoiChuaLuu = false;
        // Cờ khoá sự kiện "thay đổi": true = đang load dữ liệu nên không đếm là "dirty"
        private bool _dangTaiDuLieu    = false;

        #endregion

        #region Khởi tạo & Đăng ký sự kiện

        public UC_SanPham()
        {
            InitializeComponent();
            DangKySuKien();
        }

        // Đăng ký tất cả sự kiện tập trung một chỗ — dễ theo dõi luồng sự kiện
        private void DangKySuKien()
        {
            this.Load += UC_SanPham_Load;
            btnTaoMonMoi.Click         += BtnTaoMonMoi_Click;
            btnThemNL.Click            += BtnThemNL_Click;
            btnXoaNL.Click             += BtnXoaNL_Click;
            btnLuu.Click               += BtnLuu_Click;

            dgvCongThuc.SelectionChanged  += DgvCongThuc_SelectionChanged;
            dgvCongThuc.CellClick         += DgvCongThuc_CellClick;
            dgvCongThuc.CellDoubleClick   += DgvCongThuc_CellDoubleClick;
            txtTimKiem.TextChanged        += TxtTimKiem_TextChanged;

            // Theo dõi thay đổi trên form để đánh cờ "chưa lưu"
            txtTenMon.TextChanged                += DanhDauThayDoi;
            txtGiaBan.TextChanged                += DanhDauThayDoi;
            cboLoai.TextChanged                  += DanhDauThayDoi;
            cboTrangThai.SelectedIndexChanged    += DanhDauThayDoi;
        }

        // Gọi khi bất kỳ trường nào thay đổi — chỉ đánh cờ khi KHÔNG đang load dữ liệu
        private void DanhDauThayDoi(object sender, EventArgs e)
        {
            if (!_dangTaiDuLieu) _coThayDoiChuaLuu = true;
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            ThietLapLuoi();
            TaiDanhSachLoaiVaTrangThai();
            TaiNguyenLieuVaoComboBox();
            TaiDanhSachMonBenTrai();
            LamMoiGiaoDien();
        }

        #endregion

        #region Hàm nội bộ — Thiết lập lưới & tải dữ liệu

        // Cấu hình lưới công thức pha chế (ẩn mã, hiện tên/SL/ĐVT)
        private void ThietLapLuoi()
        {
            dgvCongThuc.AutoGenerateColumns = false;
            dgvCongThuc.Columns.Clear();
            dgvCongThuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNL",       DataPropertyName = "MaNL",    Visible = false });
            dgvCongThuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNL",      HeaderText = "Tên Nguyên Liệu", DataPropertyName = "TenNL" });
            dgvCongThuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuong",    HeaderText = "Định Lượng",    DataPropertyName = "SoLuong",   Width = 150 });
            dgvCongThuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "DonViTinh",  HeaderText = "ĐVT Kho",       DataPropertyName = "DonViTinh", Width = 150 });
        }

        // Nạp danh sách Loại sản phẩm (từ DB) và Trạng thái (hardcode) vào ComboBox
        private void TaiDanhSachLoaiVaTrangThai()
        {
            var dsLoai = _service.LayDanhSachLoaiMon();
            cboLoai.DataSource = null;
            cboLoai.Items.Clear();
            cboLoai.Items.AddRange(dsLoai.ToArray());

            if (cboTrangThai.Items.Count == 0)
                cboTrangThai.Items.AddRange(new object[] { "Còn bán", "Ngừng kinh doanh" });
            cboTrangThai.SelectedIndex = 0;
        }

        // Nạp danh sách nguyên liệu vào ComboBox chọn khi xây công thức
        private void TaiNguyenLieuVaoComboBox()
        {
            var dsNL = _service.LayDanhSachNguyenLieu();
            cboNguyenLieu.DataSource     = dsNL;
            cboNguyenLieu.DisplayMember  = "TenNl";
            cboNguyenLieu.ValueMember    = "MaNl";
            cboNguyenLieu.SelectedIndex  = -1;
        }

        // Tải danh sách sản phẩm thành các nút bấm bên trái (có lọc theo từ khóa)
        private void TaiDanhSachMonBenTrai(string tuKhoa = "")
        {
            flpDanhSachMon.Controls.Clear();
            var danhSachMon = _service.LayDanhSachMonAn();

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = tuKhoa.ToLower();
                danhSachMon = danhSachMon.Where(m =>
                    (m.TenSp != null && m.TenSp.ToLower().Contains(tuKhoa)) ||
                    (m.LoaiSp != null && m.LoaiSp.ToLower().Contains(tuKhoa))
                ).ToList();
            }

            foreach (var mon in danhSachMon)
            {
                Button btnMon = new Button
                {
                    Text      = $"{mon.TenSp}\n\n{Convert.ToDecimal(mon.DonGia):N0}đ",
                    Width     = 331, Height = 254,
                    Tag       = mon,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = mon.TrangThai == "Ngừng kinh doanh" ? Color.LightGray : Color.WhiteSmoke,
                    Font      = new Font("Segoe UI", 9, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                btnMon.FlatAppearance.BorderColor = Color.Gainsboro;
                btnMon.FlatAppearance.BorderSize  = 1;

                // Click vào nút món → load chi tiết và công thức vào form bên phải
                btnMon.Click += (s, ev) =>
                {
                    if (!KiemTraVaLuuThayDoi()) return; // Dirty check trước khi chuyển

                    _dangTaiDuLieu    = true;          // Khoá cờ để không trigger DanhDauThayDoi
                    _maMonDangChon    = mon.MaSp;
                    txtTenMon.Text    = mon.TenSp;
                    cboLoai.Text      = mon.LoaiSp;
                    txtGiaBan.Text    = mon.DonGia.ToString("N0");
                    cboTrangThai.Text = mon.TrangThai ?? "Còn bán";

                    _listCongThucTam  = _service.LayCongThucTheoMon(mon.MaSp);
                    HienThiLuoiCongThuc();

                    btnLuu.Text       = "CẬP NHẬT SẢN PHẨM";
                    btnLuu.BackColor  = Color.Orange;

                    _dangTaiDuLieu    = false;          // Mở khoá
                    _coThayDoiChuaLuu = false;          // Form vừa load xong = sạch
                };

                flpDanhSachMon.Controls.Add(btnMon);
            }
        }

        // Reset form bên phải về trạng thái "Thêm mới sản phẩm"
        private void LamMoiGiaoDien()
        {
            _dangTaiDuLieu         = true;

            _maMonDangChon         = 0;
            txtTenMon.Clear();
            txtGiaBan.Clear();
            cboLoai.Text           = "";
            cboTrangThai.SelectedIndex = 0;
            cboNguyenLieu.SelectedIndex = -1;
            txtSoLuongNL.Clear();

            _listCongThucTam.Clear();
            HienThiLuoiCongThuc();
            btnXoaNL.Enabled       = false;

            _dangTaiDuLieu         = false;
            _coThayDoiChuaLuu      = false; // Form sạch sau khi làm mới
        }

        // Refresh lưới công thức từ danh sách RAM
        private void HienThiLuoiCongThuc()
        {
            dgvCongThuc.DataSource = null;
            dgvCongThuc.DataSource = _listCongThucTam;
        }

        #endregion

        #region Hàm bảo vệ dữ liệu — Dirty Check

        // Nếu form có thay đổi chưa lưu → hỏi user muốn lưu không trước khi chuyển món
        private bool KiemTraVaLuuThayDoi()
        {
            if (!_coThayDoiChuaLuu) return true; // Form sạch, cho đi tiếp

            var result = MessageBox.Show(
                "Bạn có thông tin thay đổi chưa được lưu. Muốn lưu trước khi chuyển sang món khác?",
                "Cảnh báo chưa lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)    return ThucHienLuuXuongDB(true);  // Lưu → nếu thành công thì đi tiếp
            if (result == DialogResult.Cancel) return false;                      // Ở lại form hiện tại
            return true;                                                           // Bỏ qua thay đổi
        }

        #endregion

        #region Sự kiện tìm kiếm & Tạo mới

        private void TxtTimKiem_TextChanged(object sender, EventArgs e) => TaiDanhSachMonBenTrai(txtTimKiem.Text.Trim());

        // Tạo mới → dirty check form cũ → reset form
        private void BtnTaoMonMoi_Click(object sender, EventArgs e)
        {
            if (sender != null && !KiemTraVaLuuThayDoi()) return;
            LamMoiGiaoDien();
            btnLuu.Text      = "LƯU SẢN PHẨM MỚI";
            btnLuu.BackColor = Color.DarkSlateBlue;
            txtTenMon.Focus();
        }

        #endregion

        #region Sự kiện quản lý công thức pha chế — Nguyên liệu

        // Click vào dòng lưới công thức → nạp NL và SL vào ComboBox/TextBox để sửa
        private void DgvCongThuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvCongThuc.Rows[e.RowIndex];
            cboNguyenLieu.SelectedValue = Convert.ToInt32(row.Cells["MaNL"].Value);
            txtSoLuongNL.Text           = Convert.ToDecimal(row.Cells["SoLuong"].Value).ToString("0.##");
        }

        // Double-click → hỏi xác nhận xóa NL khỏi công thức
        private void DgvCongThuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string tenNL = _listCongThucTam[e.RowIndex].TenNL;
            if (MessageBox.Show($"Bỏ nguyên liệu '{tenNL}' khỏi công thức pha chế?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _listCongThucTam.RemoveAt(e.RowIndex);
                HienThiLuoiCongThuc();
                if (!_dangTaiDuLieu) _coThayDoiChuaLuu = true;
                KiemTraCongThucRong();
            }
        }

        // Chọn dòng → bật/tắt nút Xóa NL
        private void DgvCongThuc_SelectionChanged(object sender, EventArgs e) => btnXoaNL.Enabled = dgvCongThuc.SelectedRows.Count > 0;

        // THÊM NL vào công thức: validate → thêm mới hoặc cập nhật nếu đã có
        private void BtnThemNL_Click(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedItem == null || string.IsNullOrWhiteSpace(txtSoLuongNL.Text)) { MessageBox.Show("Vui lòng chọn Nguyên liệu và nhập Số lượng hao hụt!", "Cảnh báo"); return; }
            if (!decimal.TryParse(txtSoLuongNL.Text, out decimal soLuong) || soLuong <= 0) { MessageBox.Show("Số lượng phải là số lớn hơn 0!", "Cảnh báo"); return; }

            var nlChon = (NguyenLieu)cboNguyenLieu.SelectedItem;
            var existing = _listCongThucTam.FirstOrDefault(x => x.MaNL == nlChon.MaNl);

            if (existing != null) existing.SoLuong = soLuong; // Cập nhật SL nếu đã có
            else _listCongThucTam.Add(new CongThucHienThi { MaNL = nlChon.MaNl, TenNL = nlChon.TenNl, SoLuong = soLuong, DonViTinh = nlChon.DonViTinh });

            HienThiLuoiCongThuc();
            txtSoLuongNL.Clear();
            if (!_dangTaiDuLieu) _coThayDoiChuaLuu = true;
        }

        // XÓA NL đang chọn (multiselect) khỏi công thức
        private void BtnXoaNL_Click(object sender, EventArgs e)
        {
            if (dgvCongThuc.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Xóa các nguyên liệu đang chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = dgvCongThuc.SelectedRows.Count - 1; i >= 0; i--)
                    _listCongThucTam.RemoveAt(dgvCongThuc.SelectedRows[i].Index);

                HienThiLuoiCongThuc();
                if (!_dangTaiDuLieu) _coThayDoiChuaLuu = true;
                KiemTraCongThucRong();
            }
        }

        // Nếu công thức trống → tự động chuyển trạng thái sang "Ngừng kinh doanh"
        private void KiemTraCongThucRong()
        {
            if (_listCongThucTam.Count == 0)
            {
                MessageBox.Show("Sản phẩm không còn nguyên liệu pha chế. Tự động chuyển sang 'Ngừng kinh doanh'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Text = "Ngừng kinh doanh";
            }
        }

        #endregion

        #region Logic lưu sản phẩm xuống DB

        // Nút Lưu → thực hiện lưu → reset form
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (ThucHienLuuXuongDB(true))
            {
                TaiDanhSachLoaiVaTrangThai();
                BtnTaoMonMoi_Click(null, null); // Sau khi lưu thủ công → reset về "Tạo mới"
            }
        }

        // Validate → tạo object SanPham → gọi service Thêm hoặc Cập nhật
        private bool ThucHienLuuXuongDB(bool hienThongBao)
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text)) { MessageBox.Show("Tên món và Giá bán không được để trống!", "Cảnh báo"); return false; }
            if (!double.TryParse(txtGiaBan.Text, out double donGia) || donGia < 0) { MessageBox.Show("Giá bán không hợp lệ!", "Cảnh báo"); return false; }
            if (cboTrangThai.Text == "Còn bán" && _listCongThucTam.Count == 0) { MessageBox.Show("Sản phẩm chưa có công thức pha chế! Hãy thêm nguyên liệu hoặc chọn 'Ngừng kinh doanh'.", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            SanPham sp = new SanPham { TenSp = txtTenMon.Text.Trim(), LoaiSp = cboLoai.Text.Trim(), DonGia = (decimal)donGia, TrangThai = cboTrangThai.Text };

            bool ketQua = _maMonDangChon == 0
                ? _service.ThemMonMoi(sp, _listCongThucTam)                                       // Thêm mới
                : _service.CapNhatMon((sp.MaSp = _maMonDangChon) == _maMonDangChon ? sp : sp, _listCongThucTam); // Cập nhật

            if (ketQua)
            {
                _coThayDoiChuaLuu = false;
                if (hienThongBao) MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachMonBenTrai();
                return true;
            }

            MessageBox.Show("Có lỗi xảy ra khi lưu vào CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        #endregion
    }
}