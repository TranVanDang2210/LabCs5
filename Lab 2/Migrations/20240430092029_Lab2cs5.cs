using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_2.Migrations
{
    /// <inheritdoc />
    public partial class Lab2cs5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_Id = table.Column<int>(type: "int", nullable: false),
                    phoneNo = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "tblAddresses",
                columns: table => new
                {
                    Addr_Id = table.Column<int>(type: "int", nullable: false),
                    Home_addr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Office_addr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAddresses", x => x.Addr_Id);
                    table.ForeignKey(
                        name: "FK_tblAddresses_tblClients_Addr_Id",
                        column: x => x.Addr_Id,
                        principalTable: "tblClients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAddresses");

            migrationBuilder.DropTable(
                name: "tblClients");
        }
    }
}
