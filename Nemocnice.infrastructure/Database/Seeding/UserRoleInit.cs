using Microsoft.AspNetCore.Identity;
using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class UserRoleInit
    {
        public List<IdentityUserRole<int>> GetRolesForAdmin()
        {
            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };
            return adminUserRoles;
        }

        public List<IdentityUserRole<int>> GetRolesForDoktor()
        {
            List<IdentityUserRole<int>> doktorUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };
            return doktorUserRoles;
        }

        public List<IdentityUserRole<int>> GetRolesForPacient()
        {
            List<IdentityUserRole<int>> pacientUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 3,
                    RoleId = 3
                }
            };
            return pacientUserRoles;
        }
    }
    
}