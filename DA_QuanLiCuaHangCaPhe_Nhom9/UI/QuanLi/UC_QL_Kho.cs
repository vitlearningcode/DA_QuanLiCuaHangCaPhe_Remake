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
        private readonly QuanLi_KhoService _khoService = new QuanLi_KhoService();

        // Biến lưu người lập phiếu
        private string _maNVDangNhap;

        // Dùng BindingList thay vì List để DataGridView (dgvChiTietTam) cập nhật Real-time khi thêm món mới
        private System.ComponentModel.BindingList<ChiTietPhieuView> _danhSachTam = new System.ComponentModel.BindingList<ChiTietPhieuView>();

        // CONSTRUCTOR: Bắt buộc phải truyền Mã Nhân Viên vào đây
        public UC_QL_Kho(string maNV)
        {
            InitializeComponent();
            _maNVDangNhap = maNV;

            // Kết nối Data source cho lưới tạm ngay từ đầu
            dgvChiTietTam.DataSource = _danhSachTam;
        }

        private void UC_Load(object sender, EventArgs e)
        {
            ThietLapLuoiKho();
            LoadDanhSachKho();

            // Format tiêu đề cột cho lưới Tạm (Vì nó bind Data ngay từ Constructor)
            DinhDangLuoiChiTiet(dgvChiTietTam);
        }

        // Hàm dùng chung để format cột cho lưới Chi tiết (Lưới tạm & Lưới lịch sử)
        private void DinhDangLuoiChiTiet(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                // --- ĐÃ ẨN MÃ NL Ở ĐÂY ---
                if (dgv.Columns["MaNL"] != null)
                    dgv.Columns["MaNL"].Visible = false;

                if (dgv.Columns["TenNL"] != null)
                    dgv.Columns["TenNL"].HeaderText = "Tên Nguyên Liệu";
                if (dgv.Columns["DonViTinh"] != null)
                    dgv.Columns["DonViTinh"].HeaderText = "ĐVT";

                if (dgv.Columns["SoLuong"] != null)
                    dgv.Columns["SoLuong"].HeaderText = "Số Lượng";

                if (dgv.Columns["GiaNhap"] != null)
                {
                    dgv.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgv.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                }

                if (dgv.Columns["ThanhTien"] != null)
                {
                    dgv.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                    dgv.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
            }
        }

        private void LoadLichSuPhieu()
        {
            dgvLichSuPhieu.DataSource = _khoService.XemLichSuPhieu();

            // Định dạng cột lưới Lịch sử
            if (dgvLichSuPhieu.Columns.Count > 0)
            {
                dgvLichSuPhieu.Columns["MaPhieu"].HeaderText = "Mã Phiếu";
                dgvLichSuPhieu.Columns["NgayLap"].HeaderText = "Ngày Lập";
                dgvLichSuPhieu.Columns["LoaiPhieu"].HeaderText = "Loại";
                dgvLichSuPhieu.Columns["TenNhanVien"].HeaderText = "Người Lập Phiếu";
                dgvLichSuPhieu.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvLichSuPhieu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
        }

        private void DgvLichSuPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maPhieu = Convert.ToInt32(dgvLichSuPhieu.Rows[e.RowIndex].Cells["MaPhieu"].Value);
                dgvChiTietLichSu.DataSource = _khoService.XemChiTietPhieu(maPhieu);
                DinhDangLuoiChiTiet(dgvChiTietLichSu); // Gọi format cột
            }
        }

        // ================== LOGIC ĐIỀU HƯỚNG TAB ==================
        private void SwitchTab_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == "btnTabKho")
            {
                btnTabKho.BackColor = Color.FromArgb(45, 64, 89);
                btnTabKho.ForeColor = Color.White;
                btnTabPhieu.BackColor = Color.White;
                btnTabPhieu.ForeColor = Color.DimGray;

                pnlTonKho.Visible = true;
                pnlPhieu.Visible = false;

                LoadDanhSachKho();
            }
            else
            {
                btnTabPhieu.BackColor = Color.FromArgb(45, 64, 89);
                btnTabPhieu.ForeColor = Color.White;
                btnTabKho.BackColor = Color.White;
                btnTabKho.ForeColor = Color.DimGray;

                pnlPhieu.Visible = true;
                pnlTonKho.Visible = false;

                LoadComboboxNguyenLieu();
                LoadLichSuPhieu();
            }
        }

        // ==========================================================
        // ================== TAB 1: QUẢN LÝ TỒN KHO ================
        // ==========================================================

        private void ThietLapLuoiKho()
        {
            dgvKho.AutoGenerateColumns = false;
            // --- ĐÃ ẨN MÃ NL BẰNG CÁCH SET VISIBLE = FALSE Ở ĐÂY ---
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNl", HeaderText = "Mã NL", DataPropertyName = "MaNl", Width = 80, Visible = false });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNl", HeaderText = "Tên Nguyên Liệu", DataPropertyName = "TenNl" });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "DonViTinh", HeaderText = "ĐVT", DataPropertyName = "DonViTinh", Width = 100 });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon", HeaderText = "Tồn Kho", DataPropertyName = "SoLuongTon", Width = 150 });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "NguongCanhBao", HeaderText = "Ngưỡng Cảnh Báo", DataPropertyName = "NguongCanhBao", Width = 150 });
            dgvKho.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 180 });
        }

        private void LoadDanhSachKho()
        {
            dgvKho.DataSource = _khoService.LayTatCaNguyenLieu();
        }

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

        private void DgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvKho.Rows[e.RowIndex];
                txtMaNL.Text = row.Cells["MaNl"].Value.ToString();
                txtTenNL.Text = row.Cells["TenNl"].Value?.ToString();
                txtDVT.Text = row.Cells["DonViTinh"].Value?.ToString();
                numTonKho.Value = Convert.ToDecimal(row.Cells["SoLuongTon"].Value ?? 0);
                numCanhBao.Value = Convert.ToDecimal(row.Cells["NguongCanhBao"].Value ?? 0);

                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                if (trangThai == "Ngừng kinh doanh")
                {
                    btnNgungSuDung.Text = "✅ MỞ LẠI";
                    btnNgungSuDung.BackColor = Color.FromArgb(23, 162, 184);
                }
                else
                {
                    btnNgungSuDung.Text = "🛑 NGỪNG KINH DOANH";
                    btnNgungSuDung.BackColor = Color.FromArgb(220, 53, 69);
                }
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNL.Clear();
            txtTenNL.Clear();
            txtDVT.Clear();
            numTonKho.Value = 0;
            numCanhBao.Value = 0;
            dgvKho.ClearSelection();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNL.Text) || string.IsNullOrWhiteSpace(txtDVT.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Tên và Đơn vị tính!", "Cảnh báo");
                return;
            }

            var nl = new NguyenLieu
            {
                MaNl = string.IsNullOrEmpty(txtMaNL.Text) ? 0 : int.Parse(txtMaNL.Text),
                TenNl = txtTenNL.Text.Trim(),
                DonViTinh = txtDVT.Text.Trim(),
                SoLuongTon = numTonKho.Value,
                NguongCanhBao = numCanhBao.Value,
                TrangThai = "Đang kinh doanh"
            };

            if (_khoService.LuuThongTinNguyenLieu(nl))
            {
                MessageBox.Show("Đã lưu thông tin Nguyên Liệu!", "Thành công");
                LoadDanhSachKho();
                BtnLamMoi_Click(sender, e);
            }
            else MessageBox.Show("Lỗi khi lưu dữ liệu!", "Lỗi");
        }

        private void BtnNgungSuDung_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNL.Text)) return;
            int maNL = int.Parse(txtMaNL.Text);

            if (btnNgungSuDung.Text == "🛑 NGỪNG KINH DOANH")
            {
                if (_khoService.NgungSuDungNguyenLieu(maNL)) LoadDanhSachKho();
            }
            else
            {
                if (_khoService.MoLaiNguyenLieu(maNL)) LoadDanhSachKho();
            }
        }

        // ==========================================================
        // ================== TAB 2: PHIẾU NHẬP/XUẤT ================
        // ==========================================================

        private void LoadComboboxNguyenLieu()
        {
            var dsNL = _khoService.LayTatCaNguyenLieu().Where(x => x.TrangThai == "Đang kinh doanh").ToList();
            cboNguyenLieuPhieu.DataSource = dsNL;
            cboNguyenLieuPhieu.DisplayMember = "TenNl";
            cboNguyenLieuPhieu.ValueMember = "MaNl";
        }

        private void RadLoaiPhieu_CheckedChanged(object sender, EventArgs e)
        {
            if (radXuat.Checked)
            {
                numGiaNhap.Enabled = false;
                numGiaNhap.Value = 0;
            }
            else
            {
                numGiaNhap.Enabled = true;
            }
        }

        private void BtnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (cboNguyenLieuPhieu.SelectedValue == null) return;
            if (numSLPhieu.Value <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo"); return; }
            if (radNhap.Checked && numGiaNhap.Value <= 0) { MessageBox.Show("Vui lòng nhập giá cho Phiếu Nhập!", "Cảnh báo"); return; }

            int maNL = Convert.ToInt32(cboNguyenLieuPhieu.SelectedValue);
            decimal giaThucTe = numGiaNhap.Value;

            if (radXuat.Checked)
            {
                var nlThucTe = _khoService.LayTatCaNguyenLieu().FirstOrDefault(x => x.MaNl == maNL);
                if (nlThucTe != null)
                {
                    decimal slDaThemTam = _danhSachTam.Where(x => x.MaNL == maNL).Sum(x => x.SoLuong);
                    if (nlThucTe.SoLuongTon < (slDaThemTam + numSLPhieu.Value))
                    {
                        MessageBox.Show($"Trong kho chỉ còn {nlThucTe.SoLuongTon} {nlThucTe.DonViTinh}.\nKhông đủ để xuất!", "Cảnh báo");
                        return;
                    }
                }

                giaThucTe = _khoService.LayGiaNhapGanNhat(maNL);
                if (giaThucTe == 0)
                {
                    if (MessageBox.Show("Nguyên liệu này chưa từng được nhập kho (Giá vốn = 0). Bạn vẫn muốn xuất?", "Cảnh báo giá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }
            }

            var itemCu = _danhSachTam.FirstOrDefault(x => x.MaNL == maNL);
            if (itemCu != null)
            {
                itemCu.SoLuong += numSLPhieu.Value;
                if (radNhap.Checked) itemCu.GiaNhap = giaThucTe;
            }
            else
            {
                _danhSachTam.Add(new ChiTietPhieuView
                {
                    MaNL = maNL,
                    TenNL = cboNguyenLieuPhieu.Text,
                    DonViTinh = _khoService.LayTatCaNguyenLieu().FirstOrDefault(x => x.MaNl == maNL)?.DonViTinh,
                    SoLuong = numSLPhieu.Value,
                    GiaNhap = giaThucTe
                });
            }

            numSLPhieu.Value = 0;
            if (radNhap.Checked) numGiaNhap.Value = 0;
        }

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
            else MessageBox.Show("Có lỗi xảy ra khi lưu phiếu vào cơ sở dữ liệu!", "Lỗi Transaction");
        }
    }
}