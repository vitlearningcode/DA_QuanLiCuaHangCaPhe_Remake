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
            btnKho = new Button();
            btnSanPham = new Button();
            pnlContent = new Panel();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = SystemColors.ActiveCaptionText;
            pnlMenu.Controls.Add(btnKho);
            pnlMenu.Controls.Add(btnSanPham);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(450, 949);
            pnlMenu.TabIndex = 0;
            // 
            // btnKho
            // 
            btnKho.Dock = DockStyle.Top;
            btnKho.FlatStyle = FlatStyle.Flat;
            btnKho.ForeColor = Color.White;
            btnKho.Location = new Point(0, 60);
            btnKho.Name = "btnKho";
            btnKho.Size = new Size(450, 60);
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
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(450, 60);
            btnSanPham.TabIndex = 0;
            btnSanPham.Text = "Quản lý sản phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(450, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(826, 949);
            pnlContent.TabIndex = 1;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 949);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
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
    }
}