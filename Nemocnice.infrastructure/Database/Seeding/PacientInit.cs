using Nemocnice.domain.Entities;
using System.Collections.Generic;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class PacientInit
    {
        public IList<Pacient> GetPacients(IList<Karta> karty, IList<UserRole> userRoles, IList<User> users)
        {
            IList<Pacient> pacienti = new List<Pacient>();


            pacienti.Add(new Pacient()
            {
                PacientID = 1,
                UserRoleID = userRoles.First(ur => ur.Nazev == "Pacient").UserRoleID,
                UserID = users.First(u => u.Jmeno == "Marie" && u.Prijmeni == "Nováková").UserID
            });
            doktori.Add(new Pacient()
            {
                PacientID = 2,
                UserRoleID = userRoles.First(ur => ur.Nazev == "Pacient").UserRoleID,
                UserID = users.First(u => u.Jmeno == "Martin" && u.Prijmeni == "Bzducha").UserID
            });

            return doktori;
        }
    }
}