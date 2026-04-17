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
            button1 = new Button();
            btnKhuyenMai = new Button();
            btnNhanVien = new Button();
            btnKho = new Button();
            btnSanPham = new Button();
            pnlContent = new Panel();
            btnTongQuan = new Button();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = SystemColors.ActiveCaptionText;
            pnlMenu.Controls.Add(btnTongQuan);
            pnlMenu.Controls.Add(button1);
            pnlMenu.Controls.Add(btnKhuyenMai);
            pnlMenu.Controls.Add(btnNhanVien);
            pnlMenu.Controls.Add(btnKho);
            pnlMenu.Controls.Add(btnSanPham);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(1, 1, 1, 1);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(185, 363);
            pnlMenu.TabIndex = 0;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 88);
            button1.Margin = new Padding(1, 1, 1, 1);
            button1.Name = "button1";
            button1.Size = new Size(185, 22);
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
            btnKhuyenMai.Location = new Point(0, 66);
            btnKhuyenMai.Margin = new Padding(1, 1, 1, 1);
            btnKhuyenMai.Name = "btnKhuyenMai";
            btnKhuyenMai.Size = new Size(185, 22);
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
            btnNhanVien.Location = new Point(0, 44);
            btnNhanVien.Margin = new Padding(1, 1, 1, 1);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(185, 22);
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
            btnKho.Location = new Point(0, 22);
            btnKho.Margin = new Padding(1, 1, 1, 1);
            btnKho.Name = "btnKho";
            btnKho.Size = new Size(185, 22);
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
            btnSanPham.Margin = new Padding(1, 1, 1, 1);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(185, 22);
            btnSanPham.TabIndex = 0;
            btnSanPham.Text = "Quản lý sản phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(185, 0);
            pnlContent.Margin = new Padding(1, 1, 1, 1);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(592, 363);
            pnlContent.TabIndex = 1;
            // 
            // btnTongQuan
            // 
            btnTongQuan.Dock = DockStyle.Top;
            btnTongQuan.FlatStyle = FlatStyle.Flat;
            btnTongQuan.ForeColor = Color.White;
            btnTongQuan.Location = new Point(0, 110);
            btnTongQuan.Margin = new Padding(1);
            btnTongQuan.Name = "btnTongQuan";
            btnTongQuan.Size = new Size(185, 22);
            btnTongQuan.TabIndex = 5;
            btnTongQuan.Text = "Tổng quan";
            btnTongQuan.UseVisualStyleBackColor = true;
            btnTongQuan.Click += btnTongQuan_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 363);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Margin = new Padding(1, 1, 1, 1);
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
    }
}