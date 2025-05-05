using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpooling_Students.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    GesamtDistanz = table.Column<int>(type: "INTEGER", nullable: false),
                    Coins = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Routen",
                columns: table => new
                {
                    RoutenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartOrt = table.Column<string>(type: "TEXT", nullable: false),
                    ZielOrt = table.Column<string>(type: "TEXT", nullable: false),
                    Distanz = table.Column<double>(type: "REAL", nullable: false),
                    Weg = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routen", x => x.RoutenId);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                });

            migrationBuilder.CreateTable(
                name: "Fahrten",
                columns: table => new
                {
                    FahrtId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Abgeschlossen = table.Column<bool>(type: "INTEGER", nullable: false),
                    FahrerPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoutenId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    Typ = table.Column<int>(type: "INTEGER", nullable: true),
                    Sitze = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fahrten", x => x.FahrtId);
                    table.ForeignKey(
                        name: "FK_Fahrten_Personen_FahrerPersonId",
                        column: x => x.FahrerPersonId,
                        principalTable: "Personen",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fahrten_Routen_RoutenId",
                        column: x => x.RoutenId,
                        principalTable: "Routen",
                        principalColumn: "RoutenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ShopId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "ShopId");
                });

            migrationBuilder.CreateTable(
                name: "AutofahrtPassagiere",
                columns: table => new
                {
                    AutofahrtPassagierId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FahrtId = table.Column<int>(type: "INTEGER", nullable: false),
                    AutofahrtFahrtId = table.Column<int>(type: "INTEGER", nullable: false),
                    PassagierPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutofahrtPassagiere", x => x.AutofahrtPassagierId);
                    table.ForeignKey(
                        name: "FK_AutofahrtPassagiere_Fahrten_AutofahrtFahrtId",
                        column: x => x.AutofahrtFahrtId,
                        principalTable: "Fahrten",
                        principalColumn: "FahrtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutofahrtPassagiere_Fahrten_FahrtId",
                        column: x => x.FahrtId,
                        principalTable: "Fahrten",
                        principalColumn: "FahrtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutofahrtPassagiere_Personen_PassagierPersonId",
                        column: x => x.PassagierPersonId,
                        principalTable: "Personen",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutofahrtPassagiere_AutofahrtFahrtId",
                table: "AutofahrtPassagiere",
                column: "AutofahrtFahrtId");

            migrationBuilder.CreateIndex(
                name: "IX_AutofahrtPassagiere_FahrtId",
                table: "AutofahrtPassagiere",
                column: "FahrtId");

            migrationBuilder.CreateIndex(
                name: "IX_AutofahrtPassagiere_PassagierPersonId",
                table: "AutofahrtPassagiere",
                column: "PassagierPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fahrten_FahrerPersonId",
                table: "Fahrten",
                column: "FahrerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fahrten_RoutenId",
                table: "Fahrten",
                column: "RoutenId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShopId",
                table: "Items",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutofahrtPassagiere");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Fahrten");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Personen");

            migrationBuilder.DropTable(
                name: "Routen");
        }
    }
}
