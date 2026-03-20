namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_SanPham
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
            splitContainer1 = new SplitContainer();
            flpDanhSachMon = new FlowLayoutPanel();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            btnTaoMonMoi = new Button();
            btnXoaNL = new Button();
            btnLuu = new Button();
            dgvCongThuc = new DataGridView();
            btnThemNL = new Button();
            txtSoLuongNL = new TextBox();
            cboNguyenLieu = new ComboBox();
            groupBox1 = new GroupBox();
            cboDonVi = new ComboBox();
            cboLoai = new ComboBox();
            txtGiaBan = new TextBox();
            txtTenMon = new TextBox();
            lbl_DonVi = new Label();
            lbl_LoaiMon = new Label();
            lbl_DonGia = new Label();
            lbl_TenMon = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCongThuc).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(1);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flpDanhSachMon);
            splitContainer1.Panel1.Controls.Add(textBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(755, 325);
            splitContainer1.SplitterDistance = 251;
            splitContainer1.SplitterWidth = 2;
            splitContainer1.TabIndex = 0;
            // 
            // flpDanhSachMon
            // 
            flpDanhSachMon.AutoScroll = true;
            flpDanhSachMon.Dock = DockStyle.Fill;
            flpDanhSachMon.Location = new Point(0, 23);
            flpDanhSachMon.Margin = new Padding(1);
            flpDanhSachMon.Name = "flpDanhSachMon";
            flpDanhSachMon.Size = new Size(251, 302);
            flpDanhSachMon.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Top;
            textBox1.Location = new Point(0, 0);
            textBox1.Margin = new Padding(1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 23);
            textBox1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnTaoMonMoi);
            groupBox2.Controls.Add(btnXoaNL);
            groupBox2.Controls.Add(btnLuu);
            groupBox2.Controls.Add(dgvCongThuc);
            groupBox2.Controls.Add(btnThemNL);
            groupBox2.Controls.Add(txtSoLuongNL);
            groupBox2.Controls.Add(cboNguyenLieu);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 72);
            groupBox2.Margin = new Padding(1);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(1);
            groupBox2.Size = new Size(502, 253);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "CÔNG THỨC PHA CHẾ";
            // 
            // btnTaoMonMoi
            // 
            btnTaoMonMoi.Location = new Point(330, 4);
            btnTaoMonMoi.Name = "btnTaoMonMoi";
            btnTaoMonMoi.Size = new Size(75, 23);
            btnTaoMonMoi.TabIndex = 6;
            btnTaoMonMoi.Text = "Tạo Món Mới";
            btnTaoMonMoi.UseVisualStyleBackColor = true;
            btnTaoMonMoi.Click += btnTaoMonMoi_Click;
            // 
            // btnXoaNL
            // 
            btnXoaNL.Enabled = false;
            btnXoaNL.Location = new Point(330, 29);
            btnXoaNL.Name = "btnXoaNL";
            btnXoaNL.Size = new Size(75, 23);
            btnXoaNL.TabIndex = 5;
            btnXoaNL.Text = "Xóa";
            btnXoaNL.UseVisualStyleBackColor = true;
            btnXoaNL.Click += btnXoaNL_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuu.BackColor = Color.YellowGreen;
            btnLuu.FlatAppearance.BorderColor = Color.Black;
            btnLuu.Location = new Point(409, 226);
            btnLuu.Margin = new Padding(1);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(77, 21);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // dgvCongThuc
            // 
            dgvCongThuc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCongThuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCongThuc.Location = new Point(12, 62);
            dgvCongThuc.Margin = new Padding(1);
            dgvCongThuc.Name = "dgvCongThuc";
            dgvCongThuc.RowHeadersWidth = 102;
            dgvCongThuc.Size = new Size(475, 152);
            dgvCongThuc.TabIndex = 3;
            dgvCongThuc.CellDoubleClick += dgvCongThuc_CellDoubleClick;
            dgvCongThuc.SelectionChanged += dgvCongThuc_SelectionChanged;
            // 
            // btnThemNL
            // 
            btnThemNL.Location = new Point(409, 31);
            btnThemNL.Margin = new Padding(1);
            btnThemNL.Name = "btnThemNL";
            btnThemNL.Size = new Size(77, 21);
            btnThemNL.TabIndex = 2;
            btnThemNL.Text = "Thêm";
            btnThemNL.UseVisualStyleBackColor = true;
            btnThemNL.Click += btnThemNL_Click;
            // 
            // txtSoLuongNL
            // 
            txtSoLuongNL.Location = new Point(171, 32);
            txtSoLuongNL.Margin = new Padding(1);
            txtSoLuongNL.Name = "txtSoLuongNL";
            txtSoLuongNL.Size = new Size(105, 23);
            txtSoLuongNL.TabIndex = 1;
            // 
            // cboNguyenLieu
            // 
            cboNguyenLieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguyenLieu.FormattingEnabled = true;
            cboNguyenLieu.Location = new Point(12, 31);
            cboNguyenLieu.Margin = new Padding(1);
            cboNguyenLieu.Name = "cboNguyenLieu";
            cboNguyenLieu.Size = new Size(127, 23);
            cboNguyenLieu.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboDonVi);
            groupBox1.Controls.Add(cboLoai);
            groupBox1.Controls.Add(txtGiaBan);
            groupBox1.Controls.Add(txtTenMon);
            groupBox1.Controls.Add(lbl_DonVi);
            groupBox1.Controls.Add(lbl_LoaiMon);
            groupBox1.Controls.Add(lbl_DonGia);
            groupBox1.Controls.Add(lbl_TenMon);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1);
            groupBox1.Size = new Size(502, 72);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "THÔNG TIN SẢN PHẨM";
            // 
            // cboDonVi
            // 
            cboDonVi.FormattingEnabled = true;
            cboDonVi.Location = new Point(384, 46);
            cboDonVi.Margin = new Padding(1);
            cboDonVi.Name = "cboDonVi";
            cboDonVi.Size = new Size(105, 23);
            cboDonVi.TabIndex = 2;
            // 
            // cboLoai
            // 
            cboLoai.FormattingEnabled = true;
            cboLoai.Location = new Point(384, 22);
            cboLoai.Margin = new Padding(1);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(105, 23);
            cboLoai.TabIndex = 2;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(92, 46);
            txtGiaBan.Margin = new Padding(1);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(105, 23);
            txtGiaBan.TabIndex = 1;
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(92, 20);
            txtTenMon.Margin = new Padding(1);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(105, 23);
            txtTenMon.TabIndex = 1;
            // 
            // lbl_DonVi
            // 
            lbl_DonVi.AutoSize = true;
            lbl_DonVi.Location = new Point(303, 48);
            lbl_DonVi.Margin = new Padding(1, 0, 1, 0);
            lbl_DonVi.Name = "lbl_DonVi";
            lbl_DonVi.Size = new Size(41, 15);
            lbl_DonVi.TabIndex = 0;
            lbl_DonVi.Text = "Đơn vị";
            // 
            // lbl_LoaiMon
            // 
            lbl_LoaiMon.AutoSize = true;
            lbl_LoaiMon.Location = new Point(303, 23);
            lbl_LoaiMon.Margin = new Padding(1, 0, 1, 0);
            lbl_LoaiMon.Name = "lbl_LoaiMon";
            lbl_LoaiMon.Size = new Size(60, 15);
            lbl_LoaiMon.TabIndex = 0;
            lbl_LoaiMon.Text = "Loại món:";
            // 
            // lbl_DonGia
            // 
            lbl_DonGia.AutoSize = true;
            lbl_DonGia.Location = new Point(12, 48);
            lbl_DonGia.Margin = new Padding(1, 0, 1, 0);
            lbl_DonGia.Name = "lbl_DonGia";
            lbl_DonGia.Size = new Size(51, 15);
            lbl_DonGia.TabIndex = 0;
            lbl_DonGia.Text = "Đơn giá:";
            // 
            // lbl_TenMon
            // 
            lbl_TenMon.AutoSize = true;
            lbl_TenMon.Location = new Point(12, 22);
            lbl_TenMon.Margin = new Padding(1, 0, 1, 0);
            lbl_TenMon.Name = "lbl_TenMon";
            lbl_TenMon.Size = new Size(57, 15);
            lbl_TenMon.TabIndex = 0;
            lbl_TenMon.Text = "Tên món:";
            // 
            // UC_SanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Margin = new Padding(1);
            Name = "UC_SanPham";
            Size = new Size(755, 325);
            Load += UC_SanPham_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCongThuc).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label lbl_DonVi;
        private Label lbl_LoaiMon;
        private Label lbl_DonGia;
        private Label lbl_TenMon;
        private ComboBox cboDonVi;
        private ComboBox cboLoai;
        private TextBox txtGiaBan;
        private TextBox txtTenMon;
        private Button btnThemNL;
        private TextBox txtSoLuongNL;
        private ComboBox cboNguyenLieu;
        private Button btnLuu;
        private DataGridView dgvCongThuc;
        private FlowLayoutPanel flpDanhSachMon;
        private Button btnTaoMonMoi;
        private Button btnXoaNL;
    }
}
