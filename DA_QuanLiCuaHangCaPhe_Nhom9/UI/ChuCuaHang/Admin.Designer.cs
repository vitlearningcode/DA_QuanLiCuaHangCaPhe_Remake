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
            btnSoQuy = new Button();
            btnTongQuan = new Button();
            button1 = new Button();
            btnKhuyenMai = new Button();
            btnNhanVien = new Button();
            btnKho = new Button();
            btnSanPham = new Button();
            pnlContent = new Panel();
            btnKhachHang = new Button();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = SystemColors.ActiveCaptionText;
            pnlMenu.Controls.Add(btnKhachHang);
            pnlMenu.Controls.Add(btnSoQuy);
            pnlMenu.Controls.Add(btnTongQuan);
            pnlMenu.Controls.Add(button1);
            pnlMenu.Controls.Add(btnKhuyenMai);
            pnlMenu.Controls.Add(btnNhanVien);
            pnlMenu.Controls.Add(btnKho);
            pnlMenu.Controls.Add(btnSanPham);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(2, 3, 2, 3);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(449, 992);
            pnlMenu.TabIndex = 0;
            // 
            // btnSoQuy
            // 
            btnSoQuy.Dock = DockStyle.Top;
            btnSoQuy.FlatStyle = FlatStyle.Flat;
            btnSoQuy.ForeColor = Color.White;
            btnSoQuy.Location = new Point(0, 360);
            btnSoQuy.Margin = new Padding(2, 3, 2, 3);
            btnSoQuy.Name = "btnSoQuy";
            btnSoQuy.Size = new Size(449, 60);
            btnSoQuy.TabIndex = 6;
            btnSoQuy.Text = "Sổ Quỷ";
            btnSoQuy.UseVisualStyleBackColor = true;
            btnSoQuy.Click += btnSoQuy_Click;
            // 
            // btnTongQuan
            // 
            btnTongQuan.Dock = DockStyle.Top;
            btnTongQuan.FlatStyle = FlatStyle.Flat;
            btnTongQuan.ForeColor = Color.White;
            btnTongQuan.Location = new Point(0, 300);
            btnTongQuan.Margin = new Padding(2, 3, 2, 3);
            btnTongQuan.Name = "btnTongQuan";
            btnTongQuan.Size = new Size(449, 60);
            btnTongQuan.TabIndex = 5;
            btnTongQuan.Text = "Tổng quan";
            btnTongQuan.UseVisualStyleBackColor = true;
            btnTongQuan.Click += btnTongQuan_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 240);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(449, 60);
            button1.TabIndex = 4;
            button1.Text = "Thống kê - Báo cáo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnKhuyenMai
            // 
            btnKhuyenMai.Dock = DockStyle.Top;
            btnKhuyenMai.FlatStyle = FlatStyle.Flat;
            btnKhuyenMai.ForeColor = Color.White;
            btnKhuyenMai.Location = new Point(0, 180);
            btnKhuyenMai.Margin = new Padding(2, 3, 2, 3);
            btnKhuyenMai.Name = "btnKhuyenMai";
            btnKhuyenMai.Size = new Size(449, 60);
            btnKhuyenMai.TabIndex = 3;
            btnKhuyenMai.Text = "Quản lý Khuyến Mãi";
            btnKhuyenMai.UseVisualStyleBackColor = true;
            btnKhuyenMai.Click += btnKhuyenMai_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Dock = DockStyle.Top;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Location = new Point(0, 120);
            btnNhanVien.Margin = new Padding(2, 3, 2, 3);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(449, 60);
            btnNhanVien.TabIndex = 2;
            btnNhanVien.Text = "Quản lý Nhân Viên";
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnKho
            // 
            btnKho.Dock = DockStyle.Top;
            btnKho.FlatStyle = FlatStyle.Flat;
            btnKho.ForeColor = Color.White;
            btnKho.Location = new Point(0, 60);
            btnKho.Margin = new Padding(2, 3, 2, 3);
            btnKho.Name = "btnKho";
            btnKho.Size = new Size(449, 60);
            btnKho.TabIndex = 1;
            btnKho.Text = "Quản lý Kho";
            btnKho.UseVisualStyleBackColor = true;
            btnKho.Click += btnKho_Click;
            // 
            // btnSanPham
            // 
            btnSanPham.Dock = DockStyle.Top;
            btnSanPham.FlatStyle = FlatStyle.Flat;
            btnSanPham.ForeColor = Color.White;
            btnSanPham.Location = new Point(0, 0);
            btnSanPham.Margin = new Padding(2, 3, 2, 3);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(449, 60);
            btnSanPham.TabIndex = 0;
            btnSanPham.Text = "Quản lý sản phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(449, 0);
            pnlContent.Margin = new Padding(2, 3, 2, 3);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1438, 992);
            pnlContent.TabIndex = 1;
            // 
            // btnKhachHang
            // 
            btnKhachHang.Dock = DockStyle.Top;
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.Location = new Point(0, 420);
            btnKhachHang.Margin = new Padding(2, 3, 2, 3);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(449, 60);
            btnKhachHang.TabIndex = 7;
            btnKhachHang.Text = "Quản lý Khách Hàng";
            btnKhachHang.UseVisualStyleBackColor = true;
            btnKhachHang.Click += btnKhachHang_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1887, 992);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            pnlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlContent;
        private Button btnSanPham;
        private Button btnKho;
        private Button btnNhanVien;
        private Button btnKhuyenMai;
        private Button button1;
        private Button btnTongQuan;
        private Button btnSoQuy;
        private Button btnKhachHang;
    }
}