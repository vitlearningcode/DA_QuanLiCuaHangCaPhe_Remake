using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=oioioi\\sqlexpress;Initial Catalog=DA_QuanLiBanCaPhe;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => new { e.MaDh, e.MaSp }).HasName("PK__ChiTietD__F557D6E0F67EA2F8");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.MaDh).HasColumnName("MaDH");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.DonGia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.GhiChu).HasMaxLength(200);

            entity.HasOne(d => d.MaDhNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaDh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDon__MaDH__797309D9");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDon__MaSP__7A672E12");
        });

        modelBuilder.Entity<ChiTietPhieuKho>(entity =>
        {
            entity.HasKey(e => new { e.MaPhieu, e.MaNl }).HasName("PK__ChiTietP__F412E293576EBA86");

            entity.ToTable("ChiTietPhieuKho");

            entity.Property(e => e.MaNl).HasColumnName("MaNL");
            entity.Property(e => e.GiaNhap).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.SoLuong).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaNlNavigation).WithMany(p => p.ChiTietPhieuKhos)
                .HasForeignKey(d => d.MaNl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__MaNL__7C4F7684");

            entity.HasOne(d => d.MaPhieuNavigation).WithMany(p => p.ChiTietPhieuKhos)
                .HasForeignKey(d => d.MaPhieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__628FA481");
        });

        modelBuilder.Entity<CongNo>(entity =>
        {
            entity.HasKey(e => e.MaCongNo).HasName("PK__CongNo__E452A01EDB7FDD8B");

            entity.ToTable("CongNo");

            entity.Property(e => e.DaTra).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayGhiNhan).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.CongNos)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CongNo__MaNcc__7D439ABD");

            entity.HasOne(d => d.MaPhieuNavigation).WithMany(p => p.CongNos)
                .HasForeignKey(d => d.MaPhieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CongNo__MaPhieu__7E37BEF6");
        });

        modelBuilder.Entity<DinhLuong>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.MaNl }).HasName("PK__DinhLuon__F557556F94E10163");

            entity.ToTable("DinhLuong");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.MaNl).HasColumnName("MaNL");
            entity.Property(e => e.SoLuongCan).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaNlNavigation).WithMany(p => p.DinhLuongs)
                .HasForeignKey(d => d.MaNl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DinhLuong__MaNL__7F2BE32F");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.DinhLuongs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DinhLuong__MaSP__00200768");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDh).HasName("PK__DonHang__27258661563C8A01");

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
                .HasConstraintName("FK__DonHang__MaKH__01142BA1");

            entity.HasOne(d => d.MaKmNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKm)
                .HasConstraintName("FK__DonHang__MaKM__02084FDA");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DonHang__MaNV__02FC7413");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E85F16B54");

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
            entity.HasKey(e => e.MaKm).HasName("PK__KhuyenMa__2725CF153F53F192");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKm).HasColumnName("MaKM");
            entity.Property(e => e.DoiTuongApDung).HasMaxLength(50);
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
                        .HasConstraintName("FK__KhuyenMai___MaSP__04E4BC85"),
                    l => l.HasOne<KhuyenMai>().WithMany()
                        .HasForeignKey("MaKm")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__KhuyenMai___MaKM__03F0984C"),
                    j =>
                    {
                        j.HasKey("MaKm", "MaSp").HasName("PK__KhuyenMa__F5579F944F0BAAA5");
                        j.ToTable("KhuyenMai_SanPham");
                        j.IndexerProperty<int>("MaKm").HasColumnName("MaKM");
                        j.IndexerProperty<int>("MaSp").HasColumnName("MaSP");
                    });
        });

        modelBuilder.Entity<NguyenLieu>(entity =>
        {
            entity.HasKey(e => e.MaNl).HasName("PK__NguyenLi__2725D73CEA261F17");

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
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEB5C879B09");

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
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A909DAF60");

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
            entity.HasKey(e => e.MaPhieuChi).HasName("PK__PhieuChi__00AC0F19CC27C7CB");

            entity.ToTable("PhieuChi");

            entity.Property(e => e.HinhThuc).HasMaxLength(50);
            entity.Property(e => e.LoaiChi).HasMaxLength(50);
            entity.Property(e => e.NgayChi).HasColumnType("datetime");
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaCongNoNavigation).WithMany(p => p.PhieuChis)
                .HasForeignKey(d => d.MaCongNo)
                .HasConstraintName("FK__PhieuChi__MaCong__05D8E0BE");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuChis)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuChi_NhanVien");

            entity.HasOne(d => d.MaPhieuNavigation).WithMany(p => p.PhieuChis)
                .HasForeignKey(d => d.MaPhieu)
                .HasConstraintName("FK__PhieuChi__MaPhie__06CD04F7");
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
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Hoàn thành");

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
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C161F026E");

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
            entity.HasKey(e => e.TenDangNhap).HasName("PK__TaiKhoan__55F68FC1A7B49436");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.MaNv, "UQ__TaiKhoan__2725D70BF91C2CDA").IsUnique();

            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MatKhau).HasMaxLength(256);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaNvNavigation).WithOne(p => p.TaiKhoan)
                .HasForeignKey<TaiKhoan>(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__MaNV__09A971A2");

            entity.HasOne(d => d.MaVaiTroNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaVaiTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__MaVaiT__0A9D95DB");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaTt).HasName("PK__ThanhToa__272500798DAEAB81");

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
                .HasConstraintName("FK__ThanhToan__MaDH__0B91BA14");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.MaVaiTro).HasName("PK__VaiTro__C24C41CF3FA677B8");

            entity.ToTable("VaiTro");

            entity.HasIndex(e => e.TenVaiTro, "UQ__VaiTro__1DA558146B947DA7").IsUnique();

            entity.Property(e => e.TenVaiTro).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
