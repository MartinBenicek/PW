using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _12thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGUt/AeHlqOSBUNwcWcYXNiL59K94yh+Ns5IXg5UAIpudBw3KKMGo3C8mwb4XRwpRg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHALb2xi/d5J7lHhv1LNPj75CbkccxR4qSNMiJciACCDvekvRGXcKf/499OHMPdAsA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJW7mjCOUJjeHdowMNdCGuSVQG/3QALFq0cck29KlYTiIUEgS33MNpC/8dQJnNiNjA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "8b10538241050d9320842b64c33cf80bfd7160e7a0843580a8b8ad6df584abd6");
        }
    }
}
