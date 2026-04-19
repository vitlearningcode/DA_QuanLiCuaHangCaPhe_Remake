using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic
{
    public class CoreLogic_SanPham
    {
        // Core: Lấy toàn bộ dữ liệu gốc nguyên bản, KHÔNG join, KHÔNG chế data
        public List<SanPham> LayTatCaSanPham()
        {
            using (var db = new DataSqlContext())
            {
                return db.SanPhams.ToList();
            }
        }

        // Core: Chỉ nhận lệnh cập nhật trạng thái chung chung
        public bool CapNhatTrangThai(int maSP, string trangThaiMoi)
        {
            using (var db = new DataSqlContext())
            {
                var sp = db.SanPhams.Find(maSP);
                if (sp != null)
                {
                    sp.TrangThai = trangThaiMoi;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}