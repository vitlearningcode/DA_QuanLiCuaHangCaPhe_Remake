namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_SoQuy
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            btnTaoPhieuChi = new Button();
            cboLocThuChi = new ComboBox();
            btnLoc = new Button();
            dtpDenNgay = new DateTimePicker();
            label2 = new Label();
            dtpTuNgay = new DateTimePicker();
            label1 = new Label();
            pnlTongKet = new Panel();
            pnlTonQuy = new Panel();
            lblTonQuy = new Label();
            label6 = new Label();
            pnlTongChi = new Panel();
            lblTongChi = new Label();
            label5 = new Label();
            pnlTongThu = new Panel();
            lblTongThu = new Label();
            label3 = new Label();
            dgvSoQuy = new DataGridView();
            pnlTop.SuspendLayout();
            pnlTongKet.SuspendLayout();
            pnlTonQuy.SuspendLayout();
            pnlTongChi.SuspendLayout();
            pnlTongThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSoQuy).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(btnTaoPhieuChi);
            pnlTop.Controls.Add(cboLocThuChi);
            pnlTop.Controls.Add(btnLoc);
            pnlTop.Controls.Add(dtpDenNgay);
            pnlTop.Controls.Add(label2);
            pnlTop.Controls.Add(dtpTuNgay);
            pnlTop.Controls.Add(label1);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(900, 60);
            pnlTop.TabIndex = 0;
            // 
            // btnTaoPhieuChi
            // 
            btnTaoPhieuChi.BackColor = Color.Crimson;
            btnTaoPhieuChi.FlatStyle = FlatStyle.Flat;
            btnTaoPhieuChi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTaoPhieuChi.ForeColor = Color.White;
            btnTaoPhieuChi.Location = new Point(765, 15);
            btnTaoPhieuChi.Name = "btnTaoPhieuChi";
            btnTaoPhieuChi.Size = new Size(120, 30);
            btnTaoPhieuChi.TabIndex = 6;
            btnTaoPhieuChi.Text = "+ LẬP PHIẾU CHI";
            btnTaoPhieuChi.UseVisualStyleBackColor = false;
            btnTaoPhieuChi.Click += btnTaoPhieuChi_Click;
            // 
            // cboLocThuChi
            // 
            cboLocThuChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocThuChi.FormattingEnabled = true;
            cboLocThuChi.Items.AddRange(new object[] { "Tất cả giao dịch", "Chỉ phiếu Thu", "Chỉ phiếu Chi" });
            cboLocThuChi.Location = new Point(610, 18);
            cboLocThuChi.Name = "cboLocThuChi";
            cboLocThuChi.Size = new Size(140, 23);
            cboLocThuChi.TabIndex = 5;
            cboLocThuChi.SelectedIndexChanged += cboLocThuChi_SelectedIndexChanged;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.DodgerBlue;
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLoc.ForeColor = Color.White;
            btnLoc.Location = new Point(480, 15);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(110, 30);
            btnLoc.TabIndex = 4;
            btnLoc.Text = "XEM SỔ QUỸ";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(340, 18);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(120, 23);
            dtpDenNgay.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(275, 21);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 2;
            label2.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(140, 18);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(120, 23);
            dtpTuNgay.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(15, 21);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 0;
            label1.Text = "Thời gian (Từ ngày):";
            // 
            // pnlTongKet
            // 
            pnlTongKet.Controls.Add(pnlTonQuy);
            pnlTongKet.Controls.Add(pnlTongChi);
            pnlTongKet.Controls.Add(pnlTongThu);
            pnlTongKet.Dock = DockStyle.Top;
            pnlTongKet.Location = new Point(0, 60);
            pnlTongKet.Name = "pnlTongKet";
            pnlTongKet.Padding = new Padding(10);
            pnlTongKet.Size = new Size(900, 110);
            pnlTongKet.TabIndex = 1;
            // 
            // pnlTonQuy
            // 
            pnlTonQuy.BackColor = Color.FromArgb(0, 120, 215);
            pnlTonQuy.Controls.Add(lblTonQuy);
            pnlTonQuy.Controls.Add(label6);
            pnlTonQuy.Location = new Point(605, 10);
            pnlTonQuy.Name = "pnlTonQuy";
            pnlTonQuy.Size = new Size(280, 90);
            pnlTonQuy.TabIndex = 2;
            // 
            // lblTonQuy
            // 
            lblTonQuy.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTonQuy.ForeColor = Color.White;
            lblTonQuy.Location = new Point(0, 40);
            lblTonQuy.Name = "lblTonQuy";
            lblTonQuy.Size = new Size(280, 40);
            lblTonQuy.TabIndex = 1;
            lblTonQuy.Text = "0 đ";
            lblTonQuy.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(80, 10);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 0;
            label6.Text = "TỒN QUỸ LŨY KẾ";
            // 
            // pnlTongChi
            // 
            pnlTongChi.BackColor = Color.FromArgb(220, 53, 69);
            pnlTongChi.Controls.Add(lblTongChi);
            pnlTongChi.Controls.Add(label5);
            pnlTongChi.Location = new Point(310, 10);
            pnlTongChi.Name = "pnlTongChi";
            pnlTongChi.Size = new Size(280, 90);
            pnlTongChi.TabIndex = 1;
            // 
            // lblTongChi
            // 
            lblTongChi.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTongChi.ForeColor = Color.White;
            lblTongChi.Location = new Point(0, 40);
            lblTongChi.Name = "lblTongChi";
            lblTongChi.Size = new Size(280, 40);
            lblTongChi.TabIndex = 1;
            lblTongChi.Text = "0 đ";
            lblTongChi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(100, 10);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 0;
            label5.Text = "TỔNG CHI";
            // 
            // pnlTongThu
            // 
            pnlTongThu.BackColor = Color.FromArgb(40, 167, 69);
            pnlTongThu.Controls.Add(lblTongThu);
            pnlTongThu.Controls.Add(label3);
            pnlTongThu.Location = new Point(15, 10);
            pnlTongThu.Name = "pnlTongThu";
            pnlTongThu.Size = new Size(280, 90);
            pnlTongThu.TabIndex = 0;
            // 
            // lblTongThu
            // 
            lblTongThu.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTongThu.ForeColor = Color.White;
            lblTongThu.Location = new Point(0, 40);
            lblTongThu.Name = "lblTongThu";
            lblTongThu.Size = new Size(280, 40);
            lblTongThu.TabIndex = 1;
            lblTongThu.Text = "0 đ";
            lblTongThu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(100, 10);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 0;
            label3.Text = "TỔNG THU";
            // 
            // dgvSoQuy
            // 
            dgvSoQuy.AllowUserToAddRows = false;
            dgvSoQuy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSoQuy.BackgroundColor = Color.White;
            dgvSoQuy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSoQuy.Dock = DockStyle.Fill;
            dgvSoQuy.Location = new Point(0, 170);
            dgvSoQuy.Name = "dgvSoQuy";
            dgvSoQuy.ReadOnly = true;
            dgvSoQuy.RowHeadersVisible = false;
            dgvSoQuy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSoQuy.Size = new Size(900, 430);
            dgvSoQuy.TabIndex = 2;
            dgvSoQuy.CellFormatting += dgvSoQuy_CellFormatting;
            // 
            // UC_SoQuy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvSoQuy);
            Controls.Add(pnlTongKet);
            Controls.Add(pnlTop);
            Name = "UC_SoQuy";
            Size = new Size(900, 600);
            Load += UC_SoQuy_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlTongKet.ResumeLayout(false);
            pnlTonQuy.ResumeLayout(false);
            pnlTonQuy.PerformLayout();
            pnlTongChi.ResumeLayout(false);
            pnlTongChi.PerformLayout();
            pnlTongThu.ResumeLayout(false);
            pnlTongThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSoQuy).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label label1;
        private DateTimePicker dtpTuNgay;
        private Label label2;
        private DateTimePicker dtpDenNgay;
        private Button btnLoc;
        private ComboBox cboLocThuChi;
        private Button btnTaoPhieuChi;
        private Panel pnlTongKet;
        private Panel pnlTongThu;
        private Label lblTongThu;
        private Label label3;
        private Panel pnlTongChi;
        private Label lblTongChi;
        private Label label5;
        private Panel pnlTonQuy;
        private Label lblTonQuy;
        private Label label6;
        private DataGridView dgvSoQuy;
    }
}