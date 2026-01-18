using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class SanPhamService
    {
        // Hàm lấy danh sách món để tạo Button
        public List<SanPham> LayDanhSachMonAn()
        {
            using (var db = new DataSqlContext())
            {
                return db.SanPhams.Where(s => s.TrangThai == "Còn bán").ToList();
            }
        }

        //Lấy danh sách nguyên liệu để nạp vào ComboBox chọn
        public List<NguyenLieu> LayDanhSachNguyenLieu()
        {
            using (var db = new DataSqlContext())
            {
                return db.NguyenLieus.Where(nl => nl.TrangThai == "Đang kinh doanh").ToList();
            }
        }

        // Hàm lấy chi tiết công thức của 1 món
        public List<CongThucHienThi> LayCongThucMon(int maSp)
        {
            using (var db = new DataSqlContext())
            {
                var list = from dl in db.DinhLuongs
                           join nl in db.NguyenLieus on dl.MaNl equals nl.MaNl
                           where dl.MaSp == maSp
                           select new CongThucHienThi
                           {
                               MaNL = nl.MaNl,
                               TenNL = nl.TenNl,
                               SoLuong = dl.SoLuongCan,
                               DonViTinh = nl.DonViTinh
                           };
                return list.ToList();
            }
        }
    }

    // Class DTO để hiển thị công thức
    public class CongThucHienThi
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public decimal SoLuong { get; set; }
        public string DonViTinh { get; set; }
    }
}