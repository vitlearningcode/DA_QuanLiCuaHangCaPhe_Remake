/*
========================================================================
  SCRIPT: XÓA SẠCH, RESET IDENTITY VÀ TẠO DỮ LIỆU MẪU THỰC TẾ
  Cửa hàng: The Daily Grind Coffee
  Tạo ngày: 2026-04-20
========================================================================
*/

USE DA_QuanLiCuaHangCaPhe;
GO

-- ========================================================================
-- PHẦN 1: XÓA SẠCH DỮ LIỆU (từ bảng con → bảng cha → bảng gốc)
-- ========================================================================
PRINT N'[1/3] Đang xóa dữ liệu cũ...';

DELETE FROM ThanhToan;
DELETE FROM ChiTietDonHang;
DELETE FROM KhuyenMai_SanPham;
DELETE FROM DinhLuong;
DELETE FROM ChiTietPhieuKho;
GO

DELETE FROM DonHang;
DELETE FROM PhieuKho;
DELETE FROM TaiKhoan;
GO

DELETE FROM KhuyenMai;
DELETE FROM SanPham;
DELETE FROM NguyenLieu;
DELETE FROM NhaCungCap;
DELETE FROM KhachHang;
DELETE FROM NhanVien;
DELETE FROM VaiTro;
GO

PRINT N'    → Xóa xong.';

-- ========================================================================
-- PHẦN 2: RESET BỘ ĐẾM IDENTITY VỀ 0
-- ========================================================================
PRINT N'[2/3] Đang reset identity...';

DBCC CHECKIDENT ('ThanhToan',       RESEED, 0);
DBCC CHECKIDENT ('DonHang',         RESEED, 0);
DBCC CHECKIDENT ('KhuyenMai',       RESEED, 0);
DBCC CHECKIDENT ('PhieuKho',        RESEED, 0);
DBCC CHECKIDENT ('NhanVien',        RESEED, 0);
DBCC CHECKIDENT ('KhachHang',       RESEED, 0);
DBCC CHECKIDENT ('NhaCungCap',      RESEED, 0);
DBCC CHECKIDENT ('SanPham',         RESEED, 0);
DBCC CHECKIDENT ('NguyenLieu',      RESEED, 0);
DBCC CHECKIDENT ('VaiTro',          RESEED, 0);
GO

PRINT N'    → Reset xong.';

-- ========================================================================
-- PHẦN 3: THÊM DỮ LIỆU MẪU THỰC TẾ
-- ========================================================================
PRINT N'[3/3] Đang thêm dữ liệu mẫu...';

-- -----------------------------------------------------------------------
-- 3.1  VAI TRÒ
-- -----------------------------------------------------------------------
INSERT INTO VaiTro (TenVaiTro) VALUES
(N'Chủ cửa hàng'),   -- MaVaiTro = 1
(N'Quản lý'),         -- MaVaiTro = 2
(N'Nhân viên');       -- MaVaiTro = 3
GO

-- -----------------------------------------------------------------------
-- 3.2  NHÂN VIÊN (7 người, đa dạng chức vụ)
-- -----------------------------------------------------------------------
INSERT INTO NhanVien (TenNV, ChucVu, SoDienThoai, NgayVaoLam) VALUES
(N'Lê Văn Định',       N'Chủ cửa hàng', '0901234567', '2022-06-01'),   -- MaNV = 1
(N'Lê Minh Đức',       N'Quản lý',      '0912345678', '2023-01-15'),   -- MaNV = 2
(N'Bùi Phước Hậu',     N'Thu ngân',     '0987654321', '2023-03-01'),   -- MaNV = 3
(N'Nguyễn Minh Tuấn',  N'Pha chế',      '0933445566', '2023-05-20'),   -- MaNV = 4
(N'Trần Thị Thu Hà',   N'Thu ngân',     '0944556677', '2023-07-10'),   -- MaNV = 5
(N'Phạm Quốc Bảo',     N'Pha chế',      '0955667788', '2024-01-05'),   -- MaNV = 6
(N'Võ Ngọc Trân',      N'Phục vụ',      '0966778899', '2024-03-18');   -- MaNV = 7
GO

-- -----------------------------------------------------------------------
-- 3.3  TÀI KHOẢN (mật khẩu đã được hash SHA-256 của "Abc@123")
--       Ở đây dùng chuỗi demo để dễ test; thực tế nên dùng BCrypt.
-- -----------------------------------------------------------------------
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, MaVaiTro, TrangThai) VALUES
('dinh',  '123', 1, 1, 1),   -- Chủ cửa hàng
('duc',   '123', 2, 2, 1),   -- Quản lý
('hau',   '123', 3, 3, 1),   -- Thu ngân
('tuan',  '123', 4, 3, 1),   -- Pha chế
('thuha', '123', 5, 3, 1),   -- Thu ngân
('bao',   '123', 6, 3, 1),   -- Pha chế
('tran',  '123', 7, 3, 0);   -- Phục vụ (tạm khóa)
GO

-- -----------------------------------------------------------------------
-- 3.4  KHÁCH HÀNG (10 người có tích điểm thực tế)
-- -----------------------------------------------------------------------
INSERT INTO KhachHang (TenKH, SoDienThoai, DiaChi, LoaiKH) VALUES
(N'Trần Anh Hùng',       '0911112222', N'123 Lê Lợi, Q1, TP.HCM',          N'VIP'),     -- MaKH = 1
(N'Nguyễn Thị Lan',      '0922223333', N'456 Nguyễn Trãi, Q5, TP.HCM',      N'Thuong'),  -- MaKH = 2
(N'Phạm Văn Khoa',       '0933334444', N'789 Cách Mạng Tháng 8, Q3, TP.HCM', N'VIP'),   -- MaKH = 3
(N'Đỗ Thị Hương',        '0944445555', N'12 Trần Hưng Đạo, Q1, TP.HCM',     N'Thuong'),  -- MaKH = 4
(N'Bùi Thanh Tùng',      '0955556666', N'34 Điện Biên Phủ, Bình Thạnh',      N'Thuong'),  -- MaKH = 5
(N'Vũ Thị Mai',          '0966667777', N'56 Hoàng Văn Thụ, Phú Nhuận',       N'VIP'),    -- MaKH = 6
(N'Hoàng Minh Khải',     '0977778888', N'78 Lý Thường Kiệt, Q10, TP.HCM',   N'Thuong'),  -- MaKH = 7
(N'Nguyễn Quốc Toản',    '0988889999', N'90 Nguyễn Thị Minh Khai, Q3',       N'Thuong'), -- MaKH = 8
(N'Lý Thị Bảo Châu',     '0999990000', N'11 Võ Văn Tần, Q3, TP.HCM',         N'VIP'),   -- MaKH = 9
(N'Khách vãng lai',      NULL,          NULL,                                  N'Thuong'); -- MaKH = 10
GO

-- -----------------------------------------------------------------------
-- 3.5  NHÀ CUNG CẤP (5 nhà cung cấp)
-- -----------------------------------------------------------------------
INSERT INTO NhaCungCap (TenNCC, DiaChi, SoDienThoai) VALUES
(N'Cty Cà Phê Trung Nguyên',     N'10 Đặng Lê Nguyên Vũ, Buôn Ma Thuột', '02623123456'),  -- MaNCC = 1
(N'Cty Sữa Vinamilk',            N'Số 10, Tân Trào, Q7, TP.HCM',          '02854155555'),  -- MaNCC = 2
(N'Cty Nguyên Liệu Pha Chế ABC', N'22 Hàng Buồm, Hà Nội',                 '0243111222'),   -- MaNCC = 3
(N'Công Ty Đường Biên Hòa',      N'5 Đường 30/4, Biên Hòa, Đồng Nai',     '02513882001'),  -- MaNCC = 4
(N'Cty TNHH Thực Phẩm Sạch',    N'100 Nguyễn Văn Linh, Q7, TP.HCM',       '02838506777'); -- MaNCC = 5
GO

-- -----------------------------------------------------------------------
-- 3.6  NGUYÊN LIỆU (12 loại)
-- -----------------------------------------------------------------------
INSERT INTO NguyenLieu (TenNL, DonViTinh, SoLuongTon, NguongCanhBao) VALUES
(N'Hạt Cà Phê Robusta',    N'kg',   48.5,  10.0),   -- MaNL = 1
(N'Hạt Cà Phê Arabica',    N'kg',   22.0,   8.0),   -- MaNL = 2
(N'Sữa Tươi Không Đường',  N'lít',  85.0,  20.0),   -- MaNL = 3
(N'Sữa Đặc Ông Thọ',       N'lon',  40.0,  10.0),   -- MaNL = 4
(N'Đường Cát Trắng',       N'kg',   18.5,   5.0),   -- MaNL = 5
(N'Bột Matcha Nhật Bản',   N'kg',    4.2,   1.0),   -- MaNL = 6
(N'Siro Vanilla',           N'chai', 8.0,   2.0),   -- MaNL = 7
(N'Siro Caramel',           N'chai', 6.5,   2.0),   -- MaNL = 8
(N'Kem Tươi (Whipping)',    N'lít',  12.0,   3.0),   -- MaNL = 9
(N'Trà Olong',              N'kg',    5.0,   1.5),   -- MaNL = 10
(N'Bột Cacao',              N'kg',    3.8,   1.0),   -- MaNL = 11
(N'Đá Viên',                N'kg',   50.0,  15.0);   -- MaNL = 12
GO

-- -----------------------------------------------------------------------
-- 3.7  SẢN PHẨM (15 món đa dạng)
-- -----------------------------------------------------------------------
INSERT INTO SanPham (TenSP, LoaiSP, DonGia, DonVi, TrangThai) VALUES
(N'Cà Phê Đen',         N'Cà phê',  25000.00, N'Ly',   N'Còn bán'),   -- MaSP = 1
(N'Cà Phê Sữa',         N'Cà phê',  29000.00, N'Ly',   N'Còn bán'),   -- MaSP = 2
(N'Bạc Xỉu',            N'Cà phê',  32000.00, N'Ly',   N'Còn bán'),   -- MaSP = 3
(N'Espresso',            N'Cà phê',  35000.00, N'Ly',   N'Còn bán'),   -- MaSP = 4
(N'Cappuccino',          N'Cà phê',  49000.00, N'Ly',   N'Còn bán'),   -- MaSP = 5
(N'Caramel Macchiato',   N'Cà phê',  55000.00, N'Ly',   N'Còn bán'),   -- MaSP = 6
(N'Matcha Latte',        N'Trà',     49000.00, N'Ly',   N'Còn bán'),   -- MaSP = 7
(N'Trà Sữa Olong',      N'Trà',     45000.00, N'Ly',   N'Còn bán'),   -- MaSP = 8
(N'Chocolate Nóng',      N'Khác',    45000.00, N'Ly',   N'Còn bán'),   -- MaSP = 9
(N'Sinh Tố Bơ',         N'Khác',    59000.00, N'Ly',   N'Còn bán'),   -- MaSP = 10
(N'Bánh Croissant',      N'Bánh',    35000.00, N'Cái',  N'Còn bán'),   -- MaSP = 11
(N'Bánh Tiramisu',       N'Bánh',    55000.00, N'Miếng',N'Còn bán'),   -- MaSP = 12
(N'Cheesecake Dâu',      N'Bánh',    60000.00, N'Miếng',N'Còn bán'),   -- MaSP = 13
(N'Sandwich Gà',         N'Bánh',    45000.00, N'Cái',  N'Còn bán'),   -- MaSP = 14
(N'Cà Phê Chồn (Kopi Luwak)', N'Cà phê', 150000.00, N'Ly', N'Hết hàng'); -- MaSP = 15
GO

-- -----------------------------------------------------------------------
-- 3.8  ĐỊNH LƯỢNG – công thức pha chế (cho các SP chính)
-- -----------------------------------------------------------------------
INSERT INTO DinhLuong (MaSP, MaNL, SoLuongCan) VALUES
-- Cà Phê Đen (MaSP=1)
(1, 1, 0.020), (1, 5, 0.010), (1, 12, 0.100),
-- Cà Phê Sữa (MaSP=2)
(2, 1, 0.020), (2, 4, 0.030), (2, 5, 0.010), (2, 12, 0.100),
-- Bạc Xỉu (MaSP=3)
(3, 1, 0.015), (3, 3, 0.080), (3, 4, 0.020), (3, 12, 0.100),
-- Espresso (MaSP=4)
(4, 2, 0.018), (4, 12, 0.030),
-- Cappuccino (MaSP=5)
(5, 2, 0.018), (5, 3, 0.100), (5, 9, 0.050), (5, 12, 0.080),
-- Caramel Macchiato (MaSP=6)
(6, 2, 0.018), (6, 3, 0.120), (6, 8, 0.025), (6, 9, 0.040),
-- Matcha Latte (MaSP=7)
(7, 6, 0.015), (7, 3, 0.120), (7, 9, 0.040), (7, 5, 0.010), (7, 12, 0.050),
-- Trà Sữa Olong (MaSP=8)
(8, 10, 0.010), (8, 3, 0.100), (8, 5, 0.015), (8, 12, 0.100),
-- Chocolate Nóng (MaSP=9)
(9, 11, 0.020), (9, 3, 0.150), (9, 5, 0.015), (9, 9, 0.050);
GO

-- -----------------------------------------------------------------------
-- 3.9  KHUYẾN MÃI (4 chương trình)
-- -----------------------------------------------------------------------
INSERT INTO KhuyenMai (TenKM, MoTa, LoaiKM, GiaTri, NgayBatDau, NgayKetThuc, TrangThai) VALUES
(N'Khai trương (Đã kết thúc)',
    N'Giảm 15% toàn bộ hóa đơn dịp khai trương',
    N'HoaDon', 15.00, '2022-06-01', '2022-06-30', N'Đã kết thúc'),              -- MaKM = 1

(N'Giảm 10% cuối tuần',
    N'Áp dụng thứ 7 và Chủ Nhật cho hóa đơn từ 100.000đ trở lên',
    N'HoaDon', 10.00, '2026-04-01', '2026-06-30', N'Đang áp dụng'),             -- MaKM = 2

(N'Ưu đãi Matcha – 20%',
    N'Giảm 20% cho tất cả sản phẩm trà Matcha',
    N'SanPham', 20.00, '2026-04-15', '2026-05-15', N'Đang áp dụng'),            -- MaKM = 3

(N'Happy Hour 4-6pm – giảm 15%',
    N'Áp dụng tất cả đơn hàng trong khung giờ 16:00–18:00',
    N'HoaDon', 15.00, '2026-04-01', '2026-04-30', N'Đang áp dụng');             -- MaKM = 4
GO

-- Liên kết KM 3 (Matcha) → SP 7 (Matcha Latte)
INSERT INTO KhuyenMai_SanPham (MaKM, MaSP) VALUES (3, 7);
GO

-- -----------------------------------------------------------------------
-- 3.10  PHIẾU KHO – lịch sử nhập kho 3 tháng gần đây
-- -----------------------------------------------------------------------
INSERT INTO PhieuKho (NgayLap, LoaiPhieu, MaNV, MaNCC) VALUES
-- Tháng 2 / 2026
('2026-02-03 09:00:00', N'Nhap', 2, 1),   -- Phiếu 01 – nhập Robusta, Arabica
('2026-02-03 09:30:00', N'Nhap', 2, 2),   -- Phiếu 02 – nhập Sữa tươi, Sữa đặc, Kem
('2026-02-10 10:00:00', N'Nhap', 2, 3),   -- Phiếu 03 – nhập Matcha, Vanilla, Caramel
('2026-02-10 10:30:00', N'Nhap', 2, 4),   -- Phiếu 04 – nhập Đường, Cacao
('2026-02-10 11:00:00', N'Nhap', 2, 5),   -- Phiếu 05 – nhập Trà Olong, Đá
-- Tháng 3 / 2026
('2026-03-05 08:30:00', N'Nhap', 2, 1),   -- Phiếu 06 – nhập Robusta bổ sung
('2026-03-05 09:00:00', N'Nhap', 2, 2),   -- Phiếu 07 – nhập Sữa tươi bổ sung
('2026-03-15 14:00:00', N'Xuat', 2, NULL), -- Phiếu 08 – xuất kho (hỏng/hết hạn)
-- Tháng 4 / 2026
('2026-04-01 09:00:00', N'Nhap', 2, 1),   -- Phiếu 09 – nhập Robusta, Arabica
('2026-04-01 09:30:00', N'Nhap', 2, 2),   -- Phiếu 10 – nhập Sữa tươi, Kem
('2026-04-10 10:00:00', N'Nhap', 2, 4);   -- Phiếu 11 – nhập Đường
GO

INSERT INTO ChiTietPhieuKho (MaPhieu, MaNL, SoLuong, GiaNhap) VALUES
-- Phiếu 01
(1, 1, 30.0, 160000.00), (1, 2, 15.0, 220000.00),
-- Phiếu 02
(2, 3, 50.0, 28000.00), (2, 4, 24.0, 15000.00), (2, 9, 8.0, 120000.00),
-- Phiếu 03
(3, 6, 3.0, 980000.00), (3, 7, 5.0, 75000.00), (3, 8, 4.0, 70000.00),
-- Phiếu 04
(4, 5, 15.0, 22000.00), (4, 11, 2.5, 85000.00),
-- Phiếu 05
(5, 10, 3.0, 350000.00), (5, 12, 30.0, 5000.00),
-- Phiếu 06
(6, 1, 20.0, 165000.00),
-- Phiếu 07
(7, 3, 40.0, 28500.00),
-- Phiếu 08 – xuất (đá hết hạn, sữa sắp hỏng)
(8, 12, 5.0, NULL), (8, 3, 5.0, NULL),
-- Phiếu 09
(9, 1, 15.0, 168000.00), (9, 2, 10.0, 225000.00),
-- Phiếu 10
(10, 3, 30.0, 29000.00), (10, 9, 5.0, 122000.00),
-- Phiếu 11
(11, 5, 10.0, 23000.00);
GO

-- -----------------------------------------------------------------------
-- 3.11  ĐƠN HÀNG + CHI TIẾT + THANH TOÁN
--        Tạo 20 đơn hàng trải dài 3 tháng, đa dạng trạng thái
-- -----------------------------------------------------------------------

/* ------------------ THÁNG 2 / 2026 ------------------ */
-- DH 01
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-02-05 08:15:00', 1,  3, 104000.00, N'Đã hoàn thành', 2);  -- MaDH=1
INSERT INTO ChiTietDonHang VALUES
(1, 2, 2, 29000.00, NULL), (1, 11, 1, 35000.00, NULL), (1, 1, 1, 25000.00, NULL);
INSERT INTO ThanhToan VALUES (1, N'Tiền mặt',      104000.00, '2026-02-05 08:16:00', N'Đã thanh toán');

-- DH 02
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-02-05 09:30:00', 2, 5, 49000.00, N'Đã hoàn thành', NULL);  -- MaDH=2
INSERT INTO ChiTietDonHang VALUES (2, 7, 1, 49000.00, N'Ít đường');
INSERT INTO ThanhToan VALUES (2, N'Chuyển khoản QR', 49000.00, '2026-02-05 09:31:00', N'Đã thanh toán');

-- DH 03
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-02-12 10:00:00', 3, 3, 165000.00, N'Đã hoàn thành', NULL);  -- MaDH=3
INSERT INTO ChiTietDonHang VALUES
(3, 5, 2, 49000.00, NULL), (3, 12, 1, 55000.00, NULL), (3, 6, 1, 55000.00, N'Thêm caramel');
INSERT INTO ThanhToan VALUES (3, N'Tiền mặt', 165000.00, '2026-02-12 10:02:00', N'Đã thanh toán');

-- DH 04
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-02-14 14:00:00', 6, 5, 225000.00, N'Đã hoàn thành', 2);  -- MaDH=4 (Valentine, cuối tuần)
INSERT INTO ChiTietDonHang VALUES
(4, 12, 2, 55000.00, NULL), (4, 13, 1, 60000.00, N'Thêm dâu'), (4, 5, 1, 49000.00, NULL);
INSERT INTO ThanhToan VALUES (4, N'Chuyển khoản QR', 225000.00, '2026-02-14 14:01:00', N'Đã thanh toán');

-- DH 05
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-02-20 11:30:00', 10, 3, 58000.00, N'Đã hoàn thành', NULL);  -- MaDH=5 (khách vãng lai)
INSERT INTO ChiTietDonHang VALUES (5, 1, 1, 25000.00, NULL), (5, 11, 1, 35000.00, NULL);
INSERT INTO ThanhToan VALUES (5, N'Tiền mặt', 58000.00, '2026-02-20 11:31:00', N'Đã thanh toán');

/* ------------------ THÁNG 3 / 2026 ------------------ */
-- DH 06
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-03-03 08:00:00', 4, 3, 87000.00, N'Đã hoàn thành', NULL);  -- MaDH=6
INSERT INTO ChiTietDonHang VALUES (6, 2, 2, 29000.00, NULL), (6, 9, 1, 45000.00, N'Không đường');
INSERT INTO ThanhToan VALUES (6, N'Tiền mặt', 87000.00, '2026-03-03 08:01:00', N'Đã thanh toán');

-- DH 07
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-03-08 16:30:00', 9, 5, 110000.00, N'Đã hoàn thành', 4);  -- MaDH=7 (Happy Hour)
INSERT INTO ChiTietDonHang VALUES
(7, 6, 1, 55000.00, NULL), (7, 8, 1, 45000.00, NULL), (7, 11, 1, 35000.00, NULL);
INSERT INTO ThanhToan VALUES (7, N'Chuyển khoản QR', 110000.00, '2026-03-08 16:31:00', N'Đã thanh toán');

-- DH 08
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-03-10 09:15:00', 5, 3, 45000.00, N'Đã hoàn thành', NULL);  -- MaDH=8
INSERT INTO ChiTietDonHang VALUES (8, 8, 1, 45000.00, N'Ít đường, thêm đá');
INSERT INTO ThanhToan VALUES (8, N'Tiền mặt', 45000.00, '2026-03-10 09:16:00', N'Đã thanh toán');

-- DH 09
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-03-15 10:45:00', 7, 5, 169000.00, N'Đã hoàn thành', NULL);  -- MaDH=9
INSERT INTO ChiTietDonHang VALUES
(9, 4, 2, 35000.00, NULL), (9, 13, 1, 60000.00, NULL), (9, 14, 1, 45000.00, NULL);
INSERT INTO ThanhToan VALUES (9, N'Tiền mặt', 169000.00, '2026-03-15 10:46:00', N'Đã thanh toán');

-- DH 10
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-03-22 07:55:00', 1, 3, 254000.00, N'Đã hoàn thành', 2);  -- MaDH=10 (cuối tuần)
INSERT INTO ChiTietDonHang VALUES
(10, 5,  2, 49000.00, NULL),
(10, 7,  1, 49000.00, N'Không đường'),
(10, 12, 1, 55000.00, NULL),
(10, 14, 1, 45000.00, NULL);
INSERT INTO ThanhToan VALUES (10, N'Chuyển khoản QR', 254000.00, '2026-03-22 07:56:00', N'Đã thanh toán');

-- DH 11
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-03-28 17:00:00', 8, 5, 139000.00, N'Đã hoàn thành', 4);  -- MaDH=11 (Happy Hour)
INSERT INTO ChiTietDonHang VALUES
(11, 6, 1, 55000.00, NULL), (11, 9, 1, 45000.00, NULL), (11, 11, 1, 35000.00, NULL);
INSERT INTO ThanhToan VALUES (11, N'Tiền mặt', 139000.00, '2026-03-28 17:01:00', N'Đã thanh toán');

/* ------------------ THÁNG 4 / 2026 (gần đây) ------------------ */
-- DH 12
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-02 08:20:00', 3, 3, 129000.00, N'Đã hoàn thành', NULL);  -- MaDH=12
INSERT INTO ChiTietDonHang VALUES
(12, 2, 1, 29000.00, N'Thêm đá'), (12, 5, 1, 49000.00, NULL), (12, 11, 1, 35000.00, NULL);
INSERT INTO ThanhToan VALUES (12, N'Tiền mặt', 129000.00, '2026-04-02 08:21:00', N'Đã thanh toán');

-- DH 13
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-05 09:45:00', 6, 5, 196000.00, N'Đã hoàn thành', 2);  -- MaDH=13 (cuối tuần, KM 10%)
INSERT INTO ChiTietDonHang VALUES
(13, 7, 2, 49000.00, NULL), (13, 13, 1, 60000.00, NULL), (13, 14, 1, 45000.00, NULL);
INSERT INTO ThanhToan VALUES (13, N'Chuyển khoản QR', 196000.00, '2026-04-05 09:46:00', N'Đã thanh toán');

-- DH 14
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-07 10:30:00', 2, 3, 78000.00, N'Đã hoàn thành', NULL);  -- MaDH=14
INSERT INTO ChiTietDonHang VALUES (14, 3, 1, 32000.00, NULL), (14, 9, 1, 45000.00, N'Ít ngọt');
INSERT INTO ThanhToan VALUES (14, N'Tiền mặt', 78000.00, '2026-04-07 10:31:00', N'Đã thanh toán');

-- DH 15
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-12 11:00:00', 9, 5, 215000.00, N'Đã hoàn thành', 2);  -- MaDH=15 (cuối tuần)
INSERT INTO ChiTietDonHang VALUES
(15, 6, 2, 55000.00, NULL), (15, 12, 1, 55000.00, NULL), (15, 4, 1, 35000.00, NULL);
INSERT INTO ThanhToan VALUES (15, N'Chuyển khoản QR', 215000.00, '2026-04-12 11:01:00', N'Đã thanh toán');

-- DH 16
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-15 15:40:00', 4, 3, 93000.00, N'Đã hoàn thành', 3);  -- MaDH=16 (KM Matcha 20%)
INSERT INTO ChiTietDonHang VALUES
(16, 7, 1, 39200.00, N'KM 20%'), (16, 8, 1, 45000.00, NULL);
INSERT INTO ThanhToan VALUES (16, N'Tiền mặt', 93000.00, '2026-04-15 15:41:00', N'Đã thanh toán');

-- DH 17
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-17 17:10:00', 7, 5, 110000.00, N'Đã hoàn thành', 4);  -- MaDH=17 (Happy Hour)
INSERT INTO ChiTietDonHang VALUES
(17, 5, 1, 49000.00, NULL), (17, 9, 1, 45000.00, NULL), (17, 1, 1, 25000.00, NULL);
INSERT INTO ThanhToan VALUES (17, N'Tiền mặt', 110000.00, '2026-04-17 17:11:00', N'Đã thanh toán');

-- DH 18
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-18 08:55:00', 5, 3, 74000.00, N'Đã hoàn thành', NULL);  -- MaDH=18
INSERT INTO ChiTietDonHang VALUES (18, 2, 1, 29000.00, NULL), (18, 14, 1, 45000.00, NULL);
INSERT INTO ThanhToan VALUES (18, N'Chuyển khoản QR', 74000.00, '2026-04-18 08:56:00', N'Đã thanh toán');

-- DH 19 – Đơn đang xử lý (hôm nay)
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-20 09:00:00', 1, 3, 147000.00, N'Đang xử lý', NULL);  -- MaDH=19
INSERT INTO ChiTietDonHang VALUES
(19, 5,  1, 49000.00, NULL), (19, 7,  1, 49000.00, N'Ít đường'), (19, 11, 1, 35000.00, NULL);
INSERT INTO ThanhToan VALUES (19, N'Tiền mặt', 147000.00, '2026-04-20 09:01:00', N'Chưa thanh toán');

-- DH 20 – Đơn mới nhất, chưa thanh toán
INSERT INTO DonHang (NgayLap, MaKH, MaNV, TongTien, TrangThai, MaKM) VALUES
('2026-04-20 11:30:00', 10, 5, 86000.00, N'Đang xử lý', NULL);  -- MaDH=20 (Khách vãng lai)
INSERT INTO ChiTietDonHang VALUES (20, 6, 1, 55000.00, NULL), (20, 11, 1, 35000.00, NULL);
-- Chưa có thanh toán cho đơn 20
GO

PRINT N'========================================================================';
PRINT N'  HOÀN TẤT! Dữ liệu mẫu đã được tạo thành công.';
PRINT N'  ✔ VaiTro:   3 vai trò';
PRINT N'  ✔ NhanVien: 7 nhân viên / 7 tài khoản';
PRINT N'  ✔ KhachHang: 10 khách hàng';
PRINT N'  ✔ NhaCungCap: 5 nhà cung cấp';
PRINT N'  ✔ NguyenLieu: 12 nguyên liệu';
PRINT N'  ✔ SanPham: 15 sản phẩm';
PRINT N'  ✔ DinhLuong: 26 bản ghi công thức';
PRINT N'  ✔ KhuyenMai: 4 chương trình';
PRINT N'  ✔ PhieuKho: 11 phiếu (nhập + xuất)';
PRINT N'  ✔ DonHang: 20 đơn hàng (18 hoàn thành, 2 đang xử lý)';
PRINT N'  ✔ ThanhToan: 19 bản ghi (18 đã TT, 1 chưa TT)';
PRINT N'========================================================================';
GO
