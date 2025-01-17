using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _31thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LekarskaZprava",
                keyColumn: "Id",
                keyValue: 1,
                column: "KartaID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "LekarskaZprava",
                keyColumn: "Id",
                keyValue: 2,
                column: "KartaID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 2,
                column: "KartaID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 3,
                column: "KartaID",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LekarskaZprava",
                keyColumn: "Id",
                keyValue: 1,
                column: "KartaID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LekarskaZprava",
                keyColumn: "Id",
                keyValue: 2,
                column: "KartaID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 2,
                column: "KartaID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 3,
                column: "KartaID",
                value: 2);
        }
    }
}
