using Nemocnice.domain.Entities;  
using System.Collections.Generic;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class TitulInit
    {
        public IList<Titul> GetTituly()
        {
            return new List<Titul>
            {
                new Titul { Id = 1, Nazev = "MUDr." },
                new Titul { Id = 2, Nazev = "Bc." },
                new Titul { Id = 3, Nazev = "Ph.D." }  
                 
            };
        }
    }
}