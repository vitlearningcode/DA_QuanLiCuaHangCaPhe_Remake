using DA_QuanLiCuaHangCaPhe_Nhom9.Models;
using DA_QuanLiCuaHangCaPhe_Nhom9.Function.CoreLogic;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Function.function_Admin
{
    public class KhoService
    {
        private readonly CoreLogic_Kho _core = new CoreLogic_Kho();
        // Lấy danh sách Nhà Cung Cấp (để chọn khi nhập)
        public List<NhaCungCap> LayDanhSachNhaCungCap()
        {
            using (var db = new DataSqlContext())
            {
                return db.NhaCungCaps.ToList();
            }
        }

        //  Hàm Nhập Kho "Chuẩn Com-lê" (Lưu Phiếu + Chi Tiết + Tăng Tồn Kho)
        public bool NhapKhoChinhThuc(PhieuKho phieu, List<ChiTietPhieuKho> listChiTiet)
        {
            using (var db = new DataSqlContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.PhieuKhos.Add(phieu);
                        db.SaveChanges();

                        foreach (var item in listChiTiet)
                        {
                            item.MaPhieu = phieu.MaPhieu;
                            db.ChiTietPhieuKhos.Add(item);

                            var nl = db.NguyenLieus.Find(item.MaNl);
                            if (nl != null)
                            {
                                // --- ĐOẠN XỬ LÝ LÕI ---
                                if (phieu.LoaiPhieu == "Nhap")
                                {
                                    nl.SoLuongTon += item.SoLuong; // Nhập thì cộng
                                }
                                else if (phieu.LoaiPhieu == "Xuat")
                                {
                                    nl.SoLuongTon -= item.SoLuong; // Hủy thì trừ
                                    if (nl.SoLuongTon < 0) nl.SoLuongTon = 0; // Tránh kho bị âm
                                }
                            }
                        }
                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        string loiThatSu = ex.Message;
                        if (ex.InnerException != null)
                        {
                            loiThatSu += "\n\nChi tiết lỗi SQL: " + ex.InnerException.Message;
                        }

                        // Bật thông báo lỗi chi tiết thay vì báo chung chung
                        System.Windows.Forms.MessageBox.Show("BẮT ĐƯỢC LỖI DATABASE:\n\n" + loiThatSu, "Báo cáo Bug", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                        return false;
                       
                    }
                }
            }
        }

        // 1. Lấy danh sách nguyên liệu đang kinh doanh (delegate sang CoreLogic_Kho)
        public List<NguyenLieu> LayDanhSachNguyenLieu()
        {
            return _core.LayNguyenLieuDangKinhDoanh();
        }

        public bool ThemNguyenLieu(string ten, string donVi)
        {
            using (var db = new DataSqlContext())
            {
                if (db.NguyenLieus.Any(n => n.TenNl == ten && n.TrangThai == "Đang kinh doanh"))
                    return false;

                var nl = new NguyenLieu
                {
                    TenNl = ten,
                    DonViTinh = donVi,
                    SoLuongTon = 0,
                    TrangThai = "Đang kinh doanh"
                    // Đã xóa dòng GiaNhap = ... vì DB không có
                };
                db.NguyenLieus.Add(nl);
                db.SaveChanges();
                return true;
            }
        }

        // 3. Sửa (ĐÃ SỬA: Bỏ tham số giaNhap)
        public void SuaNguyenLieu(int maNL, string tenMoi, string donViMoi)
        {
            using (var db = new DataSqlContext())
            {
                var nl = db.NguyenLieus.Find(maNL);
                if (nl != null)
                {
                    nl.TenNl = tenMoi;
                    nl.DonViTinh = donViMoi;
                    // Đã xóa dòng GiaNhap = ...
                    db.SaveChanges();
                }
            }
        }

        // 4. Xóa nguyên liệu (Thực chất là đổi trạng thái để không mất lịch sử nhập xuất)
        public void XoaNguyenLieu(int maNL)
        {
            using (var db = new DataSqlContext())
            {
                var nl = db.NguyenLieus.Find(maNL);
                if (nl != null)
                {
                    nl.TrangThai = "Ngừng kinh doanh";
                    db.SaveChanges();
                }
            }
        }

        // Thêm hàm này vào KhoService.cs
        public void NhapHangVaoKho(int maNL, decimal soLuongThem)
        {
            using (var db = new DataSqlContext())
            {
                var nl = db.NguyenLieus.Find(maNL);
                if (nl != null)
                {
                    // Cộng dồn số lượng nhập vào số lượng đang có
                    nl.SoLuongTon += soLuongThem;
                    db.SaveChanges();
                }
            }
        }

        public bool HuyPhieuKhoVaLuiKho(int maPhieu)
        {
            using (var db = new DataSqlContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var phieu = db.PhieuKhos.Find(maPhieu);
                        if (phieu == null || phieu.TrangThai == "Đã hủy") return false;

                        // 1. Đổi trạng thái thay vì xóa
                        phieu.TrangThai = "Đã hủy";

                        // 2. Lùi kho (logic lùi kho giữ nguyên như cũ)
                        var listChiTiet = db.ChiTietPhieuKhos.Where(x => x.MaPhieu == maPhieu).ToList();
                        foreach (var item in listChiTiet)
                        {
                            var nl = db.NguyenLieus.Find(item.MaNl);
                            if (nl != null)
                            {
                                if (phieu.LoaiPhieu == "Nhap") nl.SoLuongTon -= item.SoLuong;
                                else if (phieu.LoaiPhieu == "Huy") nl.SoLuongTon += item.SoLuong;
                                if (nl.SoLuongTon < 0) nl.SoLuongTon = 0;
                            }
                        }

                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception) { transaction.Rollback(); return false; }
                }
            }
        }

        // 1. Hàm lấy chi tiết của 1 phiếu (Để click vào bảng trên hiện chi tiết bảng dưới)
        public dynamic LayChiTietCuaPhieu(int maPhieu)
        {
            using (var db = new DataSqlContext())
            {
                return (from ct in db.ChiTietPhieuKhos
                        join nl in db.NguyenLieus on ct.MaNl equals nl.MaNl
                        where ct.MaPhieu == maPhieu
                        select new
                        {
                            TenNL = nl.TenNl,
                            ct.SoLuong,
                            ct.GiaNhap,
                            ThanhTien = ct.SoLuong * ct.GiaNhap
                        }).ToList();
            }
        }

        // 2. Hàm thêm nhanh Nhà Cung Cấp (Từ cái form ảo diệu)
        public int ThemNhaCungCapNhanh(string tenNcc, string sdt, string diaChi)
        {
            using (var db = new DataSqlContext())
            {
                var ncc = new NhaCungCap
                {
                    TenNcc = tenNcc,
                    SoDienThoai = sdt,
                    DiaChi = diaChi
                };
                db.NhaCungCaps.Add(ncc);
                db.SaveChanges();
                return ncc.MaNcc;
            }
        }

        public dynamic LayDanhSachPhieuNhap()
        {
            using (var db = new DataSqlContext())
            {
                return (from p in db.PhieuKhos
                        // BẮT BUỘC PHẢI DÙNG LEFT JOIN NHƯ THẾ NÀY ĐỂ KHÔNG BỊ MẤT PHIẾU HỦY
                        join ncc in db.NhaCungCaps on p.MaNcc equals ncc.MaNcc into nccGroup
                        from ncc in nccGroup.DefaultIfEmpty()
                        orderby p.NgayLap descending
                        select new
                        {
                            p.MaPhieu,
                            LoaiPhieu = p.LoaiPhieu == "Xuat" ? "Xuất Hủy" : "Nhập Kho",
                            p.NgayLap,
                            // Nếu ncc = null (Phiếu Hủy) thì in ra chữ "Nội Bộ", ngược lại in Tên NCC
                            TenNcc = ncc != null ? ncc.TenNcc : "- Nội Bộ (Hủy Hàng) -",
                            TrangThai = p.TrangThai,
                            TongTien = db.ChiTietPhieuKhos.Where(ct => ct.MaPhieu == p.MaPhieu).Sum(ct => ct.SoLuong * ct.GiaNhap)
                        }).ToList();
            }
        }

        // Hàm tự động sinh Mã Phiếu Nhập theo format: yyMMdd + STT (2 số)
        public int TaoMaPhieuNhapMoi()
        {
            using (var db = new DataSqlContext())
            {
                // Lấy ngày hôm nay định dạng yyMMdd (Ví dụ 17/04/2026 -> 260417)
                string prefixStr = DateTime.Today.ToString("yyMMdd");

                // Đổi thành số nguyên và chừa 2 số cuối cho STT (Ví dụ 26041700)
                int prefixInt = int.Parse(prefixStr) * 100;

                // Tìm mã lớn nhất trong ngày hôm nay (nằm trong khoảng từ yyMMdd00 đến yyMMdd99)
                int minMa = prefixInt;
                int maxMa = prefixInt + 99;

                var phieuCuoiCung = db.PhieuKhos
                                      .Where(p => p.MaPhieu > minMa && p.MaPhieu <= maxMa)
                                      .OrderByDescending(p => p.MaPhieu)
                                      .FirstOrDefault();

                if (phieuCuoiCung != null)
                {
                    // Nếu hôm nay đã có phiếu rồi thì cộng dồn STT lên 1 (Ví dụ: 26041701 -> 26041702)
                    return phieuCuoiCung.MaPhieu + 1;
                }
                else
                {
                    // Nếu hôm nay chưa có phiếu nào thì đây là phiếu đầu tiên: đuôi 01
                    return prefixInt + 1;
                }
            }
        }

        // Tự động tìm hoặc tạo NCC dùng cho việc Xuất Hủy
        public int LayHoacTaoNccXuatHuy()
        {
            using (var db = new DataSqlContext())
            {
                string tenNccHuy = "Tại Cửa Hàng (Hủy Hàng)";
                var ncc = db.NhaCungCaps.FirstOrDefault(n => n.TenNcc == tenNccHuy);

                if (ncc != null) return ncc.MaNcc; // Đã có thì trả về ID

                // Chưa có thì tự tạo mới luôn
                var nccMoi = new NhaCungCap
                {
                    TenNcc = tenNccHuy,
                    SoDienThoai = "N/A",
                    DiaChi = "Nội Bộ"
                };
                db.NhaCungCaps.Add(nccMoi);
                db.SaveChanges();
                return nccMoi.MaNcc;
            }
        }

        // Tìm Giá Nhập gần nhất (delegate sang CoreLogic_Kho)
        public decimal LayGiaNhapGanNhat(int maNL)
        {
            return _core.LayGiaNhapGanNhat(maNL);
        }

        // --- 1. HÀM KIỂM TRA TÌNH TRẠNG NỢ CỦA PHIẾU ---
        public CongNo LayThongTinCongNo(int maPhieu)
        {
            using (var db = new DataSqlContext())
            {
                // Tìm xem đã từng có hồ sơ nợ cho phiếu này chưa
                var congNo = db.CongNos.FirstOrDefault(c => c.MaPhieu == maPhieu);
                if (congNo != null) return congNo;

                // Nếu chưa có (phiếu mới tinh), tự động tính tổng tiền để tạo hồ sơ ảo báo cáo ra màn hình
                var phieu = db.PhieuKhos.Find(maPhieu);
                if (phieu == null || phieu.LoaiPhieu == "Huy") return null; // Phiếu hủy thì không có nợ nần gì

                decimal tongTien = (decimal)db.ChiTietPhieuKhos.Where(ct => ct.MaPhieu == maPhieu).Sum(ct => ct.SoLuong * ct.GiaNhap);

                return new CongNo
                {
                    MaPhieu = maPhieu,
                    MaNcc = phieu.MaNcc ?? 0,
                    TongTien = tongTien,
                    DaTra = 0,
                    TrangThai = "Chưa thanh toán"
                };
            }
        }

        // --- 2. HÀM THỰC HIỆN THANH TOÁN & GHI LỊCH SỬ ---
        // Mã NV thực hiện thanh toán công nợ — nhận từ UC_Kho (Admin đăng nhập)
        public bool XuLyThanhToan(int maPhieu, decimal soTienTra, string hinhThuc, string maNV = "")
        {
            using (var db = new DataSqlContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Tìm hoặc tạo mới Công Nợ
                        var congNo = db.CongNos.FirstOrDefault(c => c.MaPhieu == maPhieu);
                        if (congNo == null)
                        {
                            var phieu = db.PhieuKhos.Find(maPhieu);
                            decimal tongTien = (decimal)db.ChiTietPhieuKhos.Where(ct => ct.MaPhieu == maPhieu).Sum(ct => ct.SoLuong * ct.GiaNhap);

                            congNo = new CongNo
                            {
                                MaPhieu = maPhieu,
                                MaNcc = phieu.MaNcc ?? 0,
                                TongTien = tongTien,
                                DaTra = 0,
                                NgayGhiNhan = DateTime.Now,
                                TrangThai = "Chưa thanh toán"
                            };
                            db.CongNos.Add(congNo);
                            db.SaveChanges(); // Phải lưu để SQL cấp mã MaCongNo
                        }

                        // Kiểm tra an toàn: Không cho trả lố số tiền còn nợ
                        if (soTienTra > (congNo.TongTien - congNo.DaTra)) return false;

                        // 2. Trừ nợ (Cộng tiền đã trả)
                        congNo.DaTra += soTienTra;

                        // 3. Cập nhật lại Trạng thái cho chuẩn
                        if (congNo.DaTra >= congNo.TongTien) congNo.TrangThai = "Đã thanh toán";
                        else if (congNo.DaTra > 0) congNo.TrangThai = "Thanh toán một phần";

                        // 4. Tạo Phiếu Chi lưu vào Lịch Sử Dòng Tiền
                        var phieuChi = new PhieuChi
                        {
                            NgayChi = DateTime.Now,
                            LoaiChi = "Trả Nợ NCC",
                            SoTien = soTienTra,
                            HinhThuc = hinhThuc,
                            GhiChu = $"Thanh toán cho phiếu nhập kho số: {maPhieu}",
                            MaPhieu = maPhieu,
                            MaCongNo = congNo.MaCongNo,
                            MaNv      = string.IsNullOrEmpty(maNV) ? null : maNV  // Mã NV thực thành toán
                        };
                        db.PhieuChis.Add(phieuChi);

                        db.SaveChanges();
                        trans.Commit(); // Chốt giao dịch!
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}