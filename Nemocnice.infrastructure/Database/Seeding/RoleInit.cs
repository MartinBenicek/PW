using Microsoft.AspNetCore.Identity;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class RoleInit
    {
        public IList<Role> GetRolesAMC()
        {
            IList<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleDoktor = new Role()
            {
                Id = 2,
                Name = "Doktor",
                NormalizedName = "DOKTOR",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role rolePacient = new Role()
            {
                Id = 3,
                Name = "Pacient",
                NormalizedName = "PACIENT",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };

            roles.Add(roleAdmin);
            roles.Add(roleDoktor);
            roles.Add(rolePacient);

            return roles;
        }
    }
}