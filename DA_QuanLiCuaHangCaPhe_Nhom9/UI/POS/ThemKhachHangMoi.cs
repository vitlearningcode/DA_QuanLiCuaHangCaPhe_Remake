using System;
using System.Windows.Forms;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Main;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.POS
{
    public partial class ThemKhachHangMoi : Form
    {
        #region Khai báo service & biến

        // Service POS: thêm khách hàng mới vào DB
        private readonly KhoTruyVanMainForm _khoTruyVan;

        // SĐT được truyền từ MainForm (điền sẵn, không chỉnh sửa được)
        private readonly string _soDienThoai;

        #endregion

        #region Khởi tạo & Load

        // Nhận SĐT từ MainForm khi mở form này
        public ThemKhachHangMoi(string sdt)
        {
            InitializeComponent();
            _soDienThoai = sdt;
            _khoTruyVan  = new KhoTruyVanMainForm();
        }

        // Load: điền sẵn SĐT, khóa ô SĐT, nạp danh sách loại KH
        private void ThemKhachHangMoi_Load(object sender, EventArgs e)
        {
            txtSDT.Text    = _soDienThoai;
            txtSDT.Enabled = false; // Không cho sửa SĐT vì đã nhập từ màn hình trước

            if (cbLoaiKH != null)
            {
                cbLoaiKH.Items.Clear();
                cbLoaiKH.Items.Add("Thuong"); // Lưu vào DB không dấu
                cbLoaiKH.Items.Add("VIP");
                cbLoaiKH.SelectedIndex = 0;   // Mặc định: Thường
            }
        }

        #endregion

        #region Sự kiện — Lưu / Hủy

        // HỦY: Đóng form không làm gì
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // LƯU: Validate → tạo object KhachHang → gọi service → đóng OK nếu thành công
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                KhachHang kh = new KhachHang
                {
                    TenKh       = txtTenKH.Text.Trim(),
                    SoDienThoai = txtSDT.Text,
                    DiaChi      = txtDiaChi.Text.Trim(),
                    LoaiKh      = cbLoaiKH.SelectedItem.ToString()
                };

                if (_khoTruyVan.ThemKhachHangMoi(kh))
                {
                    MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show("Lỗi khi lưu khách hàng. Vui lòng thử lại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu khách hàng: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        #endregion
    }
}