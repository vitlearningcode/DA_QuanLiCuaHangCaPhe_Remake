namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    partial class UC_TongQuan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pnlTop = new Panel();
            btnLoc = new Button();
            dtpDenNgay = new DateTimePicker();
            label2 = new Label();
            dtpTuNgay = new DateTimePicker();
            label1 = new Label();
            flpCards = new FlowLayoutPanel();
            pnlDoanhSo = new Panel();
            lblDoanhSo = new Label();
            label3 = new Label();
            pnlGiamGia = new Panel();
            lblGiamGia = new Label();
            label5 = new Label();
            pnlThuThuan = new Panel();
            lblDoanhThuThuan = new Label();
            label7 = new Label();
            pnlTongChi = new Panel();
            lblTongChi = new Label();
            label9 = new Label();
            pnlLoiNhuan = new Panel();
            lblLoiNhuan = new Label();
            label11 = new Label();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pnlTop.SuspendLayout();
            flpCards.SuspendLayout();
            pnlDoanhSo.SuspendLayout();
            pnlGiamGia.SuspendLayout();
            pnlThuThuan.SuspendLayout();
            pnlTongChi.SuspendLayout();
            pnlLoiNhuan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(btnLoc);
            pnlTop.Controls.Add(dtpDenNgay);
            pnlTop.Controls.Add(label2);
            pnlTop.Controls.Add(dtpTuNgay);
            pnlTop.Controls.Add(label1);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(900, 60);
            pnlTop.TabIndex = 0;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.DodgerBlue;
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLoc.ForeColor = Color.White;
            btnLoc.Location = new Point(540, 15);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(120, 30);
            btnLoc.TabIndex = 4;
            btnLoc.Text = "LỌC DỮ LIỆU";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Font = new Font("Segoe UI", 10F);
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(360, 18);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(150, 25);
            dtpDenNgay.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(280, 20);
            label2.Name = "label2";
            label2.Size = new Size(76, 19);
            label2.TabIndex = 2;
            label2.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Font = new Font("Segoe UI", 10F);
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(100, 18);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(150, 25);
            dtpTuNgay.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(67, 19);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày:";
            // 
            // flpCards
            // 
            flpCards.AutoSize = true;
            flpCards.Controls.Add(pnlDoanhSo);
            flpCards.Controls.Add(pnlGiamGia);
            flpCards.Controls.Add(pnlThuThuan);
            flpCards.Controls.Add(pnlTongChi);
            flpCards.Controls.Add(pnlLoiNhuan);
            flpCards.Dock = DockStyle.Top;
            flpCards.Location = new Point(0, 60);
            flpCards.Name = "flpCards";
            flpCards.Padding = new Padding(10);
            flpCards.Size = new Size(900, 120);
            flpCards.TabIndex = 1;
            // 
            // pnlDoanhSo
            // 
            pnlDoanhSo.BackColor = Color.FromArgb(23, 162, 184);
            pnlDoanhSo.Controls.Add(lblDoanhSo);
            pnlDoanhSo.Controls.Add(label3);
            pnlDoanhSo.Location = new Point(15, 15);
            pnlDoanhSo.Margin = new Padding(5);
            pnlDoanhSo.Name = "pnlDoanhSo";
            pnlDoanhSo.Size = new Size(165, 90);
            pnlDoanhSo.TabIndex = 0;
            // 
            // lblDoanhSo
            // 
            lblDoanhSo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDoanhSo.ForeColor = Color.White;
            lblDoanhSo.Location = new Point(10, 40);
            lblDoanhSo.Name = "lblDoanhSo";
            lblDoanhSo.Size = new Size(145, 30);
            lblDoanhSo.TabIndex = 1;
            lblDoanhSo.Text = "0 đ";
            lblDoanhSo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(10, 10);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 0;
            label3.Text = "DOANH SỐ";
            // 
            // pnlGiamGia
            // 
            pnlGiamGia.BackColor = Color.FromArgb(255, 193, 7);
            pnlGiamGia.Controls.Add(lblGiamGia);
            pnlGiamGia.Controls.Add(label5);
            pnlGiamGia.Location = new Point(190, 15);
            pnlGiamGia.Margin = new Padding(5);
            pnlGiamGia.Name = "pnlGiamGia";
            pnlGiamGia.Size = new Size(165, 90);
            pnlGiamGia.TabIndex = 1;
            // 
            // lblGiamGia
            // 
            lblGiamGia.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblGiamGia.ForeColor = Color.White;
            lblGiamGia.Location = new Point(10, 40);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(145, 30);
            lblGiamGia.TabIndex = 1;
            lblGiamGia.Text = "0 đ";
            lblGiamGia.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 10);
            label5.Name = "label5";
            label5.Size = new Size(74, 19);
            label5.TabIndex = 0;
            label5.Text = "GIẢM GIÁ";
            // 
            // pnlThuThuan
            // 
            pnlThuThuan.BackColor = Color.FromArgb(40, 167, 69);
            pnlThuThuan.Controls.Add(lblDoanhThuThuan);
            pnlThuThuan.Controls.Add(label7);
            pnlThuThuan.Location = new Point(365, 15);
            pnlThuThuan.Margin = new Padding(5);
            pnlThuThuan.Name = "pnlThuThuan";
            pnlThuThuan.Size = new Size(165, 90);
            pnlThuThuan.TabIndex = 2;
            // 
            // lblDoanhThuThuan
            // 
            lblDoanhThuThuan.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDoanhThuThuan.ForeColor = Color.White;
            lblDoanhThuThuan.Location = new Point(10, 40);
            lblDoanhThuThuan.Name = "lblDoanhThuThuan";
            lblDoanhThuThuan.Size = new Size(145, 30);
            lblDoanhThuThuan.TabIndex = 1;
            lblDoanhThuThuan.Text = "0 đ";
            lblDoanhThuThuan.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(10, 10);
            label7.Name = "label7";
            label7.Size = new Size(149, 19);
            label7.TabIndex = 0;
            label7.Text = "DOANH THU THUẦN";
            // 
            // pnlTongChi
            // 
            pnlTongChi.BackColor = Color.FromArgb(220, 53, 69);
            pnlTongChi.Controls.Add(lblTongChi);
            pnlTongChi.Controls.Add(label9);
            pnlTongChi.Location = new Point(540, 15);
            pnlTongChi.Margin = new Padding(5);
            pnlTongChi.Name = "pnlTongChi";
            pnlTongChi.Size = new Size(165, 90);
            pnlTongChi.TabIndex = 3;
            // 
            // lblTongChi
            // 
            lblTongChi.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTongChi.ForeColor = Color.White;
            lblTongChi.Location = new Point(10, 40);
            lblTongChi.Name = "lblTongChi";
            lblTongChi.Size = new Size(145, 30);
            lblTongChi.TabIndex = 1;
            lblTongChi.Text = "0 đ";
            lblTongChi.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 10);
            label9.Name = "label9";
            label9.Size = new Size(77, 19);
            label9.TabIndex = 0;
            label9.Text = "TỔNG CHI";
            // 
            // pnlLoiNhuan
            // 
            pnlLoiNhuan.BackColor = Color.FromArgb(111, 66, 193);
            pnlLoiNhuan.Controls.Add(lblLoiNhuan);
            pnlLoiNhuan.Controls.Add(label11);
            pnlLoiNhuan.Location = new Point(715, 15);
            pnlLoiNhuan.Margin = new Padding(5);
            pnlLoiNhuan.Name = "pnlLoiNhuan";
            pnlLoiNhuan.Size = new Size(165, 90);
            pnlLoiNhuan.TabIndex = 4;
            // 
            // lblLoiNhuan
            // 
            lblLoiNhuan.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLoiNhuan.ForeColor = Color.White;
            lblLoiNhuan.Location = new Point(10, 40);
            lblLoiNhuan.Name = "lblLoiNhuan";
            lblLoiNhuan.Size = new Size(145, 30);
            lblLoiNhuan.TabIndex = 1;
            lblLoiNhuan.Text = "0 đ";
            lblLoiNhuan.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(10, 10);
            label11.Name = "label11";
            label11.Size = new Size(88, 19);
            label11.TabIndex = 0;
            label11.Text = "LỢI NHUẬN";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea1);
            chartDoanhThu.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend1);
            chartDoanhThu.Location = new Point(0, 180);
            chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartDoanhThu.Series.Add(series1);
            chartDoanhThu.Size = new Size(900, 420);
            chartDoanhThu.TabIndex = 2;
            chartDoanhThu.Text = "chart1";
            // 
            // UC_TongQuan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(chartDoanhThu);
            Controls.Add(flpCards);
            Controls.Add(pnlTop);
            Name = "UC_TongQuan";
            Size = new Size(900, 600);
            Load += UC_TongQuan_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            flpCards.ResumeLayout(false);
            pnlDoanhSo.ResumeLayout(false);
            pnlDoanhSo.PerformLayout();
            pnlGiamGia.ResumeLayout(false);
            pnlGiamGia.PerformLayout();
            pnlThuThuan.ResumeLayout(false);
            pnlThuThuan.PerformLayout();
            pnlTongChi.ResumeLayout(false);
            pnlTongChi.PerformLayout();
            pnlLoiNhuan.ResumeLayout(false);
            pnlLoiNhuan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private System.Windows.Forms.Panel pnlDoanhSo;
        private System.Windows.Forms.Label lblDoanhSo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlGiamGia;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlThuThuan;
        private System.Windows.Forms.Label lblDoanhThuThuan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlTongChi;
        private System.Windows.Forms.Label lblTongChi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlLoiNhuan;
        private System.Windows.Forms.Label lblLoiNhuan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}