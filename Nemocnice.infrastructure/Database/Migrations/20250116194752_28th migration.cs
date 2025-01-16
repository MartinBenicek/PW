using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _28thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageSrc",
                value: "\\img\\ordinace\\ordinace A1.jpg");

            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageSrc",
                value: "\\img\\ordinace\\ordinace B1.jpg");

            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageSrc",
                value: "\\img\\ordinace\\ordinace C1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageSrc",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageSrc",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageSrc",
                value: null);
        }
    }
}
