namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_KhuyenMai
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
            txtTenKM = new TextBox();
            lblTenKM = new Label();
            txtMoTa = new TextBox();
            label2 = new Label();
            txtGiaTri = new TextBox();
            label3 = new Label();
            label1 = new Label();
            cboTrangThai_KM = new ComboBox();
            dtpNgayBatDau = new DateTimePicker();
            dtpNgayKetThuc = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            dgvKhuyenMai = new DataGridView();
            btnLuu = new Button();
            btnLamMoi = new Button();
            label6 = new Label();
            cboLoaiKM = new ComboBox();
            clbSanPham = new CheckedListBox();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKhuyenMai).BeginInit();
            SuspendLayout();
            // 
            // txtTenKM
            // 
            txtTenKM.Location = new Point(246, 15);
            txtTenKM.Name = "txtTenKM";
            txtTenKM.Size = new Size(250, 47);
            txtTenKM.TabIndex = 0;
            // 
            // lblTenKM
            // 
            lblTenKM.AutoSize = true;
            lblTenKM.Location = new Point(23, 15);
            lblTenKM.Name = "lblTenKM";
            lblTenKM.Size = new Size(116, 41);
            lblTenKM.TabIndex = 1;
            lblTenKM.Text = "Tên KM";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(246, 96);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(250, 47);
            txtMoTa.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 96);
            label2.Name = "label2";
            label2.Size = new Size(96, 41);
            label2.TabIndex = 1;
            label2.Text = "Mô tả";
            // 
            // txtGiaTri
            // 
            txtGiaTri.Location = new Point(246, 188);
            txtGiaTri.Name = "txtGiaTri";
            txtGiaTri.Size = new Size(250, 47);
            txtGiaTri.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 188);
            label3.Name = "label3";
            label3.Size = new Size(96, 41);
            label3.TabIndex = 1;
            label3.Text = "Giá trị";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(579, 15);
            label1.Name = "label1";
            label1.Size = new Size(200, 41);
            label1.TabIndex = 2;
            label1.Text = "Trạng thái KM";
            // 
            // cboTrangThai_KM
            // 
            cboTrangThai_KM.FormattingEnabled = true;
            cboTrangThai_KM.Items.AddRange(new object[] { "Đang áp dụng", "Đã kết thúc" });
            cboTrangThai_KM.Location = new Point(805, 24);
            cboTrangThai_KM.Name = "cboTrangThai_KM";
            cboTrangThai_KM.Size = new Size(302, 49);
            cboTrangThai_KM.TabIndex = 3;
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Format = DateTimePickerFormat.Short;
            dtpNgayBatDau.Location = new Point(805, 102);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(221, 47);
            dtpNgayBatDau.TabIndex = 4;
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.Format = DateTimePickerFormat.Short;
            dtpNgayKetThuc.Location = new Point(805, 194);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(221, 47);
            dtpNgayKetThuc.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(582, 102);
            label4.Name = "label4";
            label4.Size = new Size(197, 41);
            label4.TabIndex = 2;
            label4.Text = "Ngày bắt đầu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(582, 194);
            label5.Name = "label5";
            label5.Size = new Size(203, 41);
            label5.TabIndex = 2;
            label5.Text = "Ngày kết thúc";
            // 
            // dgvKhuyenMai
            // 
            dgvKhuyenMai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhuyenMai.Location = new Point(3, 407);
            dgvKhuyenMai.Name = "dgvKhuyenMai";
            dgvKhuyenMai.RowHeadersWidth = 102;
            dgvKhuyenMai.Size = new Size(1381, 375);
            dgvKhuyenMai.TabIndex = 5;
            dgvKhuyenMai.CellClick += dgvKhuyenMai_CellClick;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(1183, 102);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(188, 58);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(1183, 24);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(188, 58);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 270);
            label6.Name = "label6";
            label6.Size = new Size(124, 41);
            label6.TabIndex = 2;
            label6.Text = "Loại KM";
            // 
            // cboLoaiKM
            // 
            cboLoaiKM.FormattingEnabled = true;
            cboLoaiKM.Items.AddRange(new object[] { "Hóa Đơn", "Sản Phẩm" });
            cboLoaiKM.Location = new Point(246, 279);
            cboLoaiKM.Name = "cboLoaiKM";
            cboLoaiKM.Size = new Size(302, 49);
            cboLoaiKM.TabIndex = 3;
            cboLoaiKM.SelectedIndexChanged += cboLoaiKM_SelectedIndexChanged;
            // 
            // clbSanPham
            // 
            clbSanPham.FormattingEnabled = true;
            clbSanPham.Location = new Point(582, 279);
            clbSanPham.Name = "clbSanPham";
            clbSanPham.Size = new Size(789, 92);
            clbSanPham.TabIndex = 7;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(1183, 183);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(188, 58);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // UC_KhuyenMai
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(clbSanPham);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnLuu);
            Controls.Add(dgvKhuyenMai);
            Controls.Add(dtpNgayKetThuc);
            Controls.Add(dtpNgayBatDau);
            Controls.Add(cboLoaiKM);
            Controls.Add(cboTrangThai_KM);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblTenKM);
            Controls.Add(txtGiaTri);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenKM);
            Name = "UC_KhuyenMai";
            Size = new Size(1387, 795);
            Load += UC_KhuyenMai_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKhuyenMai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTenKM;
        private Label lblTenKM;
        private TextBox txtMoTa;
        private Label label2;
        private TextBox txtGiaTri;
        private Label label3;
        private Label label1;
        private ComboBox cboTrangThai_KM;
        private DateTimePicker dtpNgayBatDau;
        private DateTimePicker dtpNgayKetThuc;
        private Label label4;
        private Label label5;
        private DataGridView dgvKhuyenMai;
        private Button btnLuu;
        private Button btnLamMoi;
        private Label label6;
        private ComboBox cboLoaiKM;
        private CheckedListBox clbSanPham;
        private Button btnXoa;
    }
}
