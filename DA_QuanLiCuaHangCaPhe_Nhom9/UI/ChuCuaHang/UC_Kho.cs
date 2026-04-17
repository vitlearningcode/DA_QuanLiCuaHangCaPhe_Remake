using System;
using System.Drawing;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using Microsoft.VisualBasic;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_Kho : UserControl
    {
        #region Setup
        private readonly KhoService _service = new KhoService();
        private List<ChiTietPhieuKho> _listChiTietTam = new List<ChiTietPhieuKho>();
        private int _maNLDangChon = -1; // Biến lưu ID nguyên liệu đang chọn để sửa/xóa

        public UC_Kho()
        {
            InitializeComponent();
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void UC_Kho_Load(object sender, EventArgs e)
        {
            TaiDanhSachKho();
            LoadDanhSachPhieuNhap();

            pnlQuanLyPhieu.Dock = DockStyle.Fill;
            pnlTaoPhieuMoi.Dock = DockStyle.Fill;
            // Ép cái khung chứa 2 cái bảng neo chặt vào 4 góc màn hình
            splitContainerPhieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        #endregion

        #region LoadData

        private void TaiDanhSachKho()
        {
            var listNL = _service.LayDanhSachNguyenLieu();
            dgvNguyenLieu.DataSource = listNL;

            // Định dạng lưới cho đẹp
            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvNguyenLieu.Columns["MaNl"] != null) dgvNguyenLieu.Columns["MaNl"].Visible = false;
            if (dgvNguyenLieu.Columns["TrangThai"] != null) dgvNguyenLieu.Columns["TrangThai"].Visible = false;

            // Đặt tên cột tiếng Việt
            if (dgvNguyenLieu.Columns["TenNl"] != null) dgvNguyenLieu.Columns["TenNl"].HeaderText = "Tên Nguyên Liệu";
            if (dgvNguyenLieu.Columns["SoLuongTon"] != null) dgvNguyenLieu.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
            if (dgvNguyenLieu.Columns["DonViTinh"] != null) dgvNguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn Vị";

            cboChonNL_Tab2.DataSource = listNL;
            cboChonNL_Tab2.DisplayMember = "TenNl"; // Hiện tên
            cboChonNL_Tab2.ValueMember = "MaNl";

            // Load Nhà Cung Cấp
            cboNhaCungCap.DataSource = _service.LayDanhSachNhaCungCap();
            cboNhaCungCap.DisplayMember = "TenNcc";
            cboNhaCungCap.ValueMember = "MaNcc";
        }


        #endregion

        #region TinhNang
        // --- TÍNH NĂNG 1: TÔ MÀU CẢNH BÁO SẮP HẾT HÀNG ---
        // (nhớ chọn dgvNguyenLieu -> Events -> CellFormatting để gắn hàm này)
        private void dgvNguyenLieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra cột "SoLuongTon"
            if (dgvNguyenLieu.Columns[e.ColumnIndex].Name == "SoLuongTon" && e.Value != null)
            {
                decimal tonKho;
                if (decimal.TryParse(e.Value.ToString(), out tonKho))
                {
                    if (tonKho < 5) // NGƯỠNG CẢNH BÁO: Dưới 5 là báo động
                    {
                        // Tô màu nền đỏ, chữ trắng cho cả dòng
                        dgvNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                        dgvNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        // --- TÍNH NĂNG 2: BẤM VÀO LƯỚI -> HIỆN LÊN Ô NHẬP ---
        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguyenLieu.Rows[e.RowIndex];

                // Lấy dữ liệu từ dòng chọn
                _maNLDangChon = Convert.ToInt32(row.Cells["MaNl"].Value);
                txtTenNL.Text = row.Cells["TenNl"].Value.ToString();
                txtDonVi.Text = row.Cells["DonViTinh"].Value.ToString();

                // Đổi trạng thái nút
                btnThemNL.Enabled = false; // Đang chọn sửa thì khóa nút thêm
                btnSuaNL.Enabled = true;
                btnXoaNL.Enabled = true;
            }
        }

        // --- TÍNH NĂNG 3: Hiển thị list tạ
        private void HienThiListTam()
        {
            using (var db = new DataSqlContext())
            {
                // Join để lấy tên hiển thị
                var hienThi = from ct in _listChiTietTam
                              join nl in db.NguyenLieus on ct.MaNl equals nl.MaNl
                              select new
                              {
                                  TenNL = nl.TenNl,
                                  SoLuong = ct.SoLuong,
                                  GiaNhap = ct.GiaNhap, // <--- ĐÃ SỬA
                                  ThanhTien = ct.SoLuong * ct.GiaNhap // <--- ĐÃ SỬA
                              };
                dgvChiTietNhap.DataSource = hienThi.ToList();

                // Định dạng lại cột hiển thị tiền tệ cho đẹp (nếu cần)
                dgvChiTietNhap.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                dgvChiTietNhap.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
        }

        //reset
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

        // --- CÁC NÚT THAO TÁC (CRUD) ---
        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNL.Text)) return;

            //decimal giaNhap = 0;
            //decimal.TryParse(txtDonGia.Text, out giaNhap);

            if (_service.ThemNguyenLieu(txtTenNL.Text, txtDonVi.Text))
            {
                MessageBox.Show("Thêm mới thành công!");
                ResetInput();
            }
            else
            {
                MessageBox.Show("Lỗi: Tên nguyên liệu có thể đã tồn tại!");
            }
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            if (_maNLDangChon == -1) return;

            _service.SuaNguyenLieu(_maNLDangChon, txtTenNL.Text, txtDonVi.Text);
            MessageBox.Show("Cập nhật thành công!");
            ResetInput();
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (_maNLDangChon == -1) return;

            if (MessageBox.Show("Bạn chắc chắn muốn xóa nguyên liệu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _service.XoaNguyenLieu(_maNLDangChon);
                MessageBox.Show("Đã xóa!");
                ResetInput();
            }
        }

        private void btnThemVaoPhieu_Click(object sender, EventArgs e)
        {
            if (cboChonNL_Tab2.SelectedValue == null) return;

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

            _listChiTietTam.Add(item);
            HienThiListTam();

            // Reset ô nhập
            txtSoLuongNhap.Clear();
            txtDonGia.Clear();
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
                MaNv = 1,
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