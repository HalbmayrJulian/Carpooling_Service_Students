using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpooling_Students.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAutofahrt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutofahrtPassagiere_Fahrten_FahrtId",
                table: "AutofahrtPassagiere");

            migrationBuilder.DropIndex(
                name: "IX_AutofahrtPassagiere_FahrtId",
                table: "AutofahrtPassagiere");

            migrationBuilder.DropColumn(
                name: "FahrtId",
                table: "AutofahrtPassagiere");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FahrtId",
                table: "AutofahrtPassagiere",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AutofahrtPassagiere_FahrtId",
                table: "AutofahrtPassagiere",
                column: "FahrtId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutofahrtPassagiere_Fahrten_FahrtId",
                table: "AutofahrtPassagiere",
                column: "FahrtId",
                principalTable: "Fahrten",
                principalColumn: "FahrtId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
