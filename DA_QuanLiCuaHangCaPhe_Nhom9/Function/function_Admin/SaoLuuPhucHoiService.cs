using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    /// <summary>
    /// Service xử lý Sao Lưu và Phục Hồi database.
    ///
    /// Vấn đề gốc rễ:
    ///   SQL Server service chạy dưới account riêng (NT SERVICE\MSSQL$SQLEXPRESS).
    ///   Account này không có quyền ghi vào Desktop/Documents của user — nên BACKUP bị "Access denied".
    ///   Ngược lại, thư mục backup của SQL Server (C:\Program Files\...\Backup\)
    ///   bị khóa ACL — app C# của user không đọc được file trong đó.
    ///
    /// Giải pháp:
    ///   Sao Lưu  — Cấp quyền ghi tạm cho SQL Server service vào thư mục user chọn
    ///              → BACKUP thẳng vào đó → thu hồi quyền.
    ///   Phục Hồi — Cấp quyền đọc tạm cho SQL Server service vào thư mục chứa file .bak
    ///              → RESTORE từ đó → thu hồi quyền.
    ///   Cả hai thao tác đều KHÔNG cần thư mục trung gian, KHÔNG cần copy file.
    /// </summary>
    public class SaoLuuPhucHoiService
    {
        private const string DB_NAME = "DA_QuanLiBanCaPhe";

        // ==================== CONNECTION ====================

        private static string LayConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            return config.GetConnectionString("MyDatabase");
        }

        private static SqlConnection MoKetNoi(string databaseName = "master")
        {
            string connStr = LayConnectionString();
            var b = new SqlConnectionStringBuilder(connStr) { InitialCatalog = databaseName };
            var conn = new SqlConnection(b.ConnectionString);
            conn.Open();
            return conn;
        }

        // ==================== SAO LƯU ====================

        /// <summary>
        /// Sao lưu DB vào thư mục user chọn.
        /// Tên file tự động: QLCH(DD_MM_YYYY_HH_mm).bak
        /// </summary>
        public void SaoLuuDuLieu(string thuMucLuu, out string tenFileDaDat)
        {
            var    now      = DateTime.Now;
            string tenFile  = $"QLCH({now.Day}_{now.Month}_{now.Year}_{now.Hour}_{now.Minute}).bak";
            tenFileDaDat    = Path.Combine(thuMucLuu, tenFile);

            // 1. Tìm account SQL Server service để cấp quyền
            string sqlAccount = LayServiceAccountSqlServer();

            // 2. Cấp quyền ghi tạm cho SQL Server vào thư mục user đã chọn
            //    (User LeMinhDuc có Full Control trên Desktop/Documents → được phép sửa ACL)
            CapQuyenThuMuc(thuMucLuu, sqlAccount, FileSystemRights.FullControl, thoHoiQuyenCu: false);

            try
            {
                // 3. BACKUP thẳng vào thư mục user (SQL Server giờ đã có quyền ghi)
                string sql = $"BACKUP DATABASE [{DB_NAME}] TO DISK = N'{tenFileDaDat}' " +
                             $"WITH FORMAT, INIT, NAME = N'Backup cua hang ca phe';";
                ThucThiLenhSql(sql, "master");

                if (!File.Exists(tenFileDaDat))
                    throw new Exception(
                        $"SQL Server không ghi file ra:\n{tenFileDaDat}\n\n" +
                        $"Thư mục đã được cấp quyền cho account: {sqlAccount}");
            }
            finally
            {
                // 4. Thu hồi quyền SQL Server — dù thành công hay thất bại
                try { ThuHoiQuyenThuMuc(thuMucLuu, sqlAccount); } catch { }
            }
        }

        // ==================== PHỤC HỒI ====================

        /// <summary>
        /// Phục hồi DB từ file .bak user chọn.
        /// CẢNH BÁO: Ghi đè TOÀN BỘ dữ liệu hiện tại!
        /// </summary>
        public void PhucHoiDuLieu(string duongDanFile)
        {
            string sqlAccount = LayServiceAccountSqlServer();
            string thuMucChua = Path.GetDirectoryName(duongDanFile);

            // 1. Cấp quyền đọc tạm cho SQL Server vào thư mục chứa file .bak
            CapQuyenThuMuc(thuMucChua, sqlAccount, FileSystemRights.Read | FileSystemRights.ReadAndExecute, thoHoiQuyenCu: false);

            try
            {
                // 2. RESTORE — chạy từng lệnh riêng (không batch ALTER + RESTORE)
                ThucThiLenhSql(
                    $"USE master; ALTER DATABASE [{DB_NAME}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;",
                    "master");

                ThucThiLenhSql(
                    $"RESTORE DATABASE [{DB_NAME}] FROM DISK = N'{duongDanFile}' WITH REPLACE, RECOVERY;",
                    "master");

                ThucThiLenhSql(
                    $"USE master; ALTER DATABASE [{DB_NAME}] SET MULTI_USER;",
                    "master");
            }
            finally
            {
                // 3. Thu hồi quyền SQL Server
                try { ThuHoiQuyenThuMuc(thuMucChua, sqlAccount); } catch { }
            }
        }

        // ==================== PRIVATE HELPERS ====================

        /// <summary>
        /// Lấy tên account của SQL Server service từ sys.dm_server_services.
        /// Fallback về "NT SERVICE\MSSQL$SQLEXPRESS" nếu không query được.
        /// </summary>
        private string LayServiceAccountSqlServer()
        {
            try
            {
                using (var conn = MoKetNoi("master"))
                using (var cmd  = new SqlCommand(
                    @"SELECT TOP 1 service_account 
                      FROM   sys.dm_server_services 
                      WHERE  servicename NOT LIKE N'%Agent%'
                        AND  servicename LIKE N'SQL Server%'",
                    conn) { CommandTimeout = 10 })
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string acc = result.ToString().Trim();
                        if (!string.IsNullOrEmpty(acc)) return acc;
                    }
                }
            }
            catch { /* Fallback */ }

            // Default cho SQL Server Express named instance
            return @"NT SERVICE\MSSQL$SQLEXPRESS";
        }

        /// <summary>
        /// Cấp quyền truy cập cho account lên một thư mục.
        /// App user thường có Full Control trên Desktop/Documents nên có thể sửa ACL.
        /// </summary>
        private void CapQuyenThuMuc(string thuMuc, string account,
                                     FileSystemRights rights, bool thoHoiQuyenCu)
        {
            var dirInfo = new DirectoryInfo(thuMuc);
            var security = dirInfo.GetAccessControl(AccessControlSections.Access);

            var rule = new FileSystemAccessRule(
                account,
                rights,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow);

            if (thoHoiQuyenCu)
                security.ResetAccessRule(rule);
            else
                security.AddAccessRule(rule);

            dirInfo.SetAccessControl(security);
        }

        /// <summary>
        /// Thu hồi TẤT CẢ quyền của account trên thư mục (dọn dẹp sau backup/restore).
        /// </summary>
        private void ThuHoiQuyenThuMuc(string thuMuc, string account)
        {
            var dirInfo  = new DirectoryInfo(thuMuc);
            var security = dirInfo.GetAccessControl(AccessControlSections.Access);

            // Xóa tất cả rule của account này, bất kể rights gì
            var rules = security.GetAccessRules(true, false, typeof(NTAccount));
            foreach (FileSystemAccessRule rule in rules)
            {
                if (string.Equals(rule.IdentityReference.Value, account,
                                   StringComparison.OrdinalIgnoreCase))
                {
                    security.RemoveAccessRule(rule);
                }
            }

            dirInfo.SetAccessControl(security);
        }

        /// <summary>
        /// Thực thi câu lệnh SQL không trả dữ liệu. Ném exception có message rõ ràng nếu lỗi.
        /// </summary>
        private void ThucThiLenhSql(string sql, string databaseName = "master")
        {
            try
            {
                using (var conn = MoKetNoi(databaseName))
                using (var cmd  = new SqlCommand(sql, conn) { CommandTimeout = 600 })
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi SQL:{Environment.NewLine}{ex.Message}", ex);
            }
        }
    }
}
