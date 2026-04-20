using System;
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
        #region Khai báo service & biến trạng thái

        // Service CRUD kho: nguyên liệu, phiếu nhập xuất, nhà cung cấp
        private readonly KhoService _service = new KhoService();

        // Danh sách chi tiết phiếu đang xây dựng (giỏ tạm trước khi lưu)
        private List<ChiTietPhieuKho> _listChiTietTam = new List<ChiTietPhieuKho>();

        // Mã nguyên liệu đang chọn trên lưới tab 1 (-1 = chưa chọn)
        private int _maNLDangChon = -1;

        // Mã NV Admin đang lập phiếu — nhận từ Admin.cs để ghi vào phiếu kho
        private readonly string _maNVLap;

        #endregion

        #region Khởi tạo & Load

        public UC_Kho(string maNV = "")
        {
            InitializeComponent();
            _maNVLap = maNV;
        }

        // Load: tải tồn kho, danh sách phiếu nhập, cố định layout panel
        private void UC_Kho_Load(object sender, EventArgs e)
        {
            // Tab 1
            TaiDanhSachKho();
            LoadDanhSachPhieuNhap();

            // Hai panel lấp đầy container cha, chuyển bằng Visible
            pnlQuanLyPhieu.Dock = DockStyle.Fill;
            pnlTaoPhieuMoi.Dock = DockStyle.Fill;
            splitContainerPhieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        #endregion

        #region Hàm nội bộ — Tải dữ liệu

        // Tải danh sách tồn kho tab 1 vào lưới + nạp ComboBox nguyên liệu & NCC
        private void TaiDanhSachKho()
        {
            var listNL = _service.LayDanhSachNguyenLieu();
            dgvNguyenLieu.DataSource = listNL;

            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ẩn các cột không cần thiết
            if (dgvNguyenLieu.Columns["MaNl"]              != null) dgvNguyenLieu.Columns["MaNl"].Visible              = false;
            if (dgvNguyenLieu.Columns["TrangThai"]         != null) dgvNguyenLieu.Columns["TrangThai"].Visible          = false;
            if (dgvNguyenLieu.Columns["NguongCanhBao"]     != null) dgvNguyenLieu.Columns["NguongCanhBao"].Visible      = false;
            if (dgvNguyenLieu.Columns["ChiTietPhieuKhos"]  != null) dgvNguyenLieu.Columns["ChiTietPhieuKhos"].Visible   = false;
            if (dgvNguyenLieu.Columns["DinhLuongs"]        != null) dgvNguyenLieu.Columns["DinhLuongs"].Visible         = false;

            // Việt hóa tiêu đề cột tồn kho
            if (dgvNguyenLieu.Columns["TenNl"]       != null) dgvNguyenLieu.Columns["TenNl"].HeaderText       = "Tên Nguyên Liệu";
            if (dgvNguyenLieu.Columns["DonViTinh"]   != null) dgvNguyenLieu.Columns["DonViTinh"].HeaderText   = "Đơn Vị";
            if (dgvNguyenLieu.Columns["SoLuongTon"]  != null) dgvNguyenLieu.Columns["SoLuongTon"].HeaderText  = "Tồn Kho";

            // Nạp ComboBox chọn nguyên liệu khi lập phiếu
            cboChonNL_Tab2.DataSource    = listNL;
            cboChonNL_Tab2.DisplayMember = "TenNl";
            cboChonNL_Tab2.ValueMember   = "MaNl";

            // Nạp ComboBox nhà cung cấp
            cboNhaCungCap.DataSource    = _service.LayDanhSachNhaCungCap();
            cboNhaCungCap.DisplayMember = "TenNcc";
            cboNhaCungCap.ValueMember   = "MaNcc";
        }

        // Tải danh sách phiếu nhập/xuất vào lưới tab 2 + đăng ký tô màu trạng thái
        private void LoadDanhSachPhieuNhap()
        {
            dgvDanhSachPhieu.DataSource = _service.LayDanhSachPhieuNhap();

            // Việt hóa tiêu đề cột phiếu
            if (dgvDanhSachPhieu.Columns["MaPhieu"]   != null) dgvDanhSachPhieu.Columns["MaPhieu"].HeaderText   = "Mã Phiếu";
            if (dgvDanhSachPhieu.Columns["LoaiPhieu"] != null) dgvDanhSachPhieu.Columns["LoaiPhieu"].HeaderText = "Loại";
            if (dgvDanhSachPhieu.Columns["NgayLap"]   != null) dgvDanhSachPhieu.Columns["NgayLap"].HeaderText   = "Ngày Lập";
            if (dgvDanhSachPhieu.Columns["TenNcc"]    != null) dgvDanhSachPhieu.Columns["TenNcc"].HeaderText    = "Nhà Cung Cấp";
            if (dgvDanhSachPhieu.Columns["TrangThai"] != null) dgvDanhSachPhieu.Columns["TrangThai"].HeaderText = "Trạng Thái";
            if (dgvDanhSachPhieu.Columns["TongTien"]  != null)
            {
                dgvDanhSachPhieu.Columns["TongTien"].HeaderText                    = "Tổng Tiền";
                dgvDanhSachPhieu.Columns["TongTien"].DefaultCellStyle.Format       = "N0";
            }

            // Tô màu trạng thái phiếu (Đã hủy = Đỏ, khác = Xanh)
            dgvDanhSachPhieu.CellFormatting += (s, e) =>
            {
                if (dgvDanhSachPhieu.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
                {
                    bool dahuy = e.Value.ToString() == "Đã hủy";
                    e.CellStyle.ForeColor = dahuy ? Color.Red : Color.DarkGreen;
                    if (dahuy) e.CellStyle.Font = new Font(dgvDanhSachPhieu.Font, FontStyle.Bold);
                }
            };
        }

        // Hiển thị giỏ tạm (danh sách chi tiết đang xây dựng) ra lưới dgvChiTietNhap
        private void HienThiListTam()
        {
            using var db = new DataSqlContext();
            var hienThi = from ct in _listChiTietTam
                          join nl in db.NguyenLieus on ct.MaNl equals nl.MaNl
                          select new
                          {
                              TenNL      = nl.TenNl,
                              SoLuong    = ct.SoLuong,
                              GiaNhap    = ct.GiaNhap,
                              ThanhTien  = ct.SoLuong * ct.GiaNhap
                          };

            dgvChiTietNhap.DataSource = hienThi.ToList();

            // Việt hóa và format tiền tệ
            if (dgvChiTietNhap.Columns["TenNL"]     != null) dgvChiTietNhap.Columns["TenNL"].HeaderText     = "Nguyên Liệu";
            if (dgvChiTietNhap.Columns["SoLuong"]   != null) dgvChiTietNhap.Columns["SoLuong"].HeaderText   = "Số Lượng";
            if (dgvChiTietNhap.Columns["GiaNhap"]   != null)
            {
                dgvChiTietNhap.Columns["GiaNhap"].HeaderText                    = "Giá Nhập";
                dgvChiTietNhap.Columns["GiaNhap"].DefaultCellStyle.Format       = "N0";
            }
            if (dgvChiTietNhap.Columns["ThanhTien"] != null)
            {
                dgvChiTietNhap.Columns["ThanhTien"].HeaderText                  = "Thành Tiền";
                dgvChiTietNhap.Columns["ThanhTien"].DefaultCellStyle.Format     = "N0";
            }
        }

        // Reset form tab CRUD nguyên liệu về trạng thái ban đầu
        private void ResetInput()
        {
            txtTenNL.Clear();
            txtDonVi.Clear();
            _maNLDangChon     = -1;
            btnThemNL.Enabled = true;
            btnSuaNL.Enabled  = false;
            btnXoaNL.Enabled  = false;
            TaiDanhSachKho();
        }

        #endregion

        #region Sự kiện Tab 1 — Tồn kho (CRUD nguyên liệu)

        // Tô đỏ dòng tồn kho dưới ngưỡng cảnh báo (< 5 đơn vị)
        private void dgvNguyenLieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNguyenLieu.Columns[e.ColumnIndex].Name == "SoLuongTon" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal ton) && ton < 5)
                {
                    dgvNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                    dgvNguyenLieu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        // Click dòng lưới tồn kho → nạp thông tin vào ô nhập để sửa/xóa
        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row         = dgvNguyenLieu.Rows[e.RowIndex];
            _maNLDangChon   = Convert.ToInt32(row.Cells["MaNl"].Value);
            txtTenNL.Text   = row.Cells["TenNl"].Value.ToString();
            txtDonVi.Text   = row.Cells["DonViTinh"].Value.ToString();

            // Khi đang chọn để sửa: tắt Thêm, bật Sửa/Xóa
            btnThemNL.Enabled = false;
            btnSuaNL.Enabled  = true;
            btnXoaNL.Enabled  = true;
        }

        // LÀM MỚI → reset form nguyên liệu
        private void btnLamMoi_Click(object sender, EventArgs e) => ResetInput();

        // THÊM nguyên liệu mới vào danh mục kho
        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNL.Text)) return;

            if (_service.ThemNguyenLieu(txtTenNL.Text, txtDonVi.Text))
            {
                MessageBox.Show("Thêm mới thành công!");
                ResetInput();
            }
            else
                MessageBox.Show("Lỗi: Tên nguyên liệu có thể đã tồn tại!");
        }

        // SỬA thông tin nguyên liệu đang chọn
        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            if (_maNLDangChon == -1) return;
            _service.SuaNguyenLieu(_maNLDangChon, txtTenNL.Text, txtDonVi.Text);
            MessageBox.Show("Cập nhật thành công!");
            ResetInput();
        }

        // XÓA nguyên liệu (hỏi xác nhận)
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

        #endregion

        #region Sự kiện Tab 2 — Phiếu nhập xuất

        // Nút "Thêm Phiếu Mới" → ẩn danh sách, hiện form tạo phiếu
        private void btnThemPhieuMoi_Click(object sender, EventArgs e)
        {
            pnlQuanLyPhieu.Visible = false;
            pnlTaoPhieuMoi.Visible = true;
            pnlTaoPhieuMoi.Dock    = DockStyle.Fill;
            pnlTaoPhieuMoi.BringToFront();
        }

        // Nút "Quay Lại" → ẩn form tạo, hiện lại danh sách phiếu
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            pnlTaoPhieuMoi.Visible = false;
            pnlQuanLyPhieu.Visible = true;
            LoadDanhSachPhieuNhap();
        }

        // Click dòng phiếu trên lưới → hiển thị chi tiết ở panel phía dưới
        private void dgvDanhSachPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int maPhieu = Convert.ToInt32(dgvDanhSachPhieu.Rows[e.RowIndex].Cells["MaPhieu"].Value);
            dgvChiTietPhieuCu.DataSource = _service.LayChiTietCuaPhieu(maPhieu);

            // Việt hóa tiêu đề chi tiết phiếu
            if (dgvChiTietPhieuCu.Columns["TenNL"]     != null) dgvChiTietPhieuCu.Columns["TenNL"].HeaderText     = "Nguyên Liệu";
            if (dgvChiTietPhieuCu.Columns["SoLuong"]   != null) dgvChiTietPhieuCu.Columns["SoLuong"].HeaderText   = "Số Lượng";
            if (dgvChiTietPhieuCu.Columns["GiaNhap"]   != null)
            {
                dgvChiTietPhieuCu.Columns["GiaNhap"].HeaderText                  = "Giá Nhập";
                dgvChiTietPhieuCu.Columns["GiaNhap"].DefaultCellStyle.Format     = "N0";
            }
            if (dgvChiTietPhieuCu.Columns["ThanhTien"] != null)
            {
                dgvChiTietPhieuCu.Columns["ThanhTien"].HeaderText                = "Thành Tiền";
                dgvChiTietPhieuCu.Columns["ThanhTien"].DefaultCellStyle.Format   = "N0";
            }
        }

        // Sự kiện placeholder (cần giữ để Designer không lỗi)
        private void dgvDanhSachPhieu_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // HỦY PHIẾU: Trừ ngược tồn kho tương ứng, cần xác nhận kỹ
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhieu.CurrentRow == null) { MessageBox.Show("Vui lòng chọn 1 phiếu nhập để xóa!"); return; }

            int maPhieu = Convert.ToInt32(dgvDanhSachPhieu.CurrentRow.Cells["MaPhieu"].Value);
            if (MessageBox.Show(
                "BẠN CÓ CHẮC CHẮN MUỐN XÓA PHIẾU NÀY?\n\nSố lượng tồn kho sẽ bị trừ lại tương ứng!",
                "Cảnh báo nguy hiểm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_service.HuyPhieuKhoVaLuiKho(maPhieu))
                {
                    MessageBox.Show("Đã xóa phiếu và thu hồi tồn kho thành công!");
                    LoadDanhSachPhieuNhap();
                    TaiDanhSachKho();
                    dgvChiTietPhieuCu.DataSource = null;
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }

        // THANH TOÁN PHIẾU: Kiểm tra còn nợ → mở form thanh toán → cập nhật DB
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhieu.CurrentRow == null) { MessageBox.Show("Vui lòng chọn 1 phiếu nhập để thanh toán!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // Phiếu Xuất Hủy không phát sinh công nợ
            string loaiPhieu = dgvDanhSachPhieu.CurrentRow.Cells["LoaiPhieu"].Value?.ToString();
            if (loaiPhieu != null && loaiPhieu.Contains("Hủy")) { MessageBox.Show("Phiếu Xuất Hủy không phát sinh công nợ để thanh toán!"); return; }

            int maPhieu    = Convert.ToInt32(dgvDanhSachPhieu.CurrentRow.Cells["MaPhieu"].Value);
            var congNo     = _service.LayThongTinCongNo(maPhieu);
            if (congNo == null) return;

            decimal conNo = congNo.TongTien - congNo.DaTra;
            if (conNo <= 0) { MessageBox.Show("Phiếu này đã được thanh toán dứt điểm, không còn nợ nần!"); return; }

            // Mở form thanh toán con, lấy kết quả và ghi vào DB
            Frm_ThanhToanPhieuNhap frmTT = new Frm_ThanhToanPhieuNhap(congNo);
            if (frmTT.ShowDialog() == DialogResult.OK)
            {
                if (_service.XuLyThanhToan(maPhieu, frmTT.SoTienTra, frmTT.HinhThucThanhToan, _maNVLap))
                {
                    MessageBox.Show($"Thanh toán thành công {frmTT.SoTienTra:N0} VNĐ!\nHệ thống đã lưu Phiếu Chi và trừ công nợ.", "Giao dịch thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachPhieuNhap();
                }
                else MessageBox.Show("Lỗi CSDL khi xử lý thanh toán! Giao dịch đã bị hủy.", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Sự kiện form tạo phiếu mới — Thêm NCC & chọn loại phiếu

        // Thêm nhà cung cấp nhanh qua mini-form tạo động (không cần Designer)
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            Form frmMini = new Form { Width = 350, Height = 250, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "Thêm Nhà Cung Cấp Mới", StartPosition = FormStartPosition.CenterScreen };

            Label   lblTen    = new Label  { Left = 20, Top = 20,  Text = "Tên NCC (*):" };
            TextBox txtTen    = new TextBox { Left = 120, Top = 20, Width = 180 };
            Label   lblSdt    = new Label  { Left = 20, Top = 60,  Text = "SĐT:" };
            TextBox txtSdt    = new TextBox { Left = 120, Top = 60, Width = 180 };
            Label   lblDiaChi = new Label  { Left = 20, Top = 100, Text = "Địa chỉ:" };
            TextBox txtDiaChi = new TextBox { Left = 120, Top = 100, Width = 180 };
            Button  btnLuu    = new Button  { Text = "Lưu", Left = 120, Top = 150, Width = 80, DialogResult = DialogResult.OK, BackColor = Color.MediumSeaGreen, ForeColor = Color.White };

            frmMini.Controls.AddRange(new Control[] { lblTen, txtTen, lblSdt, txtSdt, lblDiaChi, txtDiaChi, btnLuu });
            frmMini.AcceptButton = btnLuu;

            if (frmMini.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(txtTen.Text)) { MessageBox.Show("Tên NCC không được để trống!"); return; }
                int maMoi = _service.ThemNhaCungCapNhanh(txtTen.Text, txtSdt.Text, txtDiaChi.Text);
                cboNhaCungCap.DataSource  = _service.LayDanhSachNhaCungCap();
                cboNhaCungCap.SelectedValue = maMoi;
                MessageBox.Show("Thêm Nhà cung cấp thành công!");
            }
        }

        // Đổi loại phiếu (Nhập Kho / Xuất Hủy) → cập nhật UI tương ứng
        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool laHuy = cboLoaiPhieu.Text == "Xuất Hủy";

            // Ẩn/hiện nhà cung cấp và giá nhập tùy loại phiếu
            label1.Visible          = !laHuy;
            cboNhaCungCap.Visible   = !laHuy;
            btnThemNCC.Visible      = !laHuy;
            lbl_GiaNhap.Visible     = !laHuy;
            txtDonGia.Visible       = !laHuy;

            if (laHuy)
            {
                txtDonGia.Text              = "0"; // Giá vốn lấy tự động từ DB
                lbl_SoLuongNhap.Text        = "Số Lượng Hủy:";
                btnThemVaoPhieu.Text        = "Thêm Vào Giỏ Hủy";
                btnThemVaoPhieu.BackColor   = Color.Salmon;
                btnLuuPhieu.Text            = "LƯU PHIẾU HỦY";
                btnLuuPhieu.BackColor       = Color.Red;
                btnLuuPhieu.ForeColor       = Color.White;
            }
            else
            {
                txtDonGia.Text              = "";
                lbl_SoLuongNhap.Text        = "Số Lượng:";
                btnThemVaoPhieu.Text        = "Thêm Vào Giỏ";
                btnThemVaoPhieu.BackColor   = Color.MediumSeaGreen;
                btnLuuPhieu.Text            = "LƯU PHIẾU NHẬP";
                btnLuuPhieu.BackColor       = Color.Orange;
                btnLuuPhieu.ForeColor       = Color.Black;
            }
        }
        #endregion

        #region TAB 2: NHẬP HÀNG (Dùng EF Core Models)

        // Thêm 1 dòng nguyên liệu vào giỏ tạm (validate số lượng và giá)
        private void btnThemVaoPhieu_Click(object sender, EventArgs e)
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
            if (!decimal.TryParse(txtSoLuongNhap.Text, out decimal soLuong) || soLuong <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0"); return; }

            decimal giaNhap;
            if (cboLoaiPhieu.Text == "Xuất Hủy")
                giaNhap = _service.LayGiaNhapGanNhat(maNL); // Tự động lấy giá vốn
            else
            {
                if (!decimal.TryParse(txtDonGia.Text, out giaNhap) || giaNhap < 0) { MessageBox.Show("Giá nhập không hợp lệ"); return; }
            }

            _listChiTietTam.Add(new ChiTietPhieuKho { MaNl = maNL, SoLuong = soLuong, GiaNhap = giaNhap });
            HienThiListTam();
            txtSoLuongNhap.Clear();
            txtDonGia.Clear();
        }

        // LƯU PHIẾU: Tạo phiếu kho chính thức, cập nhật tồn kho, quay về danh sách
        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (_listChiTietTam.Count == 0) { MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm nguyên liệu."); return; }

            int    maPhieuTuTao  = _service.TaoMaPhieuNhapMoi();
            string loai          = cboLoaiPhieu.Text == "Xuất Hủy" ? "Xuat" : "Nhap";
            int    maNhaCungCap  = loai == "Xuat" ? _service.LayHoacTaoNccXuatHuy() : (int)cboNhaCungCap.SelectedValue;

            PhieuKho phieu = new PhieuKho
            {
                MaPhieu   = maPhieuTuTao,
                NgayLap   = dtpNgayNhap.Value,
                MaNcc     = maNhaCungCap,
                LoaiPhieu = loai,
                MaNv      = _maNVLap,   // Mã NV đăng nhập lúc mở Admin (nhận từ Admin.cs)
                TrangThai = "Hoàn thành"
            };

            if (_service.NhapKhoChinhThuc(phieu, _listChiTietTam))
            {
                MessageBox.Show($"Đã lưu Phiếu {cboLoaiPhieu.Text} thành công!\nMã Phiếu: {maPhieuTuTao}");
                _listChiTietTam.Clear();
                dgvChiTietNhap.DataSource = null;
                TaiDanhSachKho();
                btnQuayLai_Click(null, null);
            }
            else MessageBox.Show("Lỗi khi lưu phiếu! Vui lòng thử lại.");
        }

        #endregion
    }
}