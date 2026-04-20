using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Login;
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang;
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.POS;
using DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi;

namespace DA_QuanLiCuaHangCaPhe_Nhom9
{
    public partial class Loginform : Form
    {
        #region Khai báo biến & P/Invoke kéo form

        // Service xác thực tài khoản và lấy thông tin vai trò
        private readonly KhoTruyVanDangNhap _loginService = new KhoTruyVanDangNhap();

        // P/Invoke để hỗ trợ kéo form không có title bar
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        #endregion

        #region Khởi tạo & Load

        public Loginform()
        {
            InitializeComponent();
        }

        // Thiết lập hover effect và focus ban đầu khi form mở
        private void Loginform_Load(object sender, EventArgs e)
        {
            btnDangNhap.MouseEnter += (s, _) => btnDangNhap.BackColor = Color.FromArgb(230, 148, 0);
            btnDangNhap.MouseLeave += (s, _) => btnDangNhap.BackColor = Color.FromArgb(255, 165, 0);
            txtUser.Focus();
        }

        #endregion

        #region Sự kiện kéo form & đóng

        // Kéo form bằng cách giữ chuột trên thanh title bar giả
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        // Thoát toàn bộ ứng dụng (nút X góc trên phải)
        private void BtnClose_Click(object sender, EventArgs e) => Application.Exit();

        #endregion

        #region Sự kiện UI — Hiện/ẩn mật khẩu, phím tắt Enter

        // Toggle hiển thị / ẩn mật khẩu bằng checkbox
        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        // Nhấn Enter ở ô mật khẩu → trigger nút Đăng nhập
        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnDangNhap_Click(sender, e);
        }

        #endregion

        #region Xử lý đăng nhập chính

        // Validate input → gọi service xác thực → routing theo vai trò
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;

            // 1. Validate: không để trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                HienThiLoi("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 2. Disable nút tránh click nhiều lần
            btnDangNhap.Enabled = false;
            btnDangNhap.Text    = "Đang xác thực...";

            try
            {
                // 3. Gọi service LINQ xác thực (join TaiKhoan + NhanVien + VaiTro)
                var tk = _loginService.XacThuc(username, password);

                if (tk == null)
                {
                    HienThiLoi("❌  Tên đăng nhập hoặc mật khẩu không đúng!");
                    txtPass.Clear();
                    txtPass.Focus();
                    return;
                }

                // 4. Đăng nhập thành công → routing
                this.Hide();
                DiChuyenTới(tk.TenVaiTro, tk.MaNv);
            }
            catch (Exception ex)
            {
                HienThiLoi("Lỗi kết nối CSDL: " + ex.Message);
            }
            finally
            {
                // 5. Luôn phục hồi nút dù thành công hay lỗi
                btnDangNhap.Enabled = true;
                btnDangNhap.Text    = "ĐĂNG NHẬP";
            }
        }

        #endregion

        #region Routing — Điều hướng theo vai trò

        // Mở form tương ứng với TenVaiTro từ DB
        // Đăng ký FormClosed để Loginform tự hiện lại khi form con đóng
        private void DiChuyenTới(string tenVaiTro, string maNv)
        {
            Form nextForm;

            switch (tenVaiTro)
            {
                case "Chủ cửa hàng":
                    // Admin: quản lý toàn bộ hệ thống
                    nextForm = new Admin();
                    break;

                case "Quản lý":
                    // Quản lý: xem báo cáo, ca làm, kho, sản phẩm
                    nextForm = new QuanLi(maNv);
                    break;

                case "Nhân viên":
                default:
                    // Nhân viên: màn hình POS bán hàng
                    var mf = new MainForm(maNv);
                    mf.IsDirectLogin = true; // Đánh dấu để FormClosing hỏi xác nhận đăng xuất
                    nextForm = mf;
                    break;
            }

            // Khi form con đóng → show lại Loginform + reset trạng thái
            nextForm.FormClosed += (s, args) =>
            {
                txtUser.Clear();
                txtPass.Clear();
                lblError.Visible = false;
                txtUser.Focus();
                this.Show();
            };

            nextForm.Show();
        }

        #endregion

        #region Hiệu ứng — Thông báo lỗi & Shake animation

        // Hiển thị thông báo lỗi đỏ và rung form nhẹ
        private void HienThiLoi(string msg)
        {
            lblError.Text    = msg;
            lblError.Visible = true;
            ShakeForm();
        }

        // Hiệu ứng rung form ngang khi đăng nhập sai (async không block UI)
        private async void ShakeForm()
        {
            int originX = this.Location.X;
            int[] offsets = { -8, 8, -6, 6, -4, 4, 0 };
            foreach (int offset in offsets)
            {
                this.Location = new Point(originX + offset, this.Location.Y);
                await System.Threading.Tasks.Task.Delay(30);
            }
        }

        #endregion
    }
}