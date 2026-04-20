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
            // ── Controls declaration ─────────────────────────────────────────────
            this.pnlHeader           = new System.Windows.Forms.Panel();
            this.lblTieuDe           = new System.Windows.Forms.Label();
            this.lblMoTa             = new System.Windows.Forms.Label();

            this.pnlBody             = new System.Windows.Forms.Panel();

            // Panel Sao Lưu
            this.pnlSaoLuu           = new System.Windows.Forms.Panel();
            this.lblSaoLuuTitle      = new System.Windows.Forms.Label();
            this.lblSaoLuuDesc       = new System.Windows.Forms.Label();
            this.lblThuMuc           = new System.Windows.Forms.Label();
            this.txtDuongDanSaoLuu   = new System.Windows.Forms.TextBox();
            this.btnChonThuMucSaoLuu = new System.Windows.Forms.Button();
            this.btnSaoLuu           = new System.Windows.Forms.Button();
            this.lblSaoLuuHint       = new System.Windows.Forms.Label();

            // Panel Phục Hồi
            this.pnlPhucHoi          = new System.Windows.Forms.Panel();
            this.lblPhucHoiTitle     = new System.Windows.Forms.Label();
            this.lblPhucHoiDesc      = new System.Windows.Forms.Label();
            this.lblFileBak          = new System.Windows.Forms.Label();
            this.txtDuongDanPhucHoi  = new System.Windows.Forms.TextBox();
            this.btnChonFilePhucHoi  = new System.Windows.Forms.Button();
            this.btnPhucHoi          = new System.Windows.Forms.Button();
            this.lblPhucHoiWarning   = new System.Windows.Forms.Label();

            // Panel Log
            this.pnlLog              = new System.Windows.Forms.Panel();
            this.lblLogTitle         = new System.Windows.Forms.Label();
            this.rtbLog              = new System.Windows.Forms.RichTextBox();
            this.btnXoaLog           = new System.Windows.Forms.Button();

            // ── SuspendLayout ───────────────────────────────────────────────────
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlSaoLuu.SuspendLayout();
            this.pnlPhucHoi.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════
            //  pnlHeader — Thanh tiêu đề xanh đen sang
            // ════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(29, 43, 54);
            this.pnlHeader.Controls.Add(this.lblMoTa);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height   = 90;
            this.pnlHeader.Padding  = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.pnlHeader.Name     = "pnlHeader";

            this.lblTieuDe.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Height    = 55;
            this.lblTieuDe.Text      = "🗄️  Sao Lưu & Phục Hồi Dữ Liệu";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTieuDe.Name      = "lblTieuDe";

            this.lblMoTa.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblMoTa.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblMoTa.Height    = 30;
            this.lblMoTa.Text      = "Backup và Restore database cửa hàng cà phê";
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMoTa.Name      = "lblMoTa";

            // ════════════════════════════════════════════
            //  pnlBody — Vùng nội dung chính
            // ════════════════════════════════════════════
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 246, 248);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding   = new System.Windows.Forms.Padding(20);
            this.pnlBody.Name      = "pnlBody";
            this.pnlBody.Controls.Add(this.pnlLog);
            this.pnlBody.Controls.Add(this.pnlPhucHoi);
            this.pnlBody.Controls.Add(this.pnlSaoLuu);

            // ════════════════════════════════════════════
            //  pnlSaoLuu — Card Sao Lưu
            // ════════════════════════════════════════════
            this.pnlSaoLuu.BackColor   = System.Drawing.Color.White;
            this.pnlSaoLuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSaoLuu.Location    = new System.Drawing.Point(20, 20);
            this.pnlSaoLuu.Size        = new System.Drawing.Size(520, 230);
            this.pnlSaoLuu.Name        = "pnlSaoLuu";
            this.pnlSaoLuu.Controls.Add(this.btnSaoLuu);
            this.pnlSaoLuu.Controls.Add(this.lblSaoLuuHint);
            this.pnlSaoLuu.Controls.Add(this.btnChonThuMucSaoLuu);
            this.pnlSaoLuu.Controls.Add(this.txtDuongDanSaoLuu);
            this.pnlSaoLuu.Controls.Add(this.lblThuMuc);
            this.pnlSaoLuu.Controls.Add(this.lblSaoLuuDesc);
            this.pnlSaoLuu.Controls.Add(this.lblSaoLuuTitle);

            this.lblSaoLuuTitle.Location  = new System.Drawing.Point(15, 15);
            this.lblSaoLuuTitle.Size      = new System.Drawing.Size(490, 35);
            this.lblSaoLuuTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSaoLuuTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblSaoLuuTitle.Text      = "💾  Sao Lưu Dữ Liệu";
            this.lblSaoLuuTitle.Name      = "lblSaoLuuTitle";

            this.lblSaoLuuDesc.Location  = new System.Drawing.Point(15, 50);
            this.lblSaoLuuDesc.Size      = new System.Drawing.Size(490, 30);
            this.lblSaoLuuDesc.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSaoLuuDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblSaoLuuDesc.Text      = "Tạo bản sao lưu toàn bộ CSDL vào file .bak — nên thực hiện định kỳ.";
            this.lblSaoLuuDesc.Name      = "lblSaoLuuDesc";

            this.lblThuMuc.Location  = new System.Drawing.Point(15, 90);
            this.lblThuMuc.Size      = new System.Drawing.Size(490, 22);
            this.lblThuMuc.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThuMuc.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblThuMuc.Text      = "Thư mục lưu file:";
            this.lblThuMuc.Name      = "lblThuMuc";

            this.txtDuongDanSaoLuu.Location    = new System.Drawing.Point(15, 115);
            this.txtDuongDanSaoLuu.Size        = new System.Drawing.Size(370, 28);
            this.txtDuongDanSaoLuu.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDuongDanSaoLuu.PlaceholderText = "Chọn thư mục lưu file sao lưu...";
            this.txtDuongDanSaoLuu.ReadOnly    = true;
            this.txtDuongDanSaoLuu.BackColor   = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtDuongDanSaoLuu.Name        = "txtDuongDanSaoLuu";

            this.btnChonThuMucSaoLuu.Location       = new System.Drawing.Point(393, 113);
            this.btnChonThuMucSaoLuu.Size           = new System.Drawing.Size(110, 32);
            this.btnChonThuMucSaoLuu.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnChonThuMucSaoLuu.Text           = "📂 Chọn";
            this.btnChonThuMucSaoLuu.BackColor      = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnChonThuMucSaoLuu.ForeColor      = System.Drawing.Color.White;
            this.btnChonThuMucSaoLuu.FlatStyle      = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonThuMucSaoLuu.FlatAppearance.BorderSize = 0;
            this.btnChonThuMucSaoLuu.Cursor         = System.Windows.Forms.Cursors.Hand;
            this.btnChonThuMucSaoLuu.Name           = "btnChonThuMucSaoLuu";
            this.btnChonThuMucSaoLuu.Click += new System.EventHandler(this.btnChonThuMucSaoLuu_Click);

            this.lblSaoLuuHint.Location  = new System.Drawing.Point(15, 152);
            this.lblSaoLuuHint.Size      = new System.Drawing.Size(490, 22);
            this.lblSaoLuuHint.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSaoLuuHint.ForeColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.lblSaoLuuHint.Text      = "Tên file sẽ tự động tạo theo ngày giờ: QLCH(DD_MM_YYYY_HH_mm).bak";
            this.lblSaoLuuHint.Name      = "lblSaoLuuHint";

            this.btnSaoLuu.Location  = new System.Drawing.Point(15, 180);
            this.btnSaoLuu.Size      = new System.Drawing.Size(488, 38);
            this.btnSaoLuu.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaoLuu.Text      = "💾  Bắt Đầu Sao Lưu";
            this.btnSaoLuu.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnSaoLuu.ForeColor = System.Drawing.Color.White;
            this.btnSaoLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaoLuu.FlatAppearance.BorderSize = 0;
            this.btnSaoLuu.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnSaoLuu.Name     = "btnSaoLuu";
            this.btnSaoLuu.Click   += new System.EventHandler(this.btnSaoLuu_Click);

            // ════════════════════════════════════════════
            //  pnlPhucHoi — Card Phục Hồi
            // ════════════════════════════════════════════
            this.pnlPhucHoi.BackColor   = System.Drawing.Color.White;
            this.pnlPhucHoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPhucHoi.Location    = new System.Drawing.Point(560, 20);
            this.pnlPhucHoi.Size        = new System.Drawing.Size(520, 230);
            this.pnlPhucHoi.Name        = "pnlPhucHoi";
            this.pnlPhucHoi.Controls.Add(this.btnPhucHoi);
            this.pnlPhucHoi.Controls.Add(this.lblPhucHoiWarning);
            this.pnlPhucHoi.Controls.Add(this.btnChonFilePhucHoi);
            this.pnlPhucHoi.Controls.Add(this.txtDuongDanPhucHoi);
            this.pnlPhucHoi.Controls.Add(this.lblFileBak);
            this.pnlPhucHoi.Controls.Add(this.lblPhucHoiDesc);
            this.pnlPhucHoi.Controls.Add(this.lblPhucHoiTitle);

            this.lblPhucHoiTitle.Location  = new System.Drawing.Point(15, 15);
            this.lblPhucHoiTitle.Size      = new System.Drawing.Size(490, 35);
            this.lblPhucHoiTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPhucHoiTitle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblPhucHoiTitle.Text      = "🔄  Phục Hồi Dữ Liệu";
            this.lblPhucHoiTitle.Name      = "lblPhucHoiTitle";

            this.lblPhucHoiDesc.Location  = new System.Drawing.Point(15, 50);
            this.lblPhucHoiDesc.Size      = new System.Drawing.Size(490, 30);
            this.lblPhucHoiDesc.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhucHoiDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblPhucHoiDesc.Text      = "Khôi phục CSDL từ file .bak đã sao lưu trước đó.";
            this.lblPhucHoiDesc.Name      = "lblPhucHoiDesc";

            this.lblFileBak.Location  = new System.Drawing.Point(15, 90);
            this.lblFileBak.Size      = new System.Drawing.Size(490, 22);
            this.lblFileBak.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFileBak.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblFileBak.Text      = "File sao lưu (.bak):";
            this.lblFileBak.Name      = "lblFileBak";

            this.txtDuongDanPhucHoi.Location    = new System.Drawing.Point(15, 115);
            this.txtDuongDanPhucHoi.Size        = new System.Drawing.Size(370, 28);
            this.txtDuongDanPhucHoi.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDuongDanPhucHoi.PlaceholderText = "Chọn file .bak để phục hồi...";
            this.txtDuongDanPhucHoi.ReadOnly    = true;
            this.txtDuongDanPhucHoi.BackColor   = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtDuongDanPhucHoi.Name        = "txtDuongDanPhucHoi";

            this.btnChonFilePhucHoi.Location       = new System.Drawing.Point(393, 113);
            this.btnChonFilePhucHoi.Size           = new System.Drawing.Size(110, 32);
            this.btnChonFilePhucHoi.Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnChonFilePhucHoi.Text           = "📂 Chọn";
            this.btnChonFilePhucHoi.BackColor      = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnChonFilePhucHoi.ForeColor      = System.Drawing.Color.White;
            this.btnChonFilePhucHoi.FlatStyle      = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonFilePhucHoi.FlatAppearance.BorderSize = 0;
            this.btnChonFilePhucHoi.Cursor         = System.Windows.Forms.Cursors.Hand;
            this.btnChonFilePhucHoi.Name           = "btnChonFilePhucHoi";
            this.btnChonFilePhucHoi.Click += new System.EventHandler(this.btnChonFilePhucHoi_Click);

            this.lblPhucHoiWarning.Location  = new System.Drawing.Point(15, 152);
            this.lblPhucHoiWarning.Size      = new System.Drawing.Size(490, 22);
            this.lblPhucHoiWarning.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            this.lblPhucHoiWarning.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblPhucHoiWarning.Text      = "⚠️  Cảnh báo: Thao tác này sẽ ghi đè toàn bộ dữ liệu hiện tại!";
            this.lblPhucHoiWarning.Name      = "lblPhucHoiWarning";

            this.btnPhucHoi.Location  = new System.Drawing.Point(15, 180);
            this.btnPhucHoi.Size      = new System.Drawing.Size(488, 38);
            this.btnPhucHoi.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPhucHoi.Text      = "🔄  Bắt Đầu Phục Hồi";
            this.btnPhucHoi.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnPhucHoi.ForeColor = System.Drawing.Color.White;
            this.btnPhucHoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhucHoi.FlatAppearance.BorderSize = 0;
            this.btnPhucHoi.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnPhucHoi.Name     = "btnPhucHoi";
            this.btnPhucHoi.Click   += new System.EventHandler(this.btnPhucHoi_Click);

            // ════════════════════════════════════════════
            //  pnlLog — Nhật ký hoạt động
            // ════════════════════════════════════════════
            this.pnlLog.BackColor   = System.Drawing.Color.White;
            this.pnlLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLog.Location    = new System.Drawing.Point(20, 270);
            this.pnlLog.Size        = new System.Drawing.Size(1060, 250);
            this.pnlLog.Name        = "pnlLog";
            this.pnlLog.Controls.Add(this.btnXoaLog);
            this.pnlLog.Controls.Add(this.rtbLog);
            this.pnlLog.Controls.Add(this.lblLogTitle);

            this.lblLogTitle.Location  = new System.Drawing.Point(12, 10);
            this.lblLogTitle.Size      = new System.Drawing.Size(300, 28);
            this.lblLogTitle.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogTitle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblLogTitle.Text      = "📋  Nhật Ký Hoạt Động";
            this.lblLogTitle.Name      = "lblLogTitle";

            this.btnXoaLog.Location  = new System.Drawing.Point(970, 8);
            this.btnXoaLog.Size      = new System.Drawing.Size(80, 28);
            this.btnXoaLog.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaLog.Text      = "Xóa log";
            this.btnXoaLog.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnXoaLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLog.FlatAppearance.BorderSize = 0;
            this.btnXoaLog.Cursor   = System.Windows.Forms.Cursors.Hand;
            this.btnXoaLog.Name     = "btnXoaLog";
            this.btnXoaLog.Click   += new System.EventHandler(this.btnXoaLog_Click);

            this.rtbLog.Location      = new System.Drawing.Point(12, 45);
            this.rtbLog.Size          = new System.Drawing.Size(1036, 195);
            this.rtbLog.Font          = new System.Drawing.Font("Consolas", 10F);
            this.rtbLog.BackColor     = System.Drawing.Color.FromArgb(20, 25, 30);
            this.rtbLog.ForeColor     = System.Drawing.Color.FromArgb(80, 220, 130);
            this.rtbLog.ReadOnly      = true;
            this.rtbLog.BorderStyle   = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.ScrollBars    = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Name          = "rtbLog";
            this.rtbLog.Text          = "— Nhật ký trống. Thực hiện sao lưu hoặc phục hồi để xem kết quả. —";

            // ════════════════════════════════════════════
            //  UC_SaoLuuPhucHoi
            // ════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(245, 246, 248);
            this.Size                = new System.Drawing.Size(1100, 650);
            this.Name                = "UC_SaoLuuPhucHoi";
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlSaoLuu.ResumeLayout(false);
            this.pnlSaoLuu.PerformLayout();
            this.pnlPhucHoi.ResumeLayout(false);
            this.pnlPhucHoi.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.ResumeLayout(false);
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
