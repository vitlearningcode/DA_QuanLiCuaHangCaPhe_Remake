namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang 
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            lblLogo = new Label();
            pnlMenuItems = new Panel();
            btnKho = new Button();
            btnSanPham = new Button();
            pnlContent = new Panel();
            btnNhanVien = new Button();
            pnlMenu.SuspendLayout();
            pnlMenuItems.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(34, 40, 49);
            pnlMenu.Controls.Add(pnlMenuItems);
            pnlMenu.Controls.Add(lblLogo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(220, 949);
            pnlMenu.TabIndex = 0;
            pnlMenu.Padding = new Padding(12);
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Height = 64;
            lblLogo.Text = "Cửa Hàng";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMenuItems
            // 
            pnlMenuItems.Dock = DockStyle.Fill;
            pnlMenuItems.Location = new Point(12, 76);
            pnlMenuItems.Name = "pnlMenuItems";
            pnlMenuItems.Size = new Size(196, 861);
            pnlMenuItems.TabIndex = 1;
            pnlMenuItems.Padding = new Padding(0, 8, 0, 0);
            // 
            // btnSanPham
            // 
            btnSanPham.Dock = DockStyle.Top;
            btnSanPham.FlatStyle = FlatStyle.Flat;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 81, 181);
            btnSanPham.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSanPham.ForeColor = Color.White;
            btnSanPham.Location = new Point(0, 0);
            btnSanPham.Margin = new Padding(0, 6, 0, 6);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Padding = new Padding(8, 0, 0, 0);
            btnSanPham.Size = new Size(196, 50);
            btnSanPham.TabIndex = 0;
            btnSanPham.Text = "Quản lý sản phẩm";
            btnSanPham.TextAlign = ContentAlignment.MiddleLeft;
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Cursor = Cursors.Hand;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnKho
            // 
            btnKho.Dock = DockStyle.Top;
            btnKho.FlatStyle = FlatStyle.Flat;
            btnKho.FlatAppearance.BorderSize = 0;
            btnKho.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 81, 181);
            btnKho.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnKho.ForeColor = Color.White;
            btnKho.Location = new Point(0, 56);
            btnKho.Margin = new Padding(0, 6, 0, 6);
            btnKho.Name = "btnKho";
            btnKho.Padding = new Padding(8, 0, 0, 0);
            btnKho.Size = new Size(196, 50);
            btnKho.TabIndex = 1;
            btnKho.Text = "Quản lý Kho";
            btnKho.TextAlign = ContentAlignment.MiddleLeft;
            btnKho.UseVisualStyleBackColor = true;
            btnKho.Cursor = Cursors.Hand;
            btnKho.Click += btnKho_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Dock = DockStyle.Top;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 81, 181);
            btnNhanVien.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Location = new Point(0, 112);
            btnNhanVien.Margin = new Padding(0, 6, 0, 6);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Padding = new Padding(8, 0, 0, 0);
            btnNhanVien.Size = new Size(196, 50);
            btnNhanVien.TabIndex = 2;
            btnNhanVien.Text = "Quản lý Nhân Viên";
            btnNhanVien.TextAlign = ContentAlignment.MiddleLeft;
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Cursor = Cursors.Hand;
            btnNhanVien.Click += btnNhanVien_Click;
            // add buttons into menu items panel in order
            pnlMenuItems.Controls.Add(btnNhanVien);
            pnlMenuItems.Controls.Add(btnKho);
            pnlMenuItems.Controls.Add(btnSanPham);
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(250, 250, 252);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1056, 949);
            pnlContent.TabIndex = 2;
            pnlContent.Padding = new Padding(16);
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 949);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Name = "Admin";
            Text = "Quản lý Cửa Hàng - Admin";
            Load += Admin_Load;
            pnlMenu.ResumeLayout(false);
            pnlMenuItems.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlMenuItems;
        private Panel pnlContent;
        private Button btnSanPham;
        private Button btnKho;
        private Button btnNhanVien;
        private Label lblLogo;
    }
}