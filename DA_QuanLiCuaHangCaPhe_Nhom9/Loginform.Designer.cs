namespace DA_QuanLiCuaHangCaPhe_Nhom9
{
    partial class Loginform
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pnlTitleBar  = new System.Windows.Forms.Panel();
            btnClose     = new System.Windows.Forms.Button();
            lblFormTitle = new System.Windows.Forms.Label();
            pnlLeft      = new System.Windows.Forms.Panel();
            lblCup       = new System.Windows.Forms.Label();
            lblAppName   = new System.Windows.Forms.Label();
            lblSlogan    = new System.Windows.Forms.Label();
            pnlRight     = new System.Windows.Forms.Panel();
            lblTitle     = new System.Windows.Forms.Label();
            lblUser      = new System.Windows.Forms.Label();
            txtUser      = new System.Windows.Forms.TextBox();
            lblPass      = new System.Windows.Forms.Label();
            txtPass      = new System.Windows.Forms.TextBox();
            chkShowPass  = new System.Windows.Forms.CheckBox();
            lblError     = new System.Windows.Forms.Label();
            btnDangNhap  = new System.Windows.Forms.Button();
            btnThoat     = new System.Windows.Forms.Button();

            pnlTitleBar.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();

            // ── pnlTitleBar ──────────────────────────────────────
            pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(12, 12, 20);
            pnlTitleBar.Dock      = System.Windows.Forms.DockStyle.Top;
            pnlTitleBar.Height    = 36;
            pnlTitleBar.Controls.Add(lblFormTitle);
            pnlTitleBar.Controls.Add(btnClose);
            pnlTitleBar.MouseDown += TitleBar_MouseDown;

            lblFormTitle.Text      = "Coffee Shop — Đăng Nhập";
            lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(120, 120, 160);
            lblFormTitle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            lblFormTitle.Location  = new System.Drawing.Point(12, 9);
            lblFormTitle.AutoSize  = true;

            btnClose.Text      = "✕";
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.ForeColor = System.Drawing.Color.FromArgb(180, 80, 80);
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnClose.Size      = new System.Drawing.Size(36, 36);
            btnClose.Location  = new System.Drawing.Point(364, 0);
            btnClose.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnClose.Click    += BtnClose_Click;

            // ── pnlLeft (branding) ────────────────────────────────
            pnlLeft.BackColor = System.Drawing.Color.FromArgb(24, 26, 42);
            pnlLeft.Dock      = System.Windows.Forms.DockStyle.Left;
            pnlLeft.Width     = 200;
            pnlLeft.Controls.Add(lblCup);
            pnlLeft.Controls.Add(lblAppName);
            pnlLeft.Controls.Add(lblSlogan);

            lblCup.Text      = "☕";
            lblCup.Font      = new System.Drawing.Font("Segoe UI Emoji", 40F);
            lblCup.ForeColor = System.Drawing.Color.White;
            lblCup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCup.Dock      = System.Windows.Forms.DockStyle.None;
            lblCup.Location  = new System.Drawing.Point(0, 100);
            lblCup.Size      = new System.Drawing.Size(200, 70);

            lblAppName.Text      = "COFFEE SHOP";
            lblAppName.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblAppName.ForeColor = System.Drawing.Color.FromArgb(255, 180, 50);
            lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblAppName.Location  = new System.Drawing.Point(0, 175);
            lblAppName.Size      = new System.Drawing.Size(200, 34);

            lblSlogan.Text      = "Hệ thống quản lý";
            lblSlogan.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            lblSlogan.ForeColor = System.Drawing.Color.FromArgb(130, 140, 170);
            lblSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblSlogan.Location  = new System.Drawing.Point(0, 212);
            lblSlogan.Size      = new System.Drawing.Size(200, 22);

            // ── pnlRight (form nhập) ──────────────────────────────
            pnlRight.BackColor = System.Drawing.Color.FromArgb(18, 18, 30);
            pnlRight.Dock      = System.Windows.Forms.DockStyle.Fill;
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Controls.Add(lblUser);
            pnlRight.Controls.Add(txtUser);
            pnlRight.Controls.Add(lblPass);
            pnlRight.Controls.Add(txtPass);
            pnlRight.Controls.Add(chkShowPass);
            pnlRight.Controls.Add(lblError);
            pnlRight.Controls.Add(btnDangNhap);
            pnlRight.Controls.Add(btnThoat);

            lblTitle.Text      = "Chào mừng trở lại!";
            lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location  = new System.Drawing.Point(30, 50);
            lblTitle.Size      = new System.Drawing.Size(240, 30);

            lblUser.Text      = "Tên đăng nhập";
            lblUser.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblUser.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            lblUser.Location  = new System.Drawing.Point(30, 100);
            lblUser.Size      = new System.Drawing.Size(240, 18);

            txtUser.BackColor   = System.Drawing.Color.FromArgb(30, 32, 50);
            txtUser.ForeColor   = System.Drawing.Color.White;
            txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtUser.Font        = new System.Drawing.Font("Segoe UI", 10F);
            txtUser.Location    = new System.Drawing.Point(30, 122);
            txtUser.Size        = new System.Drawing.Size(240, 27);
            txtUser.Name        = "txtUser";
            txtUser.TextChanged += (s, e) => lblError.Visible = false;

            lblPass.Text      = "Mật khẩu";
            lblPass.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPass.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            lblPass.Location  = new System.Drawing.Point(30, 165);
            lblPass.Size      = new System.Drawing.Size(240, 18);

            txtPass.BackColor             = System.Drawing.Color.FromArgb(30, 32, 50);
            txtPass.ForeColor             = System.Drawing.Color.White;
            txtPass.BorderStyle           = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPass.Font                  = new System.Drawing.Font("Segoe UI", 10F);
            txtPass.UseSystemPasswordChar = true;
            txtPass.Location              = new System.Drawing.Point(30, 187);
            txtPass.Size                  = new System.Drawing.Size(240, 27);
            txtPass.Name                  = "txtPass";
            txtPass.TextChanged          += (s, e) => lblError.Visible = false;
            txtPass.KeyDown              += TxtPass_KeyDown;

            chkShowPass.Text              = "Hiện mật khẩu";
            chkShowPass.ForeColor         = System.Drawing.Color.FromArgb(130, 140, 170);
            chkShowPass.Font              = new System.Drawing.Font("Segoe UI", 8.5F);
            chkShowPass.Location          = new System.Drawing.Point(30, 220);
            chkShowPass.Size              = new System.Drawing.Size(130, 20);
            chkShowPass.CheckedChanged   += ChkShowPass_CheckedChanged;

            lblError.Text      = "❌  Sai tên đăng nhập hoặc mật khẩu!";
            lblError.ForeColor = System.Drawing.Color.FromArgb(220, 80, 80);
            lblError.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            lblError.Location  = new System.Drawing.Point(30, 246);
            lblError.Size      = new System.Drawing.Size(240, 18);
            lblError.Visible   = false;

            btnDangNhap.Text      = "ĐĂNG NHẬP";
            btnDangNhap.BackColor = System.Drawing.Color.FromArgb(255, 165, 0);
            btnDangNhap.ForeColor = System.Drawing.Color.FromArgb(10, 10, 20);
            btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDangNhap.Location  = new System.Drawing.Point(30, 272);
            btnDangNhap.Size      = new System.Drawing.Size(240, 38);
            btnDangNhap.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnDangNhap.Click    += BtnDangNhap_Click;

            btnThoat.Text      = "Thoát ứng dụng";
            btnThoat.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            btnThoat.ForeColor = System.Drawing.Color.FromArgb(140, 140, 170);
            btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Font      = new System.Drawing.Font("Segoe UI", 9F);
            btnThoat.Location  = new System.Drawing.Point(30, 320);
            btnThoat.Size      = new System.Drawing.Size(240, 30);
            btnThoat.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnThoat.Click    += (s, e) => System.Windows.Forms.Application.Exit();

            // ── Form ─────────────────────────────────────────────
            // QUAN TRỌNG: Thứ tự Add controls vào form ảnh hưởng DockStyle
            // WinForms xử lý LIFO: control được add SAU sẽ dock TRƯỚC
            // → Add pnlRight trước (Fill), rồi pnlLeft (Left), cuối cùng pnlTitleBar (Top)
            Controls.Add(pnlRight);     // Fill - added first, docked last
            Controls.Add(pnlLeft);      // Left - docked 2nd
            Controls.Add(pnlTitleBar);  // Top  - added last → docked first (takes priority)

            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);  // 96 DPI baseline
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Dpi; // Scale theo DPI thực tế
            BackColor           = System.Drawing.Color.FromArgb(18, 18, 30); // fallback nếu panel chưa render
            ClientSize          = new System.Drawing.Size(600, 430);
            FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            Name                = "Loginform";
            Text                = "Đăng nhập";
            Load               += Loginform_Load;

            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel    pnlTitleBar;
        private System.Windows.Forms.Label    lblFormTitle;
        private System.Windows.Forms.Button   btnClose;
        private System.Windows.Forms.Panel    pnlLeft;
        private System.Windows.Forms.Label    lblCup;
        private System.Windows.Forms.Label    lblAppName;
        private System.Windows.Forms.Label    lblSlogan;
        private System.Windows.Forms.Panel    pnlRight;
        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblUser;
        private System.Windows.Forms.TextBox  txtUser;
        private System.Windows.Forms.Label    lblPass;
        private System.Windows.Forms.TextBox  txtPass;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Label    lblError;
        private System.Windows.Forms.Button   btnDangNhap;
        private System.Windows.Forms.Button   btnThoat;
    }
}
