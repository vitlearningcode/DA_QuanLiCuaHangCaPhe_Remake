using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic
{
    public class CoreLogic_Kho
    {
        public List<NguyenLieu> LayDanhSachNguyenLieu()
        {
            using (var db = new DataSqlContext())
            {
                return db.NguyenLieus.OrderByDescending(nl => nl.MaNl).ToList();
            }
        }

        public bool LuuNguyenLieu(NguyenLieu nl)
        {
            using (var db = new DataSqlContext())
            {
                try
                {
                    if (nl.MaNl == 0) db.NguyenLieus.Add(nl);
                    else
                    {
                        var nlCu = db.NguyenLieus.Find(nl.MaNl);
                        if (nlCu != null)
                        {
                            nlCu.TenNl = nl.TenNl;
                            nlCu.DonViTinh = nl.DonViTinh;
                            nlCu.SoLuongTon = nl.SoLuongTon;
                            nlCu.NguongCanhBao = nl.NguongCanhBao;
                            nlCu.TrangThai = nl.TrangThai;
                        }
                    }
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }

        // ĐÃ SỬA TỪ VỰNG: Dùng "Ngừng kinh doanh" và "Đang kinh doanh"
        public bool DoiTrangThaiNguyenLieu(int maNL, string trangThaiMoi)
        {
            using (var db = new DataSqlContext())
            {
                var nl = db.NguyenLieus.Find(maNL);
                if (nl != null)
                {
                    nl.TrangThai = trangThaiMoi;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // ================== LOGIC PHIẾU KHO CHUẨN ==================
        public List<PhieuKhoView> LayLichSuPhieuKho()
        {
            using (var db = new DataSqlContext())
            {
                return db.PhieuKhos
                    .OrderByDescending(p => p.MaPhieu)
                    .Select(p => new PhieuKhoView
                    {
                        MaPhieu = p.MaPhieu,
                        NgayLap = p.NgayLap.HasValue ? p.NgayLap.Value.ToString("dd/MM/yyyy HH:mm") : "",
                        LoaiPhieu = p.LoaiPhieu,
                        TenNhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNv == p.MaNv).TenNv,
                        TongTien = db.ChiTietPhieuKhos.Where(ct => ct.MaPhieu == p.MaPhieu).Sum(ct => ct.SoLuong * (ct.GiaNhap ?? 0))
                    }).ToList();
            }
        }

        public List<ChiTietPhieuView> LayChiTietCuaPhieu(int maPhieu)
        {
            using (var db = new DataSqlContext())
            {
                return db.ChiTietPhieuKhos
                    .Where(ct => ct.MaPhieu == maPhieu)
                    .Select(ct => new ChiTietPhieuView
                    {
                        MaNL = ct.MaNl,
                        TenNL = db.NguyenLieus.FirstOrDefault(nl => nl.MaNl == ct.MaNl).TenNl,
                        DonViTinh = db.NguyenLieus.FirstOrDefault(nl => nl.MaNl == ct.MaNl).DonViTinh,
                        SoLuong = ct.SoLuong,
                        GiaNhap = ct.GiaNhap ?? 0
                    }).ToList();
            }
        }

        // 🛑 ĐÃ SỬA LỖI TÀI CHÍNH: TỰ ĐỘNG LẤY GIÁ NHẬP GẦN NHẤT KHI XUẤT KHO
        public bool TaoPhieuKhoTransaction(string maNV, string loaiPhieu, List<ChiTietPhieuView> danhSachTam)
        {
            using (var db = new DataSqlContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int maPhieuMoi = (db.PhieuKhos.Max(p => (int?)p.MaPhieu) ?? 0) + 1;

                        var phieu = new PhieuKho
                        {
                            MaPhieu = maPhieuMoi,
                            NgayLap = DateTime.Now,
                            LoaiPhieu = loaiPhieu,
                            MaNv = maNV,
                            TrangThai = "Hoàn thành"
                        };
                        db.PhieuKhos.Add(phieu);

                        foreach (var item in danhSachTam)
                        {
                            decimal giaThucTe = item.GiaNhap;

                            // LOGIC KẾ THỪA: Nếu là phiếu XUẤT, hệ thống tự truy tìm Giá Nhập gần nhất
                            if (loaiPhieu == "Xuat")
                            {
                                var chiTietMoiNhat = db.ChiTietPhieuKhos
                                    .Where(x => x.MaNl == item.MaNL && x.GiaNhap > 0)
                                    .OrderByDescending(x => x.MaPhieu)
                                    .FirstOrDefault();
                                giaThucTe = chiTietMoiNhat != null ? (chiTietMoiNhat.GiaNhap ?? 0) : 0;
                            }

                            var ct = new ChiTietPhieuKho
                            {
                                MaPhieu = maPhieuMoi,
                                MaNl = item.MaNL,
                                SoLuong = item.SoLuong,
                                GiaNhap = giaThucTe // Gắn giá trị chuẩn
                            };
                            db.ChiTietPhieuKhos.Add(ct);

                            // Cập nhật tồn kho
                            var kho = db.NguyenLieus.Find(item.MaNL);
                            if (kho != null)
                            {
                                if (loaiPhieu == "Nhap") kho.SoLuongTon += item.SoLuong;
                                else if (loaiPhieu == "Xuat") kho.SoLuongTon -= item.SoLuong;
                            }
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


        // BỔ SUNG: Hàm truy tìm giá nhập gần nhất của nguyên liệu
        public decimal LayGiaNhapGanNhat(int maNL)
        {
            using (var db = new DataSqlContext())
            {
                var chiTiet = db.ChiTietPhieuKhos
                    .Where(x => x.MaNl == maNL && x.GiaNhap > 0)
                    .OrderByDescending(x => x.MaPhieu)
                    .FirstOrDefault();
                return chiTiet != null ? (chiTiet.GiaNhap ?? 0) : 0;
            }
        }
    }

    public class PhieuKhoView
    {
        public int MaPhieu { get; set; }
        public string NgayLap { get; set; }
        public string LoaiPhieu { get; set; }
        public string TenNhanVien { get; set; }
        public decimal TongTien { get; set; }
    }

    public class ChiTietPhieuView
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public string DonViTinh { get; set; }
        public decimal SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal ThanhTien => SoLuong * GiaNhap;
    }
}