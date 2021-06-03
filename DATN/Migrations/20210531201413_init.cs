using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoPhans",
                columns: table => new
                {
                    MaBoPhan = table.Column<string>(nullable: false),
                    TenBoPhan = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoPhans", x => x.MaBoPhan);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    MaLop = table.Column<string>(nullable: false),
                    TenLop = table.Column<string>(maxLength: 10, nullable: true),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    MaNhaCungCap = table.Column<string>(nullable: false),
                    TenNhaCungCap = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    DienThoai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.MaNhaCungCap);
                });

            migrationBuilder.CreateTable(
                name: "ThucPhams",
                columns: table => new
                {
                    MaThucPham = table.Column<string>(nullable: false),
                    TenThucPham = table.Column<string>(nullable: true),
                    DonVi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThucPhams", x => x.MaThucPham);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<bool>(nullable: false, defaultValue: true),
                    DienThoai = table.Column<string>(maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 150, nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HocSinhs",
                columns: table => new
                {
                    Idhs = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    GioiTinh = table.Column<bool>(nullable: false),
                    DienThoai = table.Column<string>(nullable: true),
                    MaLop = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinhs", x => x.Idhs);
                    table.ForeignKey(
                        name: "FK_HocSinhs_Classes_MaLop",
                        column: x => x.MaLop,
                        principalTable: "Classes",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaoViens",
                columns: table => new
                {
                    MaGV = table.Column<string>(nullable: false),
                    TrinhDo = table.Column<string>(nullable: true),
                    NgayVao = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MaLop = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoViens", x => x.MaGV);
                    table.ForeignKey(
                        name: "FK_GiaoViens_Classes_MaLop",
                        column: x => x.MaLop,
                        principalTable: "Classes",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiaoViens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MaBoPhan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanViens_BoPhans_MaBoPhan",
                        column: x => x.MaBoPhan,
                        principalTable: "BoPhans",
                        principalColumn: "MaBoPhan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanViens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuAns",
                columns: table => new
                {
                    SophieuAn = table.Column<string>(nullable: false),
                    MaGV = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuAns", x => x.SophieuAn);
                    table.ForeignKey(
                        name: "FK_PhieuAns_GiaoViens_MaGV",
                        column: x => x.MaGV,
                        principalTable: "GiaoViens",
                        principalColumn: "MaGV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonAns",
                columns: table => new
                {
                    MaMonAn = table.Column<string>(nullable: false),
                    TenMonAn = table.Column<string>(nullable: true),
                    MaNhanVien = table.Column<string>(nullable: true),
                    BuaAn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAns", x => x.MaMonAn);
                    table.ForeignKey(
                        name: "FK_MonAns_NhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuCungCaps",
                columns: table => new
                {
                    SoPhieuCugCap = table.Column<string>(nullable: false),
                    MaNhanVien = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuCungCaps", x => x.SoPhieuCugCap);
                    table.ForeignKey(
                        name: "FK_PhieuCungCaps_NhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuKiemKes",
                columns: table => new
                {
                    SoPhieuKiemKe = table.Column<string>(nullable: false),
                    MaNhanVien = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKiemKes", x => x.SoPhieuKiemKe);
                    table.ForeignKey(
                        name: "FK_PhieuKiemKes_NhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuYeuCaus",
                columns: table => new
                {
                    SoPhieuYeuCau = table.Column<string>(maxLength: 50, nullable: false),
                    MaNhanVien = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuYeuCaus", x => x.SoPhieuYeuCau);
                    table.ForeignKey(
                        name: "FK_PhieuYeuCaus_NhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DinhLuongMonAns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMonAn = table.Column<string>(nullable: true),
                    MaThucPham = table.Column<string>(nullable: true),
                    SoLuong = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinhLuongMonAns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DinhLuongMonAns_MonAns_MaMonAn",
                        column: x => x.MaMonAn,
                        principalTable: "MonAns",
                        principalColumn: "MaMonAn",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DinhLuongMonAns_ThucPhams_MaThucPham",
                        column: x => x.MaThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "MaThucPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietCungCaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieuCungCap = table.Column<string>(nullable: true),
                    MaThucPham = table.Column<string>(nullable: true),
                    MaNhaCungCap = table.Column<string>(nullable: true),
                    SoLuong = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCungCaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietCungCaps_NhaCungCaps_MaNhaCungCap",
                        column: x => x.MaNhaCungCap,
                        principalTable: "NhaCungCaps",
                        principalColumn: "MaNhaCungCap",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietCungCaps_ThucPhams_MaThucPham",
                        column: x => x.MaThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "MaThucPham",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietCungCaps_PhieuCungCaps_SoPhieuCungCap",
                        column: x => x.SoPhieuCungCap,
                        principalTable: "PhieuCungCaps",
                        principalColumn: "SoPhieuCugCap",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuGiaos",
                columns: table => new
                {
                    SoPhieuGiao = table.Column<string>(nullable: false),
                    MaNhanVien = table.Column<string>(nullable: true),
                    SoPhieuCungCap = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuGiaos", x => x.SoPhieuGiao);
                    table.ForeignKey(
                        name: "FK_PhieuGiaos_NhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuGiaos_PhieuCungCaps_SoPhieuCungCap",
                        column: x => x.SoPhieuCungCap,
                        principalTable: "PhieuCungCaps",
                        principalColumn: "SoPhieuCugCap",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKiemKes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieuKiemKe = table.Column<string>(nullable: true),
                    MaThucPham = table.Column<string>(nullable: true),
                    SoLuong = table.Column<float>(nullable: false),
                    ChatLuong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKiemKes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietKiemKes_ThucPhams_MaThucPham",
                        column: x => x.MaThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "MaThucPham",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietKiemKes_PhieuKiemKes_SoPhieuKiemKe",
                        column: x => x.SoPhieuKiemKe,
                        principalTable: "PhieuKiemKes",
                        principalColumn: "SoPhieuKiemKe",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietYeuCaus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieuYeuCau = table.Column<string>(nullable: true),
                    MaThucPham = table.Column<string>(nullable: true),
                    SoLuong = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietYeuCaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietYeuCaus_ThucPhams_MaThucPham",
                        column: x => x.MaThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "MaThucPham",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietYeuCaus_PhieuYeuCaus_SoPhieuYeuCau",
                        column: x => x.SoPhieuYeuCau,
                        principalTable: "PhieuYeuCaus",
                        principalColumn: "SoPhieuYeuCau",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuBanGiaos",
                columns: table => new
                {
                    SoPhieuBanGiao = table.Column<string>(nullable: false),
                    MaNhanVien = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    SoPhieuYeuCau = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuBanGiaos", x => x.SoPhieuBanGiao);
                    table.ForeignKey(
                        name: "FK_PhieuBanGiaos_NhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuBanGiaos_PhieuYeuCaus_SoPhieuYeuCau",
                        column: x => x.SoPhieuYeuCau,
                        principalTable: "PhieuYeuCaus",
                        principalColumn: "SoPhieuYeuCau",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGiaos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieuGiao = table.Column<string>(nullable: true),
                    MaThucPham = table.Column<string>(nullable: true),
                    MaNhaCungCap = table.Column<string>(nullable: true),
                    SoLuong = table.Column<float>(nullable: false),
                    DonGia = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGiaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietGiaos_NhaCungCaps_MaNhaCungCap",
                        column: x => x.MaNhaCungCap,
                        principalTable: "NhaCungCaps",
                        principalColumn: "MaNhaCungCap",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietGiaos_ThucPhams_MaThucPham",
                        column: x => x.MaThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "MaThucPham",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietGiaos_PhieuGiaos_SoPhieuGiao",
                        column: x => x.SoPhieuGiao,
                        principalTable: "PhieuGiaos",
                        principalColumn: "SoPhieuGiao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietBanGiaos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieuBanGiao = table.Column<string>(nullable: true),
                    MaThucPham = table.Column<string>(nullable: true),
                    SoLuong = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietBanGiaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietBanGiaos_ThucPhams_MaThucPham",
                        column: x => x.MaThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "MaThucPham",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietBanGiaos_PhieuBanGiaos_SoPhieuBanGiao",
                        column: x => x.SoPhieuBanGiao,
                        principalTable: "PhieuBanGiaos",
                        principalColumn: "SoPhieuBanGiao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBanGiaos_MaThucPham",
                table: "ChiTietBanGiaos",
                column: "MaThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBanGiaos_SoPhieuBanGiao",
                table: "ChiTietBanGiaos",
                column: "SoPhieuBanGiao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCungCaps_MaNhaCungCap",
                table: "ChiTietCungCaps",
                column: "MaNhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCungCaps_MaThucPham",
                table: "ChiTietCungCaps",
                column: "MaThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCungCaps_SoPhieuCungCap",
                table: "ChiTietCungCaps",
                column: "SoPhieuCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGiaos_MaNhaCungCap",
                table: "ChiTietGiaos",
                column: "MaNhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGiaos_MaThucPham",
                table: "ChiTietGiaos",
                column: "MaThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGiaos_SoPhieuGiao",
                table: "ChiTietGiaos",
                column: "SoPhieuGiao");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKiemKes_MaThucPham",
                table: "ChiTietKiemKes",
                column: "MaThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKiemKes_SoPhieuKiemKe",
                table: "ChiTietKiemKes",
                column: "SoPhieuKiemKe");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietYeuCaus_MaThucPham",
                table: "ChiTietYeuCaus",
                column: "MaThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietYeuCaus_SoPhieuYeuCau",
                table: "ChiTietYeuCaus",
                column: "SoPhieuYeuCau");

            migrationBuilder.CreateIndex(
                name: "IX_DinhLuongMonAns_MaMonAn",
                table: "DinhLuongMonAns",
                column: "MaMonAn");

            migrationBuilder.CreateIndex(
                name: "IX_DinhLuongMonAns_MaThucPham",
                table: "DinhLuongMonAns",
                column: "MaThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoViens_MaLop",
                table: "GiaoViens",
                column: "MaLop",
                unique: true,
                filter: "[MaLop] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoViens_UserId",
                table: "GiaoViens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HocSinhs_MaLop",
                table: "HocSinhs",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_MonAns_MaNhanVien",
                table: "MonAns",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaBoPhan",
                table: "NhanViens",
                column: "MaBoPhan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_UserId",
                table: "NhanViens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuAns_MaGV",
                table: "PhieuAns",
                column: "MaGV");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBanGiaos_MaNhanVien",
                table: "PhieuBanGiaos",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBanGiaos_SoPhieuYeuCau",
                table: "PhieuBanGiaos",
                column: "SoPhieuYeuCau",
                unique: true,
                filter: "[SoPhieuYeuCau] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuCungCaps_MaNhanVien",
                table: "PhieuCungCaps",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuGiaos_MaNhanVien",
                table: "PhieuGiaos",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuGiaos_SoPhieuCungCap",
                table: "PhieuGiaos",
                column: "SoPhieuCungCap",
                unique: true,
                filter: "[SoPhieuCungCap] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKiemKes_MaNhanVien",
                table: "PhieuKiemKes",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuYeuCaus_MaNhanVien",
                table: "PhieuYeuCaus",
                column: "MaNhanVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ChiTietBanGiaos");

            migrationBuilder.DropTable(
                name: "ChiTietCungCaps");

            migrationBuilder.DropTable(
                name: "ChiTietGiaos");

            migrationBuilder.DropTable(
                name: "ChiTietKiemKes");

            migrationBuilder.DropTable(
                name: "ChiTietYeuCaus");

            migrationBuilder.DropTable(
                name: "DinhLuongMonAns");

            migrationBuilder.DropTable(
                name: "HocSinhs");

            migrationBuilder.DropTable(
                name: "PhieuAns");

            migrationBuilder.DropTable(
                name: "PhieuBanGiaos");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");

            migrationBuilder.DropTable(
                name: "PhieuGiaos");

            migrationBuilder.DropTable(
                name: "PhieuKiemKes");

            migrationBuilder.DropTable(
                name: "MonAns");

            migrationBuilder.DropTable(
                name: "ThucPhams");

            migrationBuilder.DropTable(
                name: "GiaoViens");

            migrationBuilder.DropTable(
                name: "PhieuYeuCaus");

            migrationBuilder.DropTable(
                name: "PhieuCungCaps");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "BoPhans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
