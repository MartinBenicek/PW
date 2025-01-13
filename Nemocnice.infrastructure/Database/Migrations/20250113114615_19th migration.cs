using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _19thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Predpis_LekarskaZpravaID",
                table: "Predpis",
                column: "LekarskaZpravaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Predpis_LekarskaZprava_LekarskaZpravaID",
                table: "Predpis",
                column: "LekarskaZpravaID",
                principalTable: "LekarskaZprava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predpis_LekarskaZprava_LekarskaZpravaID",
                table: "Predpis");

            migrationBuilder.DropIndex(
                name: "IX_Predpis_LekarskaZpravaID",
                table: "Predpis");
        }
    }
}
