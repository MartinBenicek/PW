using Nemocnice.domain.Entities;  
using System.Collections.Generic;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class KartaInit
    {
        public IList<Karta> GetKartas()
        {
            IList<Karta> karty = new List<Karta>
            {
                new Karta
                {
                    KartalID = 1,
                    Stav = "Aktivní",
                    LSID = 1,  
                    PacientID = 1001  
                },
                new Karta
                {
                    KartalID = 2,
                    Stav = "Neaktivní",
                    LSID = 2,  
                    PacientID = 1002  
                }  
                
            };

            return karty;
        }
    }
}