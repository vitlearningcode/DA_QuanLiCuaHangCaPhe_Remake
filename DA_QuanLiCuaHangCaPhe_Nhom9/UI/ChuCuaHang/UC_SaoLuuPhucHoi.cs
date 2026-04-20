using DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.UI.ChuCuaHang
{
    public partial class UC_SaoLuuPhucHoi : UserControl
    {
        private readonly SaoLuuPhucHoiService _service = new SaoLuuPhucHoiService();

        public UC_SaoLuuPhucHoi()
        {
            InitializeComponent();
        }

        // ===================== SAO LƯU =====================

        private async void btnChonThuMucSaoLuu_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Chọn thư mục lưu file sao lưu";
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.OK)
                    txtDuongDanSaoLuu.Text = fbd.SelectedPath;
            }
        }

        private async void btnSaoLuu_Click(object sender, EventArgs e)
        {
            string thuMuc = txtDuongDanSaoLuu.Text.Trim();
            if (string.IsNullOrEmpty(thuMuc))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu file sao lưu!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(thuMuc))
            {
                MessageBox.Show("Thư mục không tồn tại! Vui lòng chọn lại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn sao lưu dữ liệu?\n\nFile sao lưu sẽ được lưu vào:\n" + thuMuc,
                "Xác nhận Sao Lưu",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            SetLoadingState(true, isSaoLuu: true);

            string tenFileDaDat = "";
            string loiNhan = "";

            await Task.Run(() =>
            {
                try
                {
                    _service.SaoLuuDuLieu(thuMuc, out tenFileDaDat);
                }
                catch (Exception ex)
                {
                    loiNhan = ex.Message;
                }
            });

            SetLoadingState(false, isSaoLuu: true);

            if (string.IsNullOrEmpty(loiNhan))
            {
                AppendLog($"✅ Sao lưu thành công lúc {DateTime.Now:HH:mm:ss dd/MM/yyyy}");
                AppendLog($"   → File: {tenFileDaDat}");
                MessageBox.Show(
                    $"Sao lưu thành công!\n\nFile đã được lưu tại:\n{tenFileDaDat}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AppendLog($"❌ Sao lưu thất bại: {loiNhan}");
                MessageBox.Show($"Sao lưu thất bại!\n\n{loiNhan}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== PHỤC HỒI =====================

        private void btnChonFilePhucHoi_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file sao lưu (.bak)";
                ofd.Filter = "SQL Server Backup (*.bak)|*.bak|Tất cả file (*.*)|*.*";
                ofd.FilterIndex = 1;
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtDuongDanPhucHoi.Text = ofd.FileName;
            }
        }

        private async void btnPhucHoi_Click(object sender, EventArgs e)
        {
            string duongDanFile = txtDuongDanPhucHoi.Text.Trim();
            if (string.IsNullOrEmpty(duongDanFile))
            {
                MessageBox.Show("Vui lòng chọn file sao lưu (.bak) cần phục hồi!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(duongDanFile))
            {
                MessageBox.Show("File sao lưu không tồn tại! Vui lòng kiểm tra lại đường dẫn.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                "⚠️  CẢNH BÁO: Phục hồi sẽ GHI ĐÈ TOÀN BỘ dữ liệu hiện tại!\n\n" +
                "Mọi thay đổi từ lần sao lưu gần nhất đến giờ sẽ BỊ MẤT.\n\n" +
                "Bạn có chắc chắn muốn tiếp tục?",
                "XÁC NHẬN PHỤC HỒI",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var confirm2 = MessageBox.Show(
                "Xác nhận lần cuối: Bắt đầu phục hồi từ file?\n\n" + duongDanFile,
                "Xác nhận lần 2",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (confirm2 != DialogResult.Yes) return;

            SetLoadingState(true, isSaoLuu: false);

            string loiNhan = "";

            await Task.Run(() =>
            {
                try
                {
                    _service.PhucHoiDuLieu(duongDanFile);
                }
                catch (Exception ex)
                {
                    loiNhan = ex.Message;
                }
            });

            SetLoadingState(false, isSaoLuu: false);

            if (string.IsNullOrEmpty(loiNhan))
            {
                AppendLog($"✅ Phục hồi thành công lúc {DateTime.Now:HH:mm:ss dd/MM/yyyy}");
                AppendLog($"   → Từ file: {duongDanFile}");
                MessageBox.Show(
                    "Phục hồi dữ liệu thành công!\n\nVui lòng khởi động lại ứng dụng để áp dụng.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AppendLog($"❌ Phục hồi thất bại: {loiNhan}");
                MessageBox.Show($"Phục hồi thất bại!\n\n{loiNhan}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== TIỆN ÍCH =====================

        private void btnXoaLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        private void AppendLog(string message)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => AppendLog(message)));
                return;
            }
            rtbLog.AppendText(message + Environment.NewLine);
            rtbLog.ScrollToCaret();
        }

        private void SetLoadingState(bool dangXuLy, bool isSaoLuu)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetLoadingState(dangXuLy, isSaoLuu)));
                return;
            }

            if (isSaoLuu)
            {
                btnSaoLuu.Enabled = !dangXuLy;
                btnChonThuMucSaoLuu.Enabled = !dangXuLy;
                btnSaoLuu.Text = dangXuLy ? "⏳ Đang sao lưu..." : "💾  Bắt Đầu Sao Lưu";
            }
            else
            {
                btnPhucHoi.Enabled = !dangXuLy;
                btnChonFilePhucHoi.Enabled = !dangXuLy;
                btnPhucHoi.Text = dangXuLy ? "⏳ Đang phục hồi..." : "🔄  Bắt Đầu Phục Hồi";
            }

            if (dangXuLy)
                AppendLog($"⏳ {(isSaoLuu ? "Đang sao lưu" : "Đang phục hồi")} dữ liệu, vui lòng chờ...");
        }
    }
}
