using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QLBV.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archive_NhanVien",
                columns: table => new
                {
                    ArchiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoTenNV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LoaiNhanVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaPB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Archive___33A73E7754E8CA88", x => x.ArchiveID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audit_Log",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RecordID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    PerformedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Audit_Lo__3214EC27BF5897A4", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BacSi_Archive",
                columns: table => new
                {
                    MaBS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrinhDo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BenhNhan",
                columns: table => new
                {
                    MaBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HoTenBN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BenhNhan__272475ADE7DE9241", x => x.MaBN);
                });

            migrationBuilder.CreateTable(
                name: "BenhNhan_Archive",
                columns: table => new
                {
                    MaBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoTenBN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BoPhan",
                columns: table => new
                {
                    MaBP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenBoPhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BoPhan__272475ABE52F0BF5", x => x.MaBP);
                });

            migrationBuilder.CreateTable(
                name: "BoPhan_Archive",
                columns: table => new
                {
                    MaBP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenBoPhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CaTruc_Archive",
                columns: table => new
                {
                    MaCT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThoiGianBT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThoiGianKT = table.Column<DateTime>(type: "datetime", nullable: true),
                    NVtruc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuKham_Archive",
                columns: table => new
                {
                    MaPK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaTT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TTThanhToan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhap_Archive",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaNhap = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    HanSuDung = table.Column<DateOnly>(type: "date", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ChiTietToaThuoc_Archive",
                columns: table => new
                {
                    MaToaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LieuDung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GiaBanThuoc_Archive",
                columns: table => new
                {
                    MaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayApDung = table.Column<DateOnly>(type: "date", nullable: true),
                    GiaBan = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Luong_Archive",
                columns: table => new
                {
                    MaLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    LuongCoBan = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: true),
                    PhuCap = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NgayCong = table.Column<int>(type: "int", nullable: true),
                    TongLuong = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PhieuKhamBenh_Archive",
                columns: table => new
                {
                    MaPK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrieuChung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayKham = table.Column<DateOnly>(type: "date", nullable: true),
                    NguoiKham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bacsi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhapThuoc",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayNhap = table.Column<DateOnly>(type: "date", nullable: true),
                    NhaCungCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhieuNha__1470EF3B4153D383", x => x.MaPhieuNhap);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhapThuoc_Archive",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayNhap = table.Column<DateOnly>(type: "date", nullable: true),
                    NhaCungCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PhongBan_Archive",
                columns: table => new
                {
                    MaPB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaBP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenPhongBan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "text", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan_Archive",
                columns: table => new
                {
                    MaTK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MK = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: true),
                    LoaiTK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Thuoc",
                columns: table => new
                {
                    MaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenThuoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Thuoc__4BB1F62060EBE1A0", x => x.MaThuoc);
                });

            migrationBuilder.CreateTable(
                name: "Thuoc_Archive",
                columns: table => new
                {
                    MaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenThuoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ThuTuc",
                columns: table => new
                {
                    MaThuTuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenTuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ThuTuc__3A19BB26367D849A", x => x.MaThuTuc);
                });

            migrationBuilder.CreateTable(
                name: "ThuTuc_Archive",
                columns: table => new
                {
                    MaThuTuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenTuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ToaThuoc_Archive",
                columns: table => new
                {
                    MaToaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaBacSi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaPk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayKe = table.Column<DateOnly>(type: "date", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ActionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoKhamBenh",
                columns: table => new
                {
                    MaSoKham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaPK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoKhamBenh", x => x.MaSoKham);
                    table.ForeignKey(
                        name: "FK_SoKhamBenh_BenhNhan_MaBN",
                        column: x => x.MaBN,
                        principalTable: "BenhNhan",
                        principalColumn: "MaBN");
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    MaPB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaBP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenPhongBan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhongBan__2725E7E43C0AFEA3", x => x.MaPB);
                    table.ForeignKey(
                        name: "FK__PhongBan__MoTa__3B75D760",
                        column: x => x.MaBP,
                        principalTable: "BoPhan",
                        principalColumn: "MaBP");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhap",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaNhap = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    HanSuDung = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietP__00CBF05937EC544E", x => new { x.MaPhieuNhap, x.MaThuoc });
                    table.ForeignKey(
                        name: "FK__ChiTietPh__MaPhi__6754599E",
                        column: x => x.MaPhieuNhap,
                        principalTable: "PhieuNhapThuoc",
                        principalColumn: "MaPhieuNhap");
                    table.ForeignKey(
                        name: "FK__ChiTietPh__MaThu__68487DD7",
                        column: x => x.MaThuoc,
                        principalTable: "Thuoc",
                        principalColumn: "MaThuoc");
                });

            migrationBuilder.CreateTable(
                name: "GiaBanThuoc",
                columns: table => new
                {
                    MaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayApDung = table.Column<DateOnly>(type: "date", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GiaBanTh__1E11655E12D3EF1E", x => new { x.MaThuoc, x.NgayApDung });
                    table.ForeignKey(
                        name: "FK__GiaBanThu__MaThu__6B24EA82",
                        column: x => x.MaThuoc,
                        principalTable: "Thuoc",
                        principalColumn: "MaThuoc");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HoTenNV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaPB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__2725D70A3933CAA9", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK__NhanVien__MaPB__3E52440B",
                        column: x => x.MaPB,
                        principalTable: "PhongBan",
                        principalColumn: "MaPB");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNv = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_NhanVien_MaNv",
                        column: x => x.MaNv,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BacSi",
                columns: table => new
                {
                    MaBS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrinhDo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BacSi__27247596C0E20624", x => x.MaBS);
                    table.ForeignKey(
                        name: "FK__BacSi__TrinhDo__412EB0B6",
                        column: x => x.MaBS,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "CaTruc",
                columns: table => new
                {
                    MaCT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThoiGianBT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThoiGianKT = table.Column<DateTime>(type: "datetime", nullable: true),
                    NVtruc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CaTruc__27258E740132F318", x => x.MaCT);
                    table.ForeignKey(
                        name: "FK__CaTruc__NVtruc__440B1D61",
                        column: x => x.NVtruc,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    MaLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    LuongCoBan = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: true),
                    PhuCap = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NgayCong = table.Column<int>(type: "int", nullable: true),
                    TongLuong = table.Column<decimal>(type: "decimal(20,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Luong__6609A48D447B4DD4", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK__Luong__MaNV__5812160E",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MK = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: true),
                    LoaiTK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaiKhoan__272500700D0EAAA4", x => x.MaTK);
                    table.ForeignKey(
                        name: "FK__TaiKhoan__MaNV__47DBAE45",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuKhamBenh",
                columns: table => new
                {
                    MaPK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrieuChung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayKham = table.Column<DateOnly>(type: "date", nullable: true),
                    NguoiKham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bacsi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaSoKham = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhieuKha__2725E7FD2B331110", x => x.MaPK);
                    table.ForeignKey(
                        name: "FK_PhieuKhamBenh_SoKhamBenh_MaSoKham",
                        column: x => x.MaSoKham,
                        principalTable: "SoKhamBenh",
                        principalColumn: "MaSoKham");
                    table.ForeignKey(
                        name: "FK__PhieuKham__Bacsi__4AB81AF0",
                        column: x => x.Bacsi,
                        principalTable: "BacSi",
                        principalColumn: "MaBS");
                    table.ForeignKey(
                        name: "FK__PhieuKham__Nguoi__4BAC3F29",
                        column: x => x.NguoiKham,
                        principalTable: "BenhNhan",
                        principalColumn: "MaBN");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuKham",
                columns: table => new
                {
                    MaPK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaTT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TTThanhToan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuKham", x => new { x.MaPK, x.MaTT });
                    table.ForeignKey(
                        name: "FK__ChiTietPhi__MaPK__534D60F1",
                        column: x => x.MaPK,
                        principalTable: "PhieuKhamBenh",
                        principalColumn: "MaPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ChiTietPhi__MaTT__5441852A",
                        column: x => x.MaTT,
                        principalTable: "ThuTuc",
                        principalColumn: "MaThuTuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToaThuoc",
                columns: table => new
                {
                    MaToaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaBacSi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayKe = table.Column<DateOnly>(type: "date", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MaPk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ToaThuoc__6C278B89C44EA347", x => x.MaToaThuoc);
                    table.ForeignKey(
                        name: "FK_ToaThuoc_PhieuKhamBenh_MaPk",
                        column: x => x.MaPk,
                        principalTable: "PhieuKhamBenh",
                        principalColumn: "MaPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ToaThuoc__MaBacS__5AEE82B9",
                        column: x => x.MaBacSi,
                        principalTable: "BacSi",
                        principalColumn: "MaBS");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietToaThuoc",
                columns: table => new
                {
                    MaToaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LieuDung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietToaThuoc", x => new { x.MaToaThuoc, x.MaThuoc });
                    table.ForeignKey(
                        name: "FK__ChiTietTo__MaThu__628FA481",
                        column: x => x.MaThuoc,
                        principalTable: "Thuoc",
                        principalColumn: "MaThuoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ChiTietTo__MaToa__619B8048",
                        column: x => x.MaToaThuoc,
                        principalTable: "ToaThuoc",
                        principalColumn: "MaToaThuoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BoPhan",
                columns: new[] { "MaBP", "TenBoPhan" },
                values: new object[,]
                {
                    { "BPDNT", "Bộ phận dược – nhà thuốc" },
                    { "BPDT", "Bộ phận điều trị" },
                    { "BPKT", "Bộ phận kế toán" },
                    { "BPQL", "Bộ phận quản lý" },
                    { "BPTTDP", "Bộ phận tiếp tân và điều phối" },
                    { "BPTV", "Bộ phận tài vụ" }
                });

            migrationBuilder.InsertData(
                table: "ThuTuc",
                columns: new[] { "MaThuTuc", "DonGia", "TenTuc" },
                values: new object[,]
                {
                    { "TT001", 150000.00m, "Khám tổng quát" },
                    { "TT002", 80000.00m, "Xét nghiệm máu" },
                    { "TT003", 120000.00m, "Chụp X-quang phổi" },
                    { "TT004", 200000.00m, "Siêu âm bụng tổng quát" },
                    { "TT005", 100000.00m, "Đo điện tim (ECG)" },
                    { "TT006", 90000.00m, "Khám tai mũi họng" },
                    { "TT007", 350000.00m, "Nội soi dạ dày" },
                    { "TT008", 50000.00m, "Xét nghiệm nước tiểu" },
                    { "TT009", 70000.00m, "Tiêm ngừa cúm" },
                    { "TT010", 250000.00m, "Khám chuyên khoa tim mạch" }
                });

            migrationBuilder.InsertData(
                table: "Thuoc",
                columns: new[] { "MaThuoc", "DonVi", "TenThuoc" },
                values: new object[,]
                {
                    { "TH001", "Vỉ", "Paracetamol 500mg" },
                    { "TH002", "Vỉ", "Amoxicillin 500mg" },
                    { "TH003", "Vỉ", "Vitamin C 500mg" },
                    { "TH004", "Vỉ", "Ibuprofen 200mg" },
                    { "TH005", "Vỉ", "Loratadine 10mg" },
                    { "TH006", "Vỉ", "Omeprazole 20mg" },
                    { "TH007", "Vỉ", "Salbutamol 2mg" },
                    { "TH008", "Vỉ", "Cefixime 200mg" },
                    { "TH009", "Vỉ", "Metronidazole 250mg" },
                    { "TH010", "Vỉ", "Dextromethorphan 15mg" }
                });

            migrationBuilder.InsertData(
                table: "GiaBanThuoc",
                columns: new[] { "MaThuoc", "NgayApDung", "GiaBan" },
                values: new object[,]
                {
                    { "TH001", new DateOnly(2025, 5, 1), 15000m },
                    { "TH002", new DateOnly(2025, 5, 1), 35000m },
                    { "TH003", new DateOnly(2025, 5, 1), 20000m },
                    { "TH004", new DateOnly(2025, 5, 1), 18000m },
                    { "TH005", new DateOnly(2025, 5, 1), 22000m },
                    { "TH006", new DateOnly(2025, 5, 1), 28000m },
                    { "TH007", new DateOnly(2025, 5, 1), 16000m },
                    { "TH008", new DateOnly(2025, 5, 1), 40000m },
                    { "TH009", new DateOnly(2025, 5, 1), 25000m },
                    { "TH010", new DateOnly(2025, 5, 1), 19000m }
                });

            migrationBuilder.InsertData(
                table: "PhongBan",
                columns: new[] { "MaPB", "MaBP", "MoTa", "TenPhongBan" },
                values: new object[,]
                {
                    { "PBBT", "BPDNT", null, "Phòng bán thuốc" },
                    { "PBKG", "BPDT", null, "Phòng khoa ngoại" },
                    { "PBKN", "BPDT", null, "Phòng khoa nội" },
                    { "PBKNHI", "BPDT", null, "Phòng khoa nhi" },
                    { "PBKT", "BPKT", null, "Phòng kế toán" },
                    { "PBQLCM", "BPQL", null, "Phòng quản lý chuyên môn" },
                    { "PBQLNS", "BPQL", null, "Phòng quản lý tài nguyên nhân sự" },
                    { "PBQLTV", "BPQL", null, "Phòng quản lý tài vụ" },
                    { "PBTTDP", "BPTTDP", null, "Phòng tiếp tân và điều phối" },
                    { "PBTTV", "BPTV", null, "Phòng tài vụ" }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "MaNV", "DiaChi", "GioiTinh", "HoTenNV", "MaPB", "NgaySinh", "SDT" },
                values: new object[,]
                {
                    { "BS001", "Hà Nội", "Nam", "Nguyễn Hoàng Phong", "PBKN", new DateOnly(1980, 11, 15), "0987123456" },
                    { "BS002", "Hà Nội", "Nam", "Nguyễn Quang Ngọc", "PBKG", new DateOnly(1975, 8, 22), "0912345678" },
                    { "BS003", "Hà Nội", "Nam", "Nguyễn Trần Gia Huy", "PBKNHI", new DateOnly(1982, 3, 30), "0978123456" },
                    { "NV001", "Hà Nội", "Nam", "Lê Nguyễn Minh Hoàng", "PBQLNS", new DateOnly(1982, 3, 30), "0978123456" },
                    { "NV002", "Hà Nội", "Nam", "Phan Võ Anh Hào", "PBQLTV", new DateOnly(1982, 3, 30), "0978123456" },
                    { "NV003", "Hà Nội", "Nam", "Quách Tuấn Anh", "PBQLCM", new DateOnly(1982, 3, 30), "0978123456" },
                    { "NV004", "Hà Nội", "Nam", "Nguyễn Văn A", "PBTTDP", new DateOnly(1982, 3, 30), "0978123456" },
                    { "NV005", "Hà Nội", "Nam", "Nguyễn Văn B", "PBTTV", new DateOnly(1982, 3, 30), "0978123456" },
                    { "NV006", "Hà Nội", "Nam", "Trần Thị C", "PBKT", new DateOnly(1982, 3, 30), "0978123456" },
                    { "NV007", "Hà Nội", "Nam", "Lê Văn D", "PBBT", new DateOnly(1982, 3, 30), "0978123456" }
                });

            migrationBuilder.InsertData(
                table: "BacSi",
                columns: new[] { "MaBS", "TrinhDo" },
                values: new object[,]
                {
                    { "BS001", "Tiến sĩ Y khoa" },
                    { "BS002", "Phó Giáo sư, Tiến sĩ" },
                    { "BS003", "Bác sĩ Chuyên khoa II" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaNv",
                table: "AspNetUsers",
                column: "MaNv",
                unique: true,
                filter: "[MaNv] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CaTruc_NVtruc",
                table: "CaTruc",
                column: "NVtruc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuKham_MaTT",
                table: "ChiTietPhieuKham",
                column: "MaTT");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_MaThuoc",
                table: "ChiTietPhieuNhap",
                column: "MaThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietToaThuoc_MaThuoc",
                table: "ChiTietToaThuoc",
                column: "MaThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_MaNV",
                table: "Luong",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaPB",
                table: "NhanVien",
                column: "MaPB");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhamBenh_Bacsi",
                table: "PhieuKhamBenh",
                column: "Bacsi");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhamBenh_MaSoKham",
                table: "PhieuKhamBenh",
                column: "MaSoKham");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKhamBenh_NguoiKham",
                table: "PhieuKhamBenh",
                column: "NguoiKham");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBan_MaBP",
                table: "PhongBan",
                column: "MaBP");

            migrationBuilder.CreateIndex(
                name: "IX_SoKhamBenh_MaBN",
                table: "SoKhamBenh",
                column: "MaBN");

            migrationBuilder.CreateIndex(
                name: "UQ__TaiKhoan__2725D70B0150A028",
                table: "TaiKhoan",
                column: "MaNV",
                unique: true,
                filter: "[MaNV] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ToaThuoc_MaBacSi",
                table: "ToaThuoc",
                column: "MaBacSi");

            migrationBuilder.CreateIndex(
                name: "IX_ToaThuoc_MaPk",
                table: "ToaThuoc",
                column: "MaPk",
                unique: true,
                filter: "[MaPk] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archive_NhanVien");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Audit_Log");

            migrationBuilder.DropTable(
                name: "BacSi_Archive");

            migrationBuilder.DropTable(
                name: "BenhNhan_Archive");

            migrationBuilder.DropTable(
                name: "BoPhan_Archive");

            migrationBuilder.DropTable(
                name: "CaTruc");

            migrationBuilder.DropTable(
                name: "CaTruc_Archive");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuKham");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuKham_Archive");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhap");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhap_Archive");

            migrationBuilder.DropTable(
                name: "ChiTietToaThuoc");

            migrationBuilder.DropTable(
                name: "ChiTietToaThuoc_Archive");

            migrationBuilder.DropTable(
                name: "GiaBanThuoc");

            migrationBuilder.DropTable(
                name: "GiaBanThuoc_Archive");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "Luong_Archive");

            migrationBuilder.DropTable(
                name: "PhieuKhamBenh_Archive");

            migrationBuilder.DropTable(
                name: "PhieuNhapThuoc_Archive");

            migrationBuilder.DropTable(
                name: "PhongBan_Archive");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "TaiKhoan_Archive");

            migrationBuilder.DropTable(
                name: "Thuoc_Archive");

            migrationBuilder.DropTable(
                name: "ThuTuc_Archive");

            migrationBuilder.DropTable(
                name: "ToaThuoc_Archive");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ThuTuc");

            migrationBuilder.DropTable(
                name: "PhieuNhapThuoc");

            migrationBuilder.DropTable(
                name: "ToaThuoc");

            migrationBuilder.DropTable(
                name: "Thuoc");

            migrationBuilder.DropTable(
                name: "PhieuKhamBenh");

            migrationBuilder.DropTable(
                name: "SoKhamBenh");

            migrationBuilder.DropTable(
                name: "BacSi");

            migrationBuilder.DropTable(
                name: "BenhNhan");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "BoPhan");
        }
    }
}
