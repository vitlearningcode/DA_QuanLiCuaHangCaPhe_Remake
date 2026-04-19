using System.Collections.Generic;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi
{
    public class QuanLi_BaoCaoService
    {
        private readonly CoreLogic_BaoCao _coreBaoCao = new CoreLogic_BaoCao();

        public (decimal DoanhThu, int SoDon) ThongKeNhanhHomNay() => _coreBaoCao.ThongKeHomNay();
        public List<TopSanPhamView> LayTop5MonBanChay() => _coreBaoCao.LayTopSanPhamBanChay(5);
        public List<NguyenLieu> LayKhoBaoDong() => _coreBaoCao.LayNguyenLieuBaoDong();
        public List<DoanhThuNgayView> LayBieuDo7Ngay() => _coreBaoCao.LayDoanhThu7Ngay();
    }
}