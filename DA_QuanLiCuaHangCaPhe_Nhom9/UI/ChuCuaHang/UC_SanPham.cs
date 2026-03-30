using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_SanPham : UserControl
    {
        // Khởi tạo Service
        private readonly SanPhamService _service = new SanPhamService();

        private List<CongThucHienThi> _listCongThucTam = new List<CongThucHienThi>();

        public UC_SanPham()
        {
            InitializeComponent();
        }

        // Sự kiện Load: Chạy khi màn hình vừa mở
        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            TaiDanhSachMonBenTrai();
            TaiNguyenLieuVaoComboBox();

            // Gọi hàm load dữ liệu tự động từ DB
            TaiDanhSachLoaiVaDonVi();
            LamMoiGiaoDien();
        }

        #region Các Hàm load
        private void TaiDanhSachLoaiVaDonVi()
        {
            // Tải Loại món
            cboLoai.Items.Clear();
            var listLoai = _service.LayDanhSachLoaiMon();
            if (listLoai != null) cboLoai.Items.AddRange(listLoai.ToArray());

            // Tải Đơn vị tính
            cboDonVi.Items.Clear();
            var listDonVi = _service.LayDanhSachDonVi();
            if (listDonVi != null) cboDonVi.Items.AddRange(listDonVi.ToArray());
        }

        private void LamMoiGiaoDien()
        {
            txtTenMon.Clear();
            txtGiaBan.Clear();
            cboLoai.SelectedIndex = -1;
            cboDonVi.SelectedIndex = -1;
            txtSoLuongNL.Clear();
            cboNguyenLieu.SelectedIndex = -1;

            _listCongThucTam.Clear();
            HienThiLuoiCongThuc();

            cboTrangThai_SP.Text = "Còn bán";

            btnLuu.Text = "THÊM VÀO MENU";
            btnLuu.BackColor = Color.LightSeaGreen;
            btnLuu.Tag = null; // Tag = null nghĩa là đang ở chế độ Thêm Mới

            btnXoaNL.Enabled = false;
        }

        private void TaiDanhSachMonBenTrai()
        {
            flpDanhSachMon.Controls.Clear();
            var listMon = _service.LayDanhSachMonAn();

            foreach (var mon in listMon)
            {
                Button btn = new Button();
                // Hiển thị Tên món ở dòng 1, Giá tiền ở dòng 2
                btn.Text = $"{mon.TenSp}\n({mon.DonGia:N0} đ)";

                // Kích thước và căn chỉnh
                btn.Width = 220;
                btn.Height = 100;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Màu sắc giao diện
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(64, 64, 64);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.LightGray;

                btn.Tag = mon;
                btn.Click += BtnMon_Click;

                flpDanhSachMon.Controls.Add(btn);
            }
        }

        // Hàm 2: Nạp nguyên liệu vào ComboBox để chọn
        private void TaiNguyenLieuVaoComboBox()
        {
            cboNguyenLieu.DataSource = _service.LayDanhSachNguyenLieu();
            cboNguyenLieu.DisplayMember = "TenNl";
            cboNguyenLieu.ValueMember = "MaNl";
        }

        // Hàm phụ trợ để load list tạm lên DataGridView
        private void HienThiLuoiCongThuc()
        {
            dgvCongThuc.DataSource = null;
            if (_listCongThucTam.Count > 0)
            {
                dgvCongThuc.DataSource = _listCongThucTam.ToList();

                dgvCongThuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Định dạng tên cột theo Property của CongThucHienThi
                if (dgvCongThuc.Columns["MaNL"] != null) dgvCongThuc.Columns["MaNL"].Visible = false;
                if (dgvCongThuc.Columns["TenNL"] != null) dgvCongThuc.Columns["TenNL"].HeaderText = "Tên Nguyên Liệu";
                if (dgvCongThuc.Columns["SoLuong"] != null) dgvCongThuc.Columns["SoLuong"].HeaderText = "Định Lượng";
                if (dgvCongThuc.Columns["DonViTinh"] != null) dgvCongThuc.Columns["DonViTinh"].HeaderText = "Đơn Vị";

                dgvCongThuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        #endregion

        #region các hàm sự kiện

        // Sự kiện: Khi bấm vào nút món ăn bên trái
        private void BtnMon_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SanPham monChon = (SanPham)btn.Tag;

            // Xóa sạch các ô nhập công thức cũ
            txtSoLuongNL.Clear();
            cboNguyenLieu.SelectedIndex = -1;

            // 1. Đổ thông tin món lên giao diện
            txtTenMon.Text = monChon.TenSp;
            txtGiaBan.Text = monChon.DonGia.ToString("N0");
            cboLoai.Text = monChon.LoaiSp;
            cboDonVi.Text = monChon.DonVi;
            cboTrangThai_SP.Text = monChon.TrangThai ?? "Còn bán";

            // 2. Nạp công thức từ DB vào list tạm
            _listCongThucTam.Clear();
            var listCongThucTuDB = _service.LayCongThucMon(monChon.MaSp);
            if (listCongThucTuDB != null)
            {
                _listCongThucTam.AddRange(listCongThucTuDB);
            }

            // 3. Hiển thị lên lưới
            HienThiLuoiCongThuc();

            // Đổi trạng thái nút
            btnLuu.Text = "CẬP NHẬT MÓN";
            btnLuu.BackColor = Color.Orange;
            btnLuu.Tag = monChon;
        }

        // Sự kiện: Thêm Nguyên liệu vào công thức
        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedValue == null) return;

            decimal soLuong;
            if (!decimal.TryParse(txtSoLuongNL.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập định lượng hợp lệ!");
                return;
            }

            // Lấy toàn bộ Nguyên Liệu đang được chọn trên ComboBox
            NguyenLieu nlChon = (NguyenLieu)cboNguyenLieu.SelectedItem;

            int maNLChon = (int)cboNguyenLieu.SelectedValue;
            string tenNLChon = cboNguyenLieu.Text;
            string donViChon = nlChon.DonViTinh;

            // Kiểm tra xem nguyên liệu này đã có trong lưới chưa
            var monDaCo = _listCongThucTam.FirstOrDefault(x => x.MaNL == maNLChon);
            if (monDaCo != null)
            {
                // Có rồi thì cộng dồn số lượng
                monDaCo.SoLuong += soLuong;
            }
            else
            {
                // Chưa có thì thêm mới vào list tạm dạng CongThucHienThi
                _listCongThucTam.Add(new CongThucHienThi
                {
                    MaNL = maNLChon,
                    TenNL = tenNLChon,
                    SoLuong = soLuong,
                    DonViTinh = donViChon // Đơn vị sẽ được cập nhật khi tải lại từ DB
                });
            }

            HienThiLuoiCongThuc();
            txtSoLuongNL.Clear();
        }

        // Sự kiện: Lưu Cập nhật Món và Công thức
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // --- BƯỚC 1: VALIDATION (KIỂM TRA NHẬP LIỆU) ---
            if (string.IsNullOrWhiteSpace(txtTenMon.Text)) { MessageBox.Show("Vui lòng nhập Tên món!"); txtTenMon.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtGiaBan.Text)) { MessageBox.Show("Vui lòng nhập Giá bán!"); txtGiaBan.Focus(); return; }
            if (string.IsNullOrWhiteSpace(cboLoai.Text)) { MessageBox.Show("Vui lòng chọn hoặc nhập Loại món!"); cboLoai.Focus(); return; }
            if (string.IsNullOrWhiteSpace(cboDonVi.Text)) { MessageBox.Show("Vui lòng chọn hoặc nhập Đơn vị tính!"); cboDonVi.Focus(); return; }

            decimal giaBan;
            if (!decimal.TryParse(txtGiaBan.Text.Replace(",", ""), out giaBan)) { MessageBox.Show("Giá bán không hợp lệ!"); return; }

            // --- BƯỚC 2: XỬ LÝ LOGIC "NGỪNG BÁN" 

            string trangThaiMon = cboTrangThai_SP.Text;

            if (_listCongThucTam.Count == 0 && trangThaiMon == "Còn bán")
            {
                var tl = MessageBox.Show("Món này đang không có nguyên liệu nào!\nĐể tránh lỗi khi bán hàng, hệ thống sẽ tự động đổi thành 'Ngừng bán'.\nBạn có muốn tiếp tục lưu?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (tl == DialogResult.No) return;

                trangThaiMon = "Ngừng bán";
                cboTrangThai_SP.Text = "Ngừng bán"; // Ép giao diện về ngừng bán luôn
            }

            // --- BƯỚC 3: THỰC THI THÊM HOẶC SỬA ---
            bool isSuccess = false;

            if (btnLuu.Tag == null)
            {
                // TRẠNG THÁI: THÊM MỚI SẢN PHẨM
                SanPham spMoi = new SanPham
                {
                    TenSp = txtTenMon.Text.Trim(),
                    DonGia = giaBan,
                    LoaiSp = cboLoai.Text,
                    DonVi = cboDonVi.Text,
                    TrangThai = trangThaiMon // Lấy trạng thái từ logic kiểm tra nguyên liệu ở trên
                };

                isSuccess = _service.ThemSanPhamMoi(spMoi, _listCongThucTam);

                if (isSuccess) MessageBox.Show("Đã thêm món mới vào Menu thành công!");
                else MessageBox.Show("Lỗi khi thêm món mới  vào cơ sở dữ liệu!");
            }
            else
            {
                // TRẠNG THÁI: CẬP NHẬT MÓN CŨ
                SanPham monDangChon = (SanPham)btnLuu.Tag;
                monDangChon.TenSp = txtTenMon.Text.Trim();
                monDangChon.DonGia = giaBan;
                monDangChon.LoaiSp = cboLoai.Text;
                monDangChon.DonVi = cboDonVi.Text;
                monDangChon.TrangThai = trangThaiMon; // Cập nhật trạng thái

                isSuccess = _service.CapNhatSanPhamVaCongThuc(monDangChon, _listCongThucTam);
                if (isSuccess) MessageBox.Show("Cập nhật món và công thức thành công!");
            }

            if (isSuccess)
            {
                TaiDanhSachMonBenTrai(); // Load lại lưới
                LamMoiGiaoDien(); // Quay về trạng thái sạch sẽ
            }
        }

        private void btnTaoMonMoi_Click(object sender, EventArgs e) => LamMoiGiaoDien();

        private void dgvCongThuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenNL = _listCongThucTam[e.RowIndex].TenNL;
                if (MessageBox.Show($"Bỏ nguyên liệu '{tenNL}' khỏi công thức?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _listCongThucTam.RemoveAt(e.RowIndex);
                    HienThiLuoiCongThuc();
                }
            }
        }

        // Nếu có chọn ít nhất 1 dòng thì sáng nút Xóa lên
        private void dgvCongThuc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongThuc.SelectedRows.Count > 0)
            {
                btnXoaNL.Enabled = true;
                btnXoaNL.BackColor = Color.Red;
                btnXoaNL.ForeColor = Color.White;
            }
        }


        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (dgvCongThuc.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Xóa các nguyên liệu đang chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Duyệt ngược để xóa không bị lỗi index
                    for (int i = dgvCongThuc.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        int index = dgvCongThuc.SelectedRows[i].Index;
                        _listCongThucTam.RemoveAt(index);
                    }
                    HienThiLuoiCongThuc();
                }
            }
        }

        #endregion






    }
}