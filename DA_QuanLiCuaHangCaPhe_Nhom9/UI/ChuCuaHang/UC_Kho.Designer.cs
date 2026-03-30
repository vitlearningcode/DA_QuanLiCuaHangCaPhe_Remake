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
            leftPanel = new Panel();
            lblTitle = new Label();
            tblInputs = new TableLayoutPanel();
            lbl_tenNL = new Label();
            txtTenNL = new TextBox();
            lbl_DVT = new Label();
            txtDonVi = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnThemNL = new Button();
            btnXoaNL = new Button();
            btnSuaNL = new Button();
            btnLamMoi = new Button();
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
            leftPanel.SuspendLayout();
            tblInputs.SuspendLayout();
            flpButtons.SuspendLayout();
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
            tab_Kho.Size = new Size(700, 400);
            tab_Kho.TabIndex = 0;
            // 
            // DanhSach_TonKho
            // 
            DanhSach_TonKho.Controls.Add(dgvNguyenLieu);
            DanhSach_TonKho.Controls.Add(leftPanel);
            DanhSach_TonKho.Location = new Point(4, 24);
            DanhSach_TonKho.Margin = new Padding(1);
            DanhSach_TonKho.Name = "DanhSach_TonKho";
            DanhSach_TonKho.Padding = new Padding(1);
            DanhSach_TonKho.Size = new Size(692, 372);
            DanhSach_TonKho.TabIndex = 0;
            DanhSach_TonKho.Text = "Danh Sách & Tồn Kho";
            DanhSach_TonKho.UseVisualStyleBackColor = true;
            // 
            // dgvNguyenLieu
            // 
            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguyenLieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNguyenLieu.Dock = DockStyle.Fill;
            dgvNguyenLieu.Location = new Point(220, 1);
            dgvNguyenLieu.Margin = new Padding(1);
            dgvNguyenLieu.Name = "dgvNguyenLieu";
            dgvNguyenLieu.RowHeadersWidth = 102;
            dgvNguyenLieu.Size = new Size(471, 370);
            dgvNguyenLieu.TabIndex = 1;
            dgvNguyenLieu.CellClick += dgvNguyenLieu_CellClick;
            dgvNguyenLieu.CellContentClick += dgvNguyenLieu_CellContentClick;
            dgvNguyenLieu.CellFormatting += dgvNguyenLieu_CellFormatting;
            dgvNguyenLieu.Font = new Font("Segoe UI", 9F);
            dgvNguyenLieu.BackgroundColor = Color.White;
            dgvNguyenLieu.BorderStyle = BorderStyle.None;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(lblTitle);
            leftPanel.Controls.Add(tblInputs);
            leftPanel.Controls.Add(flpButtons);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(1, 1);
            leftPanel.Margin = new Padding(1);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(219, 370);
            leftPanel.TabIndex = 0;
            leftPanel.Padding = new Padding(12);
            leftPanel.BackColor = Color.FromArgb(250,250,252);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblTitle.Text = "Nguyên Liệu";
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 28;
            // 
            // tblInputs
            // 
            tblInputs.ColumnCount = 2;
            tblInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblInputs.Controls.Add(lbl_tenNL, 0, 0);
            tblInputs.Controls.Add(txtTenNL, 1, 0);
            tblInputs.Controls.Add(lbl_DVT, 0, 1);
            tblInputs.Controls.Add(txtDonVi, 1, 1);
            tblInputs.Location = new Point(12, 36);
            tblInputs.Name = "tblInputs";
            tblInputs.RowCount = 2;
            tblInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tblInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tblInputs.Size = new Size(195, 72);
            tblInputs.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            // 
            // lbl_tenNL
            // 
            lbl_tenNL.AutoSize = true;
            lbl_tenNL.Text = "Tên NL";
            lbl_tenNL.Font = new Font("Segoe UI", 9F);
            lbl_tenNL.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTenNL
            // 
            txtTenNL.Dock = DockStyle.Fill;
            txtTenNL.Font = new Font("Segoe UI", 9F);
            txtTenNL.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lbl_DVT
            // 
            lbl_DVT.AutoSize = true;
            lbl_DVT.Text = "ĐVT";
            lbl_DVT.Font = new Font("Segoe UI", 9F);
            lbl_DVT.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDonVi
            // 
            txtDonVi.Dock = DockStyle.Fill;
            txtDonVi.Font = new Font("Segoe UI", 9F);
            txtDonVi.BorderStyle = BorderStyle.FixedSingle;
            // 
            // flpButtons
            // 
            flpButtons.Dock = DockStyle.Bottom;
            flpButtons.FlowDirection = FlowDirection.LeftToRight;
            flpButtons.Controls.Add(btnThemNL);
            flpButtons.Controls.Add(btnXoaNL);
            flpButtons.Controls.Add(btnSuaNL);
            flpButtons.Controls.Add(btnLamMoi);
            flpButtons.Padding = new Padding(0, 8, 0, 0);
            flpButtons.AutoSize = true;
            flpButtons.Location = new Point(12, 116);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(195, 40);
            // 
            // btnThemNL
            // 
            btnThemNL.Margin = new Padding(4);
            btnThemNL.Name = "btnThemNL";
            btnThemNL.Size = new Size(80, 30);
            btnThemNL.Text = "Thêm";
            btnThemNL.UseVisualStyleBackColor = true;
            btnThemNL.FlatStyle = FlatStyle.Flat;
            btnThemNL.Click += btnThemNL_Click;
            // 
            // btnXoaNL
            // 
            btnXoaNL.Margin = new Padding(4);
            btnXoaNL.Name = "btnXoaNL";
            btnXoaNL.Size = new Size(80, 30);
            btnXoaNL.Text = "Xóa";
            btnXoaNL.UseVisualStyleBackColor = true;
            btnXoaNL.FlatStyle = FlatStyle.Flat;
            btnXoaNL.Click += btnXoaNL_Click;
            // 
            // btnSuaNL
            // 
            btnSuaNL.Margin = new Padding(4);
            btnSuaNL.Name = "btnSuaNL";
            btnSuaNL.Size = new Size(80, 30);
            btnSuaNL.Text = "Sửa";
            btnSuaNL.UseVisualStyleBackColor = true;
            btnSuaNL.FlatStyle = FlatStyle.Flat;
            btnSuaNL.Click += btnSuaNL_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Margin = new Padding(4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(80, 30);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // NhapHang
            // 
            NhapHang.Controls.Add(tableLayoutPanel1);
            NhapHang.Location = new Point(4, 24);
            NhapHang.Margin = new Padding(1);
            NhapHang.Name = "NhapHang";
            NhapHang.Padding = new Padding(1);
            NhapHang.Size = new Size(692, 372);
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
            tableLayoutPanel1.Size = new Size(690, 370);
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
            tableLayoutPanel2.Size = new Size(329, 364);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // flpDanhSachHangHoa
            // 
            flpDanhSachHangHoa.Dock = DockStyle.Fill;
            flpDanhSachHangHoa.Location = new Point(3, 68);
            flpDanhSachHangHoa.Name = "flpDanhSachHangHoa";
            flpDanhSachHangHoa.Size = new Size(323, 293);
            flpDanhSachHangHoa.TabIndex = 8;
            flpDanhSachHangHoa.BackColor = Color.Transparent;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(cboNhaCungCap);
            panel3.Controls.Add(dtpNgayNhap);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(323, 59);
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
            label1.Font = new Font("Segoe UI", 9F);
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(110, 1);
            cboNhaCungCap.Margin = new Padding(1);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(200, 23);
            cboNhaCungCap.TabIndex = 1;
            cboNhaCungCap.Font = new Font("Segoe UI", 9F);
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpNgayNhap.Location = new Point(110, 26);
            dtpNgayNhap.Margin = new Padding(1);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(200, 23);
            dtpNgayNhap.TabIndex = 4;
            dtpNgayNhap.Font = new Font("Segoe UI", 9F);
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvChiTietNhap);
            panel2.Controls.Add(btnLuuPhieu);
            panel2.Controls.Add(lbl_ChonNgayNhap);
            panel2.Controls.Add(lblTongTien);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(338, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(349, 364);
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
            dgvChiTietNhap.Size = new Size(349, 230);
            dgvChiTietNhap.TabIndex = 6;
            dgvChiTietNhap.CellContentClick += dgvChiTietNhap_CellContentClick;
            dgvChiTietNhap.CellValueChanged += dgvChiTietNhap_CellValueChanged;
            dgvChiTietNhap.CurrentCellDirtyStateChanged += dgvChiTietNhap_CurrentCellDirtyStateChanged;
            dgvChiTietNhap.Font = new Font("Segoe UI", 9F);
            dgvChiTietNhap.BackgroundColor = Color.White;
            dgvChiTietNhap.BorderStyle = BorderStyle.None;
            // 
            // btnLuuPhieu
            // 
            btnLuuPhieu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuuPhieu.Location = new Point(280, 312);
            btnLuuPhieu.Margin = new Padding(1);
            btnLuuPhieu.Name = "btnLuuPhieu";
            btnLuuPhieu.Size = new Size(60, 32);
            btnLuuPhieu.TabIndex = 7;
            btnLuuPhieu.Text = "Lưu";
            btnLuuPhieu.UseVisualStyleBackColor = true;
            btnLuuPhieu.FlatStyle = FlatStyle.Flat;
            btnLuuPhieu.Font = new Font("Segoe UI", 9F);
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
            lbl_ChonNgayNhap.Font = new Font("Segoe UI", 9F);
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(26, 320);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(61, 15);
            lblTongTien.TabIndex = 1;
            lblTongTien.Text = "Tổng Tiền";
            lblTongTien.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            // 
            // UC_Kho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tab_Kho);
            Margin = new Padding(1);
            Name = "UC_Kho";
            Size = new Size(700, 400);
            Load += UC_Kho_Load;
            tab_Kho.ResumeLayout(false);
            DanhSach_TonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).EndInit();
            leftPanel.ResumeLayout(false);
            tblInputs.ResumeLayout(false);
            tblInputs.PerformLayout();
            flpButtons.ResumeLayout(false);
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
        private Panel leftPanel;
        private Label lblTitle;
        private TableLayoutPanel tblInputs;
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
        private FlowLayoutPanel flpButtons;
    }
}
