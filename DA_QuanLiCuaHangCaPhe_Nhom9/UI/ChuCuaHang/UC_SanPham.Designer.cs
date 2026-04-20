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
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.WhiteSmoke;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(flpDanhSachMon);
            pnlLeft.Controls.Add(txtTimKiem);
            pnlLeft.Controls.Add(btnTaoMonMoi);
            pnlLeft.Controls.Add(lbl_TitleLeft);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Margin = new Padding(7, 8, 7, 8);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(823, 1913);
            pnlLeft.TabIndex = 0;
            // 
            // flpDanhSachMon
            // 
            flpDanhSachMon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpDanhSachMon.AutoScroll = true;
            flpDanhSachMon.BackColor = Color.White;
            flpDanhSachMon.Location = new Point(36, 437);
            flpDanhSachMon.Margin = new Padding(7, 8, 7, 8);
            flpDanhSachMon.Name = "flpDanhSachMon";
            flpDanhSachMon.Padding = new Padding(12, 14, 12, 14);
            flpDanhSachMon.Size = new Size(741, 1424);
            flpDanhSachMon.TabIndex = 3;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(36, 328);
            txtTimKiem.Margin = new Padding(7, 8, 7, 8);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = " 🔍 Gõ tìm tên món hoặc loại...";
            txtTimKiem.Size = new Size(735, 52);
            txtTimKiem.TabIndex = 4;
            // 
            // btnTaoMonMoi
            // 
            btnTaoMonMoi.BackColor = Color.DodgerBlue;
            btnTaoMonMoi.FlatStyle = FlatStyle.Flat;
            btnTaoMonMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaoMonMoi.ForeColor = Color.White;
            btnTaoMonMoi.Location = new Point(36, 164);
            btnTaoMonMoi.Margin = new Padding(7, 8, 7, 8);
            btnTaoMonMoi.Name = "btnTaoMonMoi";
            btnTaoMonMoi.Size = new Size(741, 123);
            btnTaoMonMoi.TabIndex = 5;
            btnTaoMonMoi.Text = "+ TẠO MÓN MỚI";
            btnTaoMonMoi.UseVisualStyleBackColor = false;
            // 
            // lbl_TitleLeft
            // 
            lbl_TitleLeft.Dock = DockStyle.Top;
            lbl_TitleLeft.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbl_TitleLeft.ForeColor = Color.DarkSlateBlue;
            lbl_TitleLeft.Location = new Point(0, 0);
            lbl_TitleLeft.Margin = new Padding(7, 0, 7, 0);
            lbl_TitleLeft.Name = "lbl_TitleLeft";
            lbl_TitleLeft.Size = new Size(821, 137);
            lbl_TitleLeft.TabIndex = 6;
            lbl_TitleLeft.Text = "MENU SẢN PHẨM";
            lbl_TitleLeft.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(btnLuu);
            pnlRight.Controls.Add(gbCongThuc);
            pnlRight.Controls.Add(gbThongTin);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(823, 0);
            pnlRight.Margin = new Padding(7, 8, 7, 8);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(49, 55, 49, 55);
            pnlRight.Size = new Size(1479, 1913);
            pnlRight.TabIndex = 1;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLuu.BackColor = Color.DarkSlateBlue;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(49, 1722);
            btnLuu.Margin = new Padding(7, 8, 7, 8);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(1343, 137);
            btnLuu.TabIndex = 0;
            btnLuu.Text = "💾 LƯU SẢN PHẨM & CÔNG THỨC";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // gbCongThuc
            // 
            gbCongThuc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbCongThuc.Controls.Add(dgvCongThuc);
            gbCongThuc.Controls.Add(btnXoaNL);
            gbCongThuc.Controls.Add(btnThemNL);
            gbCongThuc.Controls.Add(txtSoLuongNL);
            gbCongThuc.Controls.Add(label2);
            gbCongThuc.Controls.Add(cboNguyenLieu);
            gbCongThuc.Controls.Add(label1);
            gbCongThuc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbCongThuc.Location = new Point(49, 642);
            gbCongThuc.Margin = new Padding(7, 8, 7, 8);
            gbCongThuc.Name = "gbCongThuc";
            gbCongThuc.Padding = new Padding(7, 8, 7, 8);
            gbCongThuc.Size = new Size(1343, 1039);
            gbCongThuc.TabIndex = 1;
            gbCongThuc.TabStop = false;
            gbCongThuc.Text = "2. Thiết lập Công thức / Định lượng (Tùy chọn)";
            // 
            // dgvCongThuc
            // 
            dgvCongThuc.AllowUserToAddRows = false;
            dgvCongThuc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCongThuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCongThuc.BackgroundColor = Color.WhiteSmoke;
            dgvCongThuc.ColumnHeadersHeight = 58;
            dgvCongThuc.Font = new Font("Segoe UI", 9F);
            dgvCongThuc.Location = new Point(49, 246);
            dgvCongThuc.Margin = new Padding(7, 8, 7, 8);
            dgvCongThuc.Name = "dgvCongThuc";
            dgvCongThuc.ReadOnly = true;
            dgvCongThuc.RowHeadersVisible = false;
            dgvCongThuc.RowHeadersWidth = 102;
            dgvCongThuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongThuc.Size = new Size(1246, 738);
            dgvCongThuc.TabIndex = 0;
            // 
            // btnXoaNL
            // 
            btnXoaNL.BackColor = Color.Crimson;
            btnXoaNL.FlatStyle = FlatStyle.Flat;
            btnXoaNL.ForeColor = Color.White;
            btnXoaNL.Location = new Point(1119, 131);
            btnXoaNL.Margin = new Padding(7, 8, 7, 8);
            btnXoaNL.Name = "btnXoaNL";
            btnXoaNL.Size = new Size(208, 74);
            btnXoaNL.TabIndex = 1;
            btnXoaNL.Text = "XÓA CHỌN";
            btnXoaNL.UseVisualStyleBackColor = false;
            // 
            // btnThemNL
            // 
            btnThemNL.BackColor = Color.MediumSeaGreen;
            btnThemNL.FlatStyle = FlatStyle.Flat;
            btnThemNL.ForeColor = Color.White;
            btnThemNL.Location = new Point(914, 131);
            btnThemNL.Margin = new Padding(7, 8, 7, 8);
            btnThemNL.Name = "btnThemNL";
            btnThemNL.Size = new Size(177, 74);
            btnThemNL.TabIndex = 2;
            btnThemNL.Text = "THÊM";
            btnThemNL.UseVisualStyleBackColor = false;
            // 
            // txtSoLuongNL
            // 
            txtSoLuongNL.Font = new Font("Segoe UI", 9F);
            txtSoLuongNL.Location = new Point(561, 137);
            txtSoLuongNL.Margin = new Padding(7, 8, 7, 8);
            txtSoLuongNL.Name = "txtSoLuongNL";
            txtSoLuongNL.Size = new Size(326, 47);
            txtSoLuongNL.TabIndex = 3;
            // 
            // label2
            // 
            label2.Location = new Point(561, 82);
            label2.Margin = new Padding(7, 0, 7, 0);
            label2.Name = "label2";
            label2.Size = new Size(326, 63);
            label2.TabIndex = 4;
            label2.Text = "Định lượng tiêu hao:";
            // 
            // cboNguyenLieu
            // 
            cboNguyenLieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguyenLieu.Font = new Font("Segoe UI", 9F);
            cboNguyenLieu.Location = new Point(49, 137);
            cboNguyenLieu.Margin = new Padding(7, 8, 7, 8);
            cboNguyenLieu.Name = "cboNguyenLieu";
            cboNguyenLieu.Size = new Size(471, 49);
            cboNguyenLieu.TabIndex = 5;
            // 
            // label1
            // 
            label1.Location = new Point(49, 82);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(441, 63);
            label1.TabIndex = 6;
            label1.Text = "Chọn Nguyên liệu từ Kho:";
            // 
            // gbThongTin
            // 
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
            gbThongTin.Location = new Point(49, 191);
            gbThongTin.Margin = new Padding(7, 8, 7, 8);
            gbThongTin.Name = "gbThongTin";
            gbThongTin.Padding = new Padding(7, 8, 7, 8);
            gbThongTin.Size = new Size(1343, 410);
            gbThongTin.TabIndex = 2;
            gbThongTin.TabStop = false;
            gbThongTin.Text = "1. Thông tin cơ bản";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Font = new Font("Segoe UI", 9F);
            cboTrangThai.Items.AddRange(new object[] { "Còn bán", "Ngừng kinh doanh" });
            cboTrangThai.Location = new Point(753, 301);
            cboTrangThai.Margin = new Padding(7, 8, 7, 8);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(699, 49);
            cboTrangThai.TabIndex = 0;
            // 
            // lbl_TrangThai
            // 
            lbl_TrangThai.Location = new Point(753, 246);
            lbl_TrangThai.Margin = new Padding(7, 0, 7, 0);
            lbl_TrangThai.Name = "lbl_TrangThai";
            lbl_TrangThai.Size = new Size(468, 63);
            lbl_TrangThai.TabIndex = 1;
            lbl_TrangThai.Text = "Trạng thái kinh doanh:";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Font = new Font("Segoe UI", 9F);
            txtGiaBan.Location = new Point(49, 301);
            txtGiaBan.Margin = new Padding(7, 8, 7, 8);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(650, 47);
            txtGiaBan.TabIndex = 2;
            // 
            // lbl_DonGia
            // 
            lbl_DonGia.Location = new Point(49, 246);
            lbl_DonGia.Margin = new Padding(7, 0, 7, 0);
            lbl_DonGia.Name = "lbl_DonGia";
            lbl_DonGia.Size = new Size(471, 63);
            lbl_DonGia.TabIndex = 3;
            lbl_DonGia.Text = "Giá bán niêm yết (VNĐ):";
            // 
            // cboLoai
            // 
            cboLoai.Font = new Font("Segoe UI", 9F);
            cboLoai.FormattingEnabled = true;
            cboLoai.Location = new Point(753, 137);
            cboLoai.Margin = new Padding(7, 8, 7, 8);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(699, 49);
            cboLoai.TabIndex = 4;
            // 
            // lbl_LoaiMon
            // 
            lbl_LoaiMon.Location = new Point(753, 82);
            lbl_LoaiMon.Margin = new Padding(7, 0, 7, 0);
            lbl_LoaiMon.Name = "lbl_LoaiMon";
            lbl_LoaiMon.Size = new Size(243, 63);
            lbl_LoaiMon.TabIndex = 5;
            lbl_LoaiMon.Text = "Loại (Nhóm):";
            // 
            // txtTenMon
            // 
            txtTenMon.Font = new Font("Segoe UI", 9F);
            txtTenMon.Location = new Point(49, 137);
            txtTenMon.Margin = new Padding(7, 8, 7, 8);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(650, 47);
            txtTenMon.TabIndex = 6;
            // 
            // lbl_TenMon
            // 
            lbl_TenMon.Location = new Point(49, 82);
            lbl_TenMon.Margin = new Padding(7, 0, 7, 0);
            lbl_TenMon.Name = "lbl_TenMon";
            lbl_TenMon.Size = new Size(366, 63);
            lbl_TenMon.TabIndex = 7;
            lbl_TenMon.Text = "Tên món / Sản phẩm:";
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateBlue;
            lblTitle.Location = new Point(49, 55);
            lblTitle.Margin = new Padding(7, 0, 7, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1381, 109);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "THIẾT LẬP CHI TIẾT SẢN PHẨM";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_SanPham
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Margin = new Padding(7, 8, 7, 8);
            Name = "UC_SanPham";
            Size = new Size(2302, 1913);
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