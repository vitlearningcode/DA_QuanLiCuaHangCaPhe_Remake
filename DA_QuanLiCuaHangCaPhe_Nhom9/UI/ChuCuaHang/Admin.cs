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
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        // Hàm này dùng để mở một UserControl vào trong pnlContent
        private void OpenChildControl(UserControl childControl)
        {
            childControl.Dock = DockStyle.Fill; // Lấp đầy khung
            pnlContent.Controls.Clear();        // Xóa cái cũ
            pnlContent.Controls.Add(childControl); // Thêm cái mới
            pnlContent.Tag = childControl;
            childControl.BringToFront();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildControl(new UC_SanPham());
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            OpenChildControl(new UC_Kho());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildControl(new UC_NhanVien());
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            OpenChildControl(new UC_KhuyenMai());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildControl(new UC_ThongKe());
        }
    }
}
