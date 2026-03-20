namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_NhanVien
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
            panel1 = new Panel();
            gb_ThongTinDangNhap = new GroupBox();
            btnResetMatKhau = new Button();
            btnLuuTaiKhoan = new Button();
            label1 = new Label();
            lbl_MatKhau = new Label();
            lbl_TenDangNhap = new Label();
            txtPassword = new TextBox();
            cboQuyen = new ComboBox();
            txtUsername = new TextBox();
            btnSua = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            dtpNgayVaoLam = new DateTimePicker();
            cboChucVu = new ComboBox();
            txtSDT = new TextBox();
            txtTenNV = new TextBox();
            lbl_NgayVaoLam = new Label();
            lbl_ChucVu = new Label();
            lbl_SĐT = new Label();
            lbl_TenNV = new Label();
            lbl_QLNV = new Label();
            dgvNhanVien = new DataGridView();
            panel1.SuspendLayout();
            gb_ThongTinDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(gb_ThongTinDangNhap);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(dtpNgayVaoLam);
            panel1.Controls.Add(cboChucVu);
            panel1.Controls.Add(txtSDT);
            panel1.Controls.Add(txtTenNV);
            panel1.Controls.Add(lbl_NgayVaoLam);
            panel1.Controls.Add(lbl_ChucVu);
            panel1.Controls.Add(lbl_SĐT);
            panel1.Controls.Add(lbl_TenNV);
            panel1.Controls.Add(lbl_QLNV);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(723, 1080);
            panel1.TabIndex = 0;
            // 
            // gb_ThongTinDangNhap
            // 
            gb_ThongTinDangNhap.Controls.Add(btnResetMatKhau);
            gb_ThongTinDangNhap.Controls.Add(btnLuuTaiKhoan);
            gb_ThongTinDangNhap.Controls.Add(label1);
            gb_ThongTinDangNhap.Controls.Add(lbl_MatKhau);
            gb_ThongTinDangNhap.Controls.Add(lbl_TenDangNhap);
            gb_ThongTinDangNhap.Controls.Add(txtPassword);
            gb_ThongTinDangNhap.Controls.Add(cboQuyen);
            gb_ThongTinDangNhap.Controls.Add(txtUsername);
            gb_ThongTinDangNhap.Location = new Point(3, 563);
            gb_ThongTinDangNhap.Name = "gb_ThongTinDangNhap";
            gb_ThongTinDangNhap.Size = new Size(720, 517);
            gb_ThongTinDangNhap.TabIndex = 5;
            gb_ThongTinDangNhap.TabStop = false;
            gb_ThongTinDangNhap.Text = "Thông tin đăng nhập";
            // 
            // btnResetMatKhau
            // 
            btnResetMatKhau.Location = new Point(300, 272);
            btnResetMatKhau.Name = "btnResetMatKhau";
            btnResetMatKhau.Size = new Size(188, 58);
            btnResetMatKhau.TabIndex = 2;
            btnResetMatKhau.Text = "RESET";
            btnResetMatKhau.UseVisualStyleBackColor = true;
            btnResetMatKhau.Click += btnResetMatKhau_Click;
            // 
            // btnLuuTaiKhoan
            // 
            btnLuuTaiKhoan.Location = new Point(55, 272);
            btnLuuTaiKhoan.Name = "btnLuuTaiKhoan";
            btnLuuTaiKhoan.Size = new Size(188, 58);
            btnLuuTaiKhoan.TabIndex = 2;
            btnLuuTaiKhoan.Text = "Lưu";
            btnLuuTaiKhoan.UseVisualStyleBackColor = true;
            btnLuuTaiKhoan.Click += btnLuuTaiKhoan_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 204);
            label1.Name = "label1";
            label1.Size = new Size(142, 41);
            label1.TabIndex = 0;
            label1.Text = "Mật khẩu";
            // 
            // lbl_MatKhau
            // 
            lbl_MatKhau.AutoSize = true;
            lbl_MatKhau.Location = new Point(11, 128);
            lbl_MatKhau.Name = "lbl_MatKhau";
            lbl_MatKhau.Size = new Size(142, 41);
            lbl_MatKhau.TabIndex = 0;
            lbl_MatKhau.Text = "Mật khẩu";
            // 
            // lbl_TenDangNhap
            // 
            lbl_TenDangNhap.AutoSize = true;
            lbl_TenDangNhap.Location = new Point(11, 69);
            lbl_TenDangNhap.Name = "lbl_TenDangNhap";
            lbl_TenDangNhap.Size = new Size(215, 41);
            lbl_TenDangNhap.TabIndex = 0;
            lbl_TenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(252, 128);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(328, 47);
            txtPassword.TabIndex = 1;
            // 
            // cboQuyen
            // 
            cboQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuyen.FormattingEnabled = true;
            cboQuyen.Location = new Point(252, 201);
            cboQuyen.Name = "cboQuyen";
            cboQuyen.Size = new Size(302, 49);
            cboQuyen.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(252, 69);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(331, 47);
            txtUsername.TabIndex = 1;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(255, 400);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(188, 58);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(3, 391);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(188, 58);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(255, 308);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(188, 58);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(14, 308);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(188, 58);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.Format = DateTimePickerFormat.Short;
            dtpNgayVaoLam.Location = new Point(208, 208);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(500, 47);
            dtpNgayVaoLam.TabIndex = 3;
            // 
            // cboChucVu
            // 
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(141, 149);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(302, 49);
            cboChucVu.TabIndex = 2;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(141, 93);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(328, 47);
            txtSDT.TabIndex = 1;
            // 
            // txtTenNV
            // 
            txtTenNV.Location = new Point(280, 44);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(389, 47);
            txtTenNV.TabIndex = 1;
            // 
            // lbl_NgayVaoLam
            // 
            lbl_NgayVaoLam.AutoSize = true;
            lbl_NgayVaoLam.Location = new Point(3, 208);
            lbl_NgayVaoLam.Name = "lbl_NgayVaoLam";
            lbl_NgayVaoLam.Size = new Size(199, 41);
            lbl_NgayVaoLam.TabIndex = 0;
            lbl_NgayVaoLam.Text = "Ngày vào làm";
            // 
            // lbl_ChucVu
            // 
            lbl_ChucVu.AutoSize = true;
            lbl_ChucVu.Location = new Point(3, 149);
            lbl_ChucVu.Name = "lbl_ChucVu";
            lbl_ChucVu.Size = new Size(125, 41);
            lbl_ChucVu.TabIndex = 0;
            lbl_ChucVu.Text = "Chức vụ";
            // 
            // lbl_SĐT
            // 
            lbl_SĐT.AutoSize = true;
            lbl_SĐT.Location = new Point(0, 93);
            lbl_SĐT.Name = "lbl_SĐT";
            lbl_SĐT.Size = new Size(104, 41);
            lbl_SĐT.TabIndex = 0;
            lbl_SĐT.Text = "txtSDT";
            // 
            // lbl_TenNV
            // 
            lbl_TenNV.AutoSize = true;
            lbl_TenNV.Location = new Point(-4, 41);
            lbl_TenNV.Name = "lbl_TenNV";
            lbl_TenNV.Size = new Size(244, 41);
            lbl_TenNV.TabIndex = 0;
            lbl_TenNV.Text = "Họ tên nhân viên";
            // 
            // lbl_QLNV
            // 
            lbl_QLNV.AutoSize = true;
            lbl_QLNV.Location = new Point(0, 0);
            lbl_QLNV.Name = "lbl_QLNV";
            lbl_QLNV.Size = new Size(304, 41);
            lbl_QLNV.TabIndex = 0;
            lbl_QLNV.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(723, 0);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 102;
            dgvNhanVien.Size = new Size(1197, 1080);
            dgvNhanVien.TabIndex = 1;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;
            // 
            // UC_NhanVien
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvNhanVien);
            Controls.Add(panel1);
            Name = "UC_NhanVien";
            Size = new Size(1920, 1080);
            Load += UC_NhanVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gb_ThongTinDangNhap.ResumeLayout(false);
            gb_ThongTinDangNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvNhanVien;
        private Label lbl_QLNV;
        private Label lbl_SĐT;
        private Label lbl_TenNV;
        private TextBox txtSDT;
        private TextBox txtTenNV;
        private Button btnSua;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnThem;
        private DateTimePicker dtpNgayVaoLam;
        private ComboBox cboChucVu;
        private Label lbl_NgayVaoLam;
        private Label lbl_ChucVu;
        private GroupBox gb_ThongTinDangNhap;
        private Label lbl_MatKhau;
        private Label lbl_TenDangNhap;
        private Button btnResetMatKhau;
        private Button btnLuuTaiKhoan;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label1;
        private ComboBox cboQuyen;
    }
}
