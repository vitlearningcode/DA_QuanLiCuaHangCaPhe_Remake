using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic;
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System.Collections.Generic;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi
{
    public class QuanLi_KhoService
    {
        // Thêm dòng này vào class QuanLi_KhoService
        public decimal LayGiaNhapGanNhat(int maNL) => _coreKho.LayGiaNhapGanNhat(maNL);

        private readonly CoreLogic_Kho _coreKho = new CoreLogic_Kho();

        public List<NguyenLieu> LayTatCaNguyenLieu() => _coreKho.LayDanhSachNguyenLieu();

        public bool LuuThongTinNguyenLieu(NguyenLieu nl) => _coreKho.LuuNguyenLieu(nl);

        public bool NgungSuDungNguyenLieu(int maNL) => _coreKho.DoiTrangThaiNguyenLieu(maNL, "Ngừng kinh doanh");

        public bool MoLaiNguyenLieu(int maNL) => _coreKho.DoiTrangThaiNguyenLieu(maNL, "Đang kinh doanh");

        public List<PhieuKhoView> XemLichSuPhieu() => _coreKho.LayLichSuPhieuKho();

        public List<ChiTietPhieuView> XemChiTietPhieu(int maPhieu) => _coreKho.LayChiTietCuaPhieu(maPhieu);

        public bool ChotPhieuKho(string maNV, string loaiPhieu, List<ChiTietPhieuView> danhSachTam)
            => _coreKho.TaoPhieuKhoTransaction(maNV, loaiPhieu, danhSachTam);
    }
}