using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nemocnice.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _4thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumNarozeni",
                table: "User",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Heslo",
                table: "User",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Jmeno",
                table: "User",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Prijmeni",
                table: "User",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "User",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DatumNarozeni", "Email", "Heslo", "Jmeno", "Prijmeni", "Telefon" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "marie.kucerova@example.com", "securepassword", "Marie", "Kučerová", "123456789" },
                    { 2, new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jakub.maly@example.com", "securepassword", "Jakub", "Malý", "987654321" },
                    { 1001, new DateTime(1989, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "marie.novakova@example.com", "securepassword", "Marie", "Nováková", "987654321" },
                    { 1002, new DateTime(2001, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "martin.bzducha@example.com", "securepassword", "Martin", "Bzducha", "987654321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DropColumn(
                name: "DatumNarozeni",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Heslo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Jmeno",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Prijmeni",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "User");
        }
    }
}
