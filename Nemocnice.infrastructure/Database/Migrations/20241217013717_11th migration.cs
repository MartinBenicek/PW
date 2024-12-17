using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _11thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJW7mjCOUJjeHdowMNdCGuSVQG/3QALFq0cck29KlYTiIUEgS33MNpC/8dQJnNiNjA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "8b10538241050d9320842b64c33cf80bfd7160e7a0843580a8b8ad6df584abd6");
        }
    }
}
