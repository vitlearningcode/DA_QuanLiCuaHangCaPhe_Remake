namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    partial class QuanLi
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnTrangOrder = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnNhanVienCaLam = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnKho = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(39, 65, 60); // Màu rêu đậm #27413C
            this.pnlMenu.Controls.Add(this.btnBaoCao);
            this.pnlMenu.Controls.Add(this.btnNhanVienCaLam);
            this.pnlMenu.Controls.Add(this.btnSanPham);
            this.pnlMenu.Controls.Add(this.btnKho);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Controls.Add(this.btnTrangOrder);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(260, 850);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnTrangOrder (Nút Lime ở dưới cùng)
            // 
            this.btnTrangOrder.BackColor = System.Drawing.Color.FromArgb(140, 223, 37); // Lime #8CDF25
            this.btnTrangOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTrangOrder.FlatAppearance.BorderSize = 0;
            this.btnTrangOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangOrder.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnTrangOrder.ForeColor = System.Drawing.Color.FromArgb(6, 12, 17); // Chữ đen cho nổi
            this.btnTrangOrder.Location = new System.Drawing.Point(0, 770);
            this.btnTrangOrder.Name = "btnTrangOrder";
            this.btnTrangOrder.Size = new System.Drawing.Size(260, 80);
            this.btnTrangOrder.TabIndex = 5;
            this.btnTrangOrder.Text = "🛒 VÀO MÀN HÌNH BÁN HÀNG";
            this.btnTrangOrder.UseVisualStyleBackColor = false;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(25, 166, 146); // Teal #19A692
            this.btnBaoCao.Location = new System.Drawing.Point(0, 320);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBaoCao.Size = new System.Drawing.Size(260, 60);
            this.btnBaoCao.TabIndex = 4;
            this.btnBaoCao.Text = "📊 Lập Báo Cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnNhanVienCaLam
            // 
            this.btnNhanVienCaLam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVienCaLam.FlatAppearance.BorderSize = 0;
            this.btnNhanVienCaLam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVienCaLam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNhanVienCaLam.ForeColor = System.Drawing.Color.FromArgb(25, 166, 146);
            this.btnNhanVienCaLam.Location = new System.Drawing.Point(0, 260);
            this.btnNhanVienCaLam.Name = "btnNhanVienCaLam";
            this.btnNhanVienCaLam.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNhanVienCaLam.Size = new System.Drawing.Size(260, 60);
            this.btnNhanVienCaLam.TabIndex = 3;
            this.btnNhanVienCaLam.Text = "🧑‍🍳 Xếp Ca Nhân Sự";
            this.btnNhanVienCaLam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVienCaLam.UseVisualStyleBackColor = true;
            // 
            // btnSanPham
            // 
            this.btnSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSanPham.FlatAppearance.BorderSize = 0;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSanPham.ForeColor = System.Drawing.Color.FromArgb(25, 166, 146);
            this.btnSanPham.Location = new System.Drawing.Point(0, 200);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSanPham.Size = new System.Drawing.Size(260, 60);
            this.btnSanPham.TabIndex = 2;
            this.btnSanPham.Text = "🍔 Menu Sản Phẩm";
            this.btnSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.UseVisualStyleBackColor = true;
            // 
            // btnKho
            // 
            this.btnKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKho.FlatAppearance.BorderSize = 0;
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKho.ForeColor = System.Drawing.Color.FromArgb(25, 166, 146);
            this.btnKho.Location = new System.Drawing.Point(0, 140);
            this.btnKho.Name = "btnKho";
            this.btnKho.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKho.Size = new System.Drawing.Size(260, 60);
            this.btnKho.TabIndex = 1;
            this.btnKho.Text = "📦 Kiểm Kê Kho";
            this.btnKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKho.UseVisualStyleBackColor = true;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(17, 30, 28); // Đen ám xanh lục
            this.pnlLogo.Controls.Add(this.lblSubTitle);
            this.pnlLogo.Controls.Add(this.lblTitle);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(260, 140);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubTitle.Location = new System.Drawing.Point(0, 70);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(260, 30);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "OPERATIONS";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(140, 223, 37); // Lime
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(260, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "COFFEE SHOP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(6, 12, 17); // Đen sâu #060C11
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(260, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1120, 850);
            this.pnlContent.TabIndex = 1;
            // 
            // QuanLi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 850);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Name = "QuanLi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Vận hành (Manager Dashboard)";
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnTrangOrder;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnNhanVienCaLam;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
    }
}