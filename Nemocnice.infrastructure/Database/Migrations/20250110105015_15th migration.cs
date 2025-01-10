using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _15thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "LekarskeSluzby",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Datum", "Ukon", "Vysetreni" },
                values: new object[] { new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Vyšetření", "Slepé střevo" });

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Datum", "Ukon" },
                values: new object[] { new DateTime(2025, 4, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), "Očkování" });

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Datum", "Ukon", "Vysetreni" },
                values: new object[] { new DateTime(2025, 5, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "Vyšetření", "Zlomená noha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                table: "LekarskeSluzby");

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ukon", "Vysetreni" },
                values: new object[] { "Léčba", "Noha" });

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ukon",
                value: "Léčba");

            migrationBuilder.UpdateData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ukon", "Vysetreni" },
                values: new object[] { "Léčba", "Ruka" });
        }
    }
}
