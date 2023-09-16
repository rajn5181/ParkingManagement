using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservedParking.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterReserved",
                columns: table => new
                {
                    Rpid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterReserved", x => x.Rpid);
                });

            migrationBuilder.CreateTable(
                name: "VCategory",
                columns: table => new
                {
                    Tid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RGPModelRpid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VCategory", x => x.Tid);
                    table.ForeignKey(
                        name: "FK_VCategory_MasterReserved_RGPModelRpid",
                        column: x => x.RGPModelRpid,
                        principalTable: "MasterReserved",
                        principalColumn: "Rpid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VCategory_RGPModelRpid",
                table: "VCategory",
                column: "RGPModelRpid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VCategory");

            migrationBuilder.DropTable(
                name: "MasterReserved");
        }
    }
}
