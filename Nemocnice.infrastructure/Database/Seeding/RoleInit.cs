using Nemocnice.domain.Entities;  
using System.Collections.Generic;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class RoleInit
    {
        public IList<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role { RoleID = 1, Nazev = "Lékaø" },
                new Role { RoleID = 2, Nazev = "Sestra" },
                new Role { RoleID = 3, Nazev = "Recepèní" }  
                
            };
        }
    }
}