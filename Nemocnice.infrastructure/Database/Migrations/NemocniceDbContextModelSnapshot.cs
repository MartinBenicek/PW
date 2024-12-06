﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nemocnice.infrastructure.Database;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    [DbContext(typeof(NemocniceDbContext))]
    partial class NemocniceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Nemocnice.domain.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserRoleID = 4
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TitulID")
                        .HasColumnType("int");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Doktor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TitulID = 1,
                            UserRoleID = 3
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Karta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LekarskeSluzbyID")
                        .HasColumnType("int");

                    b.Property<int>("PacientID")
                        .HasColumnType("int");

                    b.Property<string>("Stav")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Karta");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LekarskeSluzbyID = 1,
                            PacientID = 1,
                            Stav = "Následuje"
                        },
                        new
                        {
                            Id = 2,
                            LekarskeSluzbyID = 2,
                            PacientID = 2,
                            Stav = "Následuje"
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.LekarskeSluzby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KartaID")
                        .HasColumnType("int");

                    b.Property<string>("Ockovani")
                        .HasColumnType("longtext");

                    b.Property<int>("OrdinaceID")
                        .HasColumnType("int");

                    b.Property<string>("Ukon")
                        .HasColumnType("longtext");

                    b.Property<string>("Vysetreni")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LekarskeSluzby");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            KartaID = 1,
                            Ockovani = "",
                            OrdinaceID = 1,
                            Ukon = "Léčba",
                            Vysetreni = "Noha"
                        },
                        new
                        {
                            Id = 2,
                            KartaID = 1,
                            Ockovani = "Encefalitida",
                            OrdinaceID = 2,
                            Ukon = "Léčba",
                            Vysetreni = ""
                        },
                        new
                        {
                            Id = 3,
                            KartaID = 2,
                            Ockovani = "",
                            OrdinaceID = 3,
                            Ukon = "Léčba",
                            Vysetreni = "Ruka"
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Ordinace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Budova")
                        .HasColumnType("longtext");

                    b.Property<int>("DoktorID")
                        .HasColumnType("int");

                    b.Property<string>("Mistnost")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Ordinace");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budova = "A1",
                            DoktorID = 1,
                            Mistnost = "1/4"
                        },
                        new
                        {
                            Id = 2,
                            Budova = "B1",
                            DoktorID = 1,
                            Mistnost = "2/3"
                        },
                        new
                        {
                            Id = 3,
                            Budova = "C1",
                            DoktorID = 1,
                            Mistnost = "2/1"
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Pacient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pacient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserRoleID = 1
                        },
                        new
                        {
                            Id = 2,
                            UserRoleID = 2
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazev")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazev = "Pacient"
                        },
                        new
                        {
                            Id = 2,
                            Nazev = "Doktor"
                        },
                        new
                        {
                            Id = 3,
                            Nazev = "Admin"
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Titul", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("titul")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Titul");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            titul = "MUDr"
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumNarozeni")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Heslo")
                        .HasColumnType("longtext");

                    b.Property<string>("Jmeno")
                        .HasColumnType("longtext");

                    b.Property<string>("Prijmeni")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefon")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DatumNarozeni = new DateTime(1980, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "marie.kucerova@example.com",
                            Heslo = "securepassword",
                            Jmeno = "Marie",
                            Prijmeni = "Kučerová",
                            Telefon = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            DatumNarozeni = new DateTime(1985, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jakub.maly@example.com",
                            Heslo = "securepassword",
                            Jmeno = "Jakub",
                            Prijmeni = "Malý",
                            Telefon = "987654321"
                        },
                        new
                        {
                            Id = 3,
                            DatumNarozeni = new DateTime(1989, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "marie.novakova@example.com",
                            Heslo = "securepassword",
                            Jmeno = "Marie",
                            Prijmeni = "Nováková",
                            Telefon = "987654321"
                        },
                        new
                        {
                            Id = 4,
                            DatumNarozeni = new DateTime(2001, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "martin.bzducha@example.com",
                            Heslo = "securepassword",
                            Jmeno = "Martin",
                            Prijmeni = "Bzducha",
                            Telefon = "987654321"
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleID = 1,
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            RoleID = 1,
                            UserID = 2
                        },
                        new
                        {
                            Id = 3,
                            RoleID = 2,
                            UserID = 3
                        },
                        new
                        {
                            Id = 4,
                            RoleID = 3,
                            UserID = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
