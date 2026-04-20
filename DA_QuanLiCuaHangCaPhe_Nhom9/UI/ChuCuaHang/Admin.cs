using DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class Admin : Form
    {
        #region Khởi tạo & Load

        // Mã NV Admin đang đăng nhập — nhận từ Loginform và truyền xuống các UC cần ghi nhận người lập phiếu
        private readonly string _maNVAdmin;

        public Admin(string maNV = "")
        {
            InitializeComponent();
            _maNVAdmin = maNV;
        }

        // Load form: tự động mở trang Tổng Quan để có nội dung ngay khi khởi động
        private void Admin_Load(object sender, EventArgs e)
        {
            OpenChildControl(new UC_TongQuan());
        }

        #endregion

        #region Hàm nội bộ — Nạp UserControl vào khung nội dung

        // Xóa nội dung cũ trong pnlContent và nạp UC mới vào, luôn đưa lên trên cùng
        private void OpenChildControl(UserControl childControl)
        {
            childControl.Dock = DockStyle.Fill; // UC lấp đầy khung
            pnlContent.Controls.Clear();        // Xóa màn hình cũ
            pnlContent.Controls.Add(childControl);
            pnlContent.Tag = childControl;      // Ghi lại UC đang hiển thị (dùng debug nếu cần)
            childControl.BringToFront();
        }

        #endregion

        #region Điều hướng menu — Click các nút bên trái

        // Mỗi nút menu tương ứng với một màn hình quản lý riêng
        private void btnSanPham_Click(object sender, EventArgs e)        => OpenChildControl(new UC_SanPham());
        private void btnKho_Click(object sender, EventArgs e)             => OpenChildControl(new UC_Kho(_maNVAdmin));
        private void btnNhanVien_Click(object sender, EventArgs e)        => OpenChildControl(new UC_NhanVien());
        private void btnKhuyenMai_Click(object sender, EventArgs e)       => OpenChildControl(new UC_KhuyenMai());
        private void button1_Click(object sender, EventArgs e)            => OpenChildControl(new UC_ThongKe());
        private void btnTongQuan_Click(object sender, EventArgs e)        => OpenChildControl(new UC_TongQuan());
        private void btnSoQuy_Click(object sender, EventArgs e)           => OpenChildControl(new UC_SoQuy(_maNVAdmin));
        private void btnKhachHang_Click(object sender, EventArgs e)       => OpenChildControl(new UC_KhachHang());
        private void btnSaoLuuPhucHoi_Click(object sender, EventArgs e)   => OpenChildControl(new UC_SaoLuuPhucHoi());

        #endregion

        #region Đăng xuất

        // Hỏi xác nhận trước khi đóng form — Loginform tự hiện lại qua FormClosed event (đã đăng ký ở Loginform)
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
