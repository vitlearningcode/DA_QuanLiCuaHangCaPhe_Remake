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
        private readonly SanPhamService _service = new SanPhamService();
        private List<CongThucHienThi> _listCongThucTam = new List<CongThucHienThi>();
        private int _maMonDangChon = 0;

        // --- 2 Biến cờ hiệu bảo vệ dữ liệu ---
        private bool _coThayDoiChuaLuu = false;
        private bool _dangTaiDuLieu = false;

        public UC_SanPham()
        {
            InitializeComponent();
            DangKySuKien();
        }

        private void DangKySuKien()
        {
            this.Load += UC_SanPham_Load;
            this.btnTaoMonMoi.Click += BtnTaoMonMoi_Click;
            this.btnThemNL.Click += BtnThemNL_Click;
            this.btnXoaNL.Click += BtnXoaNL_Click;
            this.btnLuu.Click += BtnLuu_Click;

            this.dgvCongThuc.SelectionChanged += DgvCongThuc_SelectionChanged;
            this.dgvCongThuc.CellClick += DgvCongThuc_CellClick;
            this.dgvCongThuc.CellDoubleClick += DgvCongThuc_CellDoubleClick;
            this.txtTimKiem.TextChanged += TxtTimKiem_TextChanged;

            // Đăng ký bắt sự kiện khi người dùng thay đổi dữ liệu trên Form
            this.txtTenMon.TextChanged += DanhDauThayDoi;
            this.txtGiaBan.TextChanged += DanhDauThayDoi;
            this.cboLoai.TextChanged += DanhDauThayDoi;
            this.cboTrangThai.SelectedIndexChanged += DanhDauThayDoi;
        }

        // Hàm này tự động bật cờ cảnh báo nếu người dùng tác động vào form
        private void DanhDauThayDoi(object sender, EventArgs e)
        {
            if (!_dangTaiDuLieu) _coThayDoiChuaLuu = true;
        }

        // ================= HÀM BẢO VỆ DỮ LIỆU (DIRTY CHECK) =================
        private bool KiemTraVaLuuThayDoi()
        {
            if (!_coThayDoiChuaLuu) return true; // Form sạch, cho phép đi tiếp

            var rs = MessageBox.Show("Bạn có thông tin thay đổi chưa được lưu. Bạn có muốn lưu lại trước khi chuyển sang món khác không?", "Cảnh báo chưa lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                return ThucHienLuuXuongDB(true); // Lưu, nếu thành công sẽ đi tiếp
            }
            else if (rs == DialogResult.Cancel)
            {
                return false; // Hủy bỏ, đứng im tại form hiện tại
            }

            return true; // Người dùng chọn No -> Mặc kệ thay đổi, đi tiếp
        }
        // ====================================================================

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            ThietLapLuoi();
            TaiDanhSachLoaiVaTrangThai();
            TaiNguyenLieuVaoComboBox();
            TaiDanhSachMonBenTrai();
            LamMoiGiaoDien();
        }

        private void ThietLapLuoi()
        {
            dgvCongThuc.AutoGenerateColumns = false;
            dgvCongThuc.Columns.Clear();

            dgvCongThuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNL", DataPropertyName = "MaNL", Visible = false });
            dgvCongThuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNL", HeaderText = "Tên Nguyên Liệu", DataPropertyName = "TenNL" });
            dgvCongThuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuong", HeaderText = "Định Lượng", DataPropertyName = "SoLuong", Width = 150 });
            dgvCongThuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "DonViTinh", HeaderText = "ĐVT Kho", DataPropertyName = "DonViTinh", Width = 150 });
        }

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

        private void TaiNguyenLieuVaoComboBox()
        {
            var dsNL = _service.LayDanhSachNguyenLieu();
            cboNguyenLieu.DataSource = dsNL;
            cboNguyenLieu.DisplayMember = "TenNl";
            cboNguyenLieu.ValueMember = "MaNl";
            cboNguyenLieu.SelectedIndex = -1;
        }

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
                    Text = $"{mon.TenSp}\n\n{Convert.ToDecimal(mon.DonGia).ToString("N0")}đ",
                    Width = 331,
                    Height = 254,
                    Tag = mon,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = mon.TrangThai == "Ngừng kinh doanh" ? Color.LightGray : Color.WhiteSmoke,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                btnMon.FlatAppearance.BorderColor = Color.Gainsboro;
                btnMon.FlatAppearance.BorderSize = 1;

                btnMon.Click += (s, ev) =>
                {
                    // 1. Kiểm tra lưu trước khi load món mới
                    if (!KiemTraVaLuuThayDoi()) return;

                    // 2. Bắt đầu Load dữ liệu (Khóa cờ)
                    _dangTaiDuLieu = true;

                    _maMonDangChon = mon.MaSp;
                    txtTenMon.Text = mon.TenSp;
                    cboLoai.Text = mon.LoaiSp;
                    txtGiaBan.Text = mon.DonGia.ToString("N0");
                    cboTrangThai.Text = mon.TrangThai ?? "Còn bán";

                    _listCongThucTam = _service.LayCongThucTheoMon(mon.MaSp);
                    HienThiLuoiCongThuc();

                    btnLuu.Text = "CẬP NHẬT SẢN PHẨM";
                    btnLuu.BackColor = Color.Orange;

                    // 3. Kết thúc Load (Mở cờ & Reset thay đổi)
                    _dangTaiDuLieu = false;
                    _coThayDoiChuaLuu = false;
                };

                flpDanhSachMon.Controls.Add(btnMon);
            }
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TaiDanhSachMonBenTrai(txtTimKiem.Text.Trim());
        }

        private void LamMoiGiaoDien()
        {
            _dangTaiDuLieu = true;

            _maMonDangChon = 0;
            txtTenMon.Clear();
            txtGiaBan.Clear();
            cboLoai.Text = "";
            cboTrangThai.SelectedIndex = 0;

            cboNguyenLieu.SelectedIndex = -1;
            txtSoLuongNL.Clear();

            _listCongThucTam.Clear();
            HienThiLuoiCongThuc();
            btnXoaNL.Enabled = false;

            _dangTaiDuLieu = false;
            _coThayDoiChuaLuu = false; // Vừa làm mới xong thì coi như form sạch
        }

        private void HienThiLuoiCongThuc()
        {
            dgvCongThuc.DataSource = null;
            dgvCongThuc.DataSource = _listCongThucTam;
        }

        private void BtnTaoMonMoi_Click(object sender, EventArgs e)
        {
            // Nếu người dùng chủ động bấm nút Tạo Mới thì phải kiểm tra form cũ
            if (sender != null && !KiemTraVaLuuThayDoi()) return;

            LamMoiGiaoDien();
            btnLuu.Text = "LƯU SẢN PHẨM MỚI";
            btnLuu.BackColor = Color.DarkSlateBlue;
            txtTenMon.Focus();
        }

        // ================= XỬ LÝ NGUYÊN LIỆU =================
        private void DgvCongThuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvCongThuc.Rows[e.RowIndex];
                cboNguyenLieu.SelectedValue = Convert.ToInt32(row.Cells["MaNL"].Value);
                txtSoLuongNL.Text = Convert.ToDecimal(row.Cells["SoLuong"].Value).ToString("0.##");
            }
        }

        private void BtnThemNL_Click(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedItem == null || string.IsNullOrWhiteSpace(txtSoLuongNL.Text))
            {
                MessageBox.Show("Vui lòng chọn Nguyên liệu và nhập Số lượng hao hụt!", "Cảnh báo"); return;
            }

            if (!decimal.TryParse(txtSoLuongNL.Text, out decimal soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số lớn hơn 0!", "Cảnh báo"); return;
            }

            var nlDuocChon = (NguyenLieu)cboNguyenLieu.SelectedItem;
            var nguyenLieuDaCo = _listCongThucTam.FirstOrDefault(x => x.MaNL == nlDuocChon.MaNl);

            if (nguyenLieuDaCo != null) nguyenLieuDaCo.SoLuong = soLuong;
            else
            {
                _listCongThucTam.Add(new CongThucHienThi
                {
                    MaNL = nlDuocChon.MaNl,
                    TenNL = nlDuocChon.TenNl,
                    SoLuong = soLuong,
                    DonViTinh = nlDuocChon.DonViTinh
                });
            }

            HienThiLuoiCongThuc();
            txtSoLuongNL.Clear();
            if (!_dangTaiDuLieu) _coThayDoiChuaLuu = true; // Báo hiệu đã sửa công thức
        }

        private void DgvCongThuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenNL = _listCongThucTam[e.RowIndex].TenNL;
                if (MessageBox.Show($"Bỏ nguyên liệu '{tenNL}' khỏi công thức pha chế?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _listCongThucTam.RemoveAt(e.RowIndex);
                    HienThiLuoiCongThuc();
                    if (!_dangTaiDuLieu) _coThayDoiChuaLuu = true;

                    if (_listCongThucTam.Count == 0)
                    {
                        MessageBox.Show("Sản phẩm không còn nguyên liệu pha chế. Tự động chuyển sang 'Ngừng kinh doanh'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboTrangThai.Text = "Ngừng kinh doanh";
                    }
                }
            }
        }

        private void BtnXoaNL_Click(object sender, EventArgs e)
        {
            if (dgvCongThuc.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Xóa các nguyên liệu đang chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = dgvCongThuc.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        _listCongThucTam.RemoveAt(dgvCongThuc.SelectedRows[i].Index);
                    }
                    HienThiLuoiCongThuc();
                    if (!_dangTaiDuLieu) _coThayDoiChuaLuu = true;

                    if (_listCongThucTam.Count == 0)
                    {
                        MessageBox.Show("Sản phẩm không còn nguyên liệu pha chế. Tự động chuyển sang 'Ngừng kinh doanh'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboTrangThai.Text = "Ngừng kinh doanh";
                    }
                }
            }
        }

        private void DgvCongThuc_SelectionChanged(object sender, EventArgs e) => btnXoaNL.Enabled = dgvCongThuc.SelectedRows.Count > 0;

        // ================= LOGIC LƯU DB =================
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (ThucHienLuuXuongDB(true))
            {
                TaiDanhSachLoaiVaTrangThai();
                BtnTaoMonMoi_Click(null, null); // Lưu bằng nút thủ công xong thì reset form
            }
        }

        private bool ThucHienLuuXuongDB(bool hienThongBao)
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text))
            {
                MessageBox.Show("Tên món và Giá bán không được để trống!", "Cảnh báo"); return false;
            }

            if (!double.TryParse(txtGiaBan.Text, out double donGia) || donGia < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Cảnh báo"); return false;
            }

            if (cboTrangThai.Text == "Còn bán" && _listCongThucTam.Count == 0)
            {
                MessageBox.Show("Sản phẩm chưa có công thức pha chế! Phải thêm nguyên liệu hoặc chọn 'Ngừng kinh doanh'.", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SanPham sp = new SanPham
            {
                TenSp = txtTenMon.Text.Trim(),
                LoaiSp = cboLoai.Text.Trim(),
                DonGia = (decimal)donGia,
                TrangThai = cboTrangThai.Text
            };

            bool ketQua = _maMonDangChon == 0 ? _service.ThemMonMoi(sp, _listCongThucTam) : _service.CapNhatMon((sp.MaSp = _maMonDangChon) == _maMonDangChon ? sp : sp, _listCongThucTam);

            if (ketQua)
            {
                _coThayDoiChuaLuu = false; // Lưu xong thì cờ sạch
                if (hienThongBao) MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachMonBenTrai();
                return true;
            }

            MessageBox.Show("Có lỗi xảy ra khi lưu vào CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}