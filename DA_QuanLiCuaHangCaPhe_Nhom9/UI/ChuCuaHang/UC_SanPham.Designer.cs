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
            splitContainer1.Size = new Size(1834, 887);
            splitContainer1.SplitterDistance = 611;
            splitContainer1.TabIndex = 0;
            // 
            // flpDanhSachMon
            // 
            flpDanhSachMon.AutoScroll = true;
            flpDanhSachMon.Dock = DockStyle.Fill;
            flpDanhSachMon.Location = new Point(0, 47);
            flpDanhSachMon.Name = "flpDanhSachMon";
            flpDanhSachMon.Size = new Size(611, 840);
            flpDanhSachMon.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Top;
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(611, 47);
            textBox1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnLuu);
            groupBox2.Controls.Add(dgvCongThuc);
            groupBox2.Controls.Add(btnThemNL);
            groupBox2.Controls.Add(txtSoLuongNL);
            groupBox2.Controls.Add(cboNguyenLieu);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 197);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1219, 690);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "CÔNG THỨC PHA CHẾ";
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuu.BackColor = Color.YellowGreen;
            btnLuu.FlatAppearance.BorderColor = Color.Black;
            btnLuu.Location = new Point(994, 615);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(188, 58);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // dgvCongThuc
            // 
            dgvCongThuc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCongThuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCongThuc.Location = new Point(28, 169);
            dgvCongThuc.Name = "dgvCongThuc";
            dgvCongThuc.RowHeadersWidth = 102;
            dgvCongThuc.Size = new Size(1154, 413);
            dgvCongThuc.TabIndex = 3;
            // 
            // btnThemNL
            // 
            btnThemNL.Location = new Point(994, 86);
            btnThemNL.Name = "btnThemNL";
            btnThemNL.Size = new Size(188, 58);
            btnThemNL.TabIndex = 2;
            btnThemNL.Text = "Thêm";
            btnThemNL.UseVisualStyleBackColor = true;
            // 
            // txtSoLuongNL
            // 
            txtSoLuongNL.Location = new Point(415, 87);
            txtSoLuongNL.Name = "txtSoLuongNL";
            txtSoLuongNL.Size = new Size(250, 47);
            txtSoLuongNL.TabIndex = 1;
            // 
            // cboNguyenLieu
            // 
            cboNguyenLieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguyenLieu.FormattingEnabled = true;
            cboNguyenLieu.Location = new Point(28, 86);
            cboNguyenLieu.Name = "cboNguyenLieu";
            cboNguyenLieu.Size = new Size(302, 49);
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
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1219, 197);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "THÔNG TIN SẢN PHẨM";
            // 
            // cboDonVi
            // 
            cboDonVi.FormattingEnabled = true;
            cboDonVi.Location = new Point(932, 127);
            cboDonVi.Name = "cboDonVi";
            cboDonVi.Size = new Size(250, 49);
            cboDonVi.TabIndex = 2;
            // 
            // cboLoai
            // 
            cboLoai.FormattingEnabled = true;
            cboLoai.Location = new Point(932, 59);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(250, 49);
            cboLoai.TabIndex = 2;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(224, 127);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(250, 47);
            txtGiaBan.TabIndex = 1;
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(224, 56);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(250, 47);
            txtTenMon.TabIndex = 1;
            // 
            // lbl_DonVi
            // 
            lbl_DonVi.AutoSize = true;
            lbl_DonVi.Location = new Point(736, 131);
            lbl_DonVi.Name = "lbl_DonVi";
            lbl_DonVi.Size = new Size(103, 41);
            lbl_DonVi.TabIndex = 0;
            lbl_DonVi.Text = "Đơn vị";
            // 
            // lbl_LoaiMon
            // 
            lbl_LoaiMon.AutoSize = true;
            lbl_LoaiMon.Location = new Point(736, 63);
            lbl_LoaiMon.Name = "lbl_LoaiMon";
            lbl_LoaiMon.Size = new Size(148, 41);
            lbl_LoaiMon.TabIndex = 0;
            lbl_LoaiMon.Text = "Loại món:";
            // 
            // lbl_DonGia
            // 
            lbl_DonGia.AutoSize = true;
            lbl_DonGia.Location = new Point(28, 130);
            lbl_DonGia.Name = "lbl_DonGia";
            lbl_DonGia.Size = new Size(129, 41);
            lbl_DonGia.TabIndex = 0;
            lbl_DonGia.Text = "Đơn giá:";
            // 
            // lbl_TenMon
            // 
            lbl_TenMon.AutoSize = true;
            lbl_TenMon.Location = new Point(28, 59);
            lbl_TenMon.Name = "lbl_TenMon";
            lbl_TenMon.Size = new Size(140, 41);
            lbl_TenMon.TabIndex = 0;
            lbl_TenMon.Text = "Tên món:";
            // 
            // UC_SanPham
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "UC_SanPham";
            Size = new Size(1834, 887);
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
    }
}
