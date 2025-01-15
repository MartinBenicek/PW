﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nemocnice.infrastructure.Database;

#nullable disable

namespace Nemocnice.infrastructure.Migrations
{
    [DbContext(typeof(NemocniceDbContext))]
    [Migration("20250115122118_23th migration")]
    partial class _23thmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Nemocnice.domain.Entities.Karta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PacientID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Karta");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PacientID = 1
                        },
                        new
                        {
                            Id = 2,
                            PacientID = 2
                        },
                        new
                        {
                            Id = 3,
                            PacientID = 3
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Entities.LekarskaZprava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("KartaID")
                        .HasColumnType("int");

                    b.Property<string>("Zprava")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LekarskaZprava");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Datum = new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            KartaID = 1,
                            Zprava = "Pacient vykazuje známky zlepšení, doporučeno pokračovat v současné léčbě, kontrola za 14 dní."
                        },
                        new
                        {
                            Id = 2,
                            Datum = new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            KartaID = 2,
                            Zprava = "Pacientovi doporučeny Nasivin nosní kapky pro zmírnění ucpaného nosu. Aplikovat 1–2 kapky do každé nosní dírky maximálně 3× denně po dobu maximálně 7 dní. "
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Entities.LekarskeSluzby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

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
                            Datum = new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            KartaID = 1,
                            Ockovani = "",
                            OrdinaceID = 1,
                            Ukon = "Vyšetření",
                            Vysetreni = "Slepé střevo"
                        },
                        new
                        {
                            Id = 2,
                            Datum = new DateTime(2025, 4, 25, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            KartaID = 1,
                            Ockovani = "Encefalitida",
                            OrdinaceID = 2,
                            Ukon = "Očkování",
                            Vysetreni = ""
                        },
                        new
                        {
                            Id = 3,
                            Datum = new DateTime(2025, 5, 5, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            KartaID = 2,
                            Ockovani = "",
                            OrdinaceID = 3,
                            Ukon = "Vyšetření",
                            Vysetreni = "Zlomená noha"
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Entities.Ordinace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Budova")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DoktorID")
                        .HasColumnType("int");

                    b.Property<string>("Mistnost")
                        .IsRequired()
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
                            DoktorID = 2,
                            Mistnost = "2/3"
                        },
                        new
                        {
                            Id = 3,
                            Budova = "C1",
                            DoktorID = 2,
                            Mistnost = "2/1"
                        });
                });

            modelBuilder.Entity("Nemocnice.domain.Entities.Predpis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CasPodani")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LekarskaZpravaID")
                        .HasColumnType("int");

                    b.Property<string>("NazevLeku")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TypLeku")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LekarskaZpravaID");

                    b.ToTable("Predpis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CasPodani = "Ráno a večer",
                            LekarskaZpravaID = 1,
                            NazevLeku = "Cotrimoxazol",
                            TypLeku = "tableta"
                        },
                        new
                        {
                            Id = 2,
                            CasPodani = "3x denně",
                            LekarskaZpravaID = 2,
                            NazevLeku = "Nasivin",
                            TypLeku = "kapky"
                        },
                        new
                        {
                            Id = 3,
                            CasPodani = "3x denně",
                            LekarskaZpravaID = 2,
                            NazevLeku = "Bepanthen",
                            TypLeku = "mast"
                        });
                });

            modelBuilder.Entity("Nemocnice.infrastructure.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660",
                            Name = "Doktor",
                            NormalizedName = "DOKTOR"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee",
                            Name = "Pacient",
                            NormalizedName = "PACIENT"
                        });
                });

            modelBuilder.Entity("Nemocnice.infrastructure.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                            Email = "admin@admin.cz",
                            EmailConfirmed = true,
                            FirstName = "Marie",
                            LastName = "Kučerová",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.CZ",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEGUt/AeHlqOSBUNwcWcYXNiL59K94yh+Ns5IXg5UAIpudBw3KKMGo3C8mwb4XRwpRg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                            Email = "doktor@doktor.cz",
                            EmailConfirmed = true,
                            FirstName = "Jakub",
                            LastName = "Malý",
                            LockoutEnabled = true,
                            NormalizedEmail = "DOKTOR@DOKTOR.CZ",
                            NormalizedUserName = "DOKTOR",
                            PasswordHash = "AQAAAAIAAYagAAAAEHALb2xi/d5J7lHhv1LNPj75CbkccxR4qSNMiJciACCDvekvRGXcKf/499OHMPdAsA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                            TwoFactorEnabled = false,
                            UserName = "doktor"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                            Email = "pacient@pacient.cz",
                            EmailConfirmed = true,
                            FirstName = "Honza",
                            LastName = "Veselý",
                            LockoutEnabled = true,
                            NormalizedEmail = "PACIENT@PACIENT.CZ",
                            NormalizedUserName = "PACIENT",
                            PasswordHash = "AQAAAAIAAYagAAAAEHALb2xi/d5J7lHhv1LNPj75CbkccxR4qSNMiJciACCDvekvRGXcKf/499OHMPdAsA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                            TwoFactorEnabled = false,
                            UserName = "pacient"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Nemocnice.infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Nemocnice.infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Nemocnice.infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Nemocnice.infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nemocnice.infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Nemocnice.infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nemocnice.domain.Entities.Predpis", b =>
                {
                    b.HasOne("Nemocnice.domain.Entities.LekarskaZprava", "LekarskaZprava")
                        .WithMany()
                        .HasForeignKey("LekarskaZpravaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LekarskaZprava");
                });
#pragma warning restore 612, 618
        }
    }
}
