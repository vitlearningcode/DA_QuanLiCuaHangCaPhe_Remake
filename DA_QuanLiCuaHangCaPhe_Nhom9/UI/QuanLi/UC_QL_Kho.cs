using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    public partial class UC_QL_Kho : UserControl
    {
        #region Khai báo service & biến trạng thái

        // Service kho module QuanLi: xem tồn, lập phiếu nhập/xuất (bị phân quyền)
        private readonly QuanLi_KhoService _khoService;

        // Mã NV đang đăng nhập — ghi vào phiếu kho khi chốt
        private readonly string _maNVDangNhap;

        // BindingList → DataGridView tự cập nhật real-time mỗi khi thêm dòng vào _danhSachTam
        private readonly System.ComponentModel.BindingList<ChiTietPhieuView> _danhSachTam
            = new System.ComponentModel.BindingList<ChiTietPhieuView>();

        #endregion

        #region Khởi tạo — Nhận mã NV từ QuanLi.cs

        // Bắt buộc truyền maNV để ghi người lập phiếu chính xác
        public UC_QL_Kho(string maNV)
        {
            InitializeComponent();
            _khoService       = new QuanLi_KhoService();
            _maNVDangNhap     = maNV;
            // Kết nối BindingList ngay từ constructor → lưới tự refresh real-time
            dgvChiTietTam.DataSource = _danhSachTam;
        }

        #endregion

        #region Load form — Thiết lập lưới, tải tồn kho

        private void UC_Load(object sender, EventArgs e)
        {
            ThietLapLuoiKho();
            LoadDanhSachKho();
            // Format cột lưới tạm (bind từ constructor nên cần format sau khi Load)
            DinhDangLuoiChiTiet(dgvChiTietTam);
        }

        #endregion

        #region Hàm nội bộ — Format cột & tải dữ liệu

        // Format tên cột & số tiền cho cả lưới tạm lẫn lưới lịch sử (tái sử dụng)
        private void DinhDangLuoiChiTiet(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            if (dgv.Columns["MaNL"]     != null) dgv.Columns["MaNL"].Visible     = false;
            if (dgv.Columns["TenNL"]    != null) dgv.Columns["TenNL"].HeaderText = "Tên Nguyên Liệu";
            if (dgv.Columns["DonViTinh"]!= null) dgv.Columns["DonViTinh"].HeaderText = "ĐVT";
            if (dgv.Columns["SoLuong"]  != null) dgv.Columns["SoLuong"].HeaderText  = "Số Lượng";
            if (dgv.Columns["GiaNhap"]  != null)
            {
                dgv.Columns["GiaNhap"].HeaderText                   = "Giá Nhập";
                dgv.Columns["GiaNhap"].DefaultCellStyle.Format      = "N0";
            }
            if (dgv.Columns["ThanhTien"] != null)
            {
                dgv.Columns["ThanhTien"].HeaderText                  = "Thành Tiền";
                dgv.Columns["ThanhTien"].DefaultCellStyle.Format     = "N0";
            }
        }

        // Tải lịch sử phiếu nhập/xuất lên lưới lịch sử
        private void LoadLichSuPhieu()
        {
            dgvLichSuPhieu.DataSource = _khoService.XemLichSuPhieu();

            if (dgvLichSuPhieu.Columns.Count > 0)
            {
                dgvLichSuPhieu.Columns["MaPhieu"].HeaderText         = "Mã Phiếu";
                dgvLichSuPhieu.Columns["NgayLap"].HeaderText         = "Ngày Lập";
                dgvLichSuPhieu.Columns["LoaiPhieu"].HeaderText       = "Loại";
                dgvLichSuPhieu.Columns["TenNhanVien"].HeaderText     = "Người Lập Phiếu";
                dgvLichSuPhieu.Columns["TongTien"].HeaderText        = "Tổng Tiền";
                dgvLichSuPhieu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
        }

        // Tải danh sách tồn kho lên lưới Tab Tồn Kho
        private void LoadDanhSachKho() => dgvKho.DataSource = _khoService.LayTatCaNguyenLieu();

        // Tải NL đang kinh doanh vào ComboBox lập phiếu
        private void LoadComboboxNguyenLieu()
        {
            var dsNL = _khoService.LayTatCaNguyenLieu().Where(x => x.TrangThai == "Đang kinh doanh").ToList();
            cboNguyenLieuPhieu.DataSource    = dsNL;
            cboNguyenLieuPhieu.DisplayMember = "TenNl";
            cboNguyenLieuPhieu.ValueMember   = "MaNl";
        }

        #endregion

        #region Logic điều hướng Tab — Tồn Kho / Phiếu

        // Toggle giữa Tab Tồn Kho và Tab Phiếu, load dữ liệu tương ứng
        private void SwitchTab_Click(object sender, EventArgs e)
        {
            bool isKho = ((Button)sender).Name == "btnTabKho";

            btnTabKho.BackColor   = isKho ? Color.FromArgb(45, 64, 89) : Color.White;
            btnTabKho.ForeColor   = isKho ? Color.White : Color.DimGray;
            btnTabPhieu.BackColor = isKho ? Color.White : Color.FromArgb(45, 64, 89);
            btnTabPhieu.ForeColor = isKho ? Color.DimGray : Color.White;

            pnlTonKho.Visible = isKho;
            pnlPhieu.Visible  = !isKho;

            if (isKho) LoadDanhSachKho();
            else { LoadComboboxNguyenLieu(); LoadLichSuPhieu(); }
        }

        #endregion

        #region Tab 1 — Quản lý tồn kho (Xem, sửa ngưỡng, ngừng/mở lại)

        // Cấu hình cột lưới tồn kho
        private void ThietLapLuoiKho()
        {
            dgvKho.AutoGenerateColumns = false;
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNl",          HeaderText = "Mã NL",             DataPropertyName = "MaNl",          Width = 80,  Visible = false });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNl",          HeaderText = "Tên Nguyên Liệu",   DataPropertyName = "TenNl" });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "DonViTinh",      HeaderText = "ĐVT",               DataPropertyName = "DonViTinh",     Width = 100 });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon",     HeaderText = "Tồn Kho",           DataPropertyName = "SoLuongTon",    Width = 150 });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "NguongCanhBao",  HeaderText = "Ngưỡng Cảnh Báo",  DataPropertyName = "NguongCanhBao", Width = 150 });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai",      HeaderText = "Trạng Thái",        DataPropertyName = "TrangThai",     Width = 180 });
        }

        // Tô màu: xám = ngừng KD, đỏ nhạt = dưới ngưỡng cảnh báo
        private void DgvKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKho.Rows[e.RowIndex].DataBoundItem is NguyenLieu nl)
            {
                if (nl.TrangThai == "Ngừng kinh doanh")
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.DarkGray;
                }
                else if (nl.SoLuongTon <= nl.NguongCanhBao)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 238);
                    e.CellStyle.ForeColor = Color.FromArgb(211, 47, 47);
                }
            }
        }

        // Click dòng lưới → nạp vào form sửa ngưỡng và cập nhật text nút Ngừng/Mở
        private void DgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row          = dgvKho.Rows[e.RowIndex];
            txtMaNL.Text     = row.Cells["MaNl"].Value.ToString();
            txtTenNL.Text    = row.Cells["TenNl"].Value?.ToString();
            txtDVT.Text      = row.Cells["DonViTinh"].Value?.ToString();
            numTonKho.Value  = Convert.ToDecimal(row.Cells["SoLuongTon"].Value ?? 0);
            numCanhBao.Value = Convert.ToDecimal(row.Cells["NguongCanhBao"].Value ?? 0);

            bool dangNgung = row.Cells["TrangThai"].Value?.ToString() == "Ngừng kinh doanh";
            btnNgungSuDung.Text      = dangNgung ? "✅ MỞ LẠI" : "🛑 NGỪNG KINH DOANH";
            btnNgungSuDung.BackColor = dangNgung ? Color.FromArgb(23, 162, 184) : Color.FromArgb(220, 53, 69);
        }

        // Làm mới form sửa ngưỡng
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNL.Clear(); txtTenNL.Clear(); txtDVT.Clear();
            numTonKho.Value = numCanhBao.Value = 0;
            dgvKho.ClearSelection();
        }

        // Lưu thông tin nguyên liệu (thêm mới nếu txtMaNL trống, sửa nếu có mã)
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNL.Text) || string.IsNullOrWhiteSpace(txtDVT.Text)) { MessageBox.Show("Vui lòng nhập đủ Tên và Đơn vị tính!", "Cảnh báo"); return; }

            NguyenLieu nl = new NguyenLieu
            {
                MaNl           = string.IsNullOrEmpty(txtMaNL.Text) ? 0 : int.Parse(txtMaNL.Text),
                TenNl          = txtTenNL.Text.Trim(),
                DonViTinh      = txtDVT.Text.Trim(),
                SoLuongTon     = numTonKho.Value,
                NguongCanhBao  = numCanhBao.Value,
                TrangThai      = "Đang kinh doanh"
            };

            if (_khoService.LuuThongTinNguyenLieu(nl)) { MessageBox.Show("Đã lưu thông tin Nguyên Liệu!", "Thành công"); LoadDanhSachKho(); BtnLamMoi_Click(sender, e); }
            else MessageBox.Show("Lỗi khi lưu dữ liệu!", "Lỗi");
        }

        // Toggle Ngừng / Mở lại nguyên liệu
        private void BtnNgungSuDung_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNL.Text)) return;

            int maNL = int.Parse(txtMaNL.Text);
            if (btnNgungSuDung.Text == "🛑 NGỪNG KINH DOANH") { if (_khoService.NgungSuDungNguyenLieu(maNL)) LoadDanhSachKho(); }
            else { if (_khoService.MoLaiNguyenLieu(maNL)) LoadDanhSachKho(); }
        }

        #endregion

        #region Tab 2 — Lập phiếu nhập / xuất kho

        // Thay đổi loại phiếu (Nhập / Xuất) → ẩn/hiện ô giá nhập
        private void RadLoaiPhieu_CheckedChanged(object sender, EventArgs e)
        {
            numGiaNhap.Enabled = radNhap.Checked; // Xuất → giá tự lấy từ DB
            if (radXuat.Checked) numGiaNhap.Value = 0;
        }

        // Thêm dòng nguyên liệu vào _danhSachTam: merge nếu đã có, validate nếu xuất
        private void BtnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (cboNguyenLieuPhieu.SelectedValue == null) return;
            if (numSLPhieu.Value <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo"); return; }
            if (radNhap.Checked && numGiaNhap.Value <= 0) { MessageBox.Show("Vui lòng nhập giá cho Phiếu Nhập!", "Cảnh báo"); return; }

            int maNL = Convert.ToInt32(cboNguyenLieuPhieu.SelectedValue);
            decimal giaThucTe = numGiaNhap.Value;

            if (radXuat.Checked)
            {
                // Kiểm tra tồn kho đủ xuất không
                var nlThucTe = _khoService.LayTatCaNguyenLieu().FirstOrDefault(x => x.MaNl == maNL);
                if (nlThucTe != null)
                {
                    decimal slDaThemTam = _danhSachTam.Where(x => x.MaNL == maNL).Sum(x => x.SoLuong);
                    if (nlThucTe.SoLuongTon < slDaThemTam + numSLPhieu.Value) { MessageBox.Show($"Trong kho chỉ còn {nlThucTe.SoLuongTon} {nlThucTe.DonViTinh}.\nKhông đủ để xuất!", "Cảnh báo"); return; }
                }

                giaThucTe = _khoService.LayGiaNhapGanNhat(maNL);
                if (giaThucTe == 0 && MessageBox.Show("Nguyên liệu chưa từng được nhập kho (Giá vốn = 0). Vẫn muốn xuất?", "Cảnh báo giá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            }

            // Merge nếu đã có trong giỏ tạm, thêm mới nếu chưa có
            var existing = _danhSachTam.FirstOrDefault(x => x.MaNL == maNL);
            if (existing != null)
            {
                existing.SoLuong += numSLPhieu.Value;
                if (radNhap.Checked) existing.GiaNhap = giaThucTe;
            }
            else
            {
                _danhSachTam.Add(new ChiTietPhieuView
                {
                    MaNL       = maNL,
                    TenNL      = cboNguyenLieuPhieu.Text,
                    DonViTinh  = _khoService.LayTatCaNguyenLieu().FirstOrDefault(x => x.MaNl == maNL)?.DonViTinh,
                    SoLuong    = numSLPhieu.Value,
                    GiaNhap    = giaThucTe
                });
            }

            numSLPhieu.Value = 0;
            if (radNhap.Checked) numGiaNhap.Value = 0;
        }

        // Click dòng lịch sử phiếu → hiển thị chi tiết ở lưới bên dưới
        private void DgvLichSuPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int maPhieu = Convert.ToInt32(dgvLichSuPhieu.Rows[e.RowIndex].Cells["MaPhieu"].Value);
            dgvChiTietLichSu.DataSource = _khoService.XemChiTietPhieu(maPhieu);
            DinhDangLuoiChiTiet(dgvChiTietLichSu);
        }

        // Chốt phiếu: lưu xuống DB, reset giỏ tạm, refresh lịch sử và tồn kho
        private void BtnChotPhieu_Click(object sender, EventArgs e)
        {
            if (_danhSachTam.Count == 0) { MessageBox.Show("Danh sách nguyên liệu đang trống!", "Cảnh báo"); return; }

            string loaiPhieu = radNhap.Checked ? "Nhap" : "Xuat";
            if (_khoService.ChotPhieuKho(_maNVDangNhap, loaiPhieu, new List<ChiTietPhieuView>(_danhSachTam)))
            {
                MessageBox.Show($"Chốt Phiếu {loaiPhieu} thành công!", "Hoàn tất");
                _danhSachTam.Clear();
                LoadLichSuPhieu();
                LoadDanhSachKho();
            }
            else MessageBox.Show("Có lỗi xảy ra khi lưu phiếu vào CSDL!", "Lỗi Transaction");
        }

        #endregion
    }
}