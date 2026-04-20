namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class Admin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnSoQuy = new System.Windows.Forms.Button();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnKhuyenMai = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnKho = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();

            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu (Thanh điều hướng bên trái)
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(41, 53, 65); // Màu xanh đen nhám sang trọng
            this.pnlMenu.Controls.Add(this.btnKhachHang);
            this.pnlMenu.Controls.Add(this.btnSoQuy);
            this.pnlMenu.Controls.Add(this.btnTongQuan);
            this.pnlMenu.Controls.Add(this.button1);
            this.pnlMenu.Controls.Add(this.btnKhuyenMai);
            this.pnlMenu.Controls.Add(this.btnNhanVien);
            this.pnlMenu.Controls.Add(this.btnKho);
            this.pnlMenu.Controls.Add(this.btnSanPham);
            this.pnlMenu.Controls.Add(this.btnDangXuat); // Nút đăng xuất - Dock Bottom
            this.pnlMenu.Controls.Add(this.pnlLogo); // Logo phải add cuối cùng để nó nổi lên trên cùng (Top)
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(280, 850);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKhachHang.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 560);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKhachHang.Size = new System.Drawing.Size(280, 60);
            this.btnKhachHang.TabIndex = 7;
            this.btnKhachHang.Text = "👥  Quản lý Khách Hàng";
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnSoQuy
            // 
            this.btnSoQuy.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSoQuy.FlatAppearance.BorderSize = 0;
            this.btnSoQuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoQuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSoQuy.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSoQuy.Location = new System.Drawing.Point(0, 500);
            this.btnSoQuy.Name = "btnSoQuy";
            this.btnSoQuy.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSoQuy.Size = new System.Drawing.Size(280, 60);
            this.btnSoQuy.TabIndex = 6;
            this.btnSoQuy.Text = "💰  Sổ Quỹ";
            this.btnSoQuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoQuy.UseVisualStyleBackColor = true;
            this.btnSoQuy.Click += new System.EventHandler(this.btnSoQuy_Click);
            // 
            // btnTongQuan
            // 
            this.btnTongQuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTongQuan.FlatAppearance.BorderSize = 0;
            this.btnTongQuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTongQuan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTongQuan.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTongQuan.Location = new System.Drawing.Point(0, 440);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTongQuan.Size = new System.Drawing.Size(280, 60);
            this.btnTongQuan.TabIndex = 5;
            this.btnTongQuan.Text = "🌐  Tổng quan";
            this.btnTongQuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTongQuan.UseVisualStyleBackColor = true;
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(0, 380);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(280, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "📊  Thống kê - Báo cáo";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhuyenMai.FlatAppearance.BorderSize = 0;
            this.btnKhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKhuyenMai.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnKhuyenMai.Location = new System.Drawing.Point(0, 320);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKhuyenMai.Size = new System.Drawing.Size(280, 60);
            this.btnKhuyenMai.TabIndex = 3;
            this.btnKhuyenMai.Text = "🎁  Quản lý Khuyến Mãi";
            this.btnKhuyenMai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhuyenMai.UseVisualStyleBackColor = true;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNhanVien.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 260);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNhanVien.Size = new System.Drawing.Size(280, 60);
            this.btnNhanVien.TabIndex = 2;
            this.btnNhanVien.Text = "🧑‍🍳  Quản lý Nhân Viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnKho
            // 
            this.btnKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKho.FlatAppearance.BorderSize = 0;
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKho.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnKho.Location = new System.Drawing.Point(0, 200);
            this.btnKho.Name = "btnKho";
            this.btnKho.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKho.Size = new System.Drawing.Size(280, 60);
            this.btnKho.TabIndex = 1;
            this.btnKho.Text = "📦  Quản lý Kho";
            this.btnKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKho.UseVisualStyleBackColor = true;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSanPham.FlatAppearance.BorderSize = 0;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSanPham.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSanPham.Location = new System.Drawing.Point(0, 140);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSanPham.Size = new System.Drawing.Size(280, 60);
            this.btnSanPham.TabIndex = 0;
            this.btnSanPham.Text = "🍔  Quản lý Sản Phẩm";
            this.btnSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            //
            // btnDangXuat
            //
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(220, 100, 100);
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(50, 40, 40);
            this.btnDangXuat.Location = new System.Drawing.Point(0, 790);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(280, 60);
            this.btnDangXuat.TabIndex = 9;
            this.btnDangXuat.Text = "🔒  Đăng Xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pnlLogo (Khu vực Logo của cửa hàng)
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(229, 124, 35); // Màu cam cà phê tạo điểm nhấn
            this.pnlLogo.Controls.Add(this.lblStoreName);
            this.pnlLogo.Controls.Add(this.lblIcon);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(280, 140);
            this.pnlLogo.TabIndex = 8;
            // 
            // lblStoreName
            // 
            this.lblStoreName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStoreName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStoreName.ForeColor = System.Drawing.Color.White;
            this.lblStoreName.Location = new System.Drawing.Point(0, 85);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(280, 55);
            this.lblStoreName.TabIndex = 1;
            this.lblStoreName.Text = "COFFEE SHOP";
            this.lblStoreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIcon
            // 
            this.lblIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Location = new System.Drawing.Point(0, 0);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(280, 85);
            this.lblIcon.TabIndex = 0;
            this.lblIcon.Text = "☕";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlContent (Khu vực chứa các màn hình UC)
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(280, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1100, 850);
            this.pnlContent.TabIndex = 1;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 850);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Mở form lên là tự canh giữa màn hình
            this.Text = "Hệ thống Quản lý Cửa hàng Cà Phê";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnKhuyenMai;
        private System.Windows.Forms.Button button1; // Nút thống kê
        private System.Windows.Forms.Button btnTongQuan;
        private System.Windows.Forms.Button btnSoQuy;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnDangXuat;
    }
}