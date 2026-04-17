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

            LamMoiGiaoDien();
        }

        private void ThietLapLuoi()
        {
            dgvKhuyenMai.AutoGenerateColumns = false;
            dgvKhuyenMai.AllowUserToAddRows = false;
            dgvKhuyenMai.ReadOnly = true;
            dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuyenMai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKm", DataPropertyName = "MaKm", Visible = false });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKm", HeaderText = "Tên Khuyến Mãi", DataPropertyName = "TenKm" });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiKm", HeaderText = "Loại", DataPropertyName = "LoaiKm", Width = 80 }); // Thêm cột hiển thị Loại
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaTri", HeaderText = "Giảm (%)", DataPropertyName = "GiaTri" });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayBatDau", HeaderText = "Từ Ngày", DataPropertyName = "NgayBatDau", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayKetThuc", HeaderText = "Đến Ngày", DataPropertyName = "NgayKetThuc", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", DataPropertyName = "TrangThai" });
        }
            
        private void cboLoaiKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mặc định: Index 0 là "Hóa đơn", Index 1 là "Sản phẩm"
            if (cboLoaiKM.SelectedIndex == 0) // Là Hóa đơn
            {
                clbSanPham.Enabled = false; // Khóa mờ đi
                for (int i = 0; i < clbSanPham.Items.Count; i++) clbSanPham.SetItemChecked(i, false); // Tích bỏ hết
            }
            else // Là Sản phẩm
            {
                clbSanPham.Enabled = true; // Sáng lên cho chọn
            }
        }

        private void LamMoiGiaoDien()
        {
            txtTenKM.Clear();
            txtMoTa.Clear();
            txtGiaTri.Clear();
            cboTrangThai_KM.Text = "Đang áp dụng";
            cboLoaiKM.Text = "Hóa đơn"; // Mặc định là Hóa đơn

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
                    txtGiaTri.Text = kmChon.GiaTri.ToString("N0");
                    cboLoaiKM.Text = kmChon.LoaiKm ?? "Hóa đơn"; // Load Loại KM
                    dtpNgayBatDau.Value = kmChon.NgayBatDau.ToDateTime(TimeOnly.MinValue);
                    dtpNgayKetThuc.Value = kmChon.NgayKetThuc.ToDateTime(TimeOnly.MinValue);
                    cboTrangThai_KM.Text = kmChon.TrangThai ?? "Đang áp dụng";

                    // Load các dấu tick
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

            // --- LẤY VÀ KIỂM TRA MÓN ĂN ---
            List<int> danhSachSpDuocChon = new List<int>();

            // Nếu chọn "Sản phẩm" (Index == 1)
            if (cboLoaiKM.SelectedIndex == 1)
            {
                foreach (var item in clbSanPham.CheckedItems)
                {
                    SanPham sp = (SanPham)item;
                    danhSachSpDuocChon.Add(sp.MaSp);
                }

                // RÀNG BUỘC THÉP: Nếu là KM Sản phẩm thì BẮT BUỘC phải có đồ ăn
                if (danhSachSpDuocChon.Count == 0)
                {
                    MessageBox.Show("LỖI: Bạn đã chọn loại KM là 'Sản phẩm', vui lòng tích chọn ít nhất 1 sản phẩm ở danh sách bên cạnh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // CHẶN LẠI NGAY LẬP TỨC, KHÔNG CHO LƯU
                }
            }

            // --- TIẾN HÀNH LƯU ---
            bool isSuccess = false;
            string loaiKmDb = cboLoaiKM.Text; // Lấy chữ Hóa đơn hoặc Sản phẩm
            string trangThai = cboTrangThai_KM.Text;

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
                    TrangThai = trangThai
                };
                isSuccess = _service.ThemKhuyenMai(kmMoi, danhSachSpDuocChon);
                if (isSuccess) MessageBox.Show("Đã thêm Khuyến mãi thành công!");
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

                isSuccess = _service.CapNhatKhuyenMai(kmDangChon, danhSachSpDuocChon);
                if (isSuccess) MessageBox.Show("Cập nhật thành công!");
            }

            if (isSuccess)
            {
                MessageBox.Show(btnLuu.Tag == null ? "Đã thêm Khuyến mãi thành công!" : "Cập nhật Khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiGiaoDien();
            }
            // NẾU THẤT BẠI MÀ KHÔNG CÓ THÔNG BÁO LỖI TỪ DB, THÌ BÁO CHUNG CHUNG
            else
            {
                // Thông báo này đề phòng trường hợp lỗi ngầm
                MessageBox.Show("Lưu thất bại! Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnLuu.Tag != null)
            {
                KhuyenMai kmChon = (KhuyenMai)btnLuu.Tag;

                // Hỏi lại cho chắc ăn
                var xacNhan = MessageBox.Show($"Bạn có chắc chắn muốn xóa khuyến mãi '{kmChon.TenKm}' không?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (xacNhan == DialogResult.Yes)
                {
                    // Gọi hàm Xóa Thông Minh ở Service
                    string thongBao = _service.XoaKhuyenMaiAnToan(kmChon.MaKm);

                    // Hiện kết quả (Báo Xóa vĩnh viễn hay Ẩn)
                    MessageBox.Show(thongBao, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset lại màn hình cho sạch sẽ
                    LamMoiGiaoDien();
                }
            }
        }
    }
}