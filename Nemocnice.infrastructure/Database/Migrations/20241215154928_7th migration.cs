using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _7thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titul");

            migrationBuilder.AddColumn<string>(
                name: "Titul",
                table: "Doktor",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Doktor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Titul", "TitulID" },
                values: new object[] { "MUDr", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titul",
                table: "Doktor");

            migrationBuilder.CreateTable(
                name: "Titul",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titul = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titul", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Doktor",
                keyColumn: "Id",
                keyValue: 1,
                column: "TitulID",
                value: 1);

            migrationBuilder.InsertData(
                table: "Titul",
                columns: new[] { "Id", "titul" },
                values: new object[] { 1, "MUDr" });
        }
    }
}
