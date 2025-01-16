using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _24thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Ordinace",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Ordinace");
        }
    }
}
