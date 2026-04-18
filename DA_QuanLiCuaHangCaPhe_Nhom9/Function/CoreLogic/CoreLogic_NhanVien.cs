using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.SharedServices
{
    public class CoreLogic_NhanVien
    {
        // Hàm sinh mã nhân viên tự động: NV + Năm(2 số) + STT(3 số) -> Ví dụ: NV26001
        public string SinhMaNhanVienTuDong()
        {
            using (var db = new DataSqlContext())
            {
                // Lấy 2 số cuối của năm hiện tại (Ví dụ: 2026 -> "26")
                string namHienTai = DateTime.Now.ToString("yy");
                string tienTo = "NV" + namHienTai;

                // Tìm nhân viên có mã bắt đầu bằng "NV26", lấy mã lớn nhất
                var nhanVienCuoiCung = db.NhanViens
                                         .Where(nv => nv.MaNv.StartsWith(tienTo))
                                         .OrderByDescending(nv => nv.MaNv)
                                         .Select(nv => nv.MaNv)
                                         .FirstOrDefault();

                // Nếu chưa có ai trong năm nay
                if (string.IsNullOrEmpty(nhanVienCuoiCung))
                {
                    return tienTo + "001"; // Trả về NV26001
                }

                // Nếu đã có (VD: NV26004), cắt lấy 3 số cuối ("004"), ép sang int và + 1
                string baSoCuoi = nhanVienCuoiCung.Substring(4); // Lấy từ ký tự thứ 4 trở đi
                if (int.TryParse(baSoCuoi, out int soThuTu))
                {
                    soThuTu++;
                    return tienTo + soThuTu.ToString("D3"); // Format lại thành 3 chữ số (005)
                }

                // Fallback nếu có lỗi logic
                return tienTo + "999";
            }
        }
    }
}