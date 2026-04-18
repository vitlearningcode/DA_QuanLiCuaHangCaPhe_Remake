namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class frm_ThemPhieuChi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            cboHạngMuc = new ComboBox();
            label2 = new Label();
            txtSoTien = new TextBox();
            label3 = new Label();
            txtGhiChu = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Crimson;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(384, 50);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "LẬP PHIẾU CHI MỚI";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(30, 70);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Hạng mục:";
            // 
            // cboHạngMuc
            // 
            cboHạngMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHạngMuc.FormattingEnabled = true;
            cboHạngMuc.Items.AddRange(new object[] { "Tiền Điện Nước", "Tiền Mặt Bằng", "Tiền Rác", "Trả Lương NV", "Chi Khác" });
            cboHạngMuc.Location = new Point(130, 67);
            cboHạngMuc.Name = "cboHạngMuc";
            cboHạngMuc.Size = new Size(220, 23);
            cboHạngMuc.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(30, 115);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 2;
            label2.Text = "Số tiền chi:";
            // 
            // txtSoTien
            // 
            txtSoTien.Font = new Font("Segoe UI", 11F);
            txtSoTien.Location = new Point(130, 109);
            txtSoTien.Name = "txtSoTien";
            txtSoTien.Size = new Size(220, 27);
            txtSoTien.TabIndex = 3;
            txtSoTien.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(30, 160);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 4;
            label3.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(130, 157);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(220, 80);
            txtGhiChu.TabIndex = 5;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Crimson;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(60, 260);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(130, 40);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "XÁC NHẬN CHI";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Silver;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Location = new Point(200, 260);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 40);
            btnHuy.TabIndex = 7;
            btnHuy.Text = "HỦY BỎ";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // frm_ThemPhieuChi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 331);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtGhiChu);
            Controls.Add(label3);
            Controls.Add(txtSoTien);
            Controls.Add(label2);
            Controls.Add(cboHạngMuc);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frm_ThemPhieuChi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lập Phiếu Chi";
            Load += frm_ThemPhieuChi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private ComboBox cboHạngMuc;
        private Label label2;
        private TextBox txtSoTien;
        private Label label3;
        private TextBox txtGhiChu;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblTitle;
    }
}