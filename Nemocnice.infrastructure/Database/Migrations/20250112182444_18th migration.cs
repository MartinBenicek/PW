using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _18thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LekarskeSluzbyID",
                table: "Karta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LekarskeSluzbyID",
                table: "Karta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Karta",
                keyColumn: "Id",
                keyValue: 1,
                column: "LekarskeSluzbyID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Karta",
                keyColumn: "Id",
                keyValue: 2,
                column: "LekarskeSluzbyID",
                value: 2);
        }
    }
}
