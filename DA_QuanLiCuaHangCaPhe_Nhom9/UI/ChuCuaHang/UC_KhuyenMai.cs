using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_KhuyenMai : UserControl
    {
        private readonly KhuyenMaiService _service = new KhuyenMaiService();
        private readonly SanPhamService _spService = new SanPhamService();

        public UC_KhuyenMai()
        {
            InitializeComponent();
        }

        private void UC_KhuyenMai_Load(object sender, EventArgs e)
        {
            ThietLapLuoi();

            var listMon = _spService.LayDanhSachMonAn();
            ((ListBox)clbSanPham).DataSource = listMon;
            ((ListBox)clbSanPham).DisplayMember = "TenSp";
            ((ListBox)clbSanPham).ValueMember = "MaSp";

            // Đăng ký sự kiện tô màu cho lưới
            dgvKhuyenMai.CellFormatting += dgvKhuyenMai_CellFormatting;

            LamMoiGiaoDien();
        }

        private void ThietLapLuoi()
        {
            dgvKhuyenMai.AutoGenerateColumns = false;
            dgvKhuyenMai.AllowUserToAddRows = false;
            dgvKhuyenMai.ReadOnly = true;
            dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuyenMai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvKhuyenMai.Columns.Clear(); // Chống lỗi duplicate khi load lại
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKm", DataPropertyName = "MaKm", Visible = false });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKm", HeaderText = "Tên Khuyến Mãi", DataPropertyName = "TenKm" });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiKm", HeaderText = "Loại", DataPropertyName = "LoaiKm", Width = 120 });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaTri", HeaderText = "Giảm", DataPropertyName = "GiaTri", Width = 80 });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "DoiTuongApDung", HeaderText = "Áp Dụng Cho", DataPropertyName = "DoiTuongApDung", Width = 100 });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayBatDau", HeaderText = "Từ Ngày", DataPropertyName = "NgayBatDau", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayKetThuc", HeaderText = "Đến Ngày", DataPropertyName = "NgayKetThuc", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 120 });

        }

        // NÂNG CẤP: Tự động tô màu và format %
        private void dgvKhuyenMai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhuyenMai.Columns[e.ColumnIndex].Name == "GiaTri" && e.Value != null)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("0.##") + " %";
                e.FormattingApplied = true;
            }

            if (dgvKhuyenMai.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Đang áp dụng") e.CellStyle.ForeColor = Color.MediumSeaGreen;
                else if (status == "Đã kết thúc") e.CellStyle.ForeColor = Color.Crimson;
                else if (status == "Sắp diễn ra") e.CellStyle.ForeColor = Color.DarkOrange;

                e.CellStyle.Font = new Font(dgvKhuyenMai.Font, FontStyle.Bold);
            }
        }

        private void cboLoaiKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiKM.SelectedIndex == 0) // Là Hóa đơn
            {
                clbSanPham.Enabled = false;
                for (int i = 0; i < clbSanPham.Items.Count; i++) clbSanPham.SetItemChecked(i, false);
            }
            else // Là Sản phẩm
            {
                clbSanPham.Enabled = true;
            }
        }

        private void LamMoiGiaoDien()
        {
            txtTenKM.Clear();
            txtMoTa.Clear();
            txtGiaTri.Clear();

            // Xóa Trạng thái vì nó sẽ tự động tính
            cboTrangThai_KM.Text = "Đang áp dụng";
            cboDoiTuong.Text = "Tất cả"; // Đặt mặc định
            cboLoaiKM.Text = "Hóa Đơn"; // Khớp với Database của bro

            cboLoaiKM_SelectedIndexChanged(null, null);
            btnXoa.Enabled = false;

            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now.AddDays(7);

            for (int i = 0; i < clbSanPham.Items.Count; i++) clbSanPham.SetItemChecked(i, false);

            btnLuu.Text = "THÊM KHUYẾN MÃI";
            btnLuu.BackColor = Color.LightSeaGreen;
            btnLuu.Tag = null;

            dgvKhuyenMai.DataSource = _service.LayDanhSachKhuyenMai();
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoiGiaoDien(); }

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maKm = Convert.ToInt32(dgvKhuyenMai.Rows[e.RowIndex].Cells["MaKm"].Value);
                var kmChon = _service.LayDanhSachKhuyenMai().FirstOrDefault(x => x.MaKm == maKm);

                if (kmChon != null)
                {
                    txtTenKM.Text = kmChon.TenKm;
                    txtMoTa.Text = kmChon.MoTa;
                    txtGiaTri.Text = kmChon.GiaTri.ToString("0.##");
                    cboLoaiKM.Text = kmChon.LoaiKm ?? "Hóa Đơn";
                    dtpNgayBatDau.Value = kmChon.NgayBatDau.ToDateTime(TimeOnly.MinValue);
                    dtpNgayKetThuc.Value = kmChon.NgayKetThuc.ToDateTime(TimeOnly.MinValue);
                    cboTrangThai_KM.Text = kmChon.TrangThai ?? "Đang áp dụng";
                    cboDoiTuong.Text = kmChon.DoiTuongApDung ?? "Tất cả";

                    for (int i = 0; i < clbSanPham.Items.Count; i++)
                    {
                        var spTrongList = (SanPham)clbSanPham.Items[i];
                        bool isChecked = kmChon.MaSps.Any(x => x.MaSp == spTrongList.MaSp);
                        clbSanPham.SetItemChecked(i, isChecked);
                    }

                    btnLuu.Text = "CẬP NHẬT";
                    btnLuu.BackColor = Color.Orange;
                    btnLuu.Tag = kmChon;
                    btnXoa.Enabled = true;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKM.Text)) { MessageBox.Show("Vui lòng nhập tên KM!"); return; }
            if (cboLoaiKM.SelectedIndex == -1) { MessageBox.Show("Vui lòng chọn Loại KM!"); return; }
            if (dtpNgayKetThuc.Value.Date < dtpNgayBatDau.Value.Date) { MessageBox.Show("Ngày kết thúc không hợp lệ!"); return; }

            decimal giaTri = 0;
            if (!decimal.TryParse(txtGiaTri.Text.Replace(",", ""), out giaTri) || giaTri <= 0 || giaTri > 100)
            {
                MessageBox.Show("Giá trị % giảm giá phải từ 1 đến 100!"); return;
            }

            List<int> danhSachSpDuocChon = new List<int>();

            if (cboLoaiKM.Text == "Sản Phẩm")
            {
                foreach (var item in clbSanPham.CheckedItems)
                {
                    SanPham sp = (SanPham)item;
                    danhSachSpDuocChon.Add(sp.MaSp);
                }

                if (danhSachSpDuocChon.Count == 0)
                {
                    MessageBox.Show("LỖI: Bạn đã chọn loại KM là 'Sản phẩm', vui lòng tích chọn ít nhất 1 sản phẩm ở danh sách bên cạnh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            bool isSuccess = false;
            string loaiKmDb = cboLoaiKM.Text;
            string trangThai = cboTrangThai_KM.Text;
            string cboDT = cboDoiTuong.Text;

            if (btnLuu.Tag == null) // THÊM MỚI
            {
                KhuyenMai kmMoi = new KhuyenMai
                {
                    TenKm = txtTenKM.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    LoaiKm = loaiKmDb,
                    GiaTri = giaTri,
                    NgayBatDau = DateOnly.FromDateTime(dtpNgayBatDau.Value),
                    NgayKetThuc = DateOnly.FromDateTime(dtpNgayKetThuc.Value),
                    TrangThai = trangThai,
                    DoiTuongApDung = cboDT
                };
                isSuccess = _service.ThemKhuyenMai(kmMoi, danhSachSpDuocChon);
            }
            else // CẬP NHẬT
            {
                KhuyenMai kmDangChon = (KhuyenMai)btnLuu.Tag;
                kmDangChon.TenKm = txtTenKM.Text.Trim();
                kmDangChon.MoTa = txtMoTa.Text.Trim();
                kmDangChon.LoaiKm = loaiKmDb;
                kmDangChon.GiaTri = giaTri;
                kmDangChon.NgayBatDau = DateOnly.FromDateTime(dtpNgayBatDau.Value);
                kmDangChon.NgayKetThuc = DateOnly.FromDateTime(dtpNgayKetThuc.Value);
                kmDangChon.TrangThai = trangThai;
                kmDangChon.DoiTuongApDung = cboDT;

                isSuccess = _service.CapNhatKhuyenMai(kmDangChon, danhSachSpDuocChon);
            }

            if (isSuccess)
            {
                MessageBox.Show(btnLuu.Tag == null ? "Đã thêm Khuyến mãi thành công!" : "Cập nhật Khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiGiaoDien();
            }
            else
            {
                MessageBox.Show("Lưu thất bại! Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnLuu.Tag != null)
            {
                KhuyenMai kmChon = (KhuyenMai)btnLuu.Tag;
                var xacNhan = MessageBox.Show($"Bạn có chắc chắn muốn xóa khuyến mãi '{kmChon.TenKm}' không?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (xacNhan == DialogResult.Yes)
                {
                    string thongBao = _service.XoaKhuyenMaiAnToan(kmChon.MaKm);
                    MessageBox.Show(thongBao, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiGiaoDien();
                }
            }
        }
    }
}