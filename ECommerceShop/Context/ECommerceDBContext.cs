using System;
using System.Collections.Generic;
using ECommerceShop.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Context;

public partial class ECommerceDBContext : DbContext
{
    public ECommerceDBContext()
    {
    }

    public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BanBe> BanBes { get; set; }

    public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

    public virtual DbSet<ChuDe> ChuDes { get; set; }

    public virtual DbSet<GopY> Gopies { get; set; }

    public virtual DbSet<HangHoa> HangHoas { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoiDap> HoiDaps { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanCong> PhanCongs { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<TrangThai> TrangThais { get; set; }

    public virtual DbSet<TrangWeb> TrangWebs { get; set; }

    public virtual DbSet<VChiTietHoaDon> VChiTietHoaDons { get; set; }

    public virtual DbSet<YeuThich> YeuThiches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=104.154.151.51;Database=ECommerceShop;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=False;User ID=sqlserver;Password=Dinhbe30@");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanBe>(entity =>
        {
            entity.HasKey(e => e.MaBb).HasName("PK_Promotions");

            entity.Property(e => e.NgayGui).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.BanBes).HasConstraintName("FK_QuangBa_HangHoa");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.BanBes).HasConstraintName("FK_BanBe_KhachHang");
        });

        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => e.MaCt).HasName("PK_OrderDetails");

            entity.Property(e => e.SoLuong).HasDefaultValue(1);

            entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.ChiTietHds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<ChuDe>(entity =>
        {
            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.ChuDes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChuDe_NhanVien");
        });

        modelBuilder.Entity<GopY>(entity =>
        {
            entity.Property(e => e.NgayGy).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MaCdNavigation).WithMany(p => p.Gopies).HasConstraintName("FK_GopY_ChuDe");
        });

        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.HasKey(e => e.MaHh).HasName("PK_Products");

            entity.Property(e => e.DonGia).HasDefaultValue(0.0);
            entity.Property(e => e.NgaySx).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.HangHoas).HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.HangHoas).HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK_Orders");

            entity.Property(e => e.CachThanhToan).HasDefaultValue("Cash");
            entity.Property(e => e.CachVanChuyen).HasDefaultValue("Airline");
            entity.Property(e => e.NgayCan).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayDat).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayGiao).HasDefaultValueSql("(((1)/(1))/(1900))");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons).HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HoaDon_NhanVien");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.HoaDons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_TrangThai");
        });

        modelBuilder.Entity<HoiDap>(entity =>
        {
            entity.Property(e => e.MaHd).ValueGeneratedNever();
            entity.Property(e => e.NgayDua).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoiDaps).HasConstraintName("FK_HoiDap_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK_Customers");

            entity.Property(e => e.Hinh).HasDefaultValue("Photo.gif");
            entity.Property(e => e.NgaySinh).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK_Categories");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK_Suppliers");
        });

        modelBuilder.Entity<PhanCong>(entity =>
        {
            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhanCongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanCong_NhanVien");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.PhanCongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanCong_PhongBan");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.PhanQuyens).HasConstraintName("FK_PhanQuyen_PhongBan");

            entity.HasOne(d => d.MaTrangNavigation).WithMany(p => p.PhanQuyens).HasConstraintName("FK_PhanQuyen_TrangWeb");
        });

        modelBuilder.Entity<TrangThai>(entity =>
        {
            entity.Property(e => e.MaTrangThai).ValueGeneratedNever();
        });

        modelBuilder.Entity<VChiTietHoaDon>(entity =>
        {
            entity.ToView("vChiTietHoaDon");
        });

        modelBuilder.Entity<YeuThich>(entity =>
        {
            entity.HasKey(e => e.MaYt).HasName("PK_Favorites");

            entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.YeuThiches)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_YeuThich_HangHoa");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.YeuThiches)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Favorites_Customers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
