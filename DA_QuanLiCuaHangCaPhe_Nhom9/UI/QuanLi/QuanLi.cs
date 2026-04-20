using System;
using System.Drawing;
using System.Windows.Forms;
// UC của module QuanLi
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi;
// MainForm nằm trong UI/POS sau khi tái cấu trúc thư mục
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.POS;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    public partial class QuanLi : Form
    {
        #region Khai báo biến

        // Mã nhân viên đang đăng nhập (kiểu string NVARCHAR(20) — ví dụ: "NV001")
        private string _currentMaNV;

        // Nút menu đang được kích hoạt (để toggle màu active/inactive)
        private Button _currentButton;

        #endregion

        #region Khởi tạo & Đăng ký sự kiện

        public QuanLi(string maNv = "")
        {
            InitializeComponent();
            _currentMaNV = maNv;
            DangKySuKien();
        }

        // Đăng ký click handler cho tất cả nút menu một lần duy nhất trong constructor
        private void DangKySuKien()
        {
            // 4 nút menu điều hướng dùng chung handler BtnMenu_Click
            btnKho.Click             += BtnMenu_Click;
            btnSanPham.Click         += BtnMenu_Click;
            btnNhanVienCaLam.Click   += BtnMenu_Click;
            btnBaoCao.Click          += BtnMenu_Click;

            // Nút đặc biệt: chuyển sang màn hình POS bán hàng
            btnTrangOrder.Click      += BtnTrangOrder_Click;
        }

        #endregion

        #region Hiệu ứng nút menu — Active / Inactive (Cyber Dark style)

        // Kích hoạt nút đang được chọn: đổi màu sang Lime nổi bật trên nền đen
        private void ActivateButton(object btnSender)
        {
            if (btnSender == null) return;

            if (_currentButton != (Button)btnSender)
            {
                DisableButton(); // Tắt màu active của nút cũ trước
                _currentButton = (Button)btnSender;
                _currentButton.BackColor = Color.FromArgb(6, 12, 17);     // Đen sâu (hoà vào pnlContent)
                _currentButton.ForeColor = Color.FromArgb(140, 223, 37);  // Lime nổi bật = đang chọn
            }
        }

        // Reset tất cả nút menu về màu mặc định (Rêu + Teal)
        private void DisableButton()
        {
            foreach (Control ctrl in pnlMenu.Controls)
            {
                // Bỏ qua nút "Vào Bán Hàng" vì nó có màu Lime mặc định riêng
                if (ctrl is Button btn && btn.Name != "btnTrangOrder" && btn.Name != "btnDangXuat")
                {
                    btn.BackColor = Color.FromArgb(39, 65, 60);   // Nền Rêu đậm
                    btn.ForeColor = Color.FromArgb(25, 166, 146); // Chữ Teal
                }
            }
        }

        #endregion

        #region Hàm nội bộ — Nạp UserControl vào pnlContent

        // Xóa nội dung cũ và nạp UserControl mới vào khung hiển thị bên phải
        private void LoadUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;    // UC lấp đầy toàn bộ khung
            pnlContent.Controls.Clear(); // Xóa UC cũ
            pnlContent.Controls.Add(uc);
            uc.BringToFront();           // Đảm bảo UC mới hiển thị trên cùng
        }

        #endregion

        #region Điều hướng menu — Sự kiện BtnMenu_Click

        // Handler chung cho 4 nút menu, phân loại bằng btn.Name
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActivateButton(btn); // Đổi màu nút đang chọn

            if (btn.Name == "btnNhanVienCaLam")
            {
                // Màn hình phân ca và quản lý nhân sự theo ca làm
                LoadUserControl(new UC_QL_NhanVienCaLam());
            }
            else if (btn.Name == "btnKho")
            {
                // Màn hình kiểm kê và nhập xuất kho (truyền mã NV để ghi phiếu)
                LoadUserControl(new UC_QL_Kho(_currentMaNV));
            }
            else if (btn.Name == "btnSanPham")
            {
                // Màn hình xem menu sản phẩm (chỉ view, không sửa)
                LoadUserControl(new UC_QL_SanPham());
            }
            else if (btn.Name == "btnBaoCao")
            {
                // Màn hình lập báo cáo doanh thu — cần tên NV để in tiêu đề
                string tenNhanVien = LayTenNhanVien();
                LoadUserControl(new UC_QL_BaoCao(tenNhanVien));
            }
        }

        // Truy vấn tên nhân viên từ CSDL theo mã hiện tại (dùng cho báo cáo)
        private string LayTenNhanVien()
        {
            string tenNhanVien = "Quản Lí"; // Giá trị mặc định nếu không tìm thấy

            if (string.IsNullOrEmpty(_currentMaNV)) return tenNhanVien;

            try
            {
                using var db = new DA_QuanLiCuaHangCaPhe_Nhom9.Models.DataSqlContext();
                var nv = db.NhanViens.FirstOrDefault(n => n.MaNv == _currentMaNV);
                if (nv != null) tenNhanVien = nv.TenNv;
            }
            catch
            {
                // Lỗi CSDL → dùng tên mặc định, không làm crash app
            }

            return tenNhanVien;
        }

        #endregion

        #region Chuyển sang màn hình POS (Bán hàng)

        // Ẩn QuanLi form, mở MainForm POS với cùng mã NV.
        // Khi MainForm đóng → QuanLi tự hiện lại (IsDirectLogin = false → không hỏi confirm)
        private void BtnTrangOrder_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form Quản Lý (không đóng, chỉ giấu)

            MainForm mf = new MainForm(_currentMaNV);
            // IsDirectLogin = false (mặc định) → đóng thẳng không hỏi confirm

            mf.FormClosed += (s, args) => this.Show(); // Khi POS đóng → hiện lại QuanLi
            mf.Show();
        }

        #endregion

        #region Đăng xuất

        // Hỏi xác nhận trước khi đóng — Loginform tự hiện lại qua FormClosed event (đăng ký ở Loginform)
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
                this.Close();
        }

        #endregion
    }
}