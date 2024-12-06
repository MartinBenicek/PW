using Nemocnice.domain.Entities;  
using System.Collections.Generic;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class DoktorInit
    {
        public IList<Doktor> GetDoktors(IList<Titul> tituly, IList<UserRole> userRoles, IList<User> users)
        {
            IList<Doktor> doktori = new List<Doktor>();

            
            doktori.Add(new Doktor()
            {
                DoktorID = 1,
                Titul = tituly.First(t => t.Nazev == "MUDr.").Id,  
                UserRoleID = userRoles.First(ur => ur.Nazev == "Doktor").UserRoleID,  
                UserID = users.First(u => u.Jmeno == "Marie" && u.Prijmeni == "Kuèerová").UserID  
            });
            doktori.Add(new Doktor()
            {
                DoktorID = 2,
                Titul = tituly.First(t => t.Nazev == "Bc.").Id,
                UserRoleID = userRoles.First(ur => ur.Nazev == "Doktor").UserRoleID,
                UserID = users.First(u => u.Jmeno == "Jakub" && u.Prijmeni == "Malý").UserID
            });

            return doktori;
        }
    }
}