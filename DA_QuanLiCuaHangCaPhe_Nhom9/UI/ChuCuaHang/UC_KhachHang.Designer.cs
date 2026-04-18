namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_KhachHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlLeft = new Panel();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnSua = new Button();
            btnThem = new Button();
            cboLoaiKH = new ComboBox();
            label5 = new Label();
            txtDiem = new TextBox();
            label4 = new Label();
            txtSDT = new TextBox();
            label2 = new Label();
            txtTenKH = new TextBox();
            label1 = new Label();
            lblTitle = new Label();
            pnlRight = new Panel();
            dgvKhachHang = new DataGridView();
            pnlSearch = new Panel();
            txtTimKiem = new TextBox();
            label3 = new Label();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(btnXoa);
            pnlLeft.Controls.Add(btnLamMoi);
            pnlLeft.Controls.Add(btnSua);
            pnlLeft.Controls.Add(btnThem);
            pnlLeft.Controls.Add(cboLoaiKH);
            pnlLeft.Controls.Add(label5);
            pnlLeft.Controls.Add(txtDiem);
            pnlLeft.Controls.Add(label4);
            pnlLeft.Controls.Add(txtSDT);
            pnlLeft.Controls.Add(label2);
            pnlLeft.Controls.Add(txtTenKH);
            pnlLeft.Controls.Add(label1);
            pnlLeft.Controls.Add(lblTitle);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(320, 600);
            pnlLeft.TabIndex = 0;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(165, 340);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(130, 40);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "XÓA KHÁCH";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.LightGray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.Location = new Point(20, 340);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(130, 40);
            btnLamMoi.TabIndex = 12;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Orange;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(165, 290);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(130, 40);
            btnSua.TabIndex = 11;
            btnSua.Text = "CẬP NHẬT";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.MediumSeaGreen;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(20, 290);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 40);
            btnThem.TabIndex = 10;
            btnThem.Text = "THÊM KHÁCH";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // cboLoaiKH
            // 
            cboLoaiKH.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiKH.FormattingEnabled = true;
            cboLoaiKH.Items.AddRange(new object[] { "Thuong", "VIP" });
            cboLoaiKH.Location = new Point(165, 230);
            cboLoaiKH.Name = "cboLoaiKH";
            cboLoaiKH.Size = new Size(130, 23);
            cboLoaiKH.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(165, 210);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 8;
            label5.Text = "Phân hạng:";
            // 
            // txtDiem
            // 
            txtDiem.Location = new Point(20, 230);
            txtDiem.Name = "txtDiem";
            txtDiem.Size = new Size(130, 23);
            txtDiem.TabIndex = 7;
            txtDiem.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(20, 210);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 6;
            label4.Text = "Điểm tích lũy:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(20, 170);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(275, 23);
            txtSDT.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(20, 150);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 4;
            label2.Text = "Số điện thoại:";
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(20, 110);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(275, 23);
            txtTenKH.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(20, 90);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 2;
            label1.Text = "Tên khách hàng:";
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DodgerBlue;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(318, 70);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(dgvKhachHang);
            pnlRight.Controls.Add(pnlSearch);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(320, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(10);
            pnlRight.Size = new Size(580, 600);
            pnlRight.TabIndex = 1;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.Location = new Point(10, 60);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(560, 530);
            dgvKhachHang.TabIndex = 1;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            dgvKhachHang.CellFormatting += dgvKhachHang_CellFormatting;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(txtTimKiem);
            pnlSearch.Controls.Add(label3);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(10, 10);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(560, 50);
            pnlSearch.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(130, 12);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên hoặc số điện thoại để tìm...";
            txtTimKiem.Size = new Size(410, 23);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(15, 15);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 0;
            label3.Text = "Tìm nhanh khách:";
            // 
            // UC_KhachHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "UC_KhachHang";
            Size = new Size(900, 600);
            Load += UC_KhachHang_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlLeft;
        private Label lblTitle;
        private TextBox txtTenKH;
        private Label label1;
        private TextBox txtSDT;
        private Label label2;
        private TextBox txtDiem;
        private Label label4;
        private ComboBox cboLoaiKH;
        private Label label5;
        private Button btnThem;
        private Button btnSua;
        private Button btnLamMoi;
        private Button btnXoa;
        private Panel pnlRight;
        private DataGridView dgvKhachHang;
        private Panel pnlSearch;
        private TextBox txtTimKiem;
        private Label label3;
    }
}