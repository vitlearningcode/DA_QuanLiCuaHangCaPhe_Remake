using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DA_QuanLiCuaHangCaPhe_Nhom9.Models;

public partial class DataSqlContext : DbContext
{
    public DataSqlContext()
    {
    }

    public DataSqlContext(DbContextOptions<DataSqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<ChiTietPhieuKho> ChiTietPhieuKhos { get; set; }

    public virtual DbSet<CongNo> CongNos { get; set; }

    public virtual DbSet<DinhLuong> DinhLuongs { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuChi> PhieuChis { get; set; }

    public virtual DbSet<PhieuKho> PhieuKhos { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // => optionsBuilder.UseSqlServer("Server=EMBOU;Database=DATA_SQL;Trusted_Connection=True;TrustServerCertificate=True");
    // => optionsBuilder.UseSqlServer("Server=KenG_Kanowaki\\LEMINHDUCSQL;Database=DATA_SQL;Trusted_Connection=True;TrustServerCertificate=True");
    // => optionsBuilder.UseSqlServer("Server=LAPTOP-2Q4VT418\\SQLEXPRESS;Database=DA_QuanLiBanCaPhe;Trusted_Connection=True;TrustServerCertificate=True");
    {
        if (!optionsBuilder.IsConfigured)
        {
            // 1. Xây dựng đối tượng Configuration

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Lấy thư mục chạy (bin/Debug)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Đọc file json

            var configuration = configBuilder.Build();

            // 2. Lấy chuỗi kết nối từ file json
            //    ("MyDatabase" là tên bạn đặt trong file json)
            string connString = configuration.GetConnectionString("MyDatabase");

            // 3. Sử dụng chuỗi kết nối đó
            optionsBuilder.UseSqlServer(connString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => new { e.MaDh, e.MaSp }).HasName("PK__ChiTietD__F557D6E0F3C245A5");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.MaDh).HasColumnName("MaDH");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.DonGia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.GhiChu).HasMaxLength(200);

            entity.HasOne(d => d.MaDhNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaDh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDon__MaDH__60A75C0F");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDon__MaSP__619B8048");
        });

        modelBuilder.Entity<ChiTietPhieuKho>(entity =>
        {
            entity.HasKey(e => new { e.MaPhieu, e.MaNl }).HasName("PK__ChiTietP__F412E2933345CBFE");

            entity.ToTable("ChiTietPhieuKho");

            entity.Property(e => e.MaNl).HasColumnName("MaNL");
            entity.Property(e => e.GiaNhap).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.SoLuong).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaNlNavigation).WithMany(p => p.ChiTietPhieuKhos)
                .HasForeignKey(d => d.MaNl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__MaNL__6383C8BA");

            entity.HasOne(d => d.MaPhieuNavigation).WithMany(p => p.ChiTietPhieuKhos)
                .HasForeignKey(d => d.MaPhieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__628FA481");
        });

        modelBuilder.Entity<CongNo>(entity =>
        {
            entity.HasKey(e => e.MaCongNo).HasName("PK__CongNo__E452A01E423A9176");

            entity.ToTable("CongNo");

            entity.Property(e => e.DaTra).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayGhiNhan).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.CongNos)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CongNo__MaNcc__14270015");

            entity.HasOne(d => d.MaPhieuNavigation).WithMany(p => p.CongNos)
                .HasForeignKey(d => d.MaPhieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CongNo__MaPhieu__151B244E");
        });

        modelBuilder.Entity<DinhLuong>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.MaNl }).HasName("PK__DinhLuon__F557556F75BD3E8F");

            entity.ToTable("DinhLuong");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.MaNl).HasColumnName("MaNL");
            entity.Property(e => e.SoLuongCan).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaNlNavigation).WithMany(p => p.DinhLuongs)
                .HasForeignKey(d => d.MaNl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DinhLuong__MaNL__6477ECF3");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.DinhLuongs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DinhLuong__MaSP__656C112C");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDh).HasName("PK__DonHang__272586610CFEEAAE");

            entity.ToTable("DonHang");

            entity.Property(e => e.MaDh).HasColumnName("MaDH");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaKm).HasColumnName("MaKM");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Ðang x? lý");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__DonHang__MaKH__66603565");

            entity.HasOne(d => d.MaKmNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKm)
                .HasConstraintName("FK__DonHang__MaKM__6754599E");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DonHang__MaNV__68487DD7");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E6640F9A3");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.LoaiKh)
                .HasMaxLength(20)
                .HasDefaultValue("Thuong")
                .HasColumnName("LoaiKH");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenKh)
                .HasMaxLength(100)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKm).HasName("PK__KhuyenMa__2725CF152988C82D");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKm).HasColumnName("MaKM");
            entity.Property(e => e.GiaTri).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LoaiKm)
                .HasMaxLength(20)
                .HasColumnName("LoaiKM");
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.TenKm)
                .HasMaxLength(100)
                .HasColumnName("TenKM");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Ðang áp d?ng");

            entity.HasMany(d => d.MaSps).WithMany(p => p.MaKms)
                .UsingEntity<Dictionary<string, object>>(
                    "KhuyenMaiSanPham",
                    r => r.HasOne<SanPham>().WithMany()
                        .HasForeignKey("MaSp")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__KhuyenMai___MaSP__6A30C649"),
                    l => l.HasOne<KhuyenMai>().WithMany()
                        .HasForeignKey("MaKm")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__KhuyenMai___MaKM__693CA210"),
                    j =>
                    {
                        j.HasKey("MaKm", "MaSp").HasName("PK__KhuyenMa__F5579F9446FAD5DE");
                        j.ToTable("KhuyenMai_SanPham");
                        j.IndexerProperty<int>("MaKm").HasColumnName("MaKM");
                        j.IndexerProperty<int>("MaSp").HasColumnName("MaSP");
                    });
        });

        modelBuilder.Entity<NguyenLieu>(entity =>
        {
            entity.HasKey(e => e.MaNl).HasName("PK__NguyenLi__2725D73C8FD90E0B");

            entity.ToTable("NguyenLieu");

            entity.Property(e => e.MaNl).HasColumnName("MaNL");
            entity.Property(e => e.DonViTinh).HasMaxLength(20);
            entity.Property(e => e.NguongCanhBao)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SoLuongTon)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TenNl)
                .HasMaxLength(100)
                .HasColumnName("TenNL");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Ðang kinh doanh");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEB580AF50F");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenNcc)
                .HasMaxLength(100)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70AC1468378");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenNv)
                .HasMaxLength(100)
                .HasColumnName("TenNV");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Ðang làm vi?c");
        });

        modelBuilder.Entity<PhieuChi>(entity =>
        {
            entity.HasKey(e => e.MaPhieuChi).HasName("PK__PhieuChi__00AC0F193BEDDBE4");

            entity.ToTable("PhieuChi");

            entity.Property(e => e.HinhThuc).HasMaxLength(50);
            entity.Property(e => e.LoaiChi).HasMaxLength(50);
            entity.Property(e => e.NgayChi).HasColumnType("datetime");
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaCongNoNavigation).WithMany(p => p.PhieuChis)
                .HasForeignKey(d => d.MaCongNo)
                .HasConstraintName("FK__PhieuChi__MaCong__19DFD96B");

            entity.HasOne(d => d.MaPhieuNavigation).WithMany(p => p.PhieuChis)
                .HasForeignKey(d => d.MaPhieu)
                .HasConstraintName("FK__PhieuChi__MaPhie__18EBB532");
        });

        modelBuilder.Entity<PhieuKho>(entity =>
        {
            entity.HasKey(e => e.MaPhieu).HasName("PK__PhieuKho__2660BFE0F768AF39");

            entity.ToTable("PhieuKho");

            entity.Property(e => e.MaPhieu).ValueGeneratedNever();
            entity.Property(e => e.LoaiPhieu).HasMaxLength(10);
            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.PhieuKhos)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK__PhieuKho__MaNCC__6B24EA82");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuKhos)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuKho__MaNV__6C190EBB");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081CE50781EE");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.DonGia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DonVi).HasMaxLength(20);
            entity.Property(e => e.LoaiSp)
                .HasMaxLength(50)
                .HasColumnName("LoaiSP");
            entity.Property(e => e.TenSp)
                .HasMaxLength(100)
                .HasColumnName("TenSP");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Còn bán");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TenDangNhap).HasName("PK__TaiKhoan__55F68FC1ECF3CDF8");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.MaNv, "UQ__TaiKhoan__2725D70B0B5EC330").IsUnique();

            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MatKhau).HasMaxLength(256);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaNvNavigation).WithOne(p => p.TaiKhoan)
                .HasForeignKey<TaiKhoan>(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__MaNV__6D0D32F4");

            entity.HasOne(d => d.MaVaiTroNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaVaiTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__MaVaiT__6E01572D");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaTt).HasName("PK__ThanhToa__27250079EAD7D376");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.MaTt).HasColumnName("MaTT");
            entity.Property(e => e.HinhThuc).HasMaxLength(50);
            entity.Property(e => e.MaDh).HasColumnName("MaDH");
            entity.Property(e => e.NgayTt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NgayTT");
            entity.Property(e => e.SoTien).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Chưa thanh toán");

            entity.HasOne(d => d.MaDhNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.MaDh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ThanhToan__MaDH__6EF57B66");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.MaVaiTro).HasName("PK__VaiTro__C24C41CFDC8B4B9D");

            entity.ToTable("VaiTro");

            entity.HasIndex(e => e.TenVaiTro, "UQ__VaiTro__1DA558146E1285A2").IsUnique();

            entity.Property(e => e.TenVaiTro).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
