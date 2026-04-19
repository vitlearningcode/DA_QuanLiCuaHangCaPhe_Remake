namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.QuanLi
{
    partial class UC_QL_SanPham
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
            pnlTopNav = new Panel();
            pnlBoLoc = new Panel();
            cboLocLoai = new ComboBox();
            lblLoc = new Label();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            lblTitle = new Label();
            tlpMain = new TableLayoutPanel();
            dgvSanPham = new DataGridView();
            gbThaoTac = new GroupBox();
            btnDoiTrangThai = new Button();
            txtGiaBan = new TextBox();
            lblGiaBan = new Label();
            txtLoai = new TextBox();
            lblLoai = new Label();
            txtTenSP = new TextBox();
            lblTenSP = new Label();
            pnlTopNav.SuspendLayout();
            pnlBoLoc.SuspendLayout();
            tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            gbThaoTac.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopNav
            // 
            pnlTopNav.BackColor = Color.FromArgb(240, 242, 245);
            pnlTopNav.Controls.Add(pnlBoLoc);
            pnlTopNav.Controls.Add(lblTitle);
            pnlTopNav.Dock = DockStyle.Top;
            pnlTopNav.Location = new Point(0, 0);
            pnlTopNav.Margin = new Padding(6);
            pnlTopNav.Name = "pnlTopNav";
            pnlTopNav.Padding = new Padding(42, 31, 42, 31);
            pnlTopNav.Size = new Size(2550, 144);
            pnlTopNav.TabIndex = 0;
            // 
            // pnlBoLoc
            // 
            pnlBoLoc.Controls.Add(cboLocLoai);
            pnlBoLoc.Controls.Add(lblLoc);
            pnlBoLoc.Controls.Add(txtTimKiem);
            pnlBoLoc.Controls.Add(lblTimKiem);
            pnlBoLoc.Dock = DockStyle.Right;
            pnlBoLoc.Location = new Point(850, 31);
            pnlBoLoc.Margin = new Padding(6);
            pnlBoLoc.Name = "pnlBoLoc";
            pnlBoLoc.Size = new Size(1658, 82);
            pnlBoLoc.TabIndex = 1;
            // 
            // cboLocLoai
            // 
            cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoai.Font = new Font("Segoe UI", 11F);
            cboLocLoai.FormattingEnabled = true;
            cboLocLoai.Location = new Point(1148, 4);
            cboLocLoai.Margin = new Padding(6);
            cboLocLoai.Name = "cboLocLoai";
            cboLocLoai.Size = new Size(506, 58);
            cboLocLoai.TabIndex = 3;
            // 
            // lblLoc
            // 
            lblLoc.AutoSize = true;
            lblLoc.Font = new Font("Segoe UI", 11F);
            lblLoc.Location = new Point(935, 10);
            lblLoc.Margin = new Padding(6, 0, 6, 0);
            lblLoc.Name = "lblLoc";
            lblLoc.Size = new Size(192, 50);
            lblLoc.TabIndex = 2;
            lblLoc.Text = "Lọc nhóm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 11F);
            txtTimKiem.Location = new Point(212, 4);
            txtTimKiem.Margin = new Padding(6);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(676, 56);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 11F);
            lblTimKiem.Location = new Point(0, 10);
            lblTimKiem.Margin = new Padding(6, 0, 6, 0);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(176, 50);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm món:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 64, 89);
            lblTitle.Location = new Point(42, 31);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(554, 72);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "☕ MENU ĐỒ UỐNG";
            // 
            // tlpMain
            // 
            tlpMain.BackColor = Color.White;
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpMain.Controls.Add(dgvSanPham, 0, 0);
            tlpMain.Controls.Add(gbThaoTac, 1, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 144);
            tlpMain.Margin = new Padding(6);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(42, 41, 42, 41);
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(2550, 1496);
            tlpMain.TabIndex = 1;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSanPham.BackgroundColor = Color.WhiteSmoke;
            dgvSanPham.ColumnHeadersHeight = 50;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.Location = new Point(48, 47);
            dgvSanPham.Margin = new Padding(6);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(1714, 1402);
            dgvSanPham.TabIndex = 0;
            // 
            // gbThaoTac
            // 
            gbThaoTac.BackColor = Color.White;
            gbThaoTac.Controls.Add(btnDoiTrangThai);
            gbThaoTac.Controls.Add(txtGiaBan);
            gbThaoTac.Controls.Add(lblGiaBan);
            gbThaoTac.Controls.Add(txtLoai);
            gbThaoTac.Controls.Add(lblLoai);
            gbThaoTac.Controls.Add(txtTenSP);
            gbThaoTac.Controls.Add(lblTenSP);
            gbThaoTac.Dock = DockStyle.Fill;
            gbThaoTac.Font = new Font("Segoe UI", 11F);
            gbThaoTac.ForeColor = Color.FromArgb(45, 64, 89);
            gbThaoTac.Location = new Point(1789, 41);
            gbThaoTac.Margin = new Padding(21, 0, 0, 0);
            gbThaoTac.Name = "gbThaoTac";
            gbThaoTac.Padding = new Padding(6);
            gbThaoTac.Size = new Size(719, 1414);
            gbThaoTac.TabIndex = 1;
            gbThaoTac.TabStop = false;
            gbThaoTac.Text = "CHI TIẾT MÓN";
            // 
            // btnDoiTrangThai
            // 
            btnDoiTrangThai.BackColor = Color.Gray;
            btnDoiTrangThai.FlatStyle = FlatStyle.Flat;
            btnDoiTrangThai.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDoiTrangThai.ForeColor = Color.White;
            btnDoiTrangThai.Location = new Point(42, 636);
            btnDoiTrangThai.Margin = new Padding(6);
            btnDoiTrangThai.Name = "btnDoiTrangThai";
            btnDoiTrangThai.Size = new Size(616, 123);
            btnDoiTrangThai.TabIndex = 8;
            btnDoiTrangThai.Text = "CHỌN MÓN ĐỂ THAO TÁC";
            btnDoiTrangThai.UseVisualStyleBackColor = false;
            // 
            // txtGiaBan
            // 
            txtGiaBan.BackColor = Color.WhiteSmoke;
            txtGiaBan.Location = new Point(42, 492);
            txtGiaBan.Margin = new Padding(6);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.ReadOnly = true;
            txtGiaBan.Size = new Size(612, 56);
            txtGiaBan.TabIndex = 7;
            // 
            // lblGiaBan
            // 
            lblGiaBan.AutoSize = true;
            lblGiaBan.ForeColor = Color.Black;
            lblGiaBan.Location = new Point(42, 430);
            lblGiaBan.Margin = new Padding(6, 0, 6, 0);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(263, 50);
            lblGiaBan.TabIndex = 6;
            lblGiaBan.Text = "Giá Bán (VNĐ):";
            // 
            // txtLoai
            // 
            txtLoai.BackColor = Color.WhiteSmoke;
            txtLoai.Location = new Point(42, 328);
            txtLoai.Margin = new Padding(6);
            txtLoai.Name = "txtLoai";
            txtLoai.ReadOnly = true;
            txtLoai.Size = new Size(612, 56);
            txtLoai.TabIndex = 5;
            // 
            // lblLoai
            // 
            lblLoai.AutoSize = true;
            lblLoai.ForeColor = Color.Black;
            lblLoai.Location = new Point(42, 266);
            lblLoai.Margin = new Padding(6, 0, 6, 0);
            lblLoai.Name = "lblLoai";
            lblLoai.Size = new Size(315, 50);
            lblLoai.TabIndex = 4;
            lblLoai.Text = "Nhóm/Danh Mục:";
            // 
            // txtTenSP
            // 
            txtTenSP.BackColor = Color.WhiteSmoke;
            txtTenSP.Location = new Point(42, 164);
            txtTenSP.Margin = new Padding(6);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.ReadOnly = true;
            txtTenSP.Size = new Size(612, 56);
            txtTenSP.TabIndex = 3;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.ForeColor = Color.Black;
            lblTenSP.Location = new Point(42, 102);
            lblTenSP.Margin = new Padding(6, 0, 6, 0);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(171, 50);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "Tên Món:";
            // 
            // UC_QL_SanPham
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tlpMain);
            Controls.Add(pnlTopNav);
            Margin = new Padding(6);
            Name = "UC_QL_SanPham";
            Size = new Size(2550, 1640);
            pnlTopNav.ResumeLayout(false);
            pnlTopNav.PerformLayout();
            pnlBoLoc.ResumeLayout(false);
            pnlBoLoc.PerformLayout();
            tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            gbThaoTac.ResumeLayout(false);
            gbThaoTac.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopNav;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Button btnDoiTrangThai;

        // Các control mới thêm
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}