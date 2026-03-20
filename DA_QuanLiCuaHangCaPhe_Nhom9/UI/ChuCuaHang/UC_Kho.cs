using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_Kho : UserControl
    {
        #region Setup
        // DÙNG ĐÚNG KHO SERVICE CỦA BẠN - KHÔNG THÊM CLASS LẠ
        private readonly KhoService _service = new KhoService();

        private int _maNLDangChon = -1;
        private List<NguyenLieu> _danhSachKhoGoc = new List<NguyenLieu>(); // Dùng Model NguyenLieu chuẩn của EF Core

        public UC_Kho()
        {
            InitializeComponent();
        }

        private void UC_Kho_Load(object sender, EventArgs e)
        {
            // Tab 1
            TaiDanhSachKho();

            // Tab 2 (Nhập hàng)
            ThietLapLuoiNhapHang();
            _danhSachKhoGoc = _service.LayDanhSachNguyenLieu(); // Load dữ liệu gốc bằng EF Core
            HienThiTatCaHangHoaLenPanel();
        }
        #endregion

        #region TAB 1: QUẢN LÝ DANH MỤC NGUYÊN LIỆU
        private void TaiDanhSachKho()
        {
            var listNL = _service.LayDanhSachNguyenLieu();
            dgvNguyenLieu.DataSource = listNL;

            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvNguyenLieu.Columns["MaNl"] != null) dgvNguyenLieu.Columns["MaNl"].Visible = false;
            if (dgvNguyenLieu.Columns["TrangThai"] != null) dgvNguyenLieu.Columns["TrangThai"].Visible = false;
            if (dgvNguyenLieu.Columns["ChiTietPhieuKhos"] != null) dgvNguyenLieu.Columns["ChiTietPhieuKhos"].Visible = false;
            if (dgvNguyenLieu.Columns["DinhLuongs"] != null) dgvNguyenLieu.Columns["DinhLuongs"].Visible = false;

            if (dgvNguyenLieu.Columns["TenNl"] != null) dgvNguyenLieu.Columns["TenNl"].HeaderText = "Tên Nguyên Liệu";
            if (dgvNguyenLieu.Columns["SoLuongTon"] != null) dgvNguyenLieu.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
            if (dgvNguyenLieu.Columns["DonViTinh"] != null) dgvNguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn Vị";

            cboNhaCungCap.DataSource = _service.LayDanhSachNhaCungCap();
            cboNhaCungCap.DisplayMember = "TenNcc";
            cboNhaCungCap.ValueMember = "MaNcc";
        }

        private void dgvNguyenLieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNguyenLieu.Columns[e.ColumnIndex].Name == "SoLuongTon" && e.Value != null)
            {
                decimal tonKho;
                if (decimal.TryParse(e.Value.ToString(), out tonKho) && tonKho < 5) // Cảnh báo dưới 5
                {
                    dgvNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                    dgvNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguyenLieu.Rows[e.RowIndex];
                _maNLDangChon = Convert.ToInt32(row.Cells["MaNl"].Value);
                txtTenNL.Text = row.Cells["TenNl"].Value?.ToString();
                txtDonVi.Text = row.Cells["DonViTinh"].Value?.ToString();

                btnThemNL.Enabled = false;
                btnSuaNL.Enabled = true;
                btnXoaNL.Enabled = true;
            }
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

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetInput(); }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNL.Text)) return;
            if (_service.ThemNguyenLieu(txtTenNL.Text, txtDonVi.Text))
            {
                MessageBox.Show("Thêm mới thành công!");
                ResetInput();

                // Cập nhật lại khung chọn nhanh bên tab Nhập hàng
                _danhSachKhoGoc = _service.LayDanhSachNguyenLieu();
                HienThiTatCaHangHoaLenPanel();
            }
            else MessageBox.Show("Lỗi: Tên nguyên liệu có thể đã tồn tại!");
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            if (_maNLDangChon == -1) return;
            _service.SuaNguyenLieu(_maNLDangChon, txtTenNL.Text, txtDonVi.Text);
            MessageBox.Show("Cập nhật thành công!");
            ResetInput();
            _danhSachKhoGoc = _service.LayDanhSachNguyenLieu();
            HienThiTatCaHangHoaLenPanel();
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (_maNLDangChon == -1) return;
            if (MessageBox.Show("Xóa nguyên liệu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _service.XoaNguyenLieu(_maNLDangChon);
                MessageBox.Show("Đã xóa!");
                ResetInput();
                _danhSachKhoGoc = _service.LayDanhSachNguyenLieu();
                HienThiTatCaHangHoaLenPanel();
            }
        }
        #endregion

        #region TAB 2: NHẬP HÀNG (Dùng EF Core Models)

        private void ThietLapLuoiNhapHang()
        {
            dgvChiTietNhap.Columns.Clear();
            dgvChiTietNhap.AllowUserToAddRows = false;
            dgvChiTietNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvChiTietNhap.Columns.Add("MaHang", "Mã Hàng");
            dgvChiTietNhap.Columns["MaHang"].Visible = false;

            dgvChiTietNhap.Columns.Add("TenHang", "Tên Hàng Hóa");
            dgvChiTietNhap.Columns["TenHang"].ReadOnly = true;

            dgvChiTietNhap.Columns.Add("DonVi", "Đơn Vị");
            dgvChiTietNhap.Columns["DonVi"].ReadOnly = true;

            dgvChiTietNhap.Columns.Add("SoLuong", "Số Lượng");
            dgvChiTietNhap.Columns["SoLuong"].DefaultCellStyle.Format = "N2";
            dgvChiTietNhap.Columns["SoLuong"].DefaultCellStyle.BackColor = Color.LightYellow;

            dgvChiTietNhap.Columns.Add("GiaNhap", "Giá Nhập");
            dgvChiTietNhap.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            dgvChiTietNhap.Columns["GiaNhap"].DefaultCellStyle.BackColor = Color.LightYellow;

            dgvChiTietNhap.Columns.Add("ThanhTien", "Thành Tiền");
            dgvChiTietNhap.Columns["ThanhTien"].ReadOnly = true;
            dgvChiTietNhap.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void HienThiTatCaHangHoaLenPanel()
        {
            flpDanhSachHangHoa.Controls.Clear();

            foreach (var item in _danhSachKhoGoc)
            {
                Button btn = new Button();
                btn.Text = $"{item.TenNl}\n({item.DonViTinh})";
                btn.Width = 110;
                btn.Height = 80;
                btn.BackColor = Color.WhiteSmoke;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.Tag = item; // Tag lúc này chứa object NguyenLieu của EF Core
                btn.Click += BtnHangHoa_Click;
                flpDanhSachHangHoa.Controls.Add(btn);
            }
        }

        private void BtnHangHoa_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            NguyenLieu monChon = (NguyenLieu)btn.Tag;

            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                if (row.Cells["MaHang"].Value.ToString() == monChon.MaNl.ToString())
                {
                    decimal slHienTai = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                    row.Cells["SoLuong"].Value = slHienTai + 1;
                    return;
                }
            }
            dgvChiTietNhap.Rows.Add(monChon.MaNl, monChon.TenNl, monChon.DonViTinh, 1, 0, 0);
        }

        private void dgvChiTietNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenCot = dgvChiTietNhap.Columns[e.ColumnIndex].Name;
                if (tenCot == "SoLuong" || tenCot == "GiaNhap")
                {
                    var row = dgvChiTietNhap.Rows[e.RowIndex];
                    decimal soLuong = 0, giaNhap = 0;

                    decimal.TryParse(row.Cells["SoLuong"].Value?.ToString(), out soLuong);
                    decimal.TryParse(row.Cells["GiaNhap"].Value?.ToString(), out giaNhap);

                    row.Cells["ThanhTien"].Value = soLuong * giaNhap;
                    TinhTongTienPhieu();
                }
            }
        }

        private void dgvChiTietNhap_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.IsCurrentCellDirty)
            {
                dgvChiTietNhap.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void TinhTongTienPhieu()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                decimal thanhTienDoi = 0;
                if (decimal.TryParse(row.Cells["ThanhTien"].Value?.ToString(), out thanhTienDoi))
                {
                    tongTien += thanhTienDoi;
                }
            }
            if (lblTongTien != null) lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";
        }

        private void dgvChiTietNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenMon = dgvChiTietNhap.Rows[e.RowIndex].Cells["TenHang"].Value.ToString();
                if (MessageBox.Show($"Xóa {tenMon} khỏi phiếu nhập?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvChiTietNhap.Rows.RemoveAt(e.RowIndex);
                    TinhTongTienPhieu();
                }
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu nhập đang trống!"); return;
            }

            List<ChiTietPhieuKho> listNhapThucTe = new List<ChiTietPhieuKho>();
            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                listNhapThucTe.Add(new ChiTietPhieuKho
                {
                    MaNl = Convert.ToInt32(row.Cells["MaHang"].Value),
                    SoLuong = Convert.ToDecimal(row.Cells["SoLuong"].Value),
                    GiaNhap = Convert.ToDecimal(row.Cells["GiaNhap"].Value)
                });
            }

            if (listNhapThucTe.Any(x => x.SoLuong <= 0 || x.GiaNhap <= 0))
            {
                MessageBox.Show("Vui lòng kiểm tra lại! Số lượng và Giá nhập phải lớn hơn 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuKho phieu = new PhieuKho
            {
                NgayLap = DateTime.Now,
                MaNcc = (int)cboNhaCungCap.SelectedValue,
                LoaiPhieu = "Nhap",
                MaNv = 1
            };

            // Gọi thẳng hàm NhapKhoChinhThuc trong KhoService của bạn
            if (_service.NhapKhoChinhThuc(phieu, listNhapThucTe))
            {
                MessageBox.Show("Nhập kho thành công!");
                dgvChiTietNhap.Rows.Clear();
                TinhTongTienPhieu();
                TaiDanhSachKho();
                _danhSachKhoGoc = _service.LayDanhSachNguyenLieu(); // Load lại gốc
                HienThiTatCaHangHoaLenPanel();
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu phiếu! Vui lòng thử lại.");
            }
        }
        #endregion

        // Giữ các hàm sự kiện UI trống để không bị lỗi Designer
        private void dgvChiTietNhap_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void NhapHang_Click(object sender, EventArgs e) { }
    }
}