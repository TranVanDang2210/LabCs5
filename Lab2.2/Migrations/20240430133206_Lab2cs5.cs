using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2._2.Migrations
{
    /// <inheritdoc />
    public partial class Lab2cs5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lab22");

            migrationBuilder.CreateTable(
                name: "Nhanvien",
                schema: "Lab22",
                columns: table => new
                {
                    manv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    honv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tennv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenlot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dchi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    luong = table.Column<float>(type: "real", nullable: false),
                    ma_nql = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    phg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanvien", x => x.manv);
                });

            migrationBuilder.CreateTable(
                name: "Thannhan",
                schema: "Lab22",
                columns: table => new
                {
                    ma_nv = table.Column<int>(type: "int", nullable: false),
                    tenthannhan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phai = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    nsinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    qhe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thannhan", x => new { x.ma_nv, x.tenthannhan });
                    table.ForeignKey(
                        name: "FK_Thannhan_Nhanvien_ma_nv",
                        column: x => x.ma_nv,
                        principalSchema: "Lab22",
                        principalTable: "Nhanvien",
                        principalColumn: "manv",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thannhan",
                schema: "Lab22");

            migrationBuilder.DropTable(
                name: "Nhanvien",
                schema: "Lab22");
        }
    }
}
