using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpooling_Students.Migrations
{
    /// <inheritdoc />
    public partial class addBestellungKlasse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestellungId",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bestellungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bestelldatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestellungen_Personen_UserPersonId",
                        column: x => x.UserPersonId,
                        principalTable: "Personen",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_BestellungId",
                table: "Items",
                column: "BestellungId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellungen_UserPersonId",
                table: "Bestellungen",
                column: "UserPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Bestellungen_BestellungId",
                table: "Items",
                column: "BestellungId",
                principalTable: "Bestellungen",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Bestellungen_BestellungId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Bestellungen");

            migrationBuilder.DropIndex(
                name: "IX_Items_BestellungId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BestellungId",
                table: "Items");
        }
    }
}
