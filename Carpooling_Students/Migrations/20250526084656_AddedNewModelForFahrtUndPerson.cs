using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpooling_Students.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewModelForFahrtUndPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personen_Fahrten_FahrtId",
                table: "Personen");

            migrationBuilder.DropIndex(
                name: "IX_Personen_FahrtId",
                table: "Personen");

            migrationBuilder.DropColumn(
                name: "FahrtId",
                table: "Personen");

            migrationBuilder.CreateTable(
                name: "FahrtPassagiere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FahrtId = table.Column<int>(type: "INTEGER", nullable: false),
                    PassagierPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FahrtPassagiere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FahrtPassagiere_Fahrten_FahrtId",
                        column: x => x.FahrtId,
                        principalTable: "Fahrten",
                        principalColumn: "FahrtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FahrtPassagiere_Personen_PassagierPersonId",
                        column: x => x.PassagierPersonId,
                        principalTable: "Personen",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FahrtPassagiere_FahrtId",
                table: "FahrtPassagiere",
                column: "FahrtId");

            migrationBuilder.CreateIndex(
                name: "IX_FahrtPassagiere_PassagierPersonId",
                table: "FahrtPassagiere",
                column: "PassagierPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FahrtPassagiere");

            migrationBuilder.AddColumn<int>(
                name: "FahrtId",
                table: "Personen",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personen_FahrtId",
                table: "Personen",
                column: "FahrtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personen_Fahrten_FahrtId",
                table: "Personen",
                column: "FahrtId",
                principalTable: "Fahrten",
                principalColumn: "FahrtId");
        }
    }
}
