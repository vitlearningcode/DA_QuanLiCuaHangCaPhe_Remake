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
        #region Khai báo service

        // Service xử lý CRUD khuyến mãi (thêm, sửa, xóa, lấy danh sách)
        private readonly KhuyenMaiService _service   = new KhuyenMaiService();
        // Service lấy danh sách sản phẩm để chọn khi tạo KM loại "Sản Phẩm"
        private readonly SanPhamService   _spService = new SanPhamService();

        #endregion

        #region Khởi tạo & Load

        public UC_KhuyenMai()
        {
            InitializeComponent();
        }

        // Load: thiết lập lưới, nạp danh sách sản phẩm vào CheckedListBox, đăng ký tô màu lưới
        private void UC_KhuyenMai_Load(object sender, EventArgs e)
        {
            ThietLapLuoi();

            // Nạp toàn bộ sản phẩm vào list để tích chọn khi tạo KM loại "Sản Phẩm"
            var listMon = _spService.LayDanhSachMonAn();
            ((ListBox)clbSanPham).DataSource    = listMon;
            ((ListBox)clbSanPham).DisplayMember = "TenSp";
            ((ListBox)clbSanPham).ValueMember   = "MaSp";

            // Đăng ký sự kiện tô màu trạng thái khuyến mãi (Đang/Đã/Sắp)
            dgvKhuyenMai.CellFormatting += dgvKhuyenMai_CellFormatting;

            LamMoiGiaoDien(); // Tải dữ liệu lần đầu và reset form nhập
        }

        #endregion

        #region Hàm nội bộ — Thiết lập lưới & làm mới giao diện

        // Cấu hình cột DataGridView: ẩn mã, hiển thị tên / loại / giảm / đối tượng / ngày / trạng thái
        private void ThietLapLuoi()
        {
            dgvKhuyenMai.AutoGenerateColumns = false;
            dgvKhuyenMai.AllowUserToAddRows  = false;
            dgvKhuyenMai.ReadOnly            = true;
            dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuyenMai.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;

            dgvKhuyenMai.Columns.Clear();
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKm",            DataPropertyName = "MaKm",            Visible = false });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKm",            HeaderText = "Tên Khuyến Mãi",       DataPropertyName = "TenKm" });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiKm",           HeaderText = "Loại",                 DataPropertyName = "LoaiKm",           Width = 120 });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaTri",           HeaderText = "Giảm",                 DataPropertyName = "GiaTri",           Width = 80 });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "DoiTuongApDung",   HeaderText = "Áp Dụng Cho",          DataPropertyName = "DoiTuongApDung",   Width = 100 });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayBatDau",       HeaderText = "Từ Ngày",              DataPropertyName = "NgayBatDau",       DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayKetThuc",      HeaderText = "Đến Ngày",             DataPropertyName = "NgayKetThuc",      DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvKhuyenMai.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai",        HeaderText = "Trạng Thái",           DataPropertyName = "TrangThai",        Width = 120 });
        }

        // Reset toàn bộ form nhập về mặc định + tải lại lưới từ DB
        private void LamMoiGiaoDien()
        {
            txtTenKM.Clear();
            txtMoTa.Clear();
            txtGiaTri.Clear();

            cboTrangThai_KM.Text = "Đang áp dụng";
            cboDoiTuong.Text     = "Tất cả";   // Mặc định: áp dụng cho tất cả khách hàng
            cboLoaiKM.Text       = "Hóa Đơn";  // Mặc định: KM theo hóa đơn

            cboLoaiKM_SelectedIndexChanged(null, null); // Cập nhật trạng thái list sản phẩm

            btnXoa.Enabled = false; // Chưa chọn KM nào → không cho xóa
            dtpNgayBatDau.Value  = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now.AddDays(7);

            // Bỏ tích tất cả sản phẩm
            for (int i = 0; i < clbSanPham.Items.Count; i++) clbSanPham.SetItemChecked(i, false);

            // Reset nút Lưu về chế độ "Thêm mới"
            btnLuu.Text      = "THÊM KHUYẾN MÃI";
            btnLuu.BackColor = Color.LightSeaGreen;
            btnLuu.Tag       = null; // null = chế độ thêm mới; có giá trị = chế độ cập nhật

            // Tải lại danh sách từ DB
            dgvKhuyenMai.DataSource = _service.LayDanhSachKhuyenMai();
        }

        #endregion

        #region Sự kiện lưới — Tô màu & chọn dòng để sửa

        // Tô màu cột GiaTri (thêm %) và TrangThai (xanh/đỏ/cam tùy trạng thái)
        private void dgvKhuyenMai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Cột Giảm: format số thập phân + ký hiệu %
            if (dgvKhuyenMai.Columns[e.ColumnIndex].Name == "GiaTri" && e.Value != null)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("0.##") + " %";
                e.FormattingApplied = true;
            }

            // Cột Trạng Thái: màu sắc phản ánh tình trạng khuyến mãi
            if (dgvKhuyenMai.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                e.CellStyle.ForeColor = status switch
                {
                    "Đang áp dụng" => Color.MediumSeaGreen,
                    "Đã kết thúc"  => Color.Crimson,
                    "Sắp diễn ra"  => Color.DarkOrange,
                    _              => e.CellStyle.ForeColor
                };
                e.CellStyle.Font = new Font(dgvKhuyenMai.Font, FontStyle.Bold);
            }
        }

        // Khi chọn dòng lưới → nạp thông tin KM vào form để xem/sửa
        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int maKm = Convert.ToInt32(dgvKhuyenMai.Rows[e.RowIndex].Cells["MaKm"].Value);
            var kmChon = _service.LayDanhSachKhuyenMai().FirstOrDefault(x => x.MaKm == maKm);

            if (kmChon == null) return;

            txtTenKM.Text      = kmChon.TenKm;
            txtMoTa.Text       = kmChon.MoTa;
            txtGiaTri.Text     = kmChon.GiaTri.ToString("0.##");
            cboLoaiKM.Text     = kmChon.LoaiKm ?? "Hóa Đơn";
            dtpNgayBatDau.Value  = kmChon.NgayBatDau.ToDateTime(TimeOnly.MinValue);
            dtpNgayKetThuc.Value = kmChon.NgayKetThuc.ToDateTime(TimeOnly.MinValue);
            cboTrangThai_KM.Text = kmChon.TrangThai ?? "Đang áp dụng";
            // Map giá trị DB ("Thuong") → hiển thị UI ("Thường")
            cboDoiTuong.Text   = MapDbToDisplay(kmChon.DoiTuongApDung);

            // Tích chọn sản phẩm đã gắn với KM này
            for (int i = 0; i < clbSanPham.Items.Count; i++)
            {
                var sp = (SanPham)clbSanPham.Items[i];
                clbSanPham.SetItemChecked(i, kmChon.MaSps.Any(x => x.MaSp == sp.MaSp));
            }

            // Chuyển sang chế độ cập nhật
            btnLuu.Text      = "CẬP NHẬT";
            btnLuu.BackColor = Color.Orange;
            btnLuu.Tag       = kmChon; // Lưu object đang sửa vào Tag của nút
            btnXoa.Enabled   = true;
        }

        #endregion

        #region Sự kiện ComboBox — Loại KM ảnh hưởng list sản phẩm

        // Khi chọn loại "Hóa Đơn" → disable list SP; "Sản Phẩm" → enable để chọn
        private void cboLoaiKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool laSanPham = cboLoaiKM.SelectedIndex != 0; // Index 0 = "Hóa Đơn"
            clbSanPham.Enabled = laSanPham;

            if (!laSanPham)
            {
                // Bỏ tích hết khi chuyển về Hóa Đơn
                for (int i = 0; i < clbSanPham.Items.Count; i++) clbSanPham.SetItemChecked(i, false);
            }
        }

        #endregion

        #region Sự kiện CRUD khuyến mãi — Lưu / Xóa / Làm mới

        // Nút Làm Mới → reset về trạng thái ban đầu
        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoiGiaoDien();

        // LƯU: Thêm mới (btnLuu.Tag == null) hoặc Cập nhật (btnLuu.Tag có giá trị)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtTenKM.Text)) { MessageBox.Show("Vui lòng nhập tên KM!"); return; }
            if (cboLoaiKM.SelectedIndex == -1)             { MessageBox.Show("Vui lòng chọn Loại KM!"); return; }
            if (dtpNgayKetThuc.Value.Date < dtpNgayBatDau.Value.Date) { MessageBox.Show("Ngày kết thúc không hợp lệ!"); return; }

            if (!decimal.TryParse(txtGiaTri.Text.Replace(",", ""), out decimal giaTri) || giaTri <= 0 || giaTri > 100)
            {
                MessageBox.Show("Giá trị % giảm giá phải từ 1 đến 100!"); return;
            }

            // Thu thập danh sách sản phẩm được tích (nếu loại là Sản Phẩm)
            var danhSachSpDuocChon = new List<int>();
            if (cboLoaiKM.Text == "Sản Phẩm")
            {
                foreach (SanPham sp in clbSanPham.CheckedItems)
                    danhSachSpDuocChon.Add(sp.MaSp);

                if (danhSachSpDuocChon.Count == 0)
                {
                    MessageBox.Show("LỖI: Loại KM là 'Sản phẩm', vui lòng tích chọn ít nhất 1 sản phẩm!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            bool isSuccess;
            // Map UI ("Thường") → DB ("Thuong")
            string doiTuongDb = MapDisplayToDb(cboDoiTuong.Text);

            if (btnLuu.Tag == null) // ===== THÊM MỚI =====
            {
                KhuyenMai kmMoi = new KhuyenMai
                {
                    TenKm        = txtTenKM.Text.Trim(),
                    MoTa         = txtMoTa.Text.Trim(),
                    LoaiKm       = cboLoaiKM.Text,
                    GiaTri       = giaTri,
                    NgayBatDau   = DateOnly.FromDateTime(dtpNgayBatDau.Value),
                    NgayKetThuc  = DateOnly.FromDateTime(dtpNgayKetThuc.Value),
                    TrangThai    = cboTrangThai_KM.Text,
                    DoiTuongApDung = doiTuongDb
                };
                isSuccess = _service.ThemKhuyenMai(kmMoi, danhSachSpDuocChon);
            }
            else // ===== CẬP NHẬT =====
            {
                KhuyenMai kmSua = (KhuyenMai)btnLuu.Tag;
                kmSua.TenKm          = txtTenKM.Text.Trim();
                kmSua.MoTa           = txtMoTa.Text.Trim();
                kmSua.LoaiKm         = cboLoaiKM.Text;
                kmSua.GiaTri         = giaTri;
                kmSua.NgayBatDau     = DateOnly.FromDateTime(dtpNgayBatDau.Value);
                kmSua.NgayKetThuc    = DateOnly.FromDateTime(dtpNgayKetThuc.Value);
                kmSua.TrangThai      = cboTrangThai_KM.Text;
                kmSua.DoiTuongApDung = doiTuongDb;
                isSuccess = _service.CapNhatKhuyenMai(kmSua, danhSachSpDuocChon);
            }

            if (isSuccess)
            {
                string thongBao = btnLuu.Tag == null ? "Đã thêm Khuyến mãi thành công!" : "Cập nhật Khuyến mãi thành công!";
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiGiaoDien();
            }
            else
            {
                MessageBox.Show("Lưu thất bại! Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XÓA: Hỏi xác nhận trước khi xóa KM đang chọn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnLuu.Tag == null) return;

            KhuyenMai kmChon = (KhuyenMai)btnLuu.Tag;
            if (MessageBox.Show($"Bạn có chắc muốn xóa khuyến mãi '{kmChon.TenKm}'?",
                                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string ketQua = _service.XoaKhuyenMaiAnToan(kmChon.MaKm);
                MessageBox.Show(ketQua, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiGiaoDien();
            }
        }

        #endregion

        #region Helper — Map 2 chiều giữa DB và UI cho Đối Tượng Áp Dụng

        // DB lưu "Thuong" (không dấu), UI hiển thị "Thường" (có dấu)
        private string MapDbToDisplay(string dbValue) => dbValue switch
        {
            "Thuong" => "Thường",
            _        => dbValue ?? "Tất cả"
        };

        // UI chọn "Thường" → lưu vào DB là "Thuong"
        private string MapDisplayToDb(string displayValue) => displayValue switch
        {
            "Thường" => "Thuong",
            _        => displayValue ?? "Tất cả"
        };

        #endregion
    }
}