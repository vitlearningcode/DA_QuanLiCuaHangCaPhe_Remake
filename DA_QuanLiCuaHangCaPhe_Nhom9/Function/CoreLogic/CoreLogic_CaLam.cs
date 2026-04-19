using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic
{
    public class CoreLogic_CaLam
    {
        public List<NhanVien> LayNhanVienXepCa()
        {
            using (var db = new DataSqlContext())
            {
                return db.NhanViens.Where(nv => nv.TrangThai == "Đang làm việc").ToList();
            }
        }

        // BỔ SUNG: Lấy lịch làm việc của 1 nhân viên trong 1 tuần cụ thể
        public List<LichLamViec> LayLichLamViecTheoTuan(string maNV, DateTime ngayDauTuan)
        {
            using (var db = new DataSqlContext())
            {
                DateTime ngayCuoiTuan = ngayDauTuan.AddDays(6);
                var tuNgay = DateOnly.FromDateTime(ngayDauTuan);
                var denNgay = DateOnly.FromDateTime(ngayCuoiTuan);

                return db.LichLamViecs
                         .Where(l => l.MaNv == maNV && l.NgayLam >= tuNgay && l.NgayLam <= denNgay)
                         .ToList();
            }
        }

        public bool LuuLichLamViec(string maNV, DateTime ngayDauTuan, List<int> danhSachCa, List<DateTime> danhSachNgay)
        {
            using (var db = new DataSqlContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        DateTime ngayCuoiTuan = ngayDauTuan.AddDays(6);
                        var tuNgay = DateOnly.FromDateTime(ngayDauTuan);
                        var denNgay = DateOnly.FromDateTime(ngayCuoiTuan);

                        var lichCu = db.LichLamViecs.Where(l => l.MaNv == maNV && l.NgayLam >= tuNgay && l.NgayLam <= denNgay);
                        db.LichLamViecs.RemoveRange(lichCu);

                        for (int i = 0; i < danhSachCa.Count; i++)
                        {
                            db.LichLamViecs.Add(new LichLamViec
                            {
                                MaNv = maNV,
                                MaCa = danhSachCa[i],
                                NgayLam = DateOnly.FromDateTime(danhSachNgay[i]),
                                TrangThai = "Chưa làm"
                            });
                        }

                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public List<CaLamViec> LayDanhSachCaLam()
        {
            using (var db = new DataSqlContext())
            {
                // Sắp xếp theo giờ bắt đầu cho hợp logic từ Sáng đến Tối
                return db.CaLamViecs.OrderBy(c => c.GioBatDau).ToList();
            }
        }
    }
}