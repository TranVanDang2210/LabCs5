using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2._3.Migrations
{
    /// <inheritdoc />
    public partial class Lab2cs5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lab23");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Lab23",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "Lab23",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonCompanies",
                schema: "Lab23",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromYear = table.Column<int>(type: "int", nullable: false),
                    ToYear = table.Column<int>(type: "int", nullable: false),
                    Current = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Lab23",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonCompanies_People_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Lab23",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonCompanies_CompanyId",
                schema: "Lab23",
                table: "PersonCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCompanies_PersonId",
                schema: "Lab23",
                table: "PersonCompanies",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonCompanies",
                schema: "Lab23");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Lab23");

            migrationBuilder.DropTable(
                name: "People",
                schema: "Lab23");
        }
    }
}
