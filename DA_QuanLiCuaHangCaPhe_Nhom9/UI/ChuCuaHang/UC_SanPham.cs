using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin; // Gọi Service
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Drawing;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_SanPham : UserControl
    {
        // Khởi tạo Service
        private readonly SanPhamService _service = new SanPhamService();

        public UC_SanPham()
        {
            InitializeComponent();
        }

        // Sự kiện Load: Chạy khi màn hình vừa mở
        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            TaiDanhSachMonBenTrai();
            TaiNguyenLieuVaoComboBox();
        }

        // Hàm 1: Tạo nút bấm cho từng món ăn
        // SỬA LẠI HÀM NÀY
        private void TaiDanhSachMonBenTrai()
        {
            flpDanhSachMon.Controls.Clear();
            var listMon = _service.LayDanhSachMonAn();

            foreach (var mon in listMon)
            {
                Button btn = new Button();
                // Hiển thị Tên món ở dòng 1, Giá tiền ở dòng 2
                btn.Text = $"{mon.TenSp}\n({mon.DonGia:N0} đ)";

                // --- FIX LỖI 1: TĂNG KÍCH THƯỚC VÀ CĂN CHỈNH ---
                btn.Width = 220;  // Tăng chiều rộng để đủ chỗ cho tên dài
                btn.Height = 100; // Tăng chiều cao
                btn.TextAlign = ContentAlignment.MiddleCenter; // Căn giữa nội dung
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Chữ đậm dễ đọc

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

        // Sự kiện: Khi bấm vào nút món ăn bên trái
        // SỬA LẠI HÀM NÀY
        private void BtnMon_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SanPham monChon = (SanPham)btn.Tag;

            // --- FIX LỖI 2: RESET CÁC Ô NHẬP LIỆU THỪA ---
            // Trước khi load món mới, xóa sạch các ô nhập công thức cũ
            txtSoLuongNL.Clear();
            cboNguyenLieu.SelectedIndex = -1; // Bỏ chọn nguyên liệu đang treo

            // 1. Đổ thông tin món lên giao diện
            txtTenMon.Text = monChon.TenSp;
            txtGiaBan.Text = monChon.DonGia.ToString("N0"); // 25,000
            cboLoai.Text = monChon.LoaiSp;
            cboDonVi.Text = monChon.DonVi;

            // 2. Tải công thức lên lưới
            // Reset datasource về null để đảm bảo lưới sạch sẽ
            dgvCongThuc.DataSource = null;
            var listCongThuc = _service.LayCongThucMon(monChon.MaSp);

            // Nếu món đó có công thức thì mới gán, không thì để trống
            if (listCongThuc != null && listCongThuc.Count > 0)
            {
                dgvCongThuc.DataSource = listCongThuc;

                // --- FIX LỖI 3: CHỈNH LẠI DATAGRIDVIEW CHO ĐẸP ---
                dgvCongThuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự giãn full bề ngang

                // Đặt tên tiếng Việt cho cột
                if (dgvCongThuc.Columns["MaNL"] != null) dgvCongThuc.Columns["MaNL"].Visible = false; // Ẩn cột Mã
                if (dgvCongThuc.Columns["TenNL"] != null) dgvCongThuc.Columns["TenNL"].HeaderText = "Tên Nguyên Liệu";
                if (dgvCongThuc.Columns["SoLuong"] != null) dgvCongThuc.Columns["SoLuong"].HeaderText = "Định Lượng";
                if (dgvCongThuc.Columns["DonViTinh"] != null) dgvCongThuc.Columns["DonViTinh"].HeaderText = "Đơn Vị";

                // Căn giữa tiêu đề cột
                dgvCongThuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Đổi trạng thái nút
            btnLuu.Text = "CẬP NHẬT MÓN";
            btnLuu.BackColor = Color.Orange;
            btnLuu.Tag = monChon; // Lưu món đang sửa vào nút Lưu (để dùng cho logic cập nhật sau này)
        }
    }
}