using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _5thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Titul",
                newName: "titul");

            migrationBuilder.AddColumn<string>(
                name: "Nazev",
                table: "Role",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "LekarskeSluzbyID",
                table: "Karta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "UserRoleID" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "Doktor",
                columns: new[] { "Id", "TitulID", "UserRoleID" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Karta",
                columns: new[] { "Id", "LekarskeSluzbyID", "PacientID", "Stav" },
                values: new object[,]
                {
                    { 1, 1, 1, "Následuje" },
                    { 2, 2, 2, "Následuje" }
                });

            migrationBuilder.InsertData(
                table: "LekarskeSluzby",
                columns: new[] { "Id", "KartaID", "Ockovani", "OrdinaceID", "Ukon", "Vysetreni" },
                values: new object[,]
                {
                    { 1, 1, "", 1, "Léčba", "Noha" },
                    { 2, 1, "Encefalitida", 2, "Léčba", "" },
                    { 3, 2, "", 3, "Léčba", "Ruka" }
                });

            migrationBuilder.InsertData(
                table: "Ordinace",
                columns: new[] { "Id", "Budova", "DoktorID", "Mistnost" },
                values: new object[,]
                {
                    { 1, "A1", 1, "1/4" },
                    { 2, "B1", 1, "2/3" },
                    { 3, "C1", 1, "2/1" }
                });

            migrationBuilder.InsertData(
                table: "Pacient",
                columns: new[] { "Id", "UserRoleID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Nazev" },
                values: new object[,]
                {
                    { 1, "Pacient" },
                    { 2, "Doktor" },
                    { 3, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Titul",
                columns: new[] { "Id", "titul" },
                values: new object[] { 1, "MUDr" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DatumNarozeni", "Email", "Heslo", "Jmeno", "Prijmeni", "Telefon" },
                values: new object[,]
                {
                    { 3, new DateTime(1989, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "marie.novakova@example.com", "securepassword", "Marie", "Nováková", "987654321" },
                    { 4, new DateTime(2001, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "martin.bzducha@example.com", "securepassword", "Martin", "Bzducha", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleID", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doktor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Karta",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Karta",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LekarskeSluzby",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ordinace",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pacient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Titul",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Nazev",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "LekarskeSluzbyID",
                table: "Karta");

            migrationBuilder.RenameColumn(
                name: "titul",
                table: "Titul",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DatumNarozeni", "Email", "Heslo", "Jmeno", "Prijmeni", "Telefon" },
                values: new object[,]
                {
                    { 1001, new DateTime(1989, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "marie.novakova@example.com", "securepassword", "Marie", "Nováková", "987654321" },
                    { 1002, new DateTime(2001, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "martin.bzducha@example.com", "securepassword", "Martin", "Bzducha", "987654321" }
                });
        }
    }
}
