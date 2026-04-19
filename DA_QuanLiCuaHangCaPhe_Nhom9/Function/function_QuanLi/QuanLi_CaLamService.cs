using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic; // Nhúng CoreLogic vào đây
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Collections.Generic;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi
{
    public class QuanLi_CaLamService
    {
        private readonly CoreLogic_CaLam _coreCaLam = new CoreLogic_CaLam();

        public List<NhanVien> LayDanhSachNhanVienDeXepCa() => _coreCaLam.LayNhanVienXepCa();

        public List<LichLamViec> KiemTraLichCu(string maNV, DateTime ngayDauTuan)
            => _coreCaLam.LayLichLamViecTheoTuan(maNV, ngayDauTuan);

        public bool ChotLichLamViec(string maNV, DateTime ngayDau, List<int> ca, List<DateTime> ngay)
            => _coreCaLam.LuuLichLamViec(maNV, ngayDau, ca, ngay);


        public List<CaLamViec> LayDanhSachCaLamThucTe() => _coreCaLam.LayDanhSachCaLam();
    }
}