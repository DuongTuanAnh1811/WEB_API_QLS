using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_API_QLS.Migrations
{
    public partial class InitWebDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quequans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thanhpho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quequans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taikhoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taikhoans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theloais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theloais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bandocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ngaysinh = table.Column<int>(type: "int", nullable: true),
                    Thangsinh = table.Column<int>(type: "int", nullable: true),
                    Namsinh = table.Column<int>(type: "int", nullable: true),
                    Sodienthoai = table.Column<int>(type: "int", nullable: true),
                    MaSv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuequanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bandocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bandocs_Quequans_QuequanId",
                        column: x => x.QuequanId,
                        principalTable: "Quequans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nhanviens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sodienthoai = table.Column<int>(type: "int", nullable: true),
                    Ngaysinh = table.Column<int>(type: "int", nullable: true),
                    Thangsinh = table.Column<int>(type: "int", nullable: true),
                    Namsinh = table.Column<int>(type: "int", nullable: true),
                    Chucvu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuequanId = table.Column<int>(type: "int", nullable: true),
                    TaikhoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanviens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nhanviens_Quequans_QuequanId",
                        column: x => x.QuequanId,
                        principalTable: "Quequans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nhanviens_Taikhoans_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Saches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tensach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soluong = table.Column<int>(type: "int", nullable: true),
                    Tinhtrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tacgia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ngaynhap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TheloaiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saches_Theloais_TheloaiId",
                        column: x => x.TheloaiId,
                        principalTable: "Theloais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ngaymuons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SachId = table.Column<int>(type: "int", nullable: true),
                    BandocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ngaymuons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ngaymuons_Bandocs_BandocId",
                        column: x => x.BandocId,
                        principalTable: "Bandocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ngaymuons_Saches_SachId",
                        column: x => x.SachId,
                        principalTable: "Saches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bandocs_QuequanId",
                table: "Bandocs",
                column: "QuequanId");

            migrationBuilder.CreateIndex(
                name: "IX_Ngaymuons_BandocId",
                table: "Ngaymuons",
                column: "BandocId");

            migrationBuilder.CreateIndex(
                name: "IX_Ngaymuons_SachId",
                table: "Ngaymuons",
                column: "SachId");

            migrationBuilder.CreateIndex(
                name: "IX_Nhanviens_QuequanId",
                table: "Nhanviens",
                column: "QuequanId");

            migrationBuilder.CreateIndex(
                name: "IX_Nhanviens_TaikhoanId",
                table: "Nhanviens",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Saches_TheloaiId",
                table: "Saches",
                column: "TheloaiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ngaymuons");

            migrationBuilder.DropTable(
                name: "Nhanviens");

            migrationBuilder.DropTable(
                name: "Bandocs");

            migrationBuilder.DropTable(
                name: "Saches");

            migrationBuilder.DropTable(
                name: "Taikhoans");

            migrationBuilder.DropTable(
                name: "Quequans");

            migrationBuilder.DropTable(
                name: "Theloais");
        }
    }
}
