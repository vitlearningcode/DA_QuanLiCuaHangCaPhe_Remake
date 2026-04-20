namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_SaoLuuPhucHoi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblMoTa = new Label();
            lblTieuDe = new Label();
            pnlBody = new Panel();
            pnlLog = new Panel();
            btnXoaLog = new Button();
            rtbLog = new RichTextBox();
            lblLogTitle = new Label();
            pnlPhucHoi = new Panel();
            btnPhucHoi = new Button();
            lblPhucHoiWarning = new Label();
            btnChonFilePhucHoi = new Button();
            txtDuongDanPhucHoi = new TextBox();
            lblFileBak = new Label();
            lblPhucHoiDesc = new Label();
            lblPhucHoiTitle = new Label();
            pnlSaoLuu = new Panel();
            btnSaoLuu = new Button();
            lblSaoLuuHint = new Label();
            btnChonThuMucSaoLuu = new Button();
            txtDuongDanSaoLuu = new TextBox();
            lblThuMuc = new Label();
            lblSaoLuuDesc = new Label();
            lblSaoLuuTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlLog.SuspendLayout();
            pnlPhucHoi.SuspendLayout();
            pnlSaoLuu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(29, 43, 54);
            pnlHeader.Controls.Add(lblMoTa);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(7, 8, 7, 8);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(73, 0, 0, 0);
            pnlHeader.Size = new Size(2302, 246);
            pnlHeader.TabIndex = 1;
            // 
            // lblMoTa
            // 
            lblMoTa.Dock = DockStyle.Top;
            lblMoTa.Font = new Font("Segoe UI", 10F);
            lblMoTa.ForeColor = Color.FromArgb(180, 180, 180);
            lblMoTa.Location = new Point(73, 150);
            lblMoTa.Margin = new Padding(7, 0, 7, 0);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(2229, 82);
            lblMoTa.TabIndex = 0;
            lblMoTa.Text = "Backup và Restore database cửa hàng cà phê";
            lblMoTa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(73, 0);
            lblTieuDe.Margin = new Padding(7, 0, 7, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(2229, 150);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "🗄️  Sao Lưu & Phục Hồi Dữ Liệu";
            lblTieuDe.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlBody
            // 
            pnlBody.BackColor = Color.FromArgb(245, 246, 248);
            pnlBody.Controls.Add(pnlLog);
            pnlBody.Controls.Add(pnlPhucHoi);
            pnlBody.Controls.Add(pnlSaoLuu);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 246);
            pnlBody.Margin = new Padding(7, 8, 7, 8);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(49, 55, 49, 55);
            pnlBody.Size = new Size(2302, 1531);
            pnlBody.TabIndex = 0;
            // 
            // pnlLog
            // 
            pnlLog.BackColor = Color.White;
            pnlLog.BorderStyle = BorderStyle.FixedSingle;
            pnlLog.Controls.Add(btnXoaLog);
            pnlLog.Controls.Add(rtbLog);
            pnlLog.Controls.Add(lblLogTitle);
            pnlLog.Location = new Point(49, 738);
            pnlLog.Margin = new Padding(7, 8, 7, 8);
            pnlLog.Name = "pnlLog";
            pnlLog.Size = new Size(2215, 680);
            pnlLog.TabIndex = 0;
            // 
            // btnXoaLog
            // 
            btnXoaLog.BackColor = Color.FromArgb(230, 230, 230);
            btnXoaLog.Cursor = Cursors.Hand;
            btnXoaLog.FlatAppearance.BorderSize = 0;
            btnXoaLog.FlatStyle = FlatStyle.Flat;
            btnXoaLog.Font = new Font("Segoe UI", 9F);
            btnXoaLog.Location = new Point(2017, 8);
            btnXoaLog.Margin = new Padding(7, 8, 7, 8);
            btnXoaLog.Name = "btnXoaLog";
            btnXoaLog.Size = new Size(159, 77);
            btnXoaLog.TabIndex = 0;
            btnXoaLog.Text = "Xóa log";
            btnXoaLog.UseVisualStyleBackColor = false;
            btnXoaLog.Click += btnXoaLog_Click;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.FromArgb(20, 25, 30);
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Font = new Font("Consolas", 10F);
            rtbLog.ForeColor = Color.FromArgb(80, 220, 130);
            rtbLog.Location = new Point(29, 123);
            rtbLog.Margin = new Padding(7, 8, 7, 8);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbLog.Size = new Size(2147, 533);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "— Nhật ký trống. Thực hiện sao lưu hoặc phục hồi để xem kết quả. —";
            // 
            // lblLogTitle
            // 
            lblLogTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.FromArgb(50, 50, 50);
            lblLogTitle.Location = new Point(29, 27);
            lblLogTitle.Margin = new Padding(7, 0, 7, 0);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(729, 77);
            lblLogTitle.TabIndex = 2;
            lblLogTitle.Text = "📋  Nhật Ký Hoạt Động";
            // 
            // pnlPhucHoi
            // 
            pnlPhucHoi.BackColor = Color.White;
            pnlPhucHoi.BorderStyle = BorderStyle.FixedSingle;
            pnlPhucHoi.Controls.Add(btnPhucHoi);
            pnlPhucHoi.Controls.Add(lblPhucHoiWarning);
            pnlPhucHoi.Controls.Add(btnChonFilePhucHoi);
            pnlPhucHoi.Controls.Add(txtDuongDanPhucHoi);
            pnlPhucHoi.Controls.Add(lblFileBak);
            pnlPhucHoi.Controls.Add(lblPhucHoiDesc);
            pnlPhucHoi.Controls.Add(lblPhucHoiTitle);
            pnlPhucHoi.Location = new Point(1196, 55);
            pnlPhucHoi.Margin = new Padding(7, 8, 7, 8);
            pnlPhucHoi.Name = "pnlPhucHoi";
            pnlPhucHoi.Size = new Size(1068, 625);
            pnlPhucHoi.TabIndex = 1;
            // 
            // btnPhucHoi
            // 
            btnPhucHoi.BackColor = Color.FromArgb(192, 57, 43);
            btnPhucHoi.Cursor = Cursors.Hand;
            btnPhucHoi.FlatAppearance.BorderSize = 0;
            btnPhucHoi.FlatStyle = FlatStyle.Flat;
            btnPhucHoi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPhucHoi.ForeColor = Color.White;
            btnPhucHoi.Location = new Point(36, 492);
            btnPhucHoi.Margin = new Padding(7, 8, 7, 8);
            btnPhucHoi.Name = "btnPhucHoi";
            btnPhucHoi.Size = new Size(993, 104);
            btnPhucHoi.TabIndex = 0;
            btnPhucHoi.Text = "🔄  Bắt Đầu Phục Hồi";
            btnPhucHoi.UseVisualStyleBackColor = false;
            btnPhucHoi.Click += btnPhucHoi_Click;
            // 
            // lblPhucHoiWarning
            // 
            lblPhucHoiWarning.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold | FontStyle.Italic);
            lblPhucHoiWarning.ForeColor = Color.FromArgb(192, 57, 43);
            lblPhucHoiWarning.Location = new Point(36, 415);
            lblPhucHoiWarning.Margin = new Padding(7, 0, 7, 0);
            lblPhucHoiWarning.Name = "lblPhucHoiWarning";
            lblPhucHoiWarning.Size = new Size(1032, 60);
            lblPhucHoiWarning.TabIndex = 1;
            lblPhucHoiWarning.Text = "⚠️  Cảnh báo: Thao tác này sẽ ghi đè toàn bộ dữ liệu hiện tại!";
            // 
            // btnChonFilePhucHoi
            // 
            btnChonFilePhucHoi.BackColor = Color.FromArgb(52, 73, 94);
            btnChonFilePhucHoi.Cursor = Cursors.Hand;
            btnChonFilePhucHoi.FlatAppearance.BorderSize = 0;
            btnChonFilePhucHoi.FlatStyle = FlatStyle.Flat;
            btnChonFilePhucHoi.Font = new Font("Segoe UI", 9.5F);
            btnChonFilePhucHoi.ForeColor = Color.White;
            btnChonFilePhucHoi.Location = new Point(920, 296);
            btnChonFilePhucHoi.Margin = new Padding(7, 8, 7, 8);
            btnChonFilePhucHoi.Name = "btnChonFilePhucHoi";
            btnChonFilePhucHoi.Size = new Size(109, 87);
            btnChonFilePhucHoi.TabIndex = 2;
            btnChonFilePhucHoi.Text = "📂 Chọn";
            btnChonFilePhucHoi.UseVisualStyleBackColor = false;
            btnChonFilePhucHoi.Click += btnChonFilePhucHoi_Click;
            // 
            // txtDuongDanPhucHoi
            // 
            txtDuongDanPhucHoi.BackColor = Color.FromArgb(248, 249, 250);
            txtDuongDanPhucHoi.Font = new Font("Segoe UI", 10F);
            txtDuongDanPhucHoi.Location = new Point(36, 314);
            txtDuongDanPhucHoi.Margin = new Padding(7, 8, 7, 8);
            txtDuongDanPhucHoi.Name = "txtDuongDanPhucHoi";
            txtDuongDanPhucHoi.PlaceholderText = "Chọn file .bak để phục hồi...";
            txtDuongDanPhucHoi.ReadOnly = true;
            txtDuongDanPhucHoi.Size = new Size(735, 52);
            txtDuongDanPhucHoi.TabIndex = 3;
            // 
            // lblFileBak
            // 
            lblFileBak.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFileBak.ForeColor = Color.FromArgb(50, 50, 50);
            lblFileBak.Location = new Point(36, 246);
            lblFileBak.Margin = new Padding(7, 0, 7, 0);
            lblFileBak.Name = "lblFileBak";
            lblFileBak.Size = new Size(1032, 60);
            lblFileBak.TabIndex = 4;
            lblFileBak.Text = "File sao lưu (.bak):";
            // 
            // lblPhucHoiDesc
            // 
            lblPhucHoiDesc.Font = new Font("Segoe UI", 9.5F);
            lblPhucHoiDesc.ForeColor = Color.Gray;
            lblPhucHoiDesc.Location = new Point(36, 137);
            lblPhucHoiDesc.Margin = new Padding(7, 0, 7, 0);
            lblPhucHoiDesc.Name = "lblPhucHoiDesc";
            lblPhucHoiDesc.Size = new Size(1032, 82);
            lblPhucHoiDesc.TabIndex = 5;
            lblPhucHoiDesc.Text = "Khôi phục CSDL từ file .bak đã sao lưu trước đó.";
            // 
            // lblPhucHoiTitle
            // 
            lblPhucHoiTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPhucHoiTitle.ForeColor = Color.FromArgb(192, 57, 43);
            lblPhucHoiTitle.Location = new Point(36, 41);
            lblPhucHoiTitle.Margin = new Padding(7, 0, 7, 0);
            lblPhucHoiTitle.Name = "lblPhucHoiTitle";
            lblPhucHoiTitle.Size = new Size(1032, 96);
            lblPhucHoiTitle.TabIndex = 6;
            lblPhucHoiTitle.Text = "🔄  Phục Hồi Dữ Liệu";
            // 
            // pnlSaoLuu
            // 
            pnlSaoLuu.BackColor = Color.White;
            pnlSaoLuu.BorderStyle = BorderStyle.FixedSingle;
            pnlSaoLuu.Controls.Add(btnSaoLuu);
            pnlSaoLuu.Controls.Add(lblSaoLuuHint);
            pnlSaoLuu.Controls.Add(btnChonThuMucSaoLuu);
            pnlSaoLuu.Controls.Add(txtDuongDanSaoLuu);
            pnlSaoLuu.Controls.Add(lblThuMuc);
            pnlSaoLuu.Controls.Add(lblSaoLuuDesc);
            pnlSaoLuu.Controls.Add(lblSaoLuuTitle);
            pnlSaoLuu.Location = new Point(37, 55);
            pnlSaoLuu.Margin = new Padding(7, 8, 7, 8);
            pnlSaoLuu.Name = "pnlSaoLuu";
            pnlSaoLuu.Size = new Size(1126, 625);
            pnlSaoLuu.TabIndex = 2;
            // 
            // btnSaoLuu
            // 
            btnSaoLuu.BackColor = Color.FromArgb(41, 128, 185);
            btnSaoLuu.Cursor = Cursors.Hand;
            btnSaoLuu.FlatAppearance.BorderSize = 0;
            btnSaoLuu.FlatStyle = FlatStyle.Flat;
            btnSaoLuu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaoLuu.ForeColor = Color.White;
            btnSaoLuu.Location = new Point(36, 492);
            btnSaoLuu.Margin = new Padding(7, 8, 7, 8);
            btnSaoLuu.Name = "btnSaoLuu";
            btnSaoLuu.Size = new Size(1044, 104);
            btnSaoLuu.TabIndex = 0;
            btnSaoLuu.Text = "💾  Bắt Đầu Sao Lưu";
            btnSaoLuu.UseVisualStyleBackColor = false;
            btnSaoLuu.Click += btnSaoLuu_Click;
            // 
            // lblSaoLuuHint
            // 
            lblSaoLuuHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblSaoLuuHint.ForeColor = Color.FromArgb(140, 140, 140);
            lblSaoLuuHint.Location = new Point(36, 415);
            lblSaoLuuHint.Margin = new Padding(7, 0, 7, 0);
            lblSaoLuuHint.Name = "lblSaoLuuHint";
            lblSaoLuuHint.Size = new Size(942, 60);
            lblSaoLuuHint.TabIndex = 1;
            lblSaoLuuHint.Text = "Tên file sẽ tự động tạo theo ngày giờ: QLCH(DD_MM_YYYY_HH_mm).bak";
            // 
            // btnChonThuMucSaoLuu
            // 
            btnChonThuMucSaoLuu.BackColor = Color.FromArgb(52, 73, 94);
            btnChonThuMucSaoLuu.Cursor = Cursors.Hand;
            btnChonThuMucSaoLuu.FlatAppearance.BorderSize = 0;
            btnChonThuMucSaoLuu.FlatStyle = FlatStyle.Flat;
            btnChonThuMucSaoLuu.Font = new Font("Segoe UI", 9.5F);
            btnChonThuMucSaoLuu.ForeColor = Color.White;
            btnChonThuMucSaoLuu.Location = new Point(814, 296);
            btnChonThuMucSaoLuu.Margin = new Padding(7, 8, 7, 8);
            btnChonThuMucSaoLuu.Name = "btnChonThuMucSaoLuu";
            btnChonThuMucSaoLuu.Size = new Size(126, 87);
            btnChonThuMucSaoLuu.TabIndex = 2;
            btnChonThuMucSaoLuu.Text = "📂 Chọn";
            btnChonThuMucSaoLuu.UseVisualStyleBackColor = false;
            btnChonThuMucSaoLuu.Click += btnChonThuMucSaoLuu_Click;
            // 
            // txtDuongDanSaoLuu
            // 
            txtDuongDanSaoLuu.BackColor = Color.FromArgb(248, 249, 250);
            txtDuongDanSaoLuu.Font = new Font("Segoe UI", 10F);
            txtDuongDanSaoLuu.Location = new Point(36, 314);
            txtDuongDanSaoLuu.Margin = new Padding(7, 8, 7, 8);
            txtDuongDanSaoLuu.Name = "txtDuongDanSaoLuu";
            txtDuongDanSaoLuu.PlaceholderText = "Chọn thư mục lưu file sao lưu...";
            txtDuongDanSaoLuu.ReadOnly = true;
            txtDuongDanSaoLuu.Size = new Size(752, 52);
            txtDuongDanSaoLuu.TabIndex = 3;
            // 
            // lblThuMuc
            // 
            lblThuMuc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblThuMuc.ForeColor = Color.FromArgb(50, 50, 50);
            lblThuMuc.Location = new Point(36, 246);
            lblThuMuc.Margin = new Padding(7, 0, 7, 0);
            lblThuMuc.Name = "lblThuMuc";
            lblThuMuc.Size = new Size(1049, 60);
            lblThuMuc.TabIndex = 4;
            lblThuMuc.Text = "Thư mục lưu file:";
            // 
            // lblSaoLuuDesc
            // 
            lblSaoLuuDesc.Font = new Font("Segoe UI", 9.5F);
            lblSaoLuuDesc.ForeColor = Color.Gray;
            lblSaoLuuDesc.Location = new Point(36, 137);
            lblSaoLuuDesc.Margin = new Padding(7, 0, 7, 0);
            lblSaoLuuDesc.Name = "lblSaoLuuDesc";
            lblSaoLuuDesc.Size = new Size(1049, 82);
            lblSaoLuuDesc.TabIndex = 5;
            lblSaoLuuDesc.Text = "Tạo bản sao lưu toàn bộ CSDL vào file .bak — nên thực hiện định kỳ.";
            // 
            // lblSaoLuuTitle
            // 
            lblSaoLuuTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSaoLuuTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblSaoLuuTitle.Location = new Point(36, 41);
            lblSaoLuuTitle.Margin = new Padding(7, 0, 7, 0);
            lblSaoLuuTitle.Name = "lblSaoLuuTitle";
            lblSaoLuuTitle.Size = new Size(1049, 96);
            lblSaoLuuTitle.TabIndex = 6;
            lblSaoLuuTitle.Text = "💾  Sao Lưu Dữ Liệu";
            // 
            // UC_SaoLuuPhucHoi
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Margin = new Padding(7, 8, 7, 8);
            Name = "UC_SaoLuuPhucHoi";
            Size = new Size(2302, 1777);
            pnlHeader.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlLog.ResumeLayout(false);
            pnlPhucHoi.ResumeLayout(false);
            pnlPhucHoi.PerformLayout();
            pnlSaoLuu.ResumeLayout(false);
            pnlSaoLuu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // ── Control declarations ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel     pnlHeader;
        private System.Windows.Forms.Label     lblTieuDe;
        private System.Windows.Forms.Label     lblMoTa;

        private System.Windows.Forms.Panel     pnlBody;

        // Sao lưu
        private System.Windows.Forms.Panel     pnlSaoLuu;
        private System.Windows.Forms.Label     lblSaoLuuTitle;
        private System.Windows.Forms.Label     lblSaoLuuDesc;
        private System.Windows.Forms.Label     lblThuMuc;
        private System.Windows.Forms.TextBox   txtDuongDanSaoLuu;
        private System.Windows.Forms.Button    btnChonThuMucSaoLuu;
        private System.Windows.Forms.Label     lblSaoLuuHint;
        private System.Windows.Forms.Button    btnSaoLuu;

        // Phục hồi
        private System.Windows.Forms.Panel     pnlPhucHoi;
        private System.Windows.Forms.Label     lblPhucHoiTitle;
        private System.Windows.Forms.Label     lblPhucHoiDesc;
        private System.Windows.Forms.Label     lblFileBak;
        private System.Windows.Forms.TextBox   txtDuongDanPhucHoi;
        private System.Windows.Forms.Button    btnChonFilePhucHoi;
        private System.Windows.Forms.Label     lblPhucHoiWarning;
        private System.Windows.Forms.Button    btnPhucHoi;

        // Log
        private System.Windows.Forms.Panel         pnlLog;
        private System.Windows.Forms.Label         lblLogTitle;
        private System.Windows.Forms.RichTextBox   rtbLog;
        private System.Windows.Forms.Button        btnXoaLog;
    }
}
