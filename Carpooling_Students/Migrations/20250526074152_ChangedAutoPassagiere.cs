using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpooling_Students.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAutoPassagiere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutofahrtPassagiere");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Fahrten");

            migrationBuilder.AddColumn<int>(
                name: "FahrtId",
                table: "Personen",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Typ",
                table: "Fahrten",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Sitze",
                table: "Fahrten",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Typ",
                table: "Fahrten",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Sitze",
                table: "Fahrten",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Fahrten",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AutofahrtPassagiere",
                columns: table => new
                {
                    AutofahrtPassagierId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "IX_AutofahrtPassagiere_PassagierPersonId",
                table: "AutofahrtPassagiere",
                column: "PassagierPersonId");
        }
    }
}
