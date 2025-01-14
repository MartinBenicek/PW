using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _22thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Karta",
                columns: new[] { "Id", "PacientID" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 2,
                column: "DoktorID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 3,
                column: "DoktorID",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Karta",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 2,
                column: "DoktorID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 3,
                column: "DoktorID",
                value: 1);
        }
    }
}
