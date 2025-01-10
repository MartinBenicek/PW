using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _16thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LekarskaZprava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Zprava = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LekarskeSluzbyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekarskaZprava", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Predpis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypLeku = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NazevLeku = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CasPodani = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LekarskeSluzbyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predpis", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "LekarskaZprava",
                columns: new[] { "Id", "Datum", "LekarskeSluzbyID", "Zprava" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pacient vykazuje známky zlepšení, doporučeno pokračovat v současné léčbě, kontrola za 14 dní." },
                    { 2, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, "Pacientovi doporučeny Nasivin nosní kapky pro zmírnění ucpaného nosu. Aplikovat 1–2 kapky do každé nosní dírky maximálně 3× denně po dobu maximálně 7 dní. " },
                    { 3, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pacientovi doporučen Bepanthen hojivý krém na podrážděnou nebo suchou pokožku. Aplikovat tenkou vrstvu na postižené místo 2–3× denně dle potřeby." }
                });

            migrationBuilder.InsertData(
                table: "Predpis",
                columns: new[] { "Id", "CasPodani", "LekarskeSluzbyID", "NazevLeku", "TypLeku" },
                values: new object[,]
                {
                    { 1, "Ráno a večer", 1, "Cotrimoxazol", "tableta" },
                    { 2, "3x denně", 2, "Nasivin", "kapky" },
                    { 3, "3x denně", 3, "Bepanthen", "mast" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LekarskaZprava");

            migrationBuilder.DropTable(
                name: "Predpis");
        }
    }
}
