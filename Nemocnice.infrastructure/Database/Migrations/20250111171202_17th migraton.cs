using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _17thmigraton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LekarskaZprava",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Stav",
                table: "Karta");

            migrationBuilder.RenameColumn(
                name: "LekarskeSluzbyID",
                table: "Predpis",
                newName: "LekarskaZpravaID");

            migrationBuilder.RenameColumn(
                name: "LekarskeSluzbyID",
                table: "LekarskaZprava",
                newName: "KartaID");

            migrationBuilder.UpdateData(
                table: "Predpis",
                keyColumn: "NazevLeku",
                keyValue: null,
                column: "NazevLeku",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NazevLeku",
                table: "Predpis",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Predpis",
                keyColumn: "CasPodani",
                keyValue: null,
                column: "CasPodani",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CasPodani",
                table: "Predpis",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Predpis",
                keyColumn: "Id",
                keyValue: 3,
                column: "LekarskaZpravaID",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LekarskaZpravaID",
                table: "Predpis",
                newName: "LekarskeSluzbyID");

            migrationBuilder.RenameColumn(
                name: "KartaID",
                table: "LekarskaZprava",
                newName: "LekarskeSluzbyID");

            migrationBuilder.AlterColumn<string>(
                name: "NazevLeku",
                table: "Predpis",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CasPodani",
                table: "Predpis",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Stav",
                table: "Karta",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Karta",
                keyColumn: "Id",
                keyValue: 1,
                column: "Stav",
                value: "Následuje");

            migrationBuilder.UpdateData(
                table: "Karta",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stav",
                value: "Následuje");

            migrationBuilder.InsertData(
                table: "LekarskaZprava",
                columns: new[] { "Id", "Datum", "LekarskeSluzbyID", "Zprava" },
                values: new object[] { 3, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pacientovi doporučen Bepanthen hojivý krém na podrážděnou nebo suchou pokožku. Aplikovat tenkou vrstvu na postižené místo 2–3× denně dle potřeby." });

            migrationBuilder.UpdateData(
                table: "Predpis",
                keyColumn: "Id",
                keyValue: 3,
                column: "LekarskeSluzbyID",
                value: 3);
        }
    }
}
