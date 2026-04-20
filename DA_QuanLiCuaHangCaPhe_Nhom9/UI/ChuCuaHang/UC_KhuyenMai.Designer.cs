namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_KhuyenMai
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
            // Khai báo nhãn
            lblTenKM = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblDoiTuong = new Label();
            lblSanPham = new Label();
            // Khai báo điều khiển nhập liệu
            txtTenKM = new TextBox();
            txtGiaTri = new TextBox();
            txtMoTa = new TextBox();
            cboLoaiKM = new ComboBox();
            cboTrangThai_KM = new ComboBox();
            cboDoiTuong = new ComboBox();
            dtpNgayBatDau = new DateTimePicker();
            dtpNgayKetThuc = new DateTimePicker();
            clbSanPham = new CheckedListBox();
            // Khai báo Nút bấm
            btnLuu = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            // Khai báo khu vực Lưới
            pnlRight = new Panel();
            dgvKhuyenMai = new DataGridView();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhuyenMai).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft (Khung nhập liệu bên trái)
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(lblTitle);
            pnlLeft.Controls.Add(lblTenKM);
            pnlLeft.Controls.Add(txtTenKM);
            pnlLeft.Controls.Add(label2);
            pnlLeft.Controls.Add(txtGiaTri);
            pnlLeft.Controls.Add(label1);
            pnlLeft.Controls.Add(cboLoaiKM);
            pnlLeft.Controls.Add(lblDoiTuong);
            pnlLeft.Controls.Add(cboDoiTuong);
            pnlLeft.Controls.Add(label5);
            pnlLeft.Controls.Add(cboTrangThai_KM);
            pnlLeft.Controls.Add(label3);
            pnlLeft.Controls.Add(dtpNgayBatDau);
            pnlLeft.Controls.Add(label4);
            pnlLeft.Controls.Add(dtpNgayKetThuc);
            pnlLeft.Controls.Add(lblSanPham);
            pnlLeft.Controls.Add(clbSanPham);
            pnlLeft.Controls.Add(label6);
            pnlLeft.Controls.Add(txtMoTa);
            pnlLeft.Controls.Add(btnLuu);
            pnlLeft.Controls.Add(btnXoa);
            pnlLeft.Controls.Add(btnLamMoi);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(380, 700);
            pnlLeft.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DeepPink;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(378, 60);
            lblTitle.Text = "THIẾT LẬP KHUYẾN MÃI";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // --- HÀNG 1: Tên KM (Full width) ---
            lblTenKM.AutoSize = true;
            lblTenKM.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTenKM.Location = new Point(20, 70);
            lblTenKM.Text = "Tên chương trình:";
            txtTenKM.Location = new Point(20, 90);
            txtTenKM.Size = new Size(335, 23);
            // --- HÀNG 2: Giảm giá (Cột trái) & Loại (Cột phải) ---
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(20, 130);
            label2.Text = "Mức giảm (%):";
            txtGiaTri.Location = new Point(20, 150);
            txtGiaTri.Size = new Size(160, 23);
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(195, 130);
            label1.Text = "Hình thức áp dụng:";
            cboLoaiKM.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiKM.Items.AddRange(new object[] { "Hóa Đơn", "Sản Phẩm" });
            cboLoaiKM.Location = new Point(195, 150);
            cboLoaiKM.Size = new Size(160, 23);
            cboLoaiKM.SelectedIndexChanged += cboLoaiKM_SelectedIndexChanged;
            // --- HÀNG 3: Đối tượng (Cột trái) & Trạng thái (Cột phải) ---
            lblDoiTuong.AutoSize = true;
            lblDoiTuong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDoiTuong.Location = new Point(20, 190);
            lblDoiTuong.Text = "Khách hàng:";
            cboDoiTuong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoiTuong.Items.AddRange(new object[] { "Tất cả", "Thường", "VIP" });
            cboDoiTuong.Location = new Point(20, 210);
            cboDoiTuong.Size = new Size(160, 23);
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(195, 190);
            label5.Text = "Trạng thái:";
            cboTrangThai_KM.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai_KM.Items.AddRange(new object[] { "Đang áp dụng", "Đã kết thúc", "Sắp diễn ra", "Đã ẩn" });
            cboTrangThai_KM.Location = new Point(195, 210);
            cboTrangThai_KM.Size = new Size(160, 23);
            // --- HÀNG 4: Từ ngày (Cột trái) & Đến ngày (Cột phải) ---
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(20, 250);
            label3.Text = "Từ ngày:";
            dtpNgayBatDau.Format = DateTimePickerFormat.Short;
            dtpNgayBatDau.Location = new Point(20, 270);
            dtpNgayBatDau.Size = new Size(160, 23);
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(195, 250);
            label4.Text = "Đến ngày:";
            dtpNgayKetThuc.Format = DateTimePickerFormat.Short;
            dtpNgayKetThuc.Location = new Point(195, 270);
            dtpNgayKetThuc.Size = new Size(160, 23);
            // --- HÀNG 5: Chọn món (Full width) ---
            lblSanPham.AutoSize = true;
            lblSanPham.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSanPham.Location = new Point(20, 310);
            lblSanPham.Text = "Chọn Món được áp dụng Khuyến Mãi:";
            clbSanPham.FormattingEnabled = true;
            clbSanPham.Location = new Point(20, 330);
            clbSanPham.Size = new Size(335, 112);
            clbSanPham.BorderStyle = BorderStyle.FixedSingle;
            // --- HÀNG 6: Mô tả (Full width) ---
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(20, 460);
            label6.Text = "Mô tả / Thể lệ:";
            txtMoTa.Location = new Point(20, 480);
            txtMoTa.Multiline = true;
            txtMoTa.Size = new Size(335, 60);
            // --- NÚT BẤM CĂN ĐÁY ---
            btnLuu.BackColor = Color.LightSeaGreen;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(20, 560);
            btnLuu.Size = new Size(160, 45);
            btnLuu.Text = "LƯU KHUYẾN MÃI";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            btnLamMoi.BackColor = Color.LightGray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.Location = new Point(195, 560);
            btnLamMoi.Size = new Size(80, 45);
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXoa.BackColor = Color.Crimson;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(285, 560);
            btnXoa.Size = new Size(70, 45);
            btnXoa.Text = "XÓA";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // pnlRight (Lưới dữ liệu bên phải)
            // 
            pnlRight.Controls.Add(dgvKhuyenMai);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(380, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(10);
            pnlRight.Size = new Size(620, 700);
            pnlRight.TabIndex = 1;
            // 
            // dgvKhuyenMai
            // 
            dgvKhuyenMai.AllowUserToAddRows = false;
            dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuyenMai.BackgroundColor = Color.WhiteSmoke;
            dgvKhuyenMai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhuyenMai.Dock = DockStyle.Fill;
            dgvKhuyenMai.Location = new Point(10, 10);
            dgvKhuyenMai.Name = "dgvKhuyenMai";
            dgvKhuyenMai.ReadOnly = true;
            dgvKhuyenMai.RowHeadersVisible = false;
            dgvKhuyenMai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhuyenMai.Size = new Size(600, 680);
            dgvKhuyenMai.TabIndex = 0;
            dgvKhuyenMai.CellClick += dgvKhuyenMai_CellClick;
            // 
            // UC_KhuyenMai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "UC_KhuyenMai";
            Size = new Size(1000, 700);
            Load += UC_KhuyenMai_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhuyenMai).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLoaiKM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDoiTuong;
        private System.Windows.Forms.Label lblDoiTuong;
        private System.Windows.Forms.ComboBox cboTrangThai_KM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbSanPham;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
    }
}