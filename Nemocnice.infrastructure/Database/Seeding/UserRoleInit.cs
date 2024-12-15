using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class UserRoleInit
    {
        public IList<UserRole> GetUserRoles()
        {
            IList<UserRole> userRoles = new List<UserRole>();
            userRoles.Add(new UserRole()
            {
               Id = 1,
               RoleID = 1,
               UserID = 1,
            });
            userRoles.Add(new UserRole()
            {
                Id = 2,
                RoleID = 1,
                UserID = 2,
            });
            userRoles.Add(new UserRole()
            {
                Id = 3,
                RoleID = 2,
                UserID = 3,
            });
            userRoles.Add(new UserRole()
            {
                Id = 4,
                RoleID = 3,
                UserID = 4,
            });

            return userRoles;
        }
    }
}