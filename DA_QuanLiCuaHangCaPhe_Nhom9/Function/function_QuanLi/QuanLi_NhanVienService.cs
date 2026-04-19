using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic; // Nhúng CoreLogic vào đây
using DA_QuanLiCuaHangCaPhe_Nhom9.Models;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_QuanLi
{
    public class QuanLi_NhanVienService
    {
        // Khởi tạo sức mạnh từ lõi
        private readonly CoreLogic_NhanVien _coreNhanVien = new CoreLogic_NhanVien();

        // Các hàm giao tiếp với UI Quản lý (Chỉ bọc lại các hàm từ Core, không có hàm Xóa)
        public string LayMaNhanVienMoi() => _coreNhanVien.SinhMaNhanVienTuDong();

        public dynamic LayDanhSachHienThi() => _coreNhanVien.LayDanhSachNhanVienDayDu();

        public bool TaoMoiNhanSu(NhanVien nv) => _coreNhanVien.ThemNhanVien(nv);

        public bool CapNhatHoSo(NhanVien nv) => _coreNhanVien.CapNhatNhanVien(nv);
    }
}