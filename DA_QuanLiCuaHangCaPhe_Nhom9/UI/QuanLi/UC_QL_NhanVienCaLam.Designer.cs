namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    partial class UC_QL_NhanVienCaLam
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTopNav = new System.Windows.Forms.Panel();
            this.btnTabXepCa = new System.Windows.Forms.Button();
            this.btnTabHoSo = new System.Windows.Forms.Button();
            this.pnlHoSo = new System.Windows.Forms.Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.pnlXepCa = new System.Windows.Forms.Panel();
            this.dgvLichLam = new System.Windows.Forms.DataGridView();
            this.pnlXepCa_Bottom = new System.Windows.Forms.Panel();
            this.lblTongLuong = new System.Windows.Forms.Label();
            this.btnLuuLich = new System.Windows.Forms.Button();
            this.pnlXepCa_Top = new System.Windows.Forms.Panel();
            this.lblChonNV = new System.Windows.Forms.Label();
            this.cboNhanVienXepCa = new System.Windows.Forms.ComboBox();
            this.lblChonTuan = new System.Windows.Forms.Label();
            this.dtpTuan = new System.Windows.Forms.DateTimePicker();

            this.pnlTopNav.SuspendLayout();
            this.pnlHoSo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.gbThongTin.SuspendLayout();
            this.pnlXepCa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichLam)).BeginInit();
            this.pnlXepCa_Bottom.SuspendLayout();
            this.pnlXepCa_Top.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlTopNav
            // 
            this.pnlTopNav.BackColor = System.Drawing.Color.FromArgb(240, 242, 245); // Nền xám nhạt hiện đại
            this.pnlTopNav.Controls.Add(this.btnTabXepCa);
            this.pnlTopNav.Controls.Add(this.btnTabHoSo);
            this.pnlTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNav.Location = new System.Drawing.Point(0, 0);
            this.pnlTopNav.Name = "pnlTopNav";
            this.pnlTopNav.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTopNav.Size = new System.Drawing.Size(1200, 70);

            // 
            // btnTabHoSo
            // 
            this.btnTabHoSo.BackColor = System.Drawing.Color.FromArgb(45, 64, 89); // Navy đậm
            this.btnTabHoSo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabHoSo.FlatAppearance.BorderSize = 0;
            this.btnTabHoSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabHoSo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTabHoSo.ForeColor = System.Drawing.Color.White;
            this.btnTabHoSo.Location = new System.Drawing.Point(10, 10);
            this.btnTabHoSo.Name = "btnTabHoSo";
            this.btnTabHoSo.Size = new System.Drawing.Size(200, 50);
            this.btnTabHoSo.Text = "HỒ SƠ NHÂN SỰ";
            this.btnTabHoSo.UseVisualStyleBackColor = false;
            this.btnTabHoSo.Click += new System.EventHandler(this.SwitchTab_Click); // Gắn sự kiện

            // 
            // btnTabXepCa
            // 
            this.btnTabXepCa.BackColor = System.Drawing.Color.White;
            this.btnTabXepCa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTabXepCa.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTabXepCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabXepCa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTabXepCa.ForeColor = System.Drawing.Color.DimGray;
            this.btnTabXepCa.Location = new System.Drawing.Point(210, 10);
            this.btnTabXepCa.Name = "btnTabXepCa";
            this.btnTabXepCa.Size = new System.Drawing.Size(200, 50);
            this.btnTabXepCa.Text = "XẾP CA LÀM VIỆC";
            this.btnTabXepCa.UseVisualStyleBackColor = false;
            this.btnTabXepCa.Click += new System.EventHandler(this.SwitchTab_Click); // Gắn sự kiện

            // 
            // pnlHoSo
            // 
            this.pnlHoSo.BackColor = System.Drawing.Color.White;
            this.pnlHoSo.Controls.Add(this.dgvNhanVien);
            this.pnlHoSo.Controls.Add(this.gbThongTin);
            this.pnlHoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHoSo.Location = new System.Drawing.Point(0, 70);
            this.pnlHoSo.Name = "pnlHoSo";
            this.pnlHoSo.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHoSo.Size = new System.Drawing.Size(1200, 730);

            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.btnLamMoi);
            this.gbThongTin.Controls.Add(this.btnThem);
            this.gbThongTin.Controls.Add(this.btnSua);
            this.gbThongTin.Controls.Add(this.cboChucVu);
            this.gbThongTin.Controls.Add(this.lblChucVu);
            this.gbThongTin.Controls.Add(this.txtSDT);
            this.gbThongTin.Controls.Add(this.lblSDT);
            this.gbThongTin.Controls.Add(this.txtTenNV);
            this.gbThongTin.Controls.Add(this.lblTenNV);
            this.gbThongTin.Controls.Add(this.txtMaNV);
            this.gbThongTin.Controls.Add(this.lblMaNV);
            this.gbThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbThongTin.ForeColor = System.Drawing.Color.FromArgb(45, 64, 89);
            this.gbThongTin.Location = new System.Drawing.Point(20, 20);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(1160, 220);
            this.gbThongTin.Text = "THÔNG TIN NHÂN VIÊN";

            // Inputs
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.ForeColor = System.Drawing.Color.Black;
            this.lblMaNV.Location = new System.Drawing.Point(25, 40);
            this.lblMaNV.Text = "Mã Nhân Viên (Tự động):";
            this.txtMaNV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMaNV.Location = new System.Drawing.Point(25, 70);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(250, 32);

            this.lblTenNV.AutoSize = true;
            this.lblTenNV.ForeColor = System.Drawing.Color.Black;
            this.lblTenNV.Location = new System.Drawing.Point(300, 40);
            this.lblTenNV.Text = "Họ Tên:";
            this.txtTenNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNV.Location = new System.Drawing.Point(300, 70);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(400, 32);

            this.lblSDT.AutoSize = true;
            this.lblSDT.ForeColor = System.Drawing.Color.Black;
            this.lblSDT.Location = new System.Drawing.Point(25, 120);
            this.lblSDT.Text = "Số điện thoại:";
            this.txtSDT.Location = new System.Drawing.Point(25, 150);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(250, 32);

            this.lblChucVu.AutoSize = true;
            this.lblChucVu.ForeColor = System.Drawing.Color.Black;
            this.lblChucVu.Location = new System.Drawing.Point(300, 120);
            this.lblChucVu.Text = "Vị trí / Chức vụ:";
            this.cboChucVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChucVu.Location = new System.Drawing.Point(300, 150);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(400, 33);

            // Nút Thêm, Sửa
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi.Location = new System.Drawing.Point(740, 65);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(150, 40);
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.BtnLamMoi_Click); // Gắn sự kiện

            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(40, 167, 69); // Xanh lá chuyên nghiệp
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(920, 65);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(200, 40);
            this.btnThem.Text = "THÊM MỚI";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.BtnThem_Click); // Gắn sự kiện

            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(229, 124, 35); // Cam
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(920, 145);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(200, 40);
            this.btnSua.Text = "CẬP NHẬT";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.BtnSua_Click); // Gắn sự kiện

            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(20, 240);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(1160, 470);
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNhanVien_CellClick); // Gắn sự kiện

            // ==============================================================
            // pnlXepCa (MÀN HÌNH XẾP CA)
            // ==============================================================
            this.pnlXepCa.BackColor = System.Drawing.Color.White;
            this.pnlXepCa.Controls.Add(this.dgvLichLam);
            this.pnlXepCa.Controls.Add(this.pnlXepCa_Bottom);
            this.pnlXepCa.Controls.Add(this.pnlXepCa_Top);
            this.pnlXepCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlXepCa.Location = new System.Drawing.Point(0, 70);
            this.pnlXepCa.Name = "pnlXepCa";
            this.pnlXepCa.Padding = new System.Windows.Forms.Padding(20);
            this.pnlXepCa.Size = new System.Drawing.Size(1200, 730);
            this.pnlXepCa.Visible = false;

            // Top Panel
            this.pnlXepCa_Top.Controls.Add(this.lblChonNV);
            this.pnlXepCa_Top.Controls.Add(this.cboNhanVienXepCa);
            this.pnlXepCa_Top.Controls.Add(this.lblChonTuan);
            this.pnlXepCa_Top.Controls.Add(this.dtpTuan);
            this.pnlXepCa_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlXepCa_Top.Location = new System.Drawing.Point(20, 20);
            this.pnlXepCa_Top.Name = "pnlXepCa_Top";
            this.pnlXepCa_Top.Size = new System.Drawing.Size(1160, 70);

            this.lblChonNV.AutoSize = true;
            this.lblChonNV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChonNV.Location = new System.Drawing.Point(0, 20);
            this.lblChonNV.Text = "Nhân viên:";

            this.cboNhanVienXepCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVienXepCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboNhanVienXepCa.Location = new System.Drawing.Point(100, 17);
            this.cboNhanVienXepCa.Size = new System.Drawing.Size(300, 33);
            this.cboNhanVienXepCa.SelectedIndexChanged += new System.EventHandler(this.FilterLichLam_Changed); // Gắn sự kiện

            this.lblChonTuan.AutoSize = true;
            this.lblChonTuan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChonTuan.Location = new System.Drawing.Point(440, 20);
            this.lblChonTuan.Text = "Tuần làm việc:";

            this.dtpTuan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpTuan.Location = new System.Drawing.Point(570, 17);
            this.dtpTuan.Size = new System.Drawing.Size(350, 32);
            this.dtpTuan.ValueChanged += new System.EventHandler(this.FilterLichLam_Changed); // Gắn sự kiện

            // GridView Ma Trận Lịch
            this.dgvLichLam.AllowUserToAddRows = false;
            this.dgvLichLam.AllowUserToResizeColumns = false;
            this.dgvLichLam.AllowUserToResizeRows = false;
            this.dgvLichLam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichLam.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLichLam.ColumnHeadersHeight = 50;
            this.dgvLichLam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichLam.Location = new System.Drawing.Point(20, 90);
            this.dgvLichLam.Name = "dgvLichLam";
            this.dgvLichLam.ReadOnly = true;
            this.dgvLichLam.RowHeadersVisible = false;
            this.dgvLichLam.RowTemplate.Height = 100;
            this.dgvLichLam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLichLam.Size = new System.Drawing.Size(1160, 550);
            this.dgvLichLam.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLichLam.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.dgvLichLam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLichLam_CellClick); // Gắn sự kiện

            // Panel Bottom
            this.pnlXepCa_Bottom.Controls.Add(this.lblTongLuong);
            this.pnlXepCa_Bottom.Controls.Add(this.btnLuuLich);
            this.pnlXepCa_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlXepCa_Bottom.Location = new System.Drawing.Point(20, 640);
            this.pnlXepCa_Bottom.Name = "pnlXepCa_Bottom";
            this.pnlXepCa_Bottom.Size = new System.Drawing.Size(1160, 70);

            this.lblTongLuong.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTongLuong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongLuong.ForeColor = System.Drawing.Color.FromArgb(229, 124, 35); // Cam nổi bật
            this.lblTongLuong.Location = new System.Drawing.Point(0, 0);
            this.lblTongLuong.Size = new System.Drawing.Size(600, 70);
            this.lblTongLuong.Text = "Dự toán chi phí tuần: 0 VNĐ";
            this.lblTongLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnLuuLich.BackColor = System.Drawing.Color.FromArgb(45, 64, 89);
            this.btnLuuLich.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLuuLich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuLich.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnLuuLich.ForeColor = System.Drawing.Color.White;
            this.btnLuuLich.Location = new System.Drawing.Point(860, 0);
            this.btnLuuLich.Size = new System.Drawing.Size(300, 70);
            this.btnLuuLich.Text = "💾 LƯU LỊCH LÀM VIỆC";
            this.btnLuuLich.Click += new System.EventHandler(this.BtnLuuLich_Click); // Gắn sự kiện

            // 
            // UC_QL_NhanVienCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlHoSo);
            this.Controls.Add(this.pnlXepCa);
            this.Controls.Add(this.pnlTopNav);
            this.Name = "UC_QL_NhanVienCaLam";
            this.Size = new System.Drawing.Size(1200, 800);
            this.Load += new System.EventHandler(this.UC_Load); // Gắn sự kiện Load

            this.pnlTopNav.ResumeLayout(false);
            this.pnlHoSo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.pnlXepCa.ResumeLayout(false);
            this.pnlXepCa_Top.ResumeLayout(false);
            this.pnlXepCa_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichLam)).EndInit();
            this.pnlXepCa_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTopNav;
        private System.Windows.Forms.Button btnTabHoSo;
        private System.Windows.Forms.Button btnTabXepCa;
        private System.Windows.Forms.Panel pnlHoSo;
        private System.Windows.Forms.Panel pnlXepCa;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Panel pnlXepCa_Top;
        private System.Windows.Forms.Label lblChonNV;
        private System.Windows.Forms.ComboBox cboNhanVienXepCa;
        private System.Windows.Forms.Label lblChonTuan;
        private System.Windows.Forms.DateTimePicker dtpTuan;
        private System.Windows.Forms.DataGridView dgvLichLam;
        private System.Windows.Forms.Panel pnlXepCa_Bottom;
        private System.Windows.Forms.Label lblTongLuong;
        private System.Windows.Forms.Button btnLuuLich;
    }
}