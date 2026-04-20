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
        private readonly KhoTruyVanDangNhap _loginService = new KhoTruyVanDangNhap();

        // ── Kéo form không border ──
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Loginform()
        {
            InitializeComponent();
        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            // Hover effects cho nút đăng nhập
            btnDangNhap.MouseEnter += (s, _) =>
                btnDangNhap.BackColor = Color.FromArgb(230, 148, 0);
            btnDangNhap.MouseLeave += (s, _) =>
                btnDangNhap.BackColor = Color.FromArgb(255, 165, 0);

            // Focus vào ô username khi mở
            txtUser.Focus();
        }

        // ── Kéo form ──
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) => Application.Exit();

        // ── Hiện / ẩn mật khẩu ──
        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        // ── Enter → đăng nhập ──
        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnDangNhap_Click(sender, e);
        }

        // ── Xử lý đăng nhập chính ──
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                HienThiLoi("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            btnDangNhap.Enabled = false;
            btnDangNhap.Text    = "Đang xác thực...";

            try
            {
                var tk = _loginService.XacThuc(username, password);

                if (tk == null)
                {
                    HienThiLoi("❌  Tên đăng nhập hoặc mật khẩu không đúng!");
                    txtPass.Clear();
                    txtPass.Focus();
                    return;
                }

                // Đăng nhập thành công — routing theo vai trò
                this.Hide();
                DiChuyenTới(tk.TenVaiTro, tk.MaNv);
            }
            catch (Exception ex)
            {
                HienThiLoi("Lỗi kết nối CSDL: " + ex.Message);
            }
            finally
            {
                btnDangNhap.Enabled = true;
                btnDangNhap.Text    = "ĐĂNG NHẬP";
            }
        }

        // ── Routing theo vai trò ──
        private void DiChuyenTới(string tenVaiTro, string maNv)
        {
            Form nextForm;

            switch (tenVaiTro)
            {
                case "Chủ cửa hàng":
                    nextForm = new Admin();
                    break;

                case "Quản lý":
                    nextForm = new QuanLi(maNv);
                    break;

                case "Nhân viên":
                default:
                    var mf = new MainForm(maNv);
                    mf.IsDirectLogin = true; // từ Login → hỏi confirm khi đóng
                    nextForm = mf;
                    break;
            }

            // Khi đóng form con → hiện lại form đăng nhập (reset)
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

        private void HienThiLoi(string msg)
        {
            lblError.Text    = msg;
            lblError.Visible = true;
            // Shake animation nhẹ
            ShakeForm();
        }

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
    }
}