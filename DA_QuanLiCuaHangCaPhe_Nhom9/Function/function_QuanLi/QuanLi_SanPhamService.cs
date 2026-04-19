using System.Collections.Generic;
using System.Linq;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi
{
    // Class (View) đặt ở phân hệ nào thì phục vụ riêng cho UI phân hệ đó
    public class SanPhamView
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public decimal DonGia { get; set; }
        public string TrangThai { get; set; }
    }

    public class QuanLi_SanPhamService
    {
        private readonly CoreLogic_SanPham _coreSP = new CoreLogic_SanPham();

        // Kéo data từ Core lên, dùng LINQ Select chiếu sang Class View
        public List<SanPhamView> LayDanhSachMenu()
        {
            var dataCore = _coreSP.LayTatCaSanPham();

            return dataCore.Select(sp => new SanPhamView
            {
                MaSP = sp.MaSp,
                TenSP = sp.TenSp,
                LoaiSP = string.IsNullOrEmpty(sp.LoaiSp) ? "Khác" : sp.LoaiSp,
                DonGia = sp.DonGia,
                TrangThai = string.IsNullOrEmpty(sp.TrangThai) ? "Còn bán" : sp.TrangThai
            }).OrderBy(x => x.LoaiSP).ThenBy(x => x.TenSP).ToList();
        }

        // Nghiệp vụ riêng của Quản lý: Chỉ Báo hết hoặc Mở bán lại (Khớp DB)
        public bool BaoNgungBan(int maSP) => _coreSP.CapNhatTrangThai(maSP, "Ngừng bán");

        public bool MoBanLai(int maSP) => _coreSP.CapNhatTrangThai(maSP, "Còn bán");
    }
}