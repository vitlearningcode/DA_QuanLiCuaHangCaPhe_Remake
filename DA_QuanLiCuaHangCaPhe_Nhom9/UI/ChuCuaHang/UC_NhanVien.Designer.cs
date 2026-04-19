namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_NhanVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            lblTitle = new Label();
            lbl_TenNV = new Label();
            txtTenNV = new TextBox();
            lbl_SĐT = new Label();
            txtSDT = new TextBox();
            lbl_ChucVu = new Label();
            cboChucVu = new ComboBox();
            lbl_NgayVaoLam = new Label();
            dtpNgayVaoLam = new DateTimePicker();
            gb_ThongTinDangNhap = new GroupBox();
            lbl_TenDangNhap = new Label();
            txtUsername = new TextBox();
            lbl_MatKhau = new Label();
            txtPassword = new TextBox();
            label1 = new Label();
            cboQuyen = new ComboBox();
            btnLuuTaiKhoan = new Button();
            btnResetMatKhau = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            pnlRight = new Panel();
            dgvNhanVien = new DataGridView();
            pnlLeft.SuspendLayout();
            gb_ThongTinDangNhap.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(lblTitle);
            pnlLeft.Controls.Add(lbl_TenNV);
            pnlLeft.Controls.Add(txtTenNV);
            pnlLeft.Controls.Add(lbl_SĐT);
            pnlLeft.Controls.Add(txtSDT);
            pnlLeft.Controls.Add(lbl_ChucVu);
            pnlLeft.Controls.Add(cboChucVu);
            pnlLeft.Controls.Add(lbl_NgayVaoLam);
            pnlLeft.Controls.Add(dtpNgayVaoLam);
            pnlLeft.Controls.Add(gb_ThongTinDangNhap);
            pnlLeft.Controls.Add(btnThem);
            pnlLeft.Controls.Add(btnSua);
            pnlLeft.Controls.Add(btnLamMoi);
            pnlLeft.Controls.Add(btnXoa);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Margin = new Padding(7, 8, 7, 8);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(1017, 1913);
            pnlLeft.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DodgerBlue;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(7, 0, 7, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1015, 164);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÂN SỰ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_TenNV
            // 
            lbl_TenNV.AutoSize = true;
            lbl_TenNV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_TenNV.Location = new Point(49, 191);
            lbl_TenNV.Margin = new Padding(7, 0, 7, 0);
            lbl_TenNV.Name = "lbl_TenNV";
            lbl_TenNV.Size = new Size(266, 41);
            lbl_TenNV.TabIndex = 1;
            lbl_TenNV.Text = "Họ tên nhân viên:";
            // 
            // txtTenNV
            // 
            txtTenNV.Location = new Point(49, 246);
            txtTenNV.Margin = new Padding(7, 8, 7, 8);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(905, 47);
            txtTenNV.TabIndex = 2;
            // 
            // lbl_SĐT
            // 
            lbl_SĐT.AutoSize = true;
            lbl_SĐT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_SĐT.Location = new Point(49, 355);
            lbl_SĐT.Margin = new Padding(7, 0, 7, 0);
            lbl_SĐT.Name = "lbl_SĐT";
            lbl_SĐT.Size = new Size(212, 41);
            lbl_SĐT.TabIndex = 3;
            lbl_SĐT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(49, 410);
            txtSDT.Margin = new Padding(7, 8, 7, 8);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(431, 47);
            txtSDT.TabIndex = 4;
            // 
            // lbl_ChucVu
            // 
            lbl_ChucVu.AutoSize = true;
            lbl_ChucVu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_ChucVu.Location = new Point(522, 355);
            lbl_ChucVu.Margin = new Padding(7, 0, 7, 0);
            lbl_ChucVu.Name = "lbl_ChucVu";
            lbl_ChucVu.Size = new Size(139, 41);
            lbl_ChucVu.TabIndex = 5;
            lbl_ChucVu.Text = "Chức vụ:";
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Location = new Point(522, 410);
            cboChucVu.Margin = new Padding(7, 8, 7, 8);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(431, 49);
            cboChucVu.TabIndex = 6;
            // 
            // lbl_NgayVaoLam
            // 
            lbl_NgayVaoLam.AutoSize = true;
            lbl_NgayVaoLam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_NgayVaoLam.Location = new Point(49, 519);
            lbl_NgayVaoLam.Margin = new Padding(7, 0, 7, 0);
            lbl_NgayVaoLam.Name = "lbl_NgayVaoLam";
            lbl_NgayVaoLam.Size = new Size(219, 41);
            lbl_NgayVaoLam.TabIndex = 7;
            lbl_NgayVaoLam.Text = "Ngày vào làm:";
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.Format = DateTimePickerFormat.Short;
            dtpNgayVaoLam.Location = new Point(49, 574);
            dtpNgayVaoLam.Margin = new Padding(7, 8, 7, 8);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(431, 47);
            dtpNgayVaoLam.TabIndex = 8;
            // 
            // gb_ThongTinDangNhap
            // 
            gb_ThongTinDangNhap.Controls.Add(lbl_TenDangNhap);
            gb_ThongTinDangNhap.Controls.Add(txtUsername);
            gb_ThongTinDangNhap.Controls.Add(lbl_MatKhau);
            gb_ThongTinDangNhap.Controls.Add(txtPassword);
            gb_ThongTinDangNhap.Controls.Add(label1);
            gb_ThongTinDangNhap.Controls.Add(cboQuyen);
            gb_ThongTinDangNhap.Controls.Add(btnLuuTaiKhoan);
            gb_ThongTinDangNhap.Controls.Add(btnResetMatKhau);
            gb_ThongTinDangNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gb_ThongTinDangNhap.Location = new Point(49, 711);
            gb_ThongTinDangNhap.Margin = new Padding(7, 8, 7, 8);
            gb_ThongTinDangNhap.Name = "gb_ThongTinDangNhap";
            gb_ThongTinDangNhap.Padding = new Padding(7, 8, 7, 8);
            gb_ThongTinDangNhap.Size = new Size(911, 547);
            gb_ThongTinDangNhap.TabIndex = 8;
            gb_ThongTinDangNhap.TabStop = false;
            gb_ThongTinDangNhap.Text = "🔒 Tài khoản Hệ thống";
            // 
            // lbl_TenDangNhap
            // 
            lbl_TenDangNhap.AutoSize = true;
            lbl_TenDangNhap.Font = new Font("Segoe UI", 9F);
            lbl_TenDangNhap.Location = new Point(36, 82);
            lbl_TenDangNhap.Margin = new Padding(7, 0, 7, 0);
            lbl_TenDangNhap.Name = "lbl_TenDangNhap";
            lbl_TenDangNhap.Size = new Size(159, 41);
            lbl_TenDangNhap.TabIndex = 0;
            lbl_TenDangNhap.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.Location = new Point(36, 137);
            txtUsername.Margin = new Padding(7, 8, 7, 8);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(395, 47);
            txtUsername.TabIndex = 1;
            // 
            // lbl_MatKhau
            // 
            lbl_MatKhau.AutoSize = true;
            lbl_MatKhau.Font = new Font("Segoe UI", 9F);
            lbl_MatKhau.Location = new Point(474, 82);
            lbl_MatKhau.Margin = new Padding(7, 0, 7, 0);
            lbl_MatKhau.Name = "lbl_MatKhau";
            lbl_MatKhau.Size = new Size(150, 41);
            lbl_MatKhau.TabIndex = 2;
            lbl_MatKhau.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(474, 137);
            txtPassword.Margin = new Padding(7, 8, 7, 8);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(395, 47);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(36, 232);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(250, 41);
            label1.TabIndex = 4;
            label1.Text = "Phân quyền User:";
            // 
            // cboQuyen
            // 
            cboQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuyen.Font = new Font("Segoe UI", 9F);
            cboQuyen.Location = new Point(36, 287);
            cboQuyen.Margin = new Padding(7, 8, 7, 8);
            cboQuyen.Name = "cboQuyen";
            cboQuyen.Size = new Size(832, 49);
            cboQuyen.TabIndex = 5;
            // 
            // btnLuuTaiKhoan
            // 
            btnLuuTaiKhoan.BackColor = Color.DodgerBlue;
            btnLuuTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnLuuTaiKhoan.ForeColor = Color.White;
            btnLuuTaiKhoan.Location = new Point(36, 396);
            btnLuuTaiKhoan.Margin = new Padding(7, 8, 7, 8);
            btnLuuTaiKhoan.Name = "btnLuuTaiKhoan";
            btnLuuTaiKhoan.Size = new Size(401, 96);
            btnLuuTaiKhoan.TabIndex = 6;
            btnLuuTaiKhoan.Text = "CẤP TÀI KHOẢN";
            btnLuuTaiKhoan.UseVisualStyleBackColor = false;
            btnLuuTaiKhoan.Click += btnLuuTaiKhoan_Click;
            // 
            // btnResetMatKhau
            // 
            btnResetMatKhau.BackColor = Color.SlateGray;
            btnResetMatKhau.FlatStyle = FlatStyle.Flat;
            btnResetMatKhau.ForeColor = Color.White;
            btnResetMatKhau.Location = new Point(474, 396);
            btnResetMatKhau.Margin = new Padding(7, 8, 7, 8);
            btnResetMatKhau.Name = "btnResetMatKhau";
            btnResetMatKhau.Size = new Size(401, 96);
            btnResetMatKhau.TabIndex = 7;
            btnResetMatKhau.Text = "RESET MẬT KHẨU";
            btnResetMatKhau.UseVisualStyleBackColor = false;
            btnResetMatKhau.Click += btnResetMatKhau_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.MediumSeaGreen;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(49, 1312);
            btnThem.Margin = new Padding(7, 8, 7, 8);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(437, 123);
            btnThem.TabIndex = 9;
            btnThem.Text = "THÊM NHÂN VIÊN";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Orange;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(522, 1312);
            btnSua.Margin = new Padding(7, 8, 7, 8);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(437, 123);
            btnSua.TabIndex = 10;
            btnSua.Text = "CẬP NHẬT";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.LightGray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.Location = new Point(49, 1476);
            btnLamMoi.Margin = new Padding(7, 8, 7, 8);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(437, 109);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "LÀM MỚI FORM";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(522, 1476);
            btnXoa.Margin = new Padding(7, 8, 7, 8);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(437, 109);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "XÓA (NGHỈ VIỆC)";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(dgvNhanVien);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(1017, 0);
            pnlRight.Margin = new Padding(7, 8, 7, 8);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(24, 27, 24, 27);
            pnlRight.Size = new Size(1412, 1913);
            pnlRight.TabIndex = 1;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.WhiteSmoke;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(24, 27);
            dgvNhanVien.Margin = new Padding(7, 8, 7, 8);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidth = 102;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(1364, 1859);
            dgvNhanVien.TabIndex = 0;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // UC_NhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Margin = new Padding(7, 8, 7, 8);
            Name = "UC_NhanVien";
            Size = new Size(2429, 1913);
            Load += UC_NhanVien_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            gb_ThongTinDangNhap.ResumeLayout(false);
            gb_ThongTinDangNhap.PerformLayout();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lbl_TenNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lbl_SĐT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lbl_ChucVu;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Label lbl_NgayVaoLam;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;

        private System.Windows.Forms.GroupBox gb_ThongTinDangNhap;
        private System.Windows.Forms.Label lbl_TenDangNhap;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lbl_MatKhau;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboQuyen;
        private System.Windows.Forms.Button btnLuuTaiKhoan;
        private System.Windows.Forms.Button btnResetMatKhau;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;

        private System.Windows.Forms.DataGridView dgvNhanVien;
    }
}