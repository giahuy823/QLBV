using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLBV.Models.User_Model;

namespace QLBV.Models;

public partial class QLBVContext : IdentityDbContext<ApplicationUser>
{
    public QLBVContext(DbContextOptions<QLBVContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchiveNhanVien> ArchiveNhanViens { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<BacSi> BacSis { get; set; }

    public virtual DbSet<BacSiArchive> BacSiArchives { get; set; }

    public virtual DbSet<BenhNhan> BenhNhans { get; set; }

    public virtual DbSet<BenhNhanArchive> BenhNhanArchives { get; set; }

    public virtual DbSet<BoPhan> BoPhans { get; set; }

    public virtual DbSet<BoPhanArchive> BoPhanArchives { get; set; }

    public virtual DbSet<CaTruc> CaTrucs { get; set; }

    public virtual DbSet<CaTrucArchive> CaTrucArchives { get; set; }

    public virtual DbSet<ChiTietPhieuKham> ChiTietPhieuKhams { get; set; }

    public virtual DbSet<ChiTietPhieuKhamArchive> ChiTietPhieuKhamArchives { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<ChiTietPhieuNhapArchive> ChiTietPhieuNhapArchives { get; set; }

    public virtual DbSet<ChiTietToaThuoc> ChiTietToaThuocs { get; set; }

    public virtual DbSet<ChiTietToaThuocArchive> ChiTietToaThuocArchives { get; set; }

    public virtual DbSet<GiaBanThuoc> GiaBanThuocs { get; set; }

    public virtual DbSet<GiaBanThuocArchive> GiaBanThuocArchives { get; set; }

    public virtual DbSet<Luong> Luongs { get; set; }

    public virtual DbSet<LuongArchive> LuongArchives { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuKhamBenh> PhieuKhamBenhs { get; set; }

    public virtual DbSet<PhieuKhamBenhArchive> PhieuKhamBenhArchives { get; set; }

    public virtual DbSet<PhieuNhapThuoc> PhieuNhapThuocs { get; set; }

    public virtual DbSet<PhieuNhapThuocArchive> PhieuNhapThuocArchives { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<PhongBanArchive> PhongBanArchives { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TaiKhoanArchive> TaiKhoanArchives { get; set; }

    public virtual DbSet<ThuTuc> ThuTucs { get; set; }

    public virtual DbSet<ThuTucArchive> ThuTucArchives { get; set; }

    public virtual DbSet<Thuoc> Thuocs { get; set; }

    public virtual DbSet<ThuocArchive> ThuocArchives { get; set; }

    public virtual DbSet<ToaThuoc> ToaThuocs { get; set; }

    public virtual DbSet<ToaThuocArchive> ToaThuocArchives { get; set; }
    public virtual DbSet<SoKhamBenh> SoKhamBenhs { get; set; }
    public virtual DbSet<SoKhamBenhArchive> SoKhamBenhArchives { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("Server=DESKTOP-K2QLVK4;Database=QLBV;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ArchiveNhanVien>(entity =>
        {
            entity.HasKey(e => e.ArchiveId).HasName("PK__Archive___33A73E7754E8CA88");

            entity.Property(e => e.ArchivedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Audit_Lo__3214EC27BF5897A4");

            entity.Property(e => e.ActionTime).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BacSi>(entity =>
        {
            entity.HasKey(e => e.MaBs).HasName("PK__BacSi__27247596C0E20624");

            entity.HasOne(d => d.MaBsNavigation).WithOne(p => p.BacSi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BacSi__TrinhDo__412EB0B6");
        });

        modelBuilder.Entity<BacSiArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BenhNhan>(entity =>
        {
            entity.HasKey(e => e.MaBn).HasName("PK__BenhNhan__272475ADE7DE9241");
        });

        modelBuilder.Entity<BenhNhanArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BoPhan>(entity =>
        {
            entity.HasKey(e => e.MaBp).HasName("PK__BoPhan__272475ABE52F0BF5");
        });

        modelBuilder.Entity<BoPhanArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<CaTruc>(entity =>
        {
            entity.HasKey(e => e.MaCt).HasName("PK__CaTruc__27258E740132F318");

            entity.HasOne(d => d.NvtrucNavigation).WithMany(p => p.CaTrucs).HasConstraintName("FK__CaTruc__NVtruc__440B1D61");
        });

        modelBuilder.Entity<CaTrucArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ChiTietPhieuKham>(entity =>
        {
            entity.HasOne(d => d.MaPkNavigation).WithMany().HasConstraintName("FK__ChiTietPhi__MaPK__534D60F1");

            entity.HasOne(d => d.MaTtNavigation).WithMany().HasConstraintName("FK__ChiTietPhi__MaTT__5441852A");
        });

        modelBuilder.Entity<ChiTietPhieuKhamArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ChiTietPhieuKham>()
            .HasKey(c => new { c.MaPk, c.MaTt });



        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaPhieuNhap, e.MaThuoc }).HasName("PK__ChiTietP__00CBF05937EC544E");

            entity.HasOne(d => d.MaPhieuNhapNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__6754599E");

            entity.HasOne(d => d.MaThuocNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaThu__68487DD7");
        });

        modelBuilder.Entity<ChiTietPhieuNhapArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });
        modelBuilder.Entity<ChiTietToaThuoc>()
          .HasKey(ct => new { ct.MaToaThuoc, ct.MaThuoc });

        modelBuilder.Entity<ChiTietToaThuoc>(entity =>
        {
            entity.HasOne(d => d.MaThuocNavigation).WithMany().HasConstraintName("FK__ChiTietTo__MaThu__628FA481");

            entity.HasOne(d => d.MaToaThuocNavigation).WithMany().HasConstraintName("FK__ChiTietTo__MaToa__619B8048");
        });
        //Testing
        modelBuilder.Entity<ToaThuoc>()
        .HasOne(t => t.MaPkNavigation)
        .WithOne(p => p.ToaThuoc)
        .HasForeignKey<ToaThuoc>(t => t.MaPk)
        .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ChiTietToaThuocArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<GiaBanThuoc>(entity =>
        {
            entity.HasKey(e => new { e.MaThuoc, e.NgayApDung }).HasName("PK__GiaBanTh__1E11655E12D3EF1E");

            entity.HasOne(d => d.MaThuocNavigation).WithMany(p => p.GiaBanThuocs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GiaBanThu__MaThu__6B24EA82");
        });

        modelBuilder.Entity<GiaBanThuocArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK__Luong__6609A48D447B4DD4");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Luongs).HasConstraintName("FK__Luong__MaNV__5812160E");
        });

        modelBuilder.Entity<LuongArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A3933CAA9");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.NhanViens).HasConstraintName("FK__NhanVien__MaPB__3E52440B");
        });

        modelBuilder.Entity<PhieuKhamBenh>(entity =>
        {
            entity.HasKey(e => e.MaPk).HasName("PK__PhieuKha__2725E7FD2B331110");

            entity.HasOne(d => d.BacsiNavigation).WithMany(p => p.PhieuKhamBenhs).HasConstraintName("FK__PhieuKham__Bacsi__4AB81AF0");

            entity.HasOne(d => d.NguoiKhamNavigation).WithMany(p => p.PhieuKhamBenhs).HasConstraintName("FK__PhieuKham__Nguoi__4BAC3F29");
        });

        modelBuilder.Entity<PhieuKhamBenhArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<PhieuNhapThuoc>(entity =>
        {
            entity.HasKey(e => e.MaPhieuNhap).HasName("PK__PhieuNha__1470EF3B4153D383");

            entity.ToTable("PhieuNhapThuoc", tb => tb.HasTrigger("trg_Audit_PhieuNhapThuoc"));
        });

        modelBuilder.Entity<PhieuNhapThuocArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPb).HasName("PK__PhongBan__2725E7E43C0AFEA3");

            entity.HasOne(d => d.MaBpNavigation).WithMany(p => p.PhongBans).HasConstraintName("FK__PhongBan__MoTa__3B75D760");
        });

        modelBuilder.Entity<PhongBanArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTk).HasName("PK__TaiKhoan__272500700D0EAAA4");

            entity.ToTable("TaiKhoan", tb => tb.HasTrigger("trg_Audit_TaiKhoan_InsertUpdate"));

            entity.HasOne(d => d.MaNvNavigation).WithOne(p => p.TaiKhoan).HasConstraintName("FK__TaiKhoan__MaNV__47DBAE45");
        });

        modelBuilder.Entity<TaiKhoanArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ThuTuc>(entity =>
        {
            entity.HasKey(e => e.MaThuTuc).HasName("PK__ThuTuc__3A19BB26367D849A");
        });

        modelBuilder.Entity<ThuTucArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Thuoc>(entity =>
        {
            entity.HasKey(e => e.MaThuoc).HasName("PK__Thuoc__4BB1F62060EBE1A0");
        });

        modelBuilder.Entity<ThuocArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ToaThuoc>(entity =>
        {
            entity.HasKey(e => e.MaToaThuoc).HasName("PK__ToaThuoc__6C278B89C44EA347");

            entity.HasOne(d => d.MaBacSiNavigation).WithMany(p => p.ToaThuocs).HasConstraintName("FK__ToaThuoc__MaBacS__5AEE82B9");
        });

        modelBuilder.Entity<ToaThuocArchive>(entity =>
        {
            entity.Property(e => e.ArchiveDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(u => u.NhanVien)
            .WithOne(nv => nv.User)
            .HasForeignKey<ApplicationUser>(u => u.MaNv)
            .OnDelete(DeleteBehavior.SetNull);

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // BoPhan
        modelBuilder.Entity<BoPhan>().HasData(
            new BoPhan { MaBp = "BPQL", TenBoPhan = "Bộ phận quản lý" },
            new BoPhan { MaBp = "BPTTDP", TenBoPhan = "Bộ phận tiếp tân và điều phối" },
            new BoPhan { MaBp = "BPDT", TenBoPhan = "Bộ phận điều trị" },
            new BoPhan { MaBp = "BPTV", TenBoPhan = "Bộ phận tài vụ" },
            new BoPhan { MaBp = "BPKT", TenBoPhan = "Bộ phận kế toán" },
            new BoPhan { MaBp = "BPDNT", TenBoPhan = "Bộ phận dược – nhà thuốc" }
        );

        // PhongBan
        modelBuilder.Entity<PhongBan>().HasData(
            new PhongBan { MaPb = "PBQLNS", MaBp = "BPQL", TenPhongBan = "Phòng quản lý tài nguyên nhân sự", MoTa = null },
            new PhongBan { MaPb = "PBQLTV", MaBp = "BPQL", TenPhongBan = "Phòng quản lý tài vụ", MoTa = null },
            new PhongBan { MaPb = "PBQLCM", MaBp = "BPQL", TenPhongBan = "Phòng quản lý chuyên môn", MoTa = null },
            new PhongBan { MaPb = "PBTTDP", MaBp = "BPTTDP", TenPhongBan = "Phòng tiếp tân và điều phối", MoTa = null },
            new PhongBan { MaPb = "PBKN", MaBp = "BPDT", TenPhongBan = "Phòng khoa nội", MoTa = null },
            new PhongBan { MaPb = "PBKG", MaBp = "BPDT", TenPhongBan = "Phòng khoa ngoại", MoTa = null },
            new PhongBan { MaPb = "PBKNHI", MaBp = "BPDT", TenPhongBan = "Phòng khoa nhi", MoTa = null },
            new PhongBan { MaPb = "PBTTV", MaBp = "BPTV", TenPhongBan = "Phòng tài vụ", MoTa = null },
            new PhongBan { MaPb = "PBKT", MaBp = "BPKT", TenPhongBan = "Phòng kế toán", MoTa = null },
            new PhongBan { MaPb = "PBBT", MaBp = "BPDNT", TenPhongBan = "Phòng bán thuốc", MoTa = null }
        );

        // ThuTuc
        modelBuilder.Entity<ThuTuc>().HasData(
            new ThuTuc { MaThuTuc = "TT001", TenTuc = "Khám tổng quát", DonGia = 150000.00M },
            new ThuTuc { MaThuTuc = "TT002", TenTuc = "Xét nghiệm máu", DonGia = 80000.00M },
            new ThuTuc { MaThuTuc = "TT003", TenTuc = "Chụp X-quang phổi", DonGia = 120000.00M },
            new ThuTuc { MaThuTuc = "TT004", TenTuc = "Siêu âm bụng tổng quát", DonGia = 200000.00M },
            new ThuTuc { MaThuTuc = "TT005", TenTuc = "Đo điện tim (ECG)", DonGia = 100000.00M },
            new ThuTuc { MaThuTuc = "TT006", TenTuc = "Khám tai mũi họng", DonGia = 90000.00M },
            new ThuTuc { MaThuTuc = "TT007", TenTuc = "Nội soi dạ dày", DonGia = 350000.00M },
            new ThuTuc { MaThuTuc = "TT008", TenTuc = "Xét nghiệm nước tiểu", DonGia = 50000.00M },
            new ThuTuc { MaThuTuc = "TT009", TenTuc = "Tiêm ngừa cúm", DonGia = 70000.00M },
            new ThuTuc { MaThuTuc = "TT010", TenTuc = "Khám chuyên khoa tim mạch", DonGia = 250000.00M }
        );

        // Thuoc
        modelBuilder.Entity<Thuoc>().HasData(
            new Thuoc { MaThuoc = "TH001", TenThuoc = "Paracetamol 500mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH002", TenThuoc = "Amoxicillin 500mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH003", TenThuoc = "Vitamin C 500mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH004", TenThuoc = "Ibuprofen 200mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH005", TenThuoc = "Loratadine 10mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH006", TenThuoc = "Omeprazole 20mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH007", TenThuoc = "Salbutamol 2mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH008", TenThuoc = "Cefixime 200mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH009", TenThuoc = "Metronidazole 250mg", DonVi = "Vỉ" },
            new Thuoc { MaThuoc = "TH010", TenThuoc = "Dextromethorphan 15mg", DonVi = "Vỉ" }
        );

        // GiaBanThuoc
        modelBuilder.Entity<GiaBanThuoc>().HasData(
            new GiaBanThuoc { MaThuoc = "TH001", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 15000 },
            new GiaBanThuoc { MaThuoc = "TH002", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 35000 },
            new GiaBanThuoc { MaThuoc = "TH003", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 20000 },
            new GiaBanThuoc { MaThuoc = "TH004", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 18000 },
            new GiaBanThuoc { MaThuoc = "TH005", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 22000 },
            new GiaBanThuoc { MaThuoc = "TH006", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 28000 },
            new GiaBanThuoc { MaThuoc = "TH007", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 16000 },
            new GiaBanThuoc { MaThuoc = "TH008", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 40000 },
            new GiaBanThuoc { MaThuoc = "TH009", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 25000 },
            new GiaBanThuoc { MaThuoc = "TH010", NgayApDung = new DateOnly(2025, 5, 1), GiaBan = 19000 }
        );

        // NhanVien
        modelBuilder.Entity<NhanVien>().HasData(
            new NhanVien
            {
                MaNv = "BS001",
                HoTenNv = "Nguyễn Hoàng Phong",
                NgaySinh = new DateOnly(1980, 11, 15),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0987123456",
                MaPb = "PBKN"
            },
            new NhanVien
            {
                MaNv = "BS002",
                HoTenNv = "Nguyễn Quang Ngọc",
                NgaySinh = new DateOnly(1975, 8, 22),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0912345678",
                MaPb = "PBKG"
            },
            new NhanVien
            {
                MaNv = "BS003",
                HoTenNv = "Nguyễn Trần Gia Huy",
                NgaySinh = new DateOnly(1982, 3, 30),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0978123456",
                MaPb = "PBKNHI"
            },

            new NhanVien
            {
                MaNv = "NV001",
                HoTenNv = "Lê Nguyễn Minh Hoàng",
                NgaySinh = new DateOnly(1982, 3, 30),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0978123456",
                MaPb = "PBQLNS"
            },

            new NhanVien
            {
                MaNv = "NV002",
                HoTenNv = "Phan Võ Anh Hào",
                NgaySinh = new DateOnly(1982, 3, 30),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0978123456",
                MaPb = "PBQLTV"
            },

            new NhanVien
            {
                MaNv = "NV003",
                HoTenNv = "Quách Tuấn Anh",
                NgaySinh = new DateOnly(1982, 3, 30),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0978123456",
                MaPb = "PBQLCM"
            },

            new NhanVien
            {
                MaNv = "NV004",
                HoTenNv = "Nguyễn Văn A",
                NgaySinh = new DateOnly(1982, 3, 30),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0978123456",
                MaPb = "PBTTDP"
            },

            new NhanVien
            {
                MaNv = "NV005",
                HoTenNv = "Nguyễn Văn B",
                NgaySinh = new DateOnly(1982, 3, 30),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0978123456",
                MaPb = "PBTTV"
            },

            new NhanVien
            {
                MaNv = "NV006",
                HoTenNv = "Trần Thị C",
                NgaySinh = new DateOnly(1982, 3, 30),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0978123456",
                MaPb = "PBKT"
            },

            new NhanVien
            {
                MaNv = "NV007",
                HoTenNv = "Lê Văn D",
                NgaySinh = new DateOnly(1982, 3, 30),
                GioiTinh = "Nam",
                DiaChi = "Hà Nội",
                Sdt = "0978123456",
                MaPb = "PBBT"
            }

        );

        // BacSi
        modelBuilder.Entity<BacSi>().HasData(
            new BacSi { MaBs = "BS001", TrinhDo = "Tiến sĩ Y khoa" },
            new BacSi { MaBs = "BS002", TrinhDo = "Phó Giáo sư, Tiến sĩ" },
            new BacSi { MaBs = "BS003", TrinhDo = "Bác sĩ Chuyên khoa II" }
        );
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
