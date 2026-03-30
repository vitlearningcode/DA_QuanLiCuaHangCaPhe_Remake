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
            lbl_VaiTro = new Label();
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
            panel1.Margin = new Padding(1);
            panel1.Name = "panel1";
            panel1.Size = new Size(298, 395);
            panel1.TabIndex = 0;
            // 
            // gb_ThongTinDangNhap
            // 
            gb_ThongTinDangNhap.Controls.Add(btnResetMatKhau);
            gb_ThongTinDangNhap.Controls.Add(btnLuuTaiKhoan);
            gb_ThongTinDangNhap.Controls.Add(lbl_VaiTro);
            gb_ThongTinDangNhap.Controls.Add(lbl_MatKhau);
            gb_ThongTinDangNhap.Controls.Add(lbl_TenDangNhap);
            gb_ThongTinDangNhap.Controls.Add(txtPassword);
            gb_ThongTinDangNhap.Controls.Add(cboQuyen);
            gb_ThongTinDangNhap.Controls.Add(txtUsername);
            gb_ThongTinDangNhap.Location = new Point(1, 206);
            gb_ThongTinDangNhap.Margin = new Padding(1);
            gb_ThongTinDangNhap.Name = "gb_ThongTinDangNhap";
            gb_ThongTinDangNhap.Padding = new Padding(1);
            gb_ThongTinDangNhap.Size = new Size(296, 189);
            gb_ThongTinDangNhap.TabIndex = 5;
            gb_ThongTinDangNhap.TabStop = false;
            gb_ThongTinDangNhap.Text = "Thông tin đăng nhập";
            // 
            // btnResetMatKhau
            // 
            btnResetMatKhau.Location = new Point(124, 100);
            btnResetMatKhau.Margin = new Padding(1);
            btnResetMatKhau.Name = "btnResetMatKhau";
            btnResetMatKhau.Size = new Size(77, 21);
            btnResetMatKhau.TabIndex = 2;
            btnResetMatKhau.Text = "RESET";
            btnResetMatKhau.UseVisualStyleBackColor = true;
            btnResetMatKhau.Click += btnResetMatKhau_Click;
            // 
            // btnLuuTaiKhoan
            // 
            btnLuuTaiKhoan.Location = new Point(23, 100);
            btnLuuTaiKhoan.Margin = new Padding(1);
            btnLuuTaiKhoan.Name = "btnLuuTaiKhoan";
            btnLuuTaiKhoan.Size = new Size(77, 21);
            btnLuuTaiKhoan.TabIndex = 2;
            btnLuuTaiKhoan.Text = "Lưu";
            btnLuuTaiKhoan.UseVisualStyleBackColor = true;
            btnLuuTaiKhoan.Click += btnLuuTaiKhoan_Click;
            // 
            // lbl_VaiTro
            // 
            lbl_VaiTro.AutoSize = true;
            lbl_VaiTro.Location = new Point(5, 75);
            lbl_VaiTro.Margin = new Padding(1, 0, 1, 0);
            lbl_VaiTro.Name = "lbl_VaiTro";
            lbl_VaiTro.Size = new Size(42, 15);
            lbl_VaiTro.TabIndex = 0;
            lbl_VaiTro.Text = "Vai Trò";
            // 
            // lbl_MatKhau
            // 
            lbl_MatKhau.AutoSize = true;
            lbl_MatKhau.Location = new Point(5, 47);
            lbl_MatKhau.Margin = new Padding(1, 0, 1, 0);
            lbl_MatKhau.Name = "lbl_MatKhau";
            lbl_MatKhau.Size = new Size(57, 15);
            lbl_MatKhau.TabIndex = 0;
            lbl_MatKhau.Text = "Mật khẩu";
            // 
            // lbl_TenDangNhap
            // 
            lbl_TenDangNhap.AutoSize = true;
            lbl_TenDangNhap.Location = new Point(5, 25);
            lbl_TenDangNhap.Margin = new Padding(1, 0, 1, 0);
            lbl_TenDangNhap.Name = "lbl_TenDangNhap";
            lbl_TenDangNhap.Size = new Size(86, 15);
            lbl_TenDangNhap.TabIndex = 0;
            lbl_TenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(104, 47);
            txtPassword.Margin = new Padding(1);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(137, 23);
            txtPassword.TabIndex = 1;
            // 
            // cboQuyen
            // 
            cboQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuyen.FormattingEnabled = true;
            cboQuyen.Location = new Point(104, 74);
            cboQuyen.Margin = new Padding(1);
            cboQuyen.Name = "cboQuyen";
            cboQuyen.Size = new Size(127, 23);
            cboQuyen.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(104, 25);
            txtUsername.Margin = new Padding(1);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(139, 23);
            txtUsername.TabIndex = 1;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(201, 172);
            btnSua.Margin = new Padding(1);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(77, 21);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(115, 172);
            btnLamMoi.Margin = new Padding(1);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(77, 21);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(201, 139);
            btnXoa.Margin = new Padding(1);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(77, 21);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(115, 139);
            btnThem.Margin = new Padding(1);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(77, 21);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.Format = DateTimePickerFormat.Short;
            dtpNgayVaoLam.Location = new Point(115, 93);
            dtpNgayVaoLam.Margin = new Padding(1);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(163, 23);
            dtpNgayVaoLam.TabIndex = 3;
            // 
            // cboChucVu
            // 
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(115, 68);
            cboChucVu.Margin = new Padding(1);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(163, 23);
            cboChucVu.TabIndex = 2;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(115, 42);
            txtSDT.Margin = new Padding(1);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(163, 23);
            txtSDT.TabIndex = 1;
            // 
            // txtTenNV
            // 
            txtTenNV.Location = new Point(115, 16);
            txtTenNV.Margin = new Padding(1);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(163, 23);
            txtTenNV.TabIndex = 1;
            // 
            // lbl_NgayVaoLam
            // 
            lbl_NgayVaoLam.AutoSize = true;
            lbl_NgayVaoLam.Location = new Point(4, 93);
            lbl_NgayVaoLam.Margin = new Padding(1, 0, 1, 0);
            lbl_NgayVaoLam.Name = "lbl_NgayVaoLam";
            lbl_NgayVaoLam.Size = new Size(80, 15);
            lbl_NgayVaoLam.TabIndex = 0;
            lbl_NgayVaoLam.Text = "Ngày vào làm";
            // 
            // lbl_ChucVu
            // 
            lbl_ChucVu.AutoSize = true;
            lbl_ChucVu.Location = new Point(3, 68);
            lbl_ChucVu.Margin = new Padding(1, 0, 1, 0);
            lbl_ChucVu.Name = "lbl_ChucVu";
            lbl_ChucVu.Size = new Size(51, 15);
            lbl_ChucVu.TabIndex = 0;
            lbl_ChucVu.Text = "Chức vụ";
            // 
            // lbl_SĐT
            // 
            lbl_SĐT.AutoSize = true;
            lbl_SĐT.Location = new Point(1, 42);
            lbl_SĐT.Margin = new Padding(1, 0, 1, 0);
            lbl_SĐT.Name = "lbl_SĐT";
            lbl_SĐT.Size = new Size(40, 15);
            lbl_SĐT.TabIndex = 0;
            lbl_SĐT.Text = "txtSDT";
            // 
            // lbl_TenNV
            // 
            lbl_TenNV.AutoSize = true;
            lbl_TenNV.Location = new Point(-2, 15);
            lbl_TenNV.Margin = new Padding(1, 0, 1, 0);
            lbl_TenNV.Name = "lbl_TenNV";
            lbl_TenNV.Size = new Size(98, 15);
            lbl_TenNV.TabIndex = 0;
            lbl_TenNV.Text = "Họ tên nhân viên";
            // 
            // lbl_QLNV
            // 
            lbl_QLNV.AutoSize = true;
            lbl_QLNV.Location = new Point(0, 0);
            lbl_QLNV.Margin = new Padding(1, 0, 1, 0);
            lbl_QLNV.Name = "lbl_QLNV";
            lbl_QLNV.Size = new Size(122, 15);
            lbl_QLNV.TabIndex = 0;
            lbl_QLNV.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(298, 0);
            dgvNhanVien.Margin = new Padding(1);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 102;
            dgvNhanVien.Size = new Size(493, 395);
            dgvNhanVien.TabIndex = 1;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;
            // 
            // UC_NhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvNhanVien);
            Controls.Add(panel1);
            Margin = new Padding(1);
            Name = "UC_NhanVien";
            Size = new Size(791, 395);
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
        private Label lbl_VaiTro;
        private ComboBox cboQuyen;
    }
}
