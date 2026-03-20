using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

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

        #endregion

        #region Event
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

            decimal soLuong, giaNhap;
            // Validate dữ liệu nhập
            if (!decimal.TryParse(txtSoLuongNhap.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0"); return;
            }
            // Ở Tab nhập hàng, ô nhập giá bạn đặt tên là txtGiaNhap (hoặc txtDonGia tùy giao diện)
            // Nhưng quan trọng là gán vào thuộc tính GiaNhap của object
            if (!decimal.TryParse(txtDonGia.Text, out giaNhap) || giaNhap < 0)
            { // Giả sử ô nhập tên là txtDonGia
                MessageBox.Show("Giá nhập không hợp lệ"); return;
            }

            var item = new ChiTietPhieuKho
            {
                MaNl = (int)cboChonNL_Tab2.SelectedValue, // SQL dùng MaNL
                SoLuong = soLuong,
                GiaNhap = giaNhap // <--- ĐÃ SỬA: Dùng GiaNhap thay vì DonGia
            };

            _listChiTietTam.Add(item);
            HienThiListTam();

            // Reset ô nhập
            txtSoLuongNhap.Clear();
            txtDonGia.Clear();
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (_listChiTietTam.Count == 0) return;

            // Tính tổng tiền phiếu (Dùng GiaNhap)
            // Lưu ý ép kiểu (decimal) nếu cột trong DB cho phép null
            decimal tongTien = _listChiTietTam.Sum(x => x.SoLuong * (x.GiaNhap ?? 0));

            PhieuKho phieu = new PhieuKho
            {
                NgayLap = dtpNgayNhap.Value,      // <--- ĐÃ SỬA: Dùng NgayLap
                MaNcc = (int)cboNhaCungCap.SelectedValue,
                LoaiPhieu = "Nhap",               // <--- ĐÃ SỬA: Gán chuỗi "Nhap"
                MaNv = 1, // Gán tạm mã nhân viên đang đăng nhập (sau này lấy từ session)
                          // Trong SQL không có cột TongTien trong bảng PhieuKho? 
                          // Nếu file SQL bạn gửi thiếu update thì bỏ dòng này, 
                          // còn nếu có thì giữ nguyên:
                          // TongTien = tongTien 
            };

            if (_service.NhapKhoChinhThuc(phieu, _listChiTietTam))
            {
                MessageBox.Show("Nhập kho thành công!");
                _listChiTietTam.Clear();
                dgvChiTietNhap.DataSource = null;
                TaiDanhSachKho(); // Refresh lại danh sách để thấy tồn kho tăng
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu phiếu! Vui lòng thử lại.");
            }
        }
        #endregion




        private void dgvNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}