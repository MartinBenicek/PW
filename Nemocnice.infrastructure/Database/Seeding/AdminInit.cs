using Nemocnice.domain;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class AdminInit
    {
        public IList<Admin> GetAdmins()
        {
            IList<Admin> admins = new List<Admin>();

            admins.Add(new Admin()
            {
                Id = 1,
                UserRoleID = 4,
            });

            return admins;
        }
    }
}