using System;
using System.Drawing;
using System.Windows.Forms;
// THÊM DÒNG NÀY ĐỂ FORM CHA THẤY ĐƯỢC CÁC USER CONTROL CỦA QUẢN LÝ
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    public partial class QuanLi : Form
    {
        private string _currentMaNV; // Khớp với kiểu string NVARCHAR(20)
        private Button _currentButton;

        public QuanLi(string maNv = "")
        {
            InitializeComponent();
            _currentMaNV = maNv;
            DangKySuKien();
        }

        private void DangKySuKien()
        {
            // Bắt sự kiện Click cho 4 nút Menu
            btnKho.Click += BtnMenu_Click;
            btnSanPham.Click += BtnMenu_Click;
            btnNhanVienCaLam.Click += BtnMenu_Click;
            btnBaoCao.Click += BtnMenu_Click;

            // Nút mở trang POS Bán hàng
            btnTrangOrder.Click += BtnTrangOrder_Click;
        }

        // ================= HIỆU ỨNG MENU CYBER DARK =================
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_currentButton != (Button)btnSender)
                {
                    DisableButton();
                    _currentButton = (Button)btnSender;
                    _currentButton.BackColor = Color.FromArgb(6, 12, 17); // Nền Đen sâu hòa vào Content
                    _currentButton.ForeColor = Color.FromArgb(140, 223, 37); // Chữ chuyển sang Lime nổi bật
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in pnlMenu.Controls)
            {
                // Bỏ qua nút Trang Order vì nó có màu Lime mặc định sẵn rồi
                if (previousBtn.GetType() == typeof(Button) && previousBtn.Name != "btnTrangOrder")
                {
                    previousBtn.BackColor = Color.FromArgb(39, 65, 60); // Trả về nền Rêu
                    previousBtn.ForeColor = Color.FromArgb(25, 166, 146); // Trả về chữ Teal
                }
            }
        }

        // ================= HÀM NẠP USER CONTROL =================
        private void LoadUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        // ================= ĐIỀU HƯỚNG TỪNG TRANG =================
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActivateButton(btn);

            if (btn.Name == "btnNhanVienCaLam")
            {
                // ĐÃ MỞ KHÓA: Gọi UC Nhân sự & Xếp Ca lên màn hình
                LoadUserControl(new UC_QL_NhanVienCaLam());
            }
            else if (btn.Name == "btnKho")
            {
                // Sẽ nạp UC_QL_Kho vào Turn sau
                LoadUserControl(new UC_QL_Kho(_currentMaNV));
            }
            else if (btn.Name == "btnSanPham")
            {
                // Sẽ nạp UC_QL_SanPham vào Turn sau
                pnlContent.Controls.Clear();
            }
            else if (btn.Name == "btnBaoCao")
            {
                // Sẽ nạp UC_QL_BaoCao vào Turn sau
                pnlContent.Controls.Clear();
            }
        }

        private void BtnTrangOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở màn hình POS Thu ngân!\nNhân sự trực ca: " + _currentMaNV, "Thông báo chuyển trang");

            // TODO: Mở comment đoạn này khi bro ghép xong Form Bán Hàng
            // FormBanHang frm = new FormBanHang(_currentMaNV);
            // frm.Show();
            // this.Hide();
        }
    }
} 