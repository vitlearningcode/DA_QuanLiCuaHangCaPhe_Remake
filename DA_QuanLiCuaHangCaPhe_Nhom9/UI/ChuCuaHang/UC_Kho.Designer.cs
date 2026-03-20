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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            flpDanhSachHangHoa = new FlowLayoutPanel();
            panel3 = new Panel();
            label1 = new Label();
            cboNhaCungCap = new ComboBox();
            dtpNgayNhap = new DateTimePicker();
            panel2 = new Panel();
            dgvChiTietNhap = new DataGridView();
            btnLuuPhieu = new Button();
            lbl_ChonNgayNhap = new Label();
            lblTongTien = new Label();
            tab_Kho.SuspendLayout();
            DanhSach_TonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).BeginInit();
            panel1.SuspendLayout();
            NhapHang.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            SuspendLayout();
            // 
            // tab_Kho
            // 
            tab_Kho.Controls.Add(DanhSach_TonKho);
            tab_Kho.Controls.Add(NhapHang);
            tab_Kho.Dock = DockStyle.Fill;
            tab_Kho.Location = new Point(0, 0);
            tab_Kho.Margin = new Padding(1);
            tab_Kho.Name = "tab_Kho";
            tab_Kho.SelectedIndex = 0;
            tab_Kho.Size = new Size(481, 279);
            tab_Kho.TabIndex = 0;
            // 
            // DanhSach_TonKho
            // 
            DanhSach_TonKho.Controls.Add(dgvNguyenLieu);
            DanhSach_TonKho.Controls.Add(panel1);
            DanhSach_TonKho.Location = new Point(4, 24);
            DanhSach_TonKho.Margin = new Padding(1);
            DanhSach_TonKho.Name = "DanhSach_TonKho";
            DanhSach_TonKho.Padding = new Padding(1);
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
            dgvNguyenLieu.Margin = new Padding(1);
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
            panel1.Margin = new Padding(1);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 249);
            panel1.TabIndex = 0;
            // 
            // btnSuaNL
            // 
            btnSuaNL.Location = new Point(108, 160);
            btnSuaNL.Margin = new Padding(1);
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
            btnXoaNL.Margin = new Padding(1);
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
            btnLamMoi.Margin = new Padding(1);
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
            btnThemNL.Margin = new Padding(1);
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
            txtDonVi.Margin = new Padding(1);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(75, 23);
            txtDonVi.TabIndex = 0;
            // 
            // txtTenNL
            // 
            txtTenNL.Location = new Point(113, 11);
            txtTenNL.Margin = new Padding(1);
            txtTenNL.Name = "txtTenNL";
            txtTenNL.Size = new Size(75, 23);
            txtTenNL.TabIndex = 0;
            // 
            // NhapHang
            // 
            NhapHang.Controls.Add(tableLayoutPanel1);
            NhapHang.Location = new Point(4, 24);
            NhapHang.Margin = new Padding(1);
            NhapHang.Name = "NhapHang";
            NhapHang.Padding = new Padding(1);
            NhapHang.Size = new Size(473, 251);
            NhapHang.TabIndex = 1;
            NhapHang.Text = "Nhập Hàng";
            NhapHang.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.4076424F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.5923576F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(1, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 99F));
            tableLayoutPanel1.Size = new Size(471, 249);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(flpDanhSachHangHoa, 0, 1);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 178F));
            tableLayoutPanel2.Size = new Size(222, 243);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // flpDanhSachHangHoa
            // 
            flpDanhSachHangHoa.Dock = DockStyle.Fill;
            flpDanhSachHangHoa.Location = new Point(3, 68);
            flpDanhSachHangHoa.Name = "flpDanhSachHangHoa";
            flpDanhSachHangHoa.Size = new Size(216, 172);
            flpDanhSachHangHoa.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(cboNhaCungCap);
            panel3.Controls.Add(dtpNgayNhap);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(216, 59);
            panel3.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 0);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Nhà Cung Cấp";
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(88, 1);
            cboNhaCungCap.Margin = new Padding(1);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(127, 23);
            cboNhaCungCap.TabIndex = 1;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpNgayNhap.Location = new Point(88, 26);
            dtpNgayNhap.Margin = new Padding(1);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(127, 23);
            dtpNgayNhap.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvChiTietNhap);
            panel2.Controls.Add(btnLuuPhieu);
            panel2.Controls.Add(lbl_ChonNgayNhap);
            panel2.Controls.Add(lblTongTien);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(231, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(237, 243);
            panel2.TabIndex = 9;
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTietNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietNhap.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Location = new Point(0, 16);
            dgvChiTietNhap.Margin = new Padding(1);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.RowHeadersWidth = 102;
            dgvChiTietNhap.Size = new Size(235, 99);
            dgvChiTietNhap.TabIndex = 6;
            dgvChiTietNhap.CellContentClick += dgvChiTietNhap_CellContentClick;
            dgvChiTietNhap.CellValueChanged += dgvChiTietNhap_CellValueChanged;
            dgvChiTietNhap.CurrentCellDirtyStateChanged += dgvChiTietNhap_CurrentCellDirtyStateChanged;
            // 
            // btnLuuPhieu
            // 
            btnLuuPhieu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLuuPhieu.Location = new Point(145, 204);
            btnLuuPhieu.Margin = new Padding(1);
            btnLuuPhieu.Name = "btnLuuPhieu";
            btnLuuPhieu.Size = new Size(44, 38);
            btnLuuPhieu.TabIndex = 7;
            btnLuuPhieu.Text = "Lưu";
            btnLuuPhieu.UseVisualStyleBackColor = true;
            btnLuuPhieu.Click += btnLuuPhieu_Click;
            // 
            // lbl_ChonNgayNhap
            // 
            lbl_ChonNgayNhap.AutoSize = true;
            lbl_ChonNgayNhap.Location = new Point(62, 0);
            lbl_ChonNgayNhap.Margin = new Padding(1, 0, 1, 0);
            lbl_ChonNgayNhap.Name = "lbl_ChonNgayNhap";
            lbl_ChonNgayNhap.Size = new Size(106, 15);
            lbl_ChonNgayNhap.TabIndex = 0;
            lbl_ChonNgayNhap.Text = "Chọn Nguyên Liệu";
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(26, 216);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(61, 15);
            lblTongTien.TabIndex = 1;
            lblTongTien.Text = "Tổng Tiền";
            // 
            // UC_Kho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tab_Kho);
            Margin = new Padding(1);
            Name = "UC_Kho";
            Size = new Size(481, 279);
            Load += UC_Kho_Load;
            tab_Kho.ResumeLayout(false);
            DanhSach_TonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            NhapHang.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tab_Kho;
        private TabPage DanhSach_TonKho;
        private Panel panel1;
        private Label lbl_DVT;
        private Label lbl_tenNL;
        private TextBox txtTenNL;
        private TextBox txtDonVi;
        private DataGridView dgvNguyenLieu;
        private Button btnSuaNL;
        private Button btnXoaNL;
        private Button btnThemNL;
        private Button btnLamMoi;
        private TabPage NhapHang;
        private Label label1;
        private DateTimePicker dtpNgayNhap;
        private Label lbl_ChonNgayNhap;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnLuuPhieu;
        private ComboBox cboNhaCungCap;
        private DataGridView dgvChiTietNhap;
        private Label lblTongTien;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flpDanhSachHangHoa;
        private Panel panel3;
    }
}
