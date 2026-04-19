using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.VisualBasic;

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
            LoadDanhSachPhieuNhap();

            pnlQuanLyPhieu.Dock = DockStyle.Fill;
            pnlTaoPhieuMoi.Dock = DockStyle.Fill;
            // Ép cái khung chứa 2 cái bảng neo chặt vào 4 góc màn hình
            splitContainerPhieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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

        private void LoadDanhSachPhieuNhap()
        {
            dgvDanhSachPhieu.DataSource = _service.LayDanhSachPhieuNhap();

            dgvDanhSachPhieu.Columns["TrangThai"].HeaderText = "Trạng Thái";
                        
            dgvDanhSachPhieu.Columns["TongTien"].DefaultCellStyle.Format = "N0";

            // làm màu:
            dgvDanhSachPhieu.CellFormatting += (s, e) => {
                if (dgvDanhSachPhieu.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
                {
                    if (e.Value.ToString() == "Đã hủy")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(dgvDanhSachPhieu.Font, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            };
        
        }

        #endregion

        #region Event
        private void btnThemPhieuMoi_Click(object sender, EventArgs e)
        {
            // Chuyển màn hình
            pnlQuanLyPhieu.Visible = false;
            pnlTaoPhieuMoi.Visible = true;
            pnlTaoPhieuMoi.Dock = DockStyle.Fill;
            pnlTaoPhieuMoi.BringToFront();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            // Quay lại màn hình danh sách
            pnlTaoPhieuMoi.Visible = false;
            pnlQuanLyPhieu.Visible = true;
            LoadDanhSachPhieuNhap();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            // Tự động code vẽ ra 1 cái Form Mini cực ảo diệu
            Form frmMini = new Form()
            {
                Width = 350,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Thêm Nhà Cung Cấp Mới",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label lblTen = new Label() { Left = 20, Top = 20, Text = "Tên NCC (*):" };
            TextBox txtTen = new TextBox() { Left = 120, Top = 20, Width = 180 };

            Label lblSdt = new Label() { Left = 20, Top = 60, Text = "SĐT:" };
            TextBox txtSdt = new TextBox() { Left = 120, Top = 60, Width = 180 };

            Label lblDiaChi = new Label() { Left = 20, Top = 100, Text = "Địa chỉ:" };
            TextBox txtDiaChi = new TextBox() { Left = 120, Top = 100, Width = 180 };

            Button btnLuu = new Button() { Text = "Lưu", Left = 120, Top = 150, Width = 80, DialogResult = DialogResult.OK, BackColor = Color.MediumSeaGreen, ForeColor = Color.White };

            frmMini.Controls.Add(lblTen); frmMini.Controls.Add(txtTen);
            frmMini.Controls.Add(lblSdt); frmMini.Controls.Add(txtSdt);
            frmMini.Controls.Add(lblDiaChi); frmMini.Controls.Add(txtDiaChi);
            frmMini.Controls.Add(btnLuu);
            frmMini.AcceptButton = btnLuu; // Ấn Enter là lưu

            // Khi người dùng bấm nút Lưu
            if (frmMini.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(txtTen.Text))
                {
                    MessageBox.Show("Tên Nhà cung cấp không được để trống!"); return;
                }

                // Gọi service lưu vào DB
                int maMoi = _service.ThemNhaCungCapNhanh(txtTen.Text, txtSdt.Text, txtDiaChi.Text);

                // Cập nhật lại ComboBox
                cboNhaCungCap.DataSource = _service.LayDanhSachNhaCungCap();
                cboNhaCungCap.SelectedValue = maMoi;
                MessageBox.Show("Thêm Nhà cung cấp thành công!");
            }
        }

        // Click vào 1 phiếu ở trên -> Hiện chi tiết ở dưới
        private void dgvDanhSachPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maPhieu = Convert.ToInt32(dgvDanhSachPhieu.Rows[e.RowIndex].Cells["MaPhieu"].Value);
                dgvChiTietPhieuCu.DataSource = _service.LayChiTietCuaPhieu(maPhieu);
                dgvChiTietPhieuCu.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                dgvChiTietPhieuCu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhieu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu nhập để xóa!"); return;
            }

            int maPhieu = Convert.ToInt32(dgvDanhSachPhieu.CurrentRow.Cells["MaPhieu"].Value);

            if (MessageBox.Show("BẠN CÓ CHẮC CHẮN MUỐN XÓA PHIẾU NÀY?\n\nSố lượng nguyên liệu trong kho sẽ bị trừ đi tương ứng với phiếu nhập này!", "Cảnh báo nguy hiểm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_service.HuyPhieuKhoVaLuiKho(maPhieu))
                {
                    MessageBox.Show("Đã xóa phiếu và thu hồi số lượng tồn kho thành công!");
                    LoadDanhSachPhieuNhap();
                    TaiDanhSachKho(); // Refresh lại tab 1
                    dgvChiTietPhieuCu.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        // Nút LÀM MỚI (Để hủy chọn và nhập mới)
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

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

            int maNL = (int)cboChonNL_Tab2.SelectedValue;
            decimal soLuong, giaNhap = 0;

            // Validate số lượng
            if (!decimal.TryParse(txtSoLuongNhap.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0"); return;
            }

            // --- ĐOẠN LOGIC NÂNG CẤP XỊN SÒ NẰM Ở ĐÂY ---
            if (cboLoaiPhieu.Text == "Xuất Hủy")
            {
                // Nếu là phiếu hủy -> Móc giá vốn từ Database lên, không bắt user gõ
                giaNhap = _service.LayGiaNhapGanNhat(maNL);
            }
            else
            {
                // Nếu là phiếu Nhập kho -> Bắt user phải tự gõ vào ô txtDonGia
                if (!decimal.TryParse(txtDonGia.Text, out giaNhap) || giaNhap < 0)
                {
                    MessageBox.Show("Giá nhập không hợp lệ"); return;
                }
            }
            // -------------------------------------------

            var item = new ChiTietPhieuKho
            {
                MaNl = maNL,
                SoLuong = soLuong,
                GiaNhap = giaNhap // Gán cái giá đã được xử lý thông minh ở trên vào đây
            };

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
            if (_listChiTietTam.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm nguyên liệu."); return;
            }

            int maPhieuTuTao = _service.TaoMaPhieuNhapMoi();

            // LẤY LOẠI PHIẾU TỪ COMBOBOX NGƯỜI DÙNG CHỌN
            string loai = cboLoaiPhieu.Text == "Xuất Hủy" ? "Xuat" : "Nhap";
                   
            int maNhaCungCap;
            if (loai == "Xuat")
                maNhaCungCap = _service.LayHoacTaoNccXuatHuy(); // Tự động lấy NCC nội bộ
            else
                maNhaCungCap = (int)cboNhaCungCap.SelectedValue; // Lấy từ ComboBox

            PhieuKho phieu = new PhieuKho
            {
                MaPhieu = maPhieuTuTao,
                NgayLap = dtpNgayNhap.Value,
                MaNcc = maNhaCungCap,  // <--- CẬP NHẬT DÒNG NÀY (Bỏ cái (int) đi)
                LoaiPhieu = loai,
                MaNv = "1",
                TrangThai = "Hoàn thành"
            };

            // Gọi hàm lưu như bình thường
            if (_service.NhapKhoChinhThuc(phieu, _listChiTietTam))
            {
                MessageBox.Show("Đã lưu Phiếu " + cboLoaiPhieu.Text + " thành công!\nMã Phiếu: " + maPhieuTuTao);
                _listChiTietTam.Clear();
                dgvChiTietNhap.DataSource = null;
                TaiDanhSachKho();
                btnQuayLai_Click(null, null);
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu phiếu! Vui lòng thử lại.");
            }
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiPhieu.Text == "Xuất Hủy")
            {
                // Giấu các ô của Nhập hàng
                label1.Visible = false; // Chữ "Nhà Cung Cấp"
                cboNhaCungCap.Visible = false;
                btnThemNCC.Visible = false;

                lbl_GiaNhap.Visible = false;
                txtDonGia.Visible = false;
                txtDonGia.Text = "0"; // Tự ép giá bằng 0 để code không lỗi

                // Đổi UI sang chế độ HỦY (Màu đỏ cảnh báo)
                lbl_SoLuongNhap.Text = "Số Lượng Hủy:";
                btnThemVaoPhieu.Text = "Thêm Vào Giỏ Hủy";
                btnThemVaoPhieu.BackColor = Color.Salmon;

                btnLuuPhieu.Text = "LƯU PHIẾU HỦY";
                btnLuuPhieu.BackColor = Color.Red;
                btnLuuPhieu.ForeColor = Color.White;
            }
            else // Mặc định là Nhập Kho
            {
                // Hiện lại toàn bộ
                label1.Visible = true;
                cboNhaCungCap.Visible = true;
                btnThemNCC.Visible = true;

                lbl_GiaNhap.Visible = true;
                txtDonGia.Visible = true;
                txtDonGia.Text = "";

                // Đổi UI về chế độ NHẬP (Màu xanh/cam)
                lbl_SoLuongNhap.Text = "Số Lượng:";
                btnThemVaoPhieu.Text = "Thêm Vào Giỏ";
                btnThemVaoPhieu.BackColor = Color.MediumSeaGreen;

                btnLuuPhieu.Text = "LƯU PHIẾU NHẬP";
                btnLuuPhieu.BackColor = Color.Orange;
                btnLuuPhieu.ForeColor = Color.Black;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn phiếu nào trên lưới chưa
            if (dgvDanhSachPhieu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu nhập để thanh toán!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Chặn đứng không cho thanh toán các Phiếu Xuất Hủy
            string loaiPhieu = dgvDanhSachPhieu.CurrentRow.Cells["LoaiPhieu"].Value?.ToString();
            if (loaiPhieu != null && loaiPhieu.Contains("Hủy"))
            {
                MessageBox.Show("Phiếu Xuất Hủy không phát sinh công nợ để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Lấy Mã Phiếu và gọi Service check nợ
            int maPhieu = Convert.ToInt32(dgvDanhSachPhieu.CurrentRow.Cells["MaPhieu"].Value);
            var congNo = _service.LayThongTinCongNo(maPhieu);
            if (congNo == null) return;

            decimal conNo = congNo.TongTien - congNo.DaTra;

            // 4. Báo cáo Sếp nếu phiếu đã trả xong
            if (conNo <= 0)
            {
                MessageBox.Show("Tuyệt vời! Phiếu này đã được thanh toán dứt điểm, không còn nợ nần gì nữa!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // --- 5. GỌI FORM THANH TOÁN CHÍNH CHỦ CỦA BRO RA ---
            Frm_ThanhToanPhieuNhap frmTT = new Frm_ThanhToanPhieuNhap(congNo);

            // Bắt sự kiện khi user bấm nút "XÁC NHẬN" bên Form con
            if (frmTT.ShowDialog() == DialogResult.OK)
            {
                // Hứng dữ liệu từ Form con truyền về
                decimal tienTra = frmTT.SoTienTra;
                string hinhThuc = frmTT.HinhThucThanhToan;

                // Đẩy xuống CSDL để thực hiện trừ nợ và lưu Phiếu Chi
                if (_service.XuLyThanhToan(maPhieu, tienTra, hinhThuc))
                {
                    MessageBox.Show($"Thanh toán thành công {tienTra:N0} VNĐ!\nHệ thống đã tự động lưu Phiếu Chi và trừ công nợ.", "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh lại danh sách phiếu ngoài màn hình chính để cập nhật số liệu
                    LoadDanhSachPhieuNhap();
                }
                else
                {
                    MessageBox.Show("Lỗi CSDL khi xử lý thanh toán! Giao dịch đã được hủy để bảo toàn dòng tiền.", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void dgvDanhSachPhieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}