using Nemocnice.domain;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class RoleInit
    {
        public IList<Role> GetRoles()
        {
            IList<Role> roles = new List<Role>();

            roles.Add(new Role() { Id = 1, Nazev = "Pacient" });
            roles.Add(new Role() { Id = 2, Nazev = "Doktor" });
            roles.Add(new Role() { Id = 3, Nazev = "Admin" });
           
            return roles;
        }
    }
}