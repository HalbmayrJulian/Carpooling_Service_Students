using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpooling_Students.Migrations
{
    /// <inheritdoc />
    public partial class Bestellposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellungen_Personen_UserPersonId",
                table: "Bestellungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Bestellungen_BestellungId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_BestellungId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BestellungId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "UserPersonId",
                table: "Bestellungen",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bestellungen_UserPersonId",
                table: "Bestellungen",
                newName: "IX_Bestellungen_UserId");

            migrationBuilder.CreateTable(
                name: "Bestellpositionen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BestellungId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellpositionen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestellpositionen_Bestellungen_BestellungId",
                        column: x => x.BestellungId,
                        principalTable: "Bestellungen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bestellpositionen_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellpositionen_BestellungId",
                table: "Bestellpositionen",
                column: "BestellungId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellpositionen_ItemId",
                table: "Bestellpositionen",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellungen_Personen_UserId",
                table: "Bestellungen",
                column: "UserId",
                principalTable: "Personen",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellungen_Personen_UserId",
                table: "Bestellungen");

            migrationBuilder.DropTable(
                name: "Bestellpositionen");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bestellungen",
                newName: "UserPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Bestellungen_UserId",
                table: "Bestellungen",
                newName: "IX_Bestellungen_UserPersonId");

            migrationBuilder.AddColumn<int>(
                name: "BestellungId",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_BestellungId",
                table: "Items",
                column: "BestellungId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellungen_Personen_UserPersonId",
                table: "Bestellungen",
                column: "UserPersonId",
                principalTable: "Personen",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Bestellungen_BestellungId",
                table: "Items",
                column: "BestellungId",
                principalTable: "Bestellungen",
                principalColumn: "Id");
        }
    }
}
