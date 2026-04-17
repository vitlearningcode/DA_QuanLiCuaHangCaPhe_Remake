namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_Kho
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tab_Kho = new TabControl();
            DanhSach_TonKho = new TabPage();
            dgvNguyenLieu = new DataGridView();
            panel1 = new Panel();
            btnSuaNL = new Button();
            btnXoaNL = new Button();
            btnLamMoi = new Button();
            btnThemNL = new Button();
            lbl_DVT = new Label();
            lbl_tenNL = new Label();
            txtDonVi = new TextBox();
            txtTenNL = new TextBox();
            NhapHang = new TabPage();
            dgvChiTietNhap = new DataGridView();
            btnLuuPhieu = new Button();
            txtDonGia = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            btnThemVaoPhieu = new Button();
            txtSoLuongNhap = new TextBox();
            cboNhaCungCap = new ComboBox();
            cboChonNL_Tab2 = new ComboBox();
            lbl_GiaNhap = new Label();
            lbl_SoLuongNhap = new Label();
            label1 = new Label();
            lbl_ChonNgayNhap = new Label();
            lbl_ChonNguyenLieu = new Label();
            tab_Kho.SuspendLayout();
            DanhSach_TonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).BeginInit();
            panel1.SuspendLayout();
            NhapHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            SuspendLayout();
            // 
            // tab_Kho
            // 
            tab_Kho.Controls.Add(DanhSach_TonKho);
            tab_Kho.Controls.Add(NhapHang);
            tab_Kho.Dock = DockStyle.Fill;
            tab_Kho.Location = new Point(0, 0);
            tab_Kho.Margin = new Padding(1, 1, 1, 1);
            tab_Kho.Name = "tab_Kho";
            tab_Kho.SelectedIndex = 0;
            tab_Kho.Size = new Size(592, 363);
            tab_Kho.TabIndex = 0;
            // 
            // DanhSach_TonKho
            // 
            DanhSach_TonKho.Controls.Add(dgvNguyenLieu);
            DanhSach_TonKho.Controls.Add(panel1);
            DanhSach_TonKho.Location = new Point(4, 24);
            DanhSach_TonKho.Margin = new Padding(1, 1, 1, 1);
            DanhSach_TonKho.Name = "DanhSach_TonKho";
            DanhSach_TonKho.Padding = new Padding(1, 1, 1, 1);
            DanhSach_TonKho.Size = new Size(473, 251);
            DanhSach_TonKho.TabIndex = 0;
            DanhSach_TonKho.Text = "Danh Sách & Tồn Kho";
            DanhSach_TonKho.UseVisualStyleBackColor = true;
            // 
            // dgvNguyenLieu
            // 
            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguyenLieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNguyenLieu.Dock = DockStyle.Fill;
            dgvNguyenLieu.Location = new Point(207, 1);
            dgvNguyenLieu.Margin = new Padding(1, 1, 1, 1);
            dgvNguyenLieu.Name = "dgvNguyenLieu";
            dgvNguyenLieu.RowHeadersWidth = 102;
            dgvNguyenLieu.Size = new Size(265, 249);
            dgvNguyenLieu.TabIndex = 1;
            dgvNguyenLieu.CellClick += dgvNguyenLieu_CellClick;
            dgvNguyenLieu.CellContentClick += dgvNguyenLieu_CellContentClick;
            dgvNguyenLieu.CellFormatting += dgvNguyenLieu_CellFormatting;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSuaNL);
            panel1.Controls.Add(btnXoaNL);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(btnThemNL);
            panel1.Controls.Add(lbl_DVT);
            panel1.Controls.Add(lbl_tenNL);
            panel1.Controls.Add(txtDonVi);
            panel1.Controls.Add(txtTenNL);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(1, 1);
            panel1.Margin = new Padding(1, 1, 1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 249);
            panel1.TabIndex = 0;
            // 
            // btnSuaNL
            // 
            btnSuaNL.Location = new Point(108, 160);
            btnSuaNL.Margin = new Padding(1, 1, 1, 1);
            btnSuaNL.Name = "btnSuaNL";
            btnSuaNL.Size = new Size(77, 21);
            btnSuaNL.TabIndex = 2;
            btnSuaNL.Text = "Sửa";
            btnSuaNL.UseVisualStyleBackColor = true;
            btnSuaNL.Click += btnSuaNL_Click;
            // 
            // btnXoaNL
            // 
            btnXoaNL.Location = new Point(108, 124);
            btnXoaNL.Margin = new Padding(1, 1, 1, 1);
            btnXoaNL.Name = "btnXoaNL";
            btnXoaNL.Size = new Size(77, 21);
            btnXoaNL.TabIndex = 2;
            btnXoaNL.Text = "Xoá";
            btnXoaNL.UseVisualStyleBackColor = true;
            btnXoaNL.Click += btnXoaNL_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(7, 160);
            btnLamMoi.Margin = new Padding(1, 1, 1, 1);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(77, 21);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThemNL
            // 
            btnThemNL.Location = new Point(7, 124);
            btnThemNL.Margin = new Padding(1, 1, 1, 1);
            btnThemNL.Name = "btnThemNL";
            btnThemNL.Size = new Size(77, 21);
            btnThemNL.TabIndex = 2;
            btnThemNL.Text = "Thêm";
            btnThemNL.UseVisualStyleBackColor = true;
            btnThemNL.Click += btnThemNL_Click;
            // 
            // lbl_DVT
            // 
            lbl_DVT.AutoSize = true;
            lbl_DVT.Location = new Point(7, 40);
            lbl_DVT.Margin = new Padding(1, 0, 1, 0);
            lbl_DVT.Name = "lbl_DVT";
            lbl_DVT.Size = new Size(32, 15);
            lbl_DVT.TabIndex = 1;
            lbl_DVT.Text = "ĐVT:";
            // 
            // lbl_tenNL
            // 
            lbl_tenNL.AutoSize = true;
            lbl_tenNL.Location = new Point(7, 12);
            lbl_tenNL.Margin = new Padding(1, 0, 1, 0);
            lbl_tenNL.Name = "lbl_tenNL";
            lbl_tenNL.Size = new Size(47, 15);
            lbl_tenNL.TabIndex = 1;
            lbl_tenNL.Text = "Tên NL:";
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(113, 40);
            txtDonVi.Margin = new Padding(1, 1, 1, 1);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(75, 23);
            txtDonVi.TabIndex = 0;
            // 
            // txtTenNL
            // 
            txtTenNL.Location = new Point(113, 11);
            txtTenNL.Margin = new Padding(1, 1, 1, 1);
            txtTenNL.Name = "txtTenNL";
            txtTenNL.Size = new Size(75, 23);
            txtTenNL.TabIndex = 0;
            // 
            // NhapHang
            // 
            NhapHang.Controls.Add(dgvChiTietNhap);
            NhapHang.Controls.Add(btnLuuPhieu);
            NhapHang.Controls.Add(txtDonGia);
            NhapHang.Controls.Add(dtpNgayNhap);
            NhapHang.Controls.Add(btnThemVaoPhieu);
            NhapHang.Controls.Add(txtSoLuongNhap);
            NhapHang.Controls.Add(cboNhaCungCap);
            NhapHang.Controls.Add(cboChonNL_Tab2);
            NhapHang.Controls.Add(lbl_GiaNhap);
            NhapHang.Controls.Add(lbl_SoLuongNhap);
            NhapHang.Controls.Add(label1);
            NhapHang.Controls.Add(lbl_ChonNgayNhap);
            NhapHang.Controls.Add(lbl_ChonNguyenLieu);
            NhapHang.Location = new Point(4, 24);
            NhapHang.Margin = new Padding(1, 1, 1, 1);
            NhapHang.Name = "NhapHang";
            NhapHang.Padding = new Padding(1, 1, 1, 1);
            NhapHang.Size = new Size(584, 335);
            NhapHang.TabIndex = 1;
            NhapHang.Text = "Nhập Hàng";
            NhapHang.UseVisualStyleBackColor = true;
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Dock = DockStyle.Bottom;
            dgvChiTietNhap.Location = new Point(1, 226);
            dgvChiTietNhap.Margin = new Padding(1, 1, 1, 1);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.RowHeadersWidth = 102;
            dgvChiTietNhap.Size = new Size(582, 108);
            dgvChiTietNhap.TabIndex = 6;
            // 
            // btnLuuPhieu
            // 
            btnLuuPhieu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLuuPhieu.Location = new Point(289, 147);
            btnLuuPhieu.Margin = new Padding(1, 1, 1, 1);
            btnLuuPhieu.Name = "btnLuuPhieu";
            btnLuuPhieu.Size = new Size(188, 21);
            btnLuuPhieu.TabIndex = 7;
            btnLuuPhieu.Text = "Lưu";
            btnLuuPhieu.UseVisualStyleBackColor = true;
            btnLuuPhieu.Click += btnLuuPhieu_Click;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(133, 89);
            txtDonGia.Margin = new Padding(1, 1, 1, 1);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(105, 23);
            txtDonGia.TabIndex = 5;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(133, 31);
            dtpNgayNhap.Margin = new Padding(1, 1, 1, 1);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(208, 23);
            dtpNgayNhap.TabIndex = 4;
            // 
            // btnThemVaoPhieu
            // 
            btnThemVaoPhieu.BackColor = Color.FromArgb(0, 192, 0);
            btnThemVaoPhieu.Location = new Point(133, 147);
            btnThemVaoPhieu.Margin = new Padding(1, 1, 1, 1);
            btnThemVaoPhieu.Name = "btnThemVaoPhieu";
            btnThemVaoPhieu.Size = new Size(137, 23);
            btnThemVaoPhieu.TabIndex = 3;
            btnThemVaoPhieu.Text = "Thêm vào Phiếu";
            btnThemVaoPhieu.UseVisualStyleBackColor = false;
            btnThemVaoPhieu.Click += btnThemVaoPhieu_Click;
            // 
            // txtSoLuongNhap
            // 
            txtSoLuongNhap.Location = new Point(133, 118);
            txtSoLuongNhap.Margin = new Padding(1, 1, 1, 1);
            txtSoLuongNhap.Name = "txtSoLuongNhap";
            txtSoLuongNhap.Size = new Size(105, 23);
            txtSoLuongNhap.TabIndex = 2;
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(133, 2);
            cboNhaCungCap.Margin = new Padding(1, 1, 1, 1);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(127, 23);
            cboNhaCungCap.TabIndex = 1;
            // 
            // cboChonNL_Tab2
            // 
            cboChonNL_Tab2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChonNL_Tab2.FormattingEnabled = true;
            cboChonNL_Tab2.Location = new Point(133, 60);
            cboChonNL_Tab2.Margin = new Padding(1, 1, 1, 1);
            cboChonNL_Tab2.Name = "cboChonNL_Tab2";
            cboChonNL_Tab2.Size = new Size(127, 23);
            cboChonNL_Tab2.TabIndex = 1;
            // 
            // lbl_GiaNhap
            // 
            lbl_GiaNhap.AutoSize = true;
            lbl_GiaNhap.Location = new Point(8, 88);
            lbl_GiaNhap.Margin = new Padding(1, 0, 1, 0);
            lbl_GiaNhap.Name = "lbl_GiaNhap";
            lbl_GiaNhap.Size = new Size(56, 15);
            lbl_GiaNhap.TabIndex = 0;
            lbl_GiaNhap.Text = "Giá Nhập";
            // 
            // lbl_SoLuongNhap
            // 
            lbl_SoLuongNhap.AutoSize = true;
            lbl_SoLuongNhap.Location = new Point(8, 118);
            lbl_SoLuongNhap.Margin = new Padding(1, 0, 1, 0);
            lbl_SoLuongNhap.Name = "lbl_SoLuongNhap";
            lbl_SoLuongNhap.Size = new Size(89, 15);
            lbl_SoLuongNhap.TabIndex = 0;
            lbl_SoLuongNhap.Text = "Số Lượng Nhập";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 6);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Nhà Cung Cấp";
            // 
            // lbl_ChonNgayNhap
            // 
            lbl_ChonNgayNhap.AutoSize = true;
            lbl_ChonNgayNhap.Location = new Point(8, 32);
            lbl_ChonNgayNhap.Margin = new Padding(1, 0, 1, 0);
            lbl_ChonNgayNhap.Name = "lbl_ChonNgayNhap";
            lbl_ChonNgayNhap.Size = new Size(106, 15);
            lbl_ChonNgayNhap.TabIndex = 0;
            lbl_ChonNgayNhap.Text = "Chọn Nguyên Liệu";
            // 
            // lbl_ChonNguyenLieu
            // 
            lbl_ChonNguyenLieu.AutoSize = true;
            lbl_ChonNguyenLieu.Location = new Point(8, 62);
            lbl_ChonNguyenLieu.Margin = new Padding(1, 0, 1, 0);
            lbl_ChonNguyenLieu.Name = "lbl_ChonNguyenLieu";
            lbl_ChonNguyenLieu.Size = new Size(106, 15);
            lbl_ChonNguyenLieu.TabIndex = 0;
            lbl_ChonNguyenLieu.Text = "Chọn Nguyên Liệu";
            // 
            // UC_Kho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tab_Kho);
            Margin = new Padding(1, 1, 1, 1);
            Name = "UC_Kho";
            Size = new Size(592, 363);
            Load += UC_Kho_Load;
            tab_Kho.ResumeLayout(false);
            DanhSach_TonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            NhapHang.ResumeLayout(false);
            NhapHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tab_Kho;
        private TabPage DanhSach_TonKho;
        private TabPage NhapHang;
        private Panel panel1;
        private Label lbl_GiaNhap;
        private Label lbl_DVT;
        private Label lbl_tenNL;
        private TextBox txtDonGia;
        private TextBox txtTenNL;
        private TextBox txtDonVi;
        private DataGridView dgvNguyenLieu;
        private Button btnSuaNL;
        private Button btnXoaNL;
        private Button btnThemNL;
        private Button btnLamMoi;
        private Label lbl_ChonNguyenLieu;
        private ComboBox cboChonNL_Tab2;
        private Button btnThemVaoPhieu;
        private TextBox txtSoLuongNhap;
        private Label lbl_SoLuongNhap;
        private ComboBox cboNhaCungCap;
        //private TextBox txtDonGia;
        private DateTimePicker dtpNgayNhap;
        private Label label1;
        private Label lbl_ChonNgayNhap;
        private DataGridView dgvChiTietNhap;
        private Button btnLuuPhieu;
    }
}
