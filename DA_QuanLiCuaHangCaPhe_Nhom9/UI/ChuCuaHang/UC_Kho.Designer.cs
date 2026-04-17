namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_Kho
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
            tab_Kho = new TabControl();
            DanhSach_TonKho = new TabPage();
            pnlGridNL = new Panel();
            dgvNguyenLieu = new DataGridView();
            lblTitle2 = new Label();
            panel1 = new Panel();
            lblTitle1 = new Label();
            lbl_tenNL = new Label();
            txtTenNL = new TextBox();
            lbl_DVT = new Label();
            txtDonVi = new TextBox();
            btnLamMoi = new Button();
            btnThemNL = new Button();
            btnSuaNL = new Button();
            btnXoaNL = new Button();
            NhapHang = new TabPage();
            pnlQuanLyPhieu = new Panel();
            cboLoaiPhieu = new ComboBox();
            splitContainerPhieu = new SplitContainer();
            dgvDanhSachPhieu = new DataGridView();
            label2 = new Label();
            dgvChiTietPhieuCu = new DataGridView();
            label3 = new Label();
            btnThanhToan = new Button();
            btnXoaPhieu = new Button();
            btnThemPhieuMoi = new Button();
            pnlTaoPhieuMoi = new Panel();
            dgvChiTietNhap = new DataGridView();
            btnQuayLai = new Button();
            btnLuuPhieu = new Button();
            btnThemNCC = new Button();
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
            lblTongTien = new Label();
            tab_Kho.SuspendLayout();
            DanhSach_TonKho.SuspendLayout();
            pnlGridNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).BeginInit();
            panel1.SuspendLayout();
            NhapHang.SuspendLayout();
            pnlQuanLyPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerPhieu).BeginInit();
            splitContainerPhieu.Panel1.SuspendLayout();
            splitContainerPhieu.Panel2.SuspendLayout();
            splitContainerPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachPhieu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieuCu).BeginInit();
            pnlTaoPhieuMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            SuspendLayout();
            // 
            // tab_Kho
            // 
            tab_Kho.Controls.Add(DanhSach_TonKho);
            tab_Kho.Controls.Add(NhapHang);
            tab_Kho.Dock = DockStyle.Fill;
            tab_Kho.Font = new Font("Segoe UI", 9.5F);
            tab_Kho.Location = new Point(0, 0);
            tab_Kho.Margin = new Padding(1);
            tab_Kho.Name = "tab_Kho";
            tab_Kho.SelectedIndex = 0;
            tab_Kho.Size = new Size(900, 600);
            tab_Kho.TabIndex = 0;
            // 
            // DanhSach_TonKho
            // 
            DanhSach_TonKho.Controls.Add(pnlGridNL);
            DanhSach_TonKho.Controls.Add(panel1);
            DanhSach_TonKho.Location = new Point(4, 26);
            DanhSach_TonKho.Name = "DanhSach_TonKho";
            DanhSach_TonKho.Size = new Size(892, 570);
            DanhSach_TonKho.TabIndex = 0;
            DanhSach_TonKho.Text = "Danh Sách & Tồn Kho";
            DanhSach_TonKho.UseVisualStyleBackColor = true;
            // 
            // pnlGridNL
            // 
            pnlGridNL.Controls.Add(dgvNguyenLieu);
            pnlGridNL.Controls.Add(lblTitle2);
            pnlGridNL.Dock = DockStyle.Fill;
            pnlGridNL.Location = new Point(300, 0);
            pnlGridNL.Name = "pnlGridNL";
            pnlGridNL.Padding = new Padding(10);
            pnlGridNL.Size = new Size(592, 570);
            pnlGridNL.TabIndex = 0;
            // 
            // dgvNguyenLieu
            // 
            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguyenLieu.BackgroundColor = Color.White;
            dgvNguyenLieu.Dock = DockStyle.Fill;
            dgvNguyenLieu.Location = new Point(10, 45);
            dgvNguyenLieu.Name = "dgvNguyenLieu";
            dgvNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNguyenLieu.Size = new Size(572, 515);
            dgvNguyenLieu.TabIndex = 0;
            dgvNguyenLieu.CellClick += dgvNguyenLieu_CellClick;
            dgvNguyenLieu.CellFormatting += dgvNguyenLieu_CellFormatting;
            // 
            // lblTitle2
            // 
            lblTitle2.Dock = DockStyle.Top;
            lblTitle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle2.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle2.Location = new Point(10, 10);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(572, 35);
            lblTitle2.TabIndex = 1;
            lblTitle2.Text = "📦 DANH SÁCH TỒN KHO";
            lblTitle2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblTitle1);
            panel1.Controls.Add(lbl_tenNL);
            panel1.Controls.Add(txtTenNL);
            panel1.Controls.Add(lbl_DVT);
            panel1.Controls.Add(txtDonVi);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(btnThemNL);
            panel1.Controls.Add(btnSuaNL);
            panel1.Controls.Add(btnXoaNL);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 570);
            panel1.TabIndex = 1;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle1.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle1.Location = new Point(20, 20);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(235, 21);
            lblTitle1.TabIndex = 0;
            lblTitle1.Text = "✍️ THÔNG TIN NGUYÊN LIỆU";
            // 
            // lbl_tenNL
            // 
            lbl_tenNL.Location = new Point(20, 70);
            lbl_tenNL.Name = "lbl_tenNL";
            lbl_tenNL.Size = new Size(100, 23);
            lbl_tenNL.TabIndex = 1;
            lbl_tenNL.Text = "Tên Nguyên Liệu:";
            // 
            // txtTenNL
            // 
            txtTenNL.Location = new Point(20, 95);
            txtTenNL.Name = "txtTenNL";
            txtTenNL.Size = new Size(250, 24);
            txtTenNL.TabIndex = 2;
            // 
            // lbl_DVT
            // 
            lbl_DVT.Location = new Point(20, 140);
            lbl_DVT.Name = "lbl_DVT";
            lbl_DVT.Size = new Size(100, 23);
            lbl_DVT.TabIndex = 3;
            lbl_DVT.Text = "Đơn Vị Tính:";
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(20, 165);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(250, 24);
            txtDonVi.TabIndex = 4;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.LightGray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Location = new Point(20, 220);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 38);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThemNL
            // 
            btnThemNL.BackColor = Color.MediumSeaGreen;
            btnThemNL.FlatStyle = FlatStyle.Flat;
            btnThemNL.ForeColor = Color.White;
            btnThemNL.Location = new Point(150, 220);
            btnThemNL.Name = "btnThemNL";
            btnThemNL.Size = new Size(120, 38);
            btnThemNL.TabIndex = 6;
            btnThemNL.Text = "Thêm";
            btnThemNL.UseVisualStyleBackColor = false;
            btnThemNL.Click += btnThemNL_Click;
            // 
            // btnSuaNL
            // 
            btnSuaNL.BackColor = Color.DodgerBlue;
            btnSuaNL.FlatStyle = FlatStyle.Flat;
            btnSuaNL.ForeColor = Color.White;
            btnSuaNL.Location = new Point(20, 268);
            btnSuaNL.Name = "btnSuaNL";
            btnSuaNL.Size = new Size(120, 38);
            btnSuaNL.TabIndex = 7;
            btnSuaNL.Text = "Sửa";
            btnSuaNL.UseVisualStyleBackColor = false;
            btnSuaNL.Click += btnSuaNL_Click;
            // 
            // btnXoaNL
            // 
            btnXoaNL.BackColor = Color.Salmon;
            btnXoaNL.FlatStyle = FlatStyle.Flat;
            btnXoaNL.ForeColor = Color.White;
            btnXoaNL.Location = new Point(150, 268);
            btnXoaNL.Name = "btnXoaNL";
            btnXoaNL.Size = new Size(120, 38);
            btnXoaNL.TabIndex = 8;
            btnXoaNL.Text = "Xoá";
            btnXoaNL.UseVisualStyleBackColor = false;
            btnXoaNL.Click += btnXoaNL_Click;
            // 
            // NhapHang
            // 
            NhapHang.Controls.Add(pnlQuanLyPhieu);
            NhapHang.Controls.Add(pnlTaoPhieuMoi);
            NhapHang.Location = new Point(4, 26);
            NhapHang.Name = "NhapHang";
            NhapHang.Size = new Size(892, 570);
            NhapHang.TabIndex = 1;
            NhapHang.Text = "Nhập Hàng";
            NhapHang.UseVisualStyleBackColor = true;
            // 
            // pnlQuanLyPhieu
            // 
            pnlQuanLyPhieu.Controls.Add(cboLoaiPhieu);
            pnlQuanLyPhieu.Controls.Add(splitContainerPhieu);
            pnlQuanLyPhieu.Controls.Add(btnThanhToan);
            pnlQuanLyPhieu.Controls.Add(btnXoaPhieu);
            pnlQuanLyPhieu.Controls.Add(btnThemPhieuMoi);
            pnlQuanLyPhieu.Location = new Point(0, 0);
            pnlQuanLyPhieu.Name = "pnlQuanLyPhieu";
            pnlQuanLyPhieu.Size = new Size(892, 570);
            pnlQuanLyPhieu.TabIndex = 0;
            // 
            // cboLoaiPhieu
            // 
            cboLoaiPhieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhieu.FormattingEnabled = true;
            cboLoaiPhieu.Items.AddRange(new object[] { "Nhập Kho", "Xuất Hủy" });
            cboLoaiPhieu.Location = new Point(502, 10);
            cboLoaiPhieu.Name = "cboLoaiPhieu";
            cboLoaiPhieu.Size = new Size(151, 25);
            cboLoaiPhieu.TabIndex = 2;
            cboLoaiPhieu.SelectedIndexChanged += cboLoaiPhieu_SelectedIndexChanged;
            // 
            // splitContainerPhieu
            // 
            splitContainerPhieu.Location = new Point(10, 60);
            splitContainerPhieu.Name = "splitContainerPhieu";
            splitContainerPhieu.Orientation = Orientation.Horizontal;
            // 
            // splitContainerPhieu.Panel1
            // 
            splitContainerPhieu.Panel1.Controls.Add(dgvDanhSachPhieu);
            splitContainerPhieu.Panel1.Controls.Add(label2);
            // 
            // splitContainerPhieu.Panel2
            // 
            splitContainerPhieu.Panel2.Controls.Add(dgvChiTietPhieuCu);
            splitContainerPhieu.Panel2.Controls.Add(label3);
            splitContainerPhieu.Size = new Size(870, 500);
            splitContainerPhieu.SplitterDistance = 250;
            splitContainerPhieu.TabIndex = 0;
            // 
            // dgvDanhSachPhieu
            // 
            dgvDanhSachPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachPhieu.BackgroundColor = Color.White;
            dgvDanhSachPhieu.Dock = DockStyle.Fill;
            dgvDanhSachPhieu.Location = new Point(0, 17);
            dgvDanhSachPhieu.Name = "dgvDanhSachPhieu";
            dgvDanhSachPhieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachPhieu.Size = new Size(870, 233);
            dgvDanhSachPhieu.TabIndex = 0;
            dgvDanhSachPhieu.CellClick += dgvDanhSachPhieu_CellClick;
            dgvDanhSachPhieu.CellContentClick += dgvDanhSachPhieu_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(214, 17);
            label2.TabIndex = 1;
            label2.Text = "DANH SÁCH PHIẾU NHẬP HÀNG:";
            // 
            // dgvChiTietPhieuCu
            // 
            dgvChiTietPhieuCu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieuCu.BackgroundColor = Color.White;
            dgvChiTietPhieuCu.Dock = DockStyle.Fill;
            dgvChiTietPhieuCu.Location = new Point(0, 17);
            dgvChiTietPhieuCu.Name = "dgvChiTietPhieuCu";
            dgvChiTietPhieuCu.Size = new Size(870, 229);
            dgvChiTietPhieuCu.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(107, 17);
            label3.TabIndex = 1;
            label3.Text = "CHI TIẾT PHIẾU:";
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.DodgerBlue;
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(300, 10);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(170, 35);
            btnThanhToan.TabIndex = 1;
            btnThanhToan.Text = "Thanh Toán & Công Nợ";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnXoaPhieu
            // 
            btnXoaPhieu.BackColor = Color.Salmon;
            btnXoaPhieu.FlatStyle = FlatStyle.Flat;
            btnXoaPhieu.ForeColor = Color.White;
            btnXoaPhieu.Location = new Point(170, 10);
            btnXoaPhieu.Name = "btnXoaPhieu";
            btnXoaPhieu.Size = new Size(120, 35);
            btnXoaPhieu.TabIndex = 2;
            btnXoaPhieu.Text = "Xóa Phiếu";
            btnXoaPhieu.UseVisualStyleBackColor = false;
            btnXoaPhieu.Click += btnXoaPhieu_Click;
            // 
            // btnThemPhieuMoi
            // 
            btnThemPhieuMoi.BackColor = Color.MediumSeaGreen;
            btnThemPhieuMoi.FlatStyle = FlatStyle.Flat;
            btnThemPhieuMoi.ForeColor = Color.White;
            btnThemPhieuMoi.Location = new Point(10, 10);
            btnThemPhieuMoi.Name = "btnThemPhieuMoi";
            btnThemPhieuMoi.Size = new Size(150, 35);
            btnThemPhieuMoi.TabIndex = 3;
            btnThemPhieuMoi.Text = "+ TẠO PHIẾU NHẬP";
            btnThemPhieuMoi.UseVisualStyleBackColor = false;
            btnThemPhieuMoi.Click += btnThemPhieuMoi_Click;
            // 
            // pnlTaoPhieuMoi
            // 
            pnlTaoPhieuMoi.Controls.Add(dgvChiTietNhap);
            pnlTaoPhieuMoi.Controls.Add(btnQuayLai);
            pnlTaoPhieuMoi.Controls.Add(btnLuuPhieu);
            pnlTaoPhieuMoi.Controls.Add(btnThemNCC);
            pnlTaoPhieuMoi.Controls.Add(txtDonGia);
            pnlTaoPhieuMoi.Controls.Add(dtpNgayNhap);
            pnlTaoPhieuMoi.Controls.Add(btnThemVaoPhieu);
            pnlTaoPhieuMoi.Controls.Add(txtSoLuongNhap);
            pnlTaoPhieuMoi.Controls.Add(cboNhaCungCap);
            pnlTaoPhieuMoi.Controls.Add(cboChonNL_Tab2);
            pnlTaoPhieuMoi.Controls.Add(lbl_GiaNhap);
            pnlTaoPhieuMoi.Controls.Add(lbl_SoLuongNhap);
            pnlTaoPhieuMoi.Controls.Add(label1);
            pnlTaoPhieuMoi.Controls.Add(lbl_ChonNgayNhap);
            pnlTaoPhieuMoi.Controls.Add(lbl_ChonNguyenLieu);
            pnlTaoPhieuMoi.Location = new Point(0, 0);
            pnlTaoPhieuMoi.Name = "pnlTaoPhieuMoi";
            pnlTaoPhieuMoi.Size = new Size(892, 570);
            pnlTaoPhieuMoi.TabIndex = 1;
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTietNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietNhap.Location = new Point(10, 320);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.Size = new Size(870, 240);
            dgvChiTietNhap.TabIndex = 0;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(10, 10);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(100, 30);
            btnQuayLai.TabIndex = 1;
            btnQuayLai.Text = "< Quay Lại";
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // btnLuuPhieu
            // 
            btnLuuPhieu.BackColor = Color.Orange;
            btnLuuPhieu.FlatStyle = FlatStyle.Flat;
            btnLuuPhieu.Location = new Point(270, 260);
            btnLuuPhieu.Name = "btnLuuPhieu";
            btnLuuPhieu.Size = new Size(150, 35);
            btnLuuPhieu.TabIndex = 2;
            btnLuuPhieu.Text = "LƯU PHIẾU NHẬP";
            btnLuuPhieu.UseVisualStyleBackColor = false;
            btnLuuPhieu.Click += btnLuuPhieu_Click;
            // 
            // btnThemNCC
            // 
            btnThemNCC.Location = new Point(345, 56);
            btnThemNCC.Name = "btnThemNCC";
            btnThemNCC.Size = new Size(30, 27);
            btnThemNCC.TabIndex = 3;
            btnThemNCC.Text = "+";
            btnThemNCC.Click += btnThemNCC_Click;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(140, 177);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(200, 24);
            txtDonGia.TabIndex = 4;
            // 
            // panel3
            // 
            dtpNgayNhap.Location = new Point(140, 97);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(200, 24);
            dtpNgayNhap.TabIndex = 5;
            // 
            // btnThemVaoPhieu
            // 
            btnThemVaoPhieu.BackColor = Color.MediumSeaGreen;
            btnThemVaoPhieu.FlatStyle = FlatStyle.Flat;
            btnThemVaoPhieu.ForeColor = Color.White;
            btnThemVaoPhieu.Location = new Point(140, 260);
            btnThemVaoPhieu.Name = "btnThemVaoPhieu";
            btnThemVaoPhieu.Size = new Size(120, 35);
            btnThemVaoPhieu.TabIndex = 6;
            btnThemVaoPhieu.Text = "Thêm Vào Giỏ";
            btnThemVaoPhieu.UseVisualStyleBackColor = false;
            btnThemVaoPhieu.Click += btnThemVaoPhieu_Click;
            // 
            // label1
            // 
            txtSoLuongNhap.Location = new Point(140, 217);
            txtSoLuongNhap.Name = "txtSoLuongNhap";
            txtSoLuongNhap.Size = new Size(200, 24);
            txtSoLuongNhap.TabIndex = 7;
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.Location = new Point(140, 57);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(200, 25);
            cboNhaCungCap.TabIndex = 8;
            // 
            // dtpNgayNhap
            // 
            cboChonNL_Tab2.Location = new Point(140, 137);
            cboChonNL_Tab2.Name = "cboChonNL_Tab2";
            cboChonNL_Tab2.Size = new Size(200, 25);
            cboChonNL_Tab2.TabIndex = 9;
            // 
            // panel2
            // 
            lbl_GiaNhap.Location = new Point(20, 180);
            lbl_GiaNhap.Name = "lbl_GiaNhap";
            lbl_GiaNhap.Size = new Size(100, 23);
            lbl_GiaNhap.TabIndex = 10;
            lbl_GiaNhap.Text = "Giá Nhập:";
            // 
            // dgvChiTietNhap
            // 
            lbl_SoLuongNhap.Location = new Point(20, 220);
            lbl_SoLuongNhap.Name = "lbl_SoLuongNhap";
            lbl_SoLuongNhap.Size = new Size(100, 23);
            lbl_SoLuongNhap.TabIndex = 11;
            lbl_SoLuongNhap.Text = "Số Lượng:";
            // 
            // btnLuuPhieu
            // 
            label1.Location = new Point(20, 60);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 12;
            label1.Text = "Nhà Cung Cấp:";
            // 
            // lbl_ChonNgayNhap
            // 
            lbl_ChonNgayNhap.Location = new Point(20, 100);
            lbl_ChonNgayNhap.Name = "lbl_ChonNgayNhap";
            lbl_ChonNgayNhap.Size = new Size(100, 23);
            lbl_ChonNgayNhap.TabIndex = 13;
            lbl_ChonNgayNhap.Text = "Ngày Nhập:";
            // 
            // lblTongTien
            // 
            lbl_ChonNguyenLieu.Location = new Point(20, 140);
            lbl_ChonNguyenLieu.Name = "lbl_ChonNguyenLieu";
            lbl_ChonNguyenLieu.Size = new Size(100, 23);
            lbl_ChonNguyenLieu.TabIndex = 14;
            lbl_ChonNguyenLieu.Text = "Nguyên Liệu:";
            // 
            // UC_Kho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tab_Kho);
            Margin = new Padding(1);
            Name = "UC_Kho";
            Size = new Size(900, 600);
            Load += UC_Kho_Load;
            tab_Kho.ResumeLayout(false);
            DanhSach_TonKho.ResumeLayout(false);
            pnlGridNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            NhapHang.ResumeLayout(false);
            pnlQuanLyPhieu.ResumeLayout(false);
            splitContainerPhieu.Panel1.ResumeLayout(false);
            splitContainerPhieu.Panel1.PerformLayout();
            splitContainerPhieu.Panel2.ResumeLayout(false);
            splitContainerPhieu.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerPhieu).EndInit();
            splitContainerPhieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachPhieu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieuCu).EndInit();
            pnlTaoPhieuMoi.ResumeLayout(false);
            pnlTaoPhieuMoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TabControl tab_Kho;
        private System.Windows.Forms.TabPage DanhSach_TonKho;
        private System.Windows.Forms.TabPage NhapHang;

        // Tab 1 Controls
        private System.Windows.Forms.Panel pnlGridNL;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lbl_GiaNhap;
        private System.Windows.Forms.Label lbl_DVT;
        private System.Windows.Forms.Label lbl_tenNL;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenNL;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.DataGridView dgvNguyenLieu;
        private System.Windows.Forms.Button btnSuaNL;
        private System.Windows.Forms.Button btnXoaNL;
        private System.Windows.Forms.Button btnThemNL;
        private System.Windows.Forms.Button btnLamMoi;

        // Tab 2 Controls
        private System.Windows.Forms.Label lbl_ChonNguyenLieu;
        private System.Windows.Forms.ComboBox cboChonNL_Tab2;
        private System.Windows.Forms.Button btnThemVaoPhieu;
        private System.Windows.Forms.TextBox txtSoLuongNhap;
        private System.Windows.Forms.Label lbl_SoLuongNhap;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ChonNgayNhap;
        private System.Windows.Forms.DataGridView dgvChiTietNhap;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Panel pnlQuanLyPhieu;
        private System.Windows.Forms.Panel pnlTaoPhieuMoi;
        private System.Windows.Forms.Button btnThemPhieuMoi;
        private System.Windows.Forms.Button btnXoaPhieu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnThemNCC;
        private System.Windows.Forms.SplitContainer splitContainerPhieu;
        private System.Windows.Forms.DataGridView dgvDanhSachPhieu;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuCu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ComboBox cboLoaiPhieu;
    }
}