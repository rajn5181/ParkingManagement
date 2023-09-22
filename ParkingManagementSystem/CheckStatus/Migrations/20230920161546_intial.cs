using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckStatus.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterAvailability",
                columns: table => new
                {
                    Pid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Available = table.Column<DateTime>(type: "datetime2", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAvailability", x => x.Pid);
                });

            migrationBuilder.CreateTable(
                name: "MasterSlot",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Two = table.Column<bool>(type: "bit", nullable: false),
                    Three = table.Column<bool>(type: "bit", nullable: false),
                    Six = table.Column<bool>(type: "bit", nullable: false),
                    Twelve = table.Column<bool>(type: "bit", nullable: false),
                    Day = table.Column<bool>(type: "bit", nullable: false),
                    CPAPid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterSlot_MasterAvailability_CPAPid",
                        column: x => x.CPAPid,
                        principalTable: "MasterAvailability",
                        principalColumn: "Pid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterSlot_CPAPid",
                table: "MasterSlot",
                column: "CPAPid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterSlot");

            migrationBuilder.DropTable(
                name: "MasterAvailability");
        }
    }
}
