namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_SanPham
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
            pnlLeft = new Panel();
            flpDanhSachMon = new FlowLayoutPanel();
            txtTimKiem = new TextBox();
            btnTaoMonMoi = new Button();
            lbl_TitleLeft = new Label();
            pnlRight = new Panel();
            btnLuu = new Button();
            gbCongThuc = new GroupBox();
            dgvCongThuc = new DataGridView();
            btnXoaNL = new Button();
            btnThemNL = new Button();
            txtSoLuongNL = new TextBox();
            label2 = new Label();
            cboNguyenLieu = new ComboBox();
            label1 = new Label();
            gbThongTin = new GroupBox();
            cboTrangThai = new ComboBox();
            lbl_TrangThai = new Label();
            txtGiaBan = new TextBox();
            lbl_DonGia = new Label();
            cboLoai = new ComboBox();
            lbl_LoaiMon = new Label();
            txtTenMon = new TextBox();
            lbl_TenMon = new Label();
            lblTitle = new Label();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            gbCongThuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCongThuc).BeginInit();
            gbThongTin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft (Bề ngang 340px)
            // 
            pnlLeft.BackColor = Color.WhiteSmoke;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(flpDanhSachMon);
            pnlLeft.Controls.Add(txtTimKiem);
            pnlLeft.Controls.Add(btnTaoMonMoi);
            pnlLeft.Controls.Add(lbl_TitleLeft);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(340, 700);
            pnlLeft.TabIndex = 0;
            // lbl_TitleLeft
            lbl_TitleLeft.Dock = DockStyle.Top;
            lbl_TitleLeft.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbl_TitleLeft.ForeColor = Color.DarkSlateBlue;
            lbl_TitleLeft.Location = new Point(0, 0);
            lbl_TitleLeft.Name = "lbl_TitleLeft";
            lbl_TitleLeft.Size = new Size(338, 50);
            lbl_TitleLeft.Text = "MENU SẢN PHẨM";
            lbl_TitleLeft.TextAlign = ContentAlignment.MiddleCenter;
            // btnTaoMonMoi
            btnTaoMonMoi.BackColor = Color.DodgerBlue;
            btnTaoMonMoi.FlatStyle = FlatStyle.Flat;
            btnTaoMonMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaoMonMoi.ForeColor = Color.White;
            btnTaoMonMoi.Location = new Point(15, 60);
            btnTaoMonMoi.Name = "btnTaoMonMoi";
            btnTaoMonMoi.Size = new Size(305, 45);
            btnTaoMonMoi.Text = "+ TẠO MÓN MỚI";
            btnTaoMonMoi.UseVisualStyleBackColor = false;
            // txtTimKiem
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(15, 120);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = " 🔍 Gõ tìm tên món hoặc loại...";
            txtTimKiem.Size = new Size(305, 25);
            // flpDanhSachMon
            flpDanhSachMon.AutoScroll = true;
            flpDanhSachMon.BackColor = Color.White;
            flpDanhSachMon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpDanhSachMon.Location = new Point(15, 160);
            flpDanhSachMon.Name = "flpDanhSachMon";
            flpDanhSachMon.Padding = new Padding(5);
            flpDanhSachMon.Size = new Size(305, 520);
            flpDanhSachMon.TabIndex = 3;
            // 
            // pnlRight (Khu vực chính diện)
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(btnLuu);
            pnlRight.Controls.Add(gbCongThuc);
            pnlRight.Controls.Add(gbThongTin);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(340, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(20);
            pnlRight.Size = new Size(660, 700);
            pnlRight.TabIndex = 1;
            // lblTitle
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateBlue;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(620, 40);
            lblTitle.Text = "THIẾT LẬP CHI TIẾT SẢN PHẨM";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // gbThongTin
            gbThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbThongTin.Controls.Add(cboTrangThai);
            gbThongTin.Controls.Add(lbl_TrangThai);
            gbThongTin.Controls.Add(txtGiaBan);
            gbThongTin.Controls.Add(lbl_DonGia);
            gbThongTin.Controls.Add(cboLoai);
            gbThongTin.Controls.Add(lbl_LoaiMon);
            gbThongTin.Controls.Add(txtTenMon);
            gbThongTin.Controls.Add(lbl_TenMon);
            gbThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbThongTin.Location = new Point(20, 70);
            gbThongTin.Name = "gbThongTin";
            gbThongTin.Size = new Size(620, 150);
            gbThongTin.Text = "1. Thông tin cơ bản";
            // Dòng 1
            lbl_TenMon.Location = new Point(20, 30);
            lbl_TenMon.Text = "Tên món / Sản phẩm:";
            txtTenMon.Location = new Point(20, 50);
            txtTenMon.Font = new Font("Segoe UI", 9F);
            txtTenMon.Size = new Size(270, 23);
            lbl_LoaiMon.Location = new Point(310, 30);
            lbl_LoaiMon.Text = "Loại (Nhóm):";
            cboLoai.Location = new Point(310, 50);
            cboLoai.Font = new Font("Segoe UI", 9F);
            cboLoai.Size = new Size(290, 23);
            cboLoai.FormattingEnabled = true;
            // Dòng 2
            lbl_DonGia.Location = new Point(20, 90);
            lbl_DonGia.Text = "Giá bán niêm yết (VNĐ):";
            txtGiaBan.Location = new Point(20, 110);
            txtGiaBan.Font = new Font("Segoe UI", 9F);
            txtGiaBan.Size = new Size(270, 23);
            lbl_TrangThai.Location = new Point(310, 90);
            lbl_TrangThai.Text = "Trạng thái kinh doanh:";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(310, 110);
            cboTrangThai.Font = new Font("Segoe UI", 9F);
            cboTrangThai.Size = new Size(290, 23);
            cboTrangThai.Items.AddRange(new object[] { "Còn bán", "Ngừng kinh doanh" });
            // gbCongThuc
            gbCongThuc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbCongThuc.Controls.Add(dgvCongThuc);
            gbCongThuc.Controls.Add(btnXoaNL);
            gbCongThuc.Controls.Add(btnThemNL);
            gbCongThuc.Controls.Add(txtSoLuongNL);
            gbCongThuc.Controls.Add(label2);
            gbCongThuc.Controls.Add(cboNguyenLieu);
            gbCongThuc.Controls.Add(label1);
            gbCongThuc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbCongThuc.Location = new Point(20, 235);
            gbCongThuc.Name = "gbCongThuc";
            gbCongThuc.Size = new Size(620, 380);
            gbCongThuc.Text = "2. Thiết lập Công thức / Định lượng (Tùy chọn)";
            label1.Location = new Point(20, 30);
            label1.Text = "Chọn Nguyên liệu từ Kho:";
            cboNguyenLieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguyenLieu.Location = new Point(20, 50);
            cboNguyenLieu.Font = new Font("Segoe UI", 9F);
            cboNguyenLieu.Size = new Size(230, 23);
            label2.Location = new Point(270, 30);
            label2.Text = "Định lượng tiêu hao:";
            txtSoLuongNL.Location = new Point(270, 50);
            txtSoLuongNL.Font = new Font("Segoe UI", 9F);
            txtSoLuongNL.Size = new Size(120, 23);
            btnThemNL.BackColor = Color.MediumSeaGreen;
            btnThemNL.FlatStyle = FlatStyle.Flat;
            btnThemNL.ForeColor = Color.White;
            btnThemNL.Location = new Point(410, 48);
            btnThemNL.Size = new Size(80, 27);
            btnThemNL.Text = "THÊM";
            btnThemNL.UseVisualStyleBackColor = false;
            btnXoaNL.BackColor = Color.Crimson;
            btnXoaNL.FlatStyle = FlatStyle.Flat;
            btnXoaNL.ForeColor = Color.White;
            btnXoaNL.Location = new Point(500, 48);
            btnXoaNL.Size = new Size(100, 27);
            btnXoaNL.Text = "XÓA CHỌN";
            btnXoaNL.UseVisualStyleBackColor = false;
            dgvCongThuc.AllowUserToAddRows = false;
            dgvCongThuc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCongThuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCongThuc.BackgroundColor = Color.WhiteSmoke;
            dgvCongThuc.Location = new Point(20, 90);
            dgvCongThuc.Name = "dgvCongThuc";
            dgvCongThuc.ReadOnly = true;
            dgvCongThuc.RowHeadersVisible = false;
            dgvCongThuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongThuc.Size = new Size(580, 270);
            dgvCongThuc.Font = new Font("Segoe UI", 9F);
            // btnLuu
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLuu.BackColor = Color.DarkSlateBlue;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(20, 630);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(620, 50);
            btnLuu.Text = "💾 LƯU SẢN PHẨM & CÔNG THỨC";
            btnLuu.UseVisualStyleBackColor = false;
            // UC_SanPham
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "UC_SanPham";
            Size = new Size(1000, 700);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            gbCongThuc.ResumeLayout(false);
            gbCongThuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCongThuc).EndInit();
            gbThongTin.ResumeLayout(false);
            gbThongTin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lbl_TitleLeft;
        private System.Windows.Forms.Button btnTaoMonMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachMon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lbl_TenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lbl_LoaiMon;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lbl_DonGia;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lbl_TrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.GroupBox gbCongThuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNguyenLieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLuongNL;
        private System.Windows.Forms.Button btnThemNL;
        private System.Windows.Forms.Button btnXoaNL;
        private System.Windows.Forms.DataGridView dgvCongThuc;
        private System.Windows.Forms.Button btnLuu;
    }
}