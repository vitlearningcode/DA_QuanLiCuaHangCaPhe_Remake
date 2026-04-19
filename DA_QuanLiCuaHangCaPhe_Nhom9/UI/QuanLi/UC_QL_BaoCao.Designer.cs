namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    partial class UC_QL_BaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlCardDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThuSo = new System.Windows.Forms.Label();
            this.lblDoanhThuTitle = new System.Windows.Forms.Label();
            this.pnlCardDonHang = new System.Windows.Forms.Panel();
            this.lblDonHangSo = new System.Windows.Forms.Label();
            this.lblDonHangTitle = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbTopMon = new System.Windows.Forms.GroupBox();
            this.dgvTopMon = new System.Windows.Forms.DataGridView();
            this.gbDoanhThu7Ngay = new System.Windows.Forms.GroupBox();
            this.dgvDoanhThu7Ngay = new System.Windows.Forms.DataGridView();
            this.gbKhoBaoDong = new System.Windows.Forms.GroupBox();
            this.dgvKhoBaoDong = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlCardDoanhThu.SuspendLayout();
            this.pnlCardDonHang.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.gbTopMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopMon)).BeginInit();
            this.gbDoanhThu7Ngay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu7Ngay)).BeginInit();
            this.gbKhoBaoDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoBaoDong)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 70);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(437, 37);
            this.lblTitle.Text = "📊 BÁO CÁO TỔNG QUAN (DASHBOARD)";
            // 
            // pnlCards
            // 
            this.pnlCards.Controls.Add(this.pnlCardDoanhThu);
            this.pnlCards.Controls.Add(this.pnlCardDonHang);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 70);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCards.Size = new System.Drawing.Size(1200, 140);
            // 
            // pnlCardDoanhThu
            // 
            this.pnlCardDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.pnlCardDoanhThu.Controls.Add(this.lblDoanhThuSo);
            this.pnlCardDoanhThu.Controls.Add(this.lblDoanhThuTitle);
            this.pnlCardDoanhThu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCardDoanhThu.Location = new System.Drawing.Point(20, 20);
            this.pnlCardDoanhThu.Name = "pnlCardDoanhThu";
            this.pnlCardDoanhThu.Size = new System.Drawing.Size(400, 100);
            // 
            // lblDoanhThuSo
            // 
            this.lblDoanhThuSo.AutoSize = true;
            this.lblDoanhThuSo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuSo.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuSo.Location = new System.Drawing.Point(15, 35);
            this.lblDoanhThuSo.Name = "lblDoanhThuSo";
            this.lblDoanhThuSo.Size = new System.Drawing.Size(135, 54);
            this.lblDoanhThuSo.Text = "0 VNĐ";
            // 
            // lblDoanhThuTitle
            // 
            this.lblDoanhThuTitle.AutoSize = true;
            this.lblDoanhThuTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDoanhThuTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDoanhThuTitle.Location = new System.Drawing.Point(20, 10);
            this.lblDoanhThuTitle.Name = "lblDoanhThuTitle";
            this.lblDoanhThuTitle.Size = new System.Drawing.Size(209, 28);
            this.lblDoanhThuTitle.Text = "DOANH THU HÔM NAY";
            // 
            // pnlCardDonHang
            // 
            this.pnlCardDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.pnlCardDonHang.Controls.Add(this.lblDonHangSo);
            this.pnlCardDonHang.Controls.Add(this.lblDonHangTitle);
            this.pnlCardDonHang.Location = new System.Drawing.Point(450, 20);
            this.pnlCardDonHang.Name = "pnlCardDonHang";
            this.pnlCardDonHang.Size = new System.Drawing.Size(300, 100);
            // 
            // lblDonHangSo
            // 
            this.lblDonHangSo.AutoSize = true;
            this.lblDonHangSo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDonHangSo.ForeColor = System.Drawing.Color.White;
            this.lblDonHangSo.Location = new System.Drawing.Point(15, 35);
            this.lblDonHangSo.Name = "lblDonHangSo";
            this.lblDonHangSo.Size = new System.Drawing.Size(46, 54);
            this.lblDonHangSo.Text = "0";
            // 
            // lblDonHangTitle
            // 
            this.lblDonHangTitle.AutoSize = true;
            this.lblDonHangTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDonHangTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDonHangTitle.Location = new System.Drawing.Point(20, 10);
            this.lblDonHangTitle.Name = "lblDonHangTitle";
            this.lblDonHangTitle.Size = new System.Drawing.Size(193, 28);
            this.lblDonHangTitle.Text = "SỐ ĐƠN HOÀN TẤT";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.gbTopMon, 0, 0);
            this.tlpMain.Controls.Add(this.gbDoanhThu7Ngay, 1, 0);
            this.tlpMain.Controls.Add(this.gbKhoBaoDong, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 210);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(20);
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(1200, 590);
            // 
            // gbTopMon
            // 
            this.gbTopMon.Controls.Add(this.dgvTopMon);
            this.gbTopMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTopMon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbTopMon.Location = new System.Drawing.Point(23, 23);
            this.gbTopMon.Name = "gbTopMon";
            this.gbTopMon.Padding = new System.Windows.Forms.Padding(10);
            this.gbTopMon.Size = new System.Drawing.Size(574, 269);
            this.gbTopMon.Text = "🔥 TOP 5 MÓN BÁN CHẠY";
            // 
            // dgvTopMon
            // 
            this.dgvTopMon.AllowUserToAddRows = false;
            this.dgvTopMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopMon.Location = new System.Drawing.Point(10, 35);
            this.dgvTopMon.Name = "dgvTopMon";
            this.dgvTopMon.ReadOnly = true;
            this.dgvTopMon.RowHeadersVisible = false;
            this.dgvTopMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // gbDoanhThu7Ngay
            // 
            this.gbDoanhThu7Ngay.Controls.Add(this.dgvDoanhThu7Ngay);
            this.gbDoanhThu7Ngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDoanhThu7Ngay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbDoanhThu7Ngay.Location = new System.Drawing.Point(603, 23);
            this.gbDoanhThu7Ngay.Name = "gbDoanhThu7Ngay";
            this.gbDoanhThu7Ngay.Padding = new System.Windows.Forms.Padding(10);
            this.gbDoanhThu7Ngay.Size = new System.Drawing.Size(574, 269);
            this.gbDoanhThu7Ngay.Text = "📈 DOANH THU 7 NGÀY GẦN NHẤT";
            // 
            // dgvDoanhThu7Ngay
            // 
            this.dgvDoanhThu7Ngay.AllowUserToAddRows = false;
            this.dgvDoanhThu7Ngay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu7Ngay.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu7Ngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu7Ngay.Location = new System.Drawing.Point(10, 35);
            this.dgvDoanhThu7Ngay.Name = "dgvDoanhThu7Ngay";
            this.dgvDoanhThu7Ngay.ReadOnly = true;
            this.dgvDoanhThu7Ngay.RowHeadersVisible = false;
            this.dgvDoanhThu7Ngay.Font = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // gbKhoBaoDong
            // 
            this.tlpMain.SetColumnSpan(this.gbKhoBaoDong, 2);
            this.gbKhoBaoDong.Controls.Add(this.dgvKhoBaoDong);
            this.gbKhoBaoDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbKhoBaoDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbKhoBaoDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.gbKhoBaoDong.Location = new System.Drawing.Point(23, 298);
            this.gbKhoBaoDong.Name = "gbKhoBaoDong";
            this.gbKhoBaoDong.Padding = new System.Windows.Forms.Padding(10);
            this.gbKhoBaoDong.Size = new System.Drawing.Size(1154, 269);
            this.gbKhoBaoDong.Text = "⚠️ CẢNH BÁO: NGUYÊN LIỆU SẮP HẾT";
            // 
            // dgvKhoBaoDong
            // 
            this.dgvKhoBaoDong.AllowUserToAddRows = false;
            this.dgvKhoBaoDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoBaoDong.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoBaoDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoBaoDong.Location = new System.Drawing.Point(10, 35);
            this.dgvKhoBaoDong.Name = "dgvKhoBaoDong";
            this.dgvKhoBaoDong.ReadOnly = true;
            this.dgvKhoBaoDong.RowHeadersVisible = false;
            this.dgvKhoBaoDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvKhoBaoDong.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvKhoBaoDong_CellFormatting);
            // 
            // UC_QL_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlTop);
            this.Name = "UC_QL_BaoCao";
            this.Size = new System.Drawing.Size(1200, 800);
            this.Load += new System.EventHandler(this.UC_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlCardDoanhThu.ResumeLayout(false);
            this.pnlCardDoanhThu.PerformLayout();
            this.pnlCardDonHang.ResumeLayout(false);
            this.pnlCardDonHang.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.gbTopMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopMon)).EndInit();
            this.gbDoanhThu7Ngay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu7Ngay)).EndInit();
            this.gbKhoBaoDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoBaoDong)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlCardDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuSo;
        private System.Windows.Forms.Label lblDoanhThuTitle;
        private System.Windows.Forms.Panel pnlCardDonHang;
        private System.Windows.Forms.Label lblDonHangSo;
        private System.Windows.Forms.Label lblDonHangTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbTopMon;
        private System.Windows.Forms.DataGridView dgvTopMon;
        private System.Windows.Forms.GroupBox gbDoanhThu7Ngay;
        private System.Windows.Forms.DataGridView dgvDoanhThu7Ngay;
        private System.Windows.Forms.GroupBox gbKhoBaoDong;
        private System.Windows.Forms.DataGridView dgvKhoBaoDong;
    }
}