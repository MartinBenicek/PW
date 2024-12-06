using Nemocnice.domain.Entities;  
using System.Collections.Generic;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class UserRoleInit
    {
        public IList<UserRole> GetUserRoles()
        {
            return new List<UserRole>
            {
                new UserRole { UserRoleID = 1, Nazev = "Doktor" },
                new UserRole { UserRoleID = 2, Nazev = "Pacient" },
                new UserRole { UserRoleID = 3, Nazev = "Admin" }  
                
            };
        }
    }
}