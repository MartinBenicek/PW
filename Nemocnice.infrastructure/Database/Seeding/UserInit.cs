using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class UserInit
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public UserInit()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public User GetAdmin()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Marie",
                LastName = "Kuèerová",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGUt/AeHlqOSBUNwcWcYXNiL59K94yh+Ns5IXg5UAIpudBw3KKMGo3C8mwb4XRwpRg==", //heslo: admin
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            return admin;
        }

        public User GetDoktor()
        {
            User doktor = new User()
            {
                Id = 2,
                FirstName = "Jakub",
                LastName = "Malý",
                UserName = "doktor",
                NormalizedUserName = "DOKTOR",
                Email = "doktor@doktor.cz",
                NormalizedEmail = "DOKTOR@DOKTOR.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEHALb2xi/d5J7lHhv1LNPj75CbkccxR4qSNMiJciACCDvekvRGXcKf/499OHMPdAsA==", //heslo: manager
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            return doktor;
        }

        public User GetPacient()
        {
            User user = new User()
            {
                Id = 3,
                FirstName = "Honza",
                LastName = "Veselý",
                UserName = "pacient",
                NormalizedUserName = "PACIENT",
                Email = "pacient@pacient.cz",
                NormalizedEmail = "PACIENT@PACIENT.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEHALb2xi/d5J7lHhv1LNPj75CbkccxR4qSNMiJciACCDvekvRGXcKf/499OHMPdAsA==", //heslo: manager
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            return user;
        }
    }
}