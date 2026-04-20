using System;
using System.Drawing;
using System.Windows.Forms;
// THÊM DÒNG NÀY ĐỂ FORM CHA THẤY ĐƯỢC CÁC USER CONTROL CỦA QUẢN LÝ
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi;
// Tham chiếu tới MainForm đã chuyển vào UI/POS
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.POS;

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
                LoadUserControl(new UC_QL_SanPham());
            }
            else if (btn.Name == "btnBaoCao")
            {
                // 1. Khởi tạo tên mặc định phòng trường hợp lỗi
                string tenNhanVien = "Quản Lí";

                // 2. Lấy tên thật của nhân viên từ CSDL dựa vào _currentMaNV
                if (!string.IsNullOrEmpty(_currentMaNV))
                {
                    try
                    {
                        using (var db = new DA_QuanLiCuaHangCaPhe_Nhom9.Models.DataSqlContext())
                        {
                            // Tìm nhân viên có mã khớp với mã đang đăng nhập
                            var nv = db.NhanViens.FirstOrDefault(n => n.MaNv == _currentMaNV);
                            if (nv != null)
                            {
                                tenNhanVien = nv.TenNv; // Lấy tên thật
                            }
                        }
                    }
                    catch
                    {
                        // Lỗi kết nối thì cứ để mặc định là "Admin", không làm crash app
                    }
                }

                // 3. Nạp UC_QL_BaoCao và truyền cái tên xịn xò vào!
                LoadUserControl(new UC_QL_BaoCao(tenNhanVien));
            }
        }

        private void BtnTrangOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở màn hình POS Thu ngân!", "Thông báo chuyển trang");

            this.Hide();

            // 2. Khởi tạo form Bán Hàng (MainForm)
            MainForm mf = new MainForm(_currentMaNV);

            // 3. Đăng ký sự kiện "Lắng nghe": Khi nào mf bị đóng (bấm nút X), thì chạy đoạn code bên trong
            mf.FormClosed += (s, args) =>
            {
                this.Show(); // Hiện lại form Quản Lý
            };

            // 4. Hiển thị form Bán Hàng (Dùng Show thay vì ShowDialog để luồng app chạy mượt hơn)
            mf.Show();
        }
    }
} 