namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    partial class UC_QL_Kho
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
            this.pnlTopNav = new System.Windows.Forms.Panel();
            this.btnTabPhieu = new System.Windows.Forms.Button();
            this.btnTabKho = new System.Windows.Forms.Button();
            this.pnlTonKho = new System.Windows.Forms.Panel();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.btnNgungSuDung = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.numCanhBao = new System.Windows.Forms.NumericUpDown();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.numTonKho = new System.Windows.Forms.NumericUpDown();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtTenNL = new System.Windows.Forms.TextBox();
            this.lblTenNL = new System.Windows.Forms.Label();
            this.txtMaNL = new System.Windows.Forms.TextBox();
            this.lblMaNL = new System.Windows.Forms.Label();
            this.pnlPhieu = new System.Windows.Forms.Panel();
            this.tlpPhieu = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTaoPhieu = new System.Windows.Forms.Panel();
            this.dgvChiTietTam = new System.Windows.Forms.DataGridView();
            this.btnChotPhieu = new System.Windows.Forms.Button();
            this.gbNhapLieuPhieu = new System.Windows.Forms.GroupBox();
            this.btnThemChiTiet = new System.Windows.Forms.Button();
            this.numGiaNhap = new System.Windows.Forms.NumericUpDown();
            this.lblGiaNhap = new System.Windows.Forms.Label();
            this.numSLPhieu = new System.Windows.Forms.NumericUpDown();
            this.lblSLPhieu = new System.Windows.Forms.Label();
            this.cboNguyenLieuPhieu = new System.Windows.Forms.ComboBox();
            this.lblChonNL = new System.Windows.Forms.Label();
            this.radXuat = new System.Windows.Forms.RadioButton();
            this.radNhap = new System.Windows.Forms.RadioButton();
            this.pnlLichSu = new System.Windows.Forms.Panel();
            this.gbChiTietLichSu = new System.Windows.Forms.GroupBox();
            this.dgvChiTietLichSu = new System.Windows.Forms.DataGridView();
            this.gbLichSuPhieu = new System.Windows.Forms.GroupBox();
            this.dgvLichSuPhieu = new System.Windows.Forms.DataGridView();
            this.pnlTopNav.SuspendLayout();
            this.pnlTonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCanhBao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTonKho)).BeginInit();
            this.pnlPhieu.SuspendLayout();
            this.tlpPhieu.SuspendLayout();
            this.pnlTaoPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietTam)).BeginInit();
            this.gbNhapLieuPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSLPhieu)).BeginInit();
            this.pnlLichSu.SuspendLayout();
            this.gbChiTietLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietLichSu)).BeginInit();
            this.gbLichSuPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuPhieu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopNav
            // 
            this.pnlTopNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlTopNav.Controls.Add(this.btnTabPhieu);
            this.pnlTopNav.Controls.Add(this.btnTabKho);
            this.pnlTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNav.Location = new System.Drawing.Point(0, 0);
            this.pnlTopNav.Name = "pnlTopNav";
            this.pnlTopNav.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTopNav.Size = new System.Drawing.Size(1200, 70);
            this.pnlTopNav.TabIndex = 0;
            // 
            // btnTabPhieu
            // 
            this.btnTabPhieu.BackColor = System.Drawing.Color.White;
            this.btnTabPhieu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabPhieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTabPhieu.ForeColor = System.Drawing.Color.DimGray;
            this.btnTabPhieu.Location = new System.Drawing.Point(230, 10);
            this.btnTabPhieu.Name = "btnTabPhieu";
            this.btnTabPhieu.Size = new System.Drawing.Size(220, 50);
            this.btnTabPhieu.TabIndex = 1;
            this.btnTabPhieu.Text = "📝 PHIẾU NHẬP/XUẤT";
            this.btnTabPhieu.UseVisualStyleBackColor = false;
            this.btnTabPhieu.Click += new System.EventHandler(this.SwitchTab_Click);
            // 
            // btnTabKho
            // 
            this.btnTabKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.btnTabKho.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabKho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTabKho.ForeColor = System.Drawing.Color.White;
            this.btnTabKho.Location = new System.Drawing.Point(10, 10);
            this.btnTabKho.Name = "btnTabKho";
            this.btnTabKho.Size = new System.Drawing.Size(220, 50);
            this.btnTabKho.TabIndex = 0;
            this.btnTabKho.Text = "📦 TỒN KHO";
            this.btnTabKho.UseVisualStyleBackColor = false;
            this.btnTabKho.Click += new System.EventHandler(this.SwitchTab_Click);
            // 
            // pnlTonKho
            // 
            this.pnlTonKho.BackColor = System.Drawing.Color.White;
            this.pnlTonKho.Controls.Add(this.dgvKho);
            this.pnlTonKho.Controls.Add(this.gbThongTin);
            this.pnlTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTonKho.Location = new System.Drawing.Point(0, 70);
            this.pnlTonKho.Name = "pnlTonKho";
            this.pnlTonKho.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTonKho.Size = new System.Drawing.Size(1200, 730);
            this.pnlTonKho.TabIndex = 1;
            // 
            // dgvKho
            // 
            this.dgvKho.AllowUserToAddRows = false;
            this.dgvKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKho.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvKho.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKho.ColumnHeadersHeight = 50;
            this.dgvKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKho.Location = new System.Drawing.Point(20, 310);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.ReadOnly = true;
            this.dgvKho.RowHeadersVisible = false;
            this.dgvKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKho.Size = new System.Drawing.Size(1160, 400);
            this.dgvKho.TabIndex = 1;
            this.dgvKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvKho_CellClick);
            this.dgvKho.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvKho_CellFormatting);
            // 
            // gbThongTin
            // 
            this.gbThongTin.BackColor = System.Drawing.Color.White;
            this.gbThongTin.Controls.Add(this.btnNgungSuDung);
            this.gbThongTin.Controls.Add(this.btnLuu);
            this.gbThongTin.Controls.Add(this.btnLamMoi);
            this.gbThongTin.Controls.Add(this.numCanhBao);
            this.gbThongTin.Controls.Add(this.lblCanhBao);
            this.gbThongTin.Controls.Add(this.numTonKho);
            this.gbThongTin.Controls.Add(this.lblTonKho);
            this.gbThongTin.Controls.Add(this.txtDVT);
            this.gbThongTin.Controls.Add(this.lblDVT);
            this.gbThongTin.Controls.Add(this.txtTenNL);
            this.gbThongTin.Controls.Add(this.lblTenNL);
            this.gbThongTin.Controls.Add(this.txtMaNL);
            this.gbThongTin.Controls.Add(this.lblMaNL);
            this.gbThongTin.Dock = System.Windows.Forms.DockStyle.Top;

            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gbThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.gbThongTin.Location = new System.Drawing.Point(20, 20);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(1160, 290);
            this.gbThongTin.TabIndex = 0;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "QUẢN LÝ NGUYÊN LIỆU";
            // 
            // btnNgungSuDung
            // 
            this.btnNgungSuDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnNgungSuDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNgungSuDung.ForeColor = System.Drawing.Color.White;
            this.btnNgungSuDung.Location = new System.Drawing.Point(350, 210);
            this.btnNgungSuDung.Name = "btnNgungSuDung";
            this.btnNgungSuDung.Size = new System.Drawing.Size(200, 45);
            this.btnNgungSuDung.TabIndex = 12;
            this.btnNgungSuDung.Text = "🛑 NGỪNG KINH Doang";
            this.btnNgungSuDung.UseVisualStyleBackColor = false;
            this.btnNgungSuDung.Click += new System.EventHandler(this.BtnNgungSuDung_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(160, 210);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(180, 45);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "💾 LƯU DỮ LIỆU";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi.Location = new System.Drawing.Point(30, 210);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 45);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.BtnLamMoi_Click);
            // 
            // numCanhBao
            // 
            this.numCanhBao.DecimalPlaces = 2;
            this.numCanhBao.Location = new System.Drawing.Point(250, 150);
            this.numCanhBao.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCanhBao.Name = "numCanhBao";
            this.numCanhBao.Size = new System.Drawing.Size(200, 32);
            this.numCanhBao.TabIndex = 9;
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.ForeColor = System.Drawing.Color.Black;
            this.lblCanhBao.Location = new System.Drawing.Point(250, 120);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(215, 25);
            this.lblCanhBao.TabIndex = 8;
            this.lblCanhBao.Text = "Ngưỡng cảnh báo hết:";
            // 
            // numTonKho
            // 
            this.numTonKho.DecimalPlaces = 2;
            this.numTonKho.Enabled = false;
            this.numTonKho.Location = new System.Drawing.Point(30, 150);
            this.numTonKho.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTonKho.Name = "numTonKho";
            this.numTonKho.Size = new System.Drawing.Size(200, 32);
            this.numTonKho.TabIndex = 7;
            // 
            // lblTonKho
            // 
            this.lblTonKho.AutoSize = true;
            this.lblTonKho.ForeColor = System.Drawing.Color.Black;
            this.lblTonKho.Location = new System.Drawing.Point(30, 120);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(221, 25);
            this.lblTonKho.TabIndex = 6;
            this.lblTonKho.Text = "Số lượng tồn (Chỉ đọc):";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(470, 70);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(150, 32);
            this.txtDVT.TabIndex = 5;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.ForeColor = System.Drawing.Color.Black;
            this.lblDVT.Location = new System.Drawing.Point(470, 40);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(117, 25);
            this.lblDVT.TabIndex = 4;
            this.lblDVT.Text = "Đơn vị tính:";
            // 
            // txtTenNL
            // 
            this.txtTenNL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNL.Location = new System.Drawing.Point(150, 70);
            this.txtTenNL.Name = "txtTenNL";
            this.txtTenNL.Size = new System.Drawing.Size(300, 32);
            this.txtTenNL.TabIndex = 3;
            // 
            // lblTenNL
            // 
            this.lblTenNL.AutoSize = true;
            this.lblTenNL.ForeColor = System.Drawing.Color.Black;
            this.lblTenNL.Location = new System.Drawing.Point(150, 40);
            this.lblTenNL.Name = "lblTenNL";
            this.lblTenNL.Size = new System.Drawing.Size(158, 25);
            this.lblTenNL.TabIndex = 2;
            this.lblTenNL.Text = "Tên nguyên liệu:";
            // 
            // txtMaNL
            // 
            this.txtMaNL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMaNL.Location = new System.Drawing.Point(30, 70);
            this.txtMaNL.Name = "txtMaNL";
            this.txtMaNL.ReadOnly = true;
            this.txtMaNL.Size = new System.Drawing.Size(100, 32);
            this.txtMaNL.TabIndex = 1;
            // 
            // lblMaNL
            // 
            this.lblMaNL.AutoSize = true;
            this.lblMaNL.ForeColor = System.Drawing.Color.Black;
            this.lblMaNL.Location = new System.Drawing.Point(30, 40);
            this.lblMaNL.Name = "lblMaNL";
            this.lblMaNL.Size = new System.Drawing.Size(76, 25);
            this.lblMaNL.TabIndex = 0;
            this.lblMaNL.Text = "Mã NL:";
            // 
            // pnlPhieu
            // 
            this.pnlPhieu.BackColor = System.Drawing.Color.White;
            this.pnlPhieu.Controls.Add(this.tlpPhieu);
            this.pnlPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhieu.Location = new System.Drawing.Point(0, 70);
            this.pnlPhieu.Name = "pnlPhieu";
            this.pnlPhieu.Padding = new System.Windows.Forms.Padding(10);
            this.pnlPhieu.Size = new System.Drawing.Size(1200, 730);
            this.pnlPhieu.TabIndex = 2;
            this.pnlPhieu.Visible = false;
            // 
            // tlpPhieu
            // 
            this.tlpPhieu.BackColor = System.Drawing.Color.White;
            this.tlpPhieu.ColumnCount = 2;
            this.tlpPhieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPhieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpPhieu.Controls.Add(this.pnlTaoPhieu, 0, 0);
            this.tlpPhieu.Controls.Add(this.pnlLichSu, 1, 0);
            this.tlpPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPhieu.Location = new System.Drawing.Point(10, 10);
            this.tlpPhieu.Name = "tlpPhieu";
            this.tlpPhieu.RowCount = 1;
            this.tlpPhieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhieu.Size = new System.Drawing.Size(1180, 710);
            this.tlpPhieu.TabIndex = 0;
            // 
            // pnlTaoPhieu
            // 
            this.pnlTaoPhieu.BackColor = System.Drawing.Color.White;
            this.pnlTaoPhieu.Controls.Add(this.dgvChiTietTam);
            this.pnlTaoPhieu.Controls.Add(this.btnChotPhieu);
            this.pnlTaoPhieu.Controls.Add(this.gbNhapLieuPhieu);
            this.pnlTaoPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTaoPhieu.Location = new System.Drawing.Point(3, 3);
            this.pnlTaoPhieu.Name = "pnlTaoPhieu";
            this.pnlTaoPhieu.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTaoPhieu.Size = new System.Drawing.Size(466, 704);
            this.pnlTaoPhieu.TabIndex = 0;
            // 
            // dgvChiTietTam
            // 
            this.dgvChiTietTam.AllowUserToAddRows = false;
            this.dgvChiTietTam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietTam.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvChiTietTam.ColumnHeadersHeight = 40;
            this.dgvChiTietTam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietTam.Location = new System.Drawing.Point(5, 285);
            this.dgvChiTietTam.Name = "dgvChiTietTam";
            this.dgvChiTietTam.RowHeadersVisible = false;
            this.dgvChiTietTam.Size = new System.Drawing.Size(456, 354);
            this.dgvChiTietTam.TabIndex = 2;
            // 
            // btnChotPhieu
            // 
            this.btnChotPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnChotPhieu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChotPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChotPhieu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnChotPhieu.ForeColor = System.Drawing.Color.White;
            this.btnChotPhieu.Location = new System.Drawing.Point(5, 639);
            this.btnChotPhieu.Name = "btnChotPhieu";
            this.btnChotPhieu.Size = new System.Drawing.Size(456, 60);
            this.btnChotPhieu.TabIndex = 1;
            this.btnChotPhieu.Text = "💾 CHỐT PHIẾU KHO";
            this.btnChotPhieu.UseVisualStyleBackColor = false;
            this.btnChotPhieu.Click += new System.EventHandler(this.BtnChotPhieu_Click);
            // 
            // gbNhapLieuPhieu
            // 
            this.gbNhapLieuPhieu.BackColor = System.Drawing.Color.White;
            this.gbNhapLieuPhieu.Controls.Add(this.btnThemChiTiet);
            this.gbNhapLieuPhieu.Controls.Add(this.numGiaNhap);
            this.gbNhapLieuPhieu.Controls.Add(this.lblGiaNhap);
            this.gbNhapLieuPhieu.Controls.Add(this.numSLPhieu);
            this.gbNhapLieuPhieu.Controls.Add(this.lblSLPhieu);
            this.gbNhapLieuPhieu.Controls.Add(this.cboNguyenLieuPhieu);
            this.gbNhapLieuPhieu.Controls.Add(this.lblChonNL);
            this.gbNhapLieuPhieu.Controls.Add(this.radXuat);
            this.gbNhapLieuPhieu.Controls.Add(this.radNhap);
            this.gbNhapLieuPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbNhapLieuPhieu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gbNhapLieuPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.gbNhapLieuPhieu.Location = new System.Drawing.Point(5, 5);
            this.gbNhapLieuPhieu.Name = "gbNhapLieuPhieu";
            this.gbNhapLieuPhieu.Size = new System.Drawing.Size(456, 280);
            this.gbNhapLieuPhieu.TabIndex = 0;
            this.gbNhapLieuPhieu.TabStop = false;
            this.gbNhapLieuPhieu.Text = "TẠO PHIẾU MỚI";
            // 
            // btnThemChiTiet
            // 
            this.btnThemChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnThemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnThemChiTiet.Location = new System.Drawing.Point(290, 195);
            this.btnThemChiTiet.Name = "btnThemChiTiet";
            this.btnThemChiTiet.Size = new System.Drawing.Size(120, 40);
            this.btnThemChiTiet.TabIndex = 8;
            this.btnThemChiTiet.Text = "➕ THÊM";
            this.btnThemChiTiet.UseVisualStyleBackColor = false;
            this.btnThemChiTiet.Click += new System.EventHandler(this.BtnThemChiTiet_Click);
            // 
            // numGiaNhap
            // 
            this.numGiaNhap.Location = new System.Drawing.Point(20, 200);
            this.numGiaNhap.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numGiaNhap.Name = "numGiaNhap";
            this.numGiaNhap.Size = new System.Drawing.Size(250, 32);
            this.numGiaNhap.TabIndex = 7;
            // 
            // lblGiaNhap
            // 
            this.lblGiaNhap.AutoSize = true;
            this.lblGiaNhap.ForeColor = System.Drawing.Color.Black;
            this.lblGiaNhap.Location = new System.Drawing.Point(20, 170);
            this.lblGiaNhap.Name = "lblGiaNhap";
            this.lblGiaNhap.Size = new System.Drawing.Size(155, 25);
            this.lblGiaNhap.TabIndex = 6;
            this.lblGiaNhap.Text = "Giá nhập (VNĐ):";
            // 
            // numSLPhieu
            // 
            this.numSLPhieu.DecimalPlaces = 2;
            this.numSLPhieu.Location = new System.Drawing.Point(290, 120);
            this.numSLPhieu.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSLPhieu.Name = "numSLPhieu";
            this.numSLPhieu.Size = new System.Drawing.Size(120, 32);
            this.numSLPhieu.TabIndex = 5;
            // 
            // lblSLPhieu
            // 
            this.lblSLPhieu.AutoSize = true;
            this.lblSLPhieu.ForeColor = System.Drawing.Color.Black;
            this.lblSLPhieu.Location = new System.Drawing.Point(290, 90);
            this.lblSLPhieu.Name = "lblSLPhieu";
            this.lblSLPhieu.Size = new System.Drawing.Size(99, 25);
            this.lblSLPhieu.TabIndex = 4;
            this.lblSLPhieu.Text = "Số lượng:";
            // 
            // cboNguyenLieuPhieu
            // 
            this.cboNguyenLieuPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguyenLieuPhieu.FormattingEnabled = true;
            this.cboNguyenLieuPhieu.Location = new System.Drawing.Point(20, 120);
            this.cboNguyenLieuPhieu.Name = "cboNguyenLieuPhieu";
            this.cboNguyenLieuPhieu.Size = new System.Drawing.Size(250, 33);
            this.cboNguyenLieuPhieu.TabIndex = 3;
            // 
            // lblChonNL
            // 
            this.lblChonNL.AutoSize = true;
            this.lblChonNL.ForeColor = System.Drawing.Color.Black;
            this.lblChonNL.Location = new System.Drawing.Point(20, 90);
            this.lblChonNL.Name = "lblChonNL";
            this.lblChonNL.Size = new System.Drawing.Size(123, 25);
            this.lblChonNL.TabIndex = 2;
            this.lblChonNL.Text = "Nguyên liệu:";
            // 
            // radXuat
            // 
            this.radXuat.AutoSize = true;
            this.radXuat.ForeColor = System.Drawing.Color.Red;
            this.radXuat.Location = new System.Drawing.Point(200, 40);
            this.radXuat.Name = "radXuat";
            this.radXuat.Size = new System.Drawing.Size(155, 29);
            this.radXuat.TabIndex = 1;
            this.radXuat.Text = "Phiếu Xuất (-)";
            this.radXuat.UseVisualStyleBackColor = true;
            this.radXuat.CheckedChanged += new System.EventHandler(this.RadLoaiPhieu_CheckedChanged);
            // 
            // radNhap
            // 
            this.radNhap.AutoSize = true;
            this.radNhap.Checked = true;
            this.radNhap.ForeColor = System.Drawing.Color.Green;
            this.radNhap.Location = new System.Drawing.Point(20, 40);
            this.radNhap.Name = "radNhap";
            this.radNhap.Size = new System.Drawing.Size(161, 29);
            this.radNhap.TabIndex = 0;
            this.radNhap.TabStop = true;
            this.radNhap.Text = "Phiếu Nhập (+)";
            this.radNhap.UseVisualStyleBackColor = true;
            this.radNhap.CheckedChanged += new System.EventHandler(this.RadLoaiPhieu_CheckedChanged);
            // 
            // pnlLichSu
            // 
            this.pnlLichSu.BackColor = System.Drawing.Color.White;
            this.pnlLichSu.Controls.Add(this.gbChiTietLichSu);
            this.pnlLichSu.Controls.Add(this.gbLichSuPhieu);
            this.pnlLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLichSu.Location = new System.Drawing.Point(475, 3);
            this.pnlLichSu.Name = "pnlLichSu";
            this.pnlLichSu.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.pnlLichSu.Size = new System.Drawing.Size(702, 704);
            this.pnlLichSu.TabIndex = 1;
            // 
            // gbChiTietLichSu
            // 
            this.gbChiTietLichSu.BackColor = System.Drawing.Color.White;
            this.gbChiTietLichSu.Controls.Add(this.dgvChiTietLichSu);
            this.gbChiTietLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChiTietLichSu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gbChiTietLichSu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.gbChiTietLichSu.Location = new System.Drawing.Point(10, 355);
            this.gbChiTietLichSu.Name = "gbChiTietLichSu";
            this.gbChiTietLichSu.Size = new System.Drawing.Size(687, 344);
            this.gbChiTietLichSu.TabIndex = 1;
            this.gbChiTietLichSu.TabStop = false;
            this.gbChiTietLichSu.Text = "CHI TIẾT PHIẾU";
            // 
            // dgvChiTietLichSu
            // 
            this.dgvChiTietLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietLichSu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvChiTietLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietLichSu.Location = new System.Drawing.Point(3, 28);
            this.dgvChiTietLichSu.Name = "dgvChiTietLichSu";
            this.dgvChiTietLichSu.RowHeadersVisible = false;
            this.dgvChiTietLichSu.Size = new System.Drawing.Size(681, 313);
            this.dgvChiTietLichSu.TabIndex = 0;
            // 
            // gbLichSuPhieu
            // 
            this.gbLichSuPhieu.BackColor = System.Drawing.Color.White;
            this.gbLichSuPhieu.Controls.Add(this.dgvLichSuPhieu);
            this.gbLichSuPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLichSuPhieu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gbLichSuPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.gbLichSuPhieu.Location = new System.Drawing.Point(10, 5);
            this.gbLichSuPhieu.Name = "gbLichSuPhieu";
            this.gbLichSuPhieu.Size = new System.Drawing.Size(687, 350);
            this.gbLichSuPhieu.TabIndex = 0;
            this.gbLichSuPhieu.TabStop = false;
            this.gbLichSuPhieu.Text = "LỊCH SỬ PHIẾU";
            // 
            // dgvLichSuPhieu
            // 
            this.dgvLichSuPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuPhieu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLichSuPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuPhieu.Location = new System.Drawing.Point(3, 28);
            this.dgvLichSuPhieu.Name = "dgvLichSuPhieu";
            this.dgvLichSuPhieu.RowHeadersVisible = false;
            this.dgvLichSuPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuPhieu.Size = new System.Drawing.Size(681, 319);
            this.dgvLichSuPhieu.TabIndex = 0;
            this.dgvLichSuPhieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLichSuPhieu_CellClick);
            // 
            // UC_QL_Kho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTonKho);
            this.Controls.Add(this.pnlPhieu);
            this.Controls.Add(this.pnlTopNav);
            this.Name = "UC_QL_Kho";
            this.Size = new System.Drawing.Size(1200, 800);
            this.Load += new System.EventHandler(this.UC_Load);
            this.pnlTopNav.ResumeLayout(false);
            this.pnlTonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCanhBao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTonKho)).EndInit();
            this.pnlPhieu.ResumeLayout(false);
            this.tlpPhieu.ResumeLayout(false);
            this.pnlTaoPhieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietTam)).EndInit();
            this.gbNhapLieuPhieu.ResumeLayout(false);
            this.gbNhapLieuPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSLPhieu)).EndInit();
            this.pnlLichSu.ResumeLayout(false);
            this.gbChiTietLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietLichSu)).EndInit();
            this.gbLichSuPhieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuPhieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopNav;
        private System.Windows.Forms.Button btnTabKho;
        private System.Windows.Forms.Button btnTabPhieu;
        private System.Windows.Forms.Panel pnlTonKho;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Button btnNgungSuDung;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.NumericUpDown numCanhBao;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.NumericUpDown numTonKho;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtTenNL;
        private System.Windows.Forms.Label lblTenNL;
        private System.Windows.Forms.TextBox txtMaNL;
        private System.Windows.Forms.Label lblMaNL;
        private System.Windows.Forms.Panel pnlPhieu;
        private System.Windows.Forms.TableLayoutPanel tlpPhieu;
        private System.Windows.Forms.Panel pnlTaoPhieu;
        private System.Windows.Forms.Panel pnlLichSu;
        private System.Windows.Forms.GroupBox gbNhapLieuPhieu;
        private System.Windows.Forms.RadioButton radXuat;
        private System.Windows.Forms.RadioButton radNhap;
        private System.Windows.Forms.Label lblChonNL;
        private System.Windows.Forms.ComboBox cboNguyenLieuPhieu;
        private System.Windows.Forms.Label lblSLPhieu;
        private System.Windows.Forms.NumericUpDown numSLPhieu;
        private System.Windows.Forms.Label lblGiaNhap;
        private System.Windows.Forms.NumericUpDown numGiaNhap;
        private System.Windows.Forms.Button btnThemChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTietTam;
        private System.Windows.Forms.Button btnChotPhieu;
        private System.Windows.Forms.GroupBox gbLichSuPhieu;
        private System.Windows.Forms.DataGridView dgvLichSuPhieu;
        private System.Windows.Forms.GroupBox gbChiTietLichSu;
        private System.Windows.Forms.DataGridView dgvChiTietLichSu;
    }
}