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
            btnThemNL = new Button();
            lbl_DVT = new Label();
            lbl_tenNL = new Label();
            txtDonVi = new TextBox();
            txtTenNL = new TextBox();
            NhapHang = new TabPage();
            btnLamMoi = new Button();
            tab_Kho.SuspendLayout();
            DanhSach_TonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tab_Kho
            // 
            tab_Kho.Controls.Add(DanhSach_TonKho);
            tab_Kho.Controls.Add(NhapHang);
            tab_Kho.Dock = DockStyle.Fill;
            tab_Kho.Location = new Point(0, 0);
            tab_Kho.Name = "tab_Kho";
            tab_Kho.SelectedIndex = 0;
            tab_Kho.Size = new Size(1519, 739);
            tab_Kho.TabIndex = 0;
            // 
            // DanhSach_TonKho
            // 
            DanhSach_TonKho.Controls.Add(dgvNguyenLieu);
            DanhSach_TonKho.Controls.Add(panel1);
            DanhSach_TonKho.Location = new Point(10, 58);
            DanhSach_TonKho.Name = "DanhSach_TonKho";
            DanhSach_TonKho.Padding = new Padding(3);
            DanhSach_TonKho.Size = new Size(1499, 671);
            DanhSach_TonKho.TabIndex = 0;
            DanhSach_TonKho.Text = "Danh Sách & Tồn Kho";
            DanhSach_TonKho.UseVisualStyleBackColor = true;
            // 
            // dgvNguyenLieu
            // 
            dgvNguyenLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguyenLieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNguyenLieu.Dock = DockStyle.Fill;
            dgvNguyenLieu.Location = new Point(503, 3);
            dgvNguyenLieu.Name = "dgvNguyenLieu";
            dgvNguyenLieu.RowHeadersWidth = 102;
            dgvNguyenLieu.Size = new Size(993, 665);
            dgvNguyenLieu.TabIndex = 1;
            dgvNguyenLieu.CellClick += dgvNguyenLieu_CellClick;
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
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 665);
            panel1.TabIndex = 0;
            // 
            // btnSuaNL
            // 
            btnSuaNL.Location = new Point(263, 437);
            btnSuaNL.Name = "btnSuaNL";
            btnSuaNL.Size = new Size(188, 58);
            btnSuaNL.TabIndex = 2;
            btnSuaNL.Text = "Sửa";
            btnSuaNL.UseVisualStyleBackColor = true;
            btnSuaNL.Click += btnSuaNL_Click;
            // 
            // btnXoaNL
            // 
            btnXoaNL.Location = new Point(263, 338);
            btnXoaNL.Name = "btnXoaNL";
            btnXoaNL.Size = new Size(188, 58);
            btnXoaNL.TabIndex = 2;
            btnXoaNL.Text = "Xoá";
            btnXoaNL.UseVisualStyleBackColor = true;
            btnXoaNL.Click += btnXoaNL_Click;
            // 
            // btnThemNL
            // 
            btnThemNL.Location = new Point(18, 338);
            btnThemNL.Name = "btnThemNL";
            btnThemNL.Size = new Size(188, 58);
            btnThemNL.TabIndex = 2;
            btnThemNL.Text = "Thêm";
            btnThemNL.UseVisualStyleBackColor = true;
            btnThemNL.Click += btnThemNL_Click;
            // 
            // lbl_DVT
            // 
            lbl_DVT.AutoSize = true;
            lbl_DVT.Location = new Point(18, 110);
            lbl_DVT.Name = "lbl_DVT";
            lbl_DVT.Size = new Size(82, 41);
            lbl_DVT.TabIndex = 1;
            lbl_DVT.Text = "ĐVT:";
            // 
            // lbl_tenNL
            // 
            lbl_tenNL.AutoSize = true;
            lbl_tenNL.Location = new Point(18, 34);
            lbl_tenNL.Name = "lbl_tenNL";
            lbl_tenNL.Size = new Size(115, 41);
            lbl_tenNL.TabIndex = 1;
            lbl_tenNL.Text = "Tên NL:";
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(274, 109);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(177, 47);
            txtDonVi.TabIndex = 0;
            // 
            // txtTenNL
            // 
            txtTenNL.Location = new Point(274, 31);
            txtTenNL.Name = "txtTenNL";
            txtTenNL.Size = new Size(177, 47);
            txtTenNL.TabIndex = 0;
            // 
            // NhapHang
            // 
            NhapHang.Location = new Point(10, 58);
            NhapHang.Name = "NhapHang";
            NhapHang.Padding = new Padding(3);
            NhapHang.Size = new Size(1499, 671);
            NhapHang.TabIndex = 1;
            NhapHang.Text = "Nhập Hàng";
            NhapHang.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(18, 437);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(188, 58);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // UC_Kho
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tab_Kho);
            Name = "UC_Kho";
            Size = new Size(1519, 739);
            Load += UC_Kho_Load;
            tab_Kho.ResumeLayout(false);
            DanhSach_TonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguyenLieu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
    }
}
