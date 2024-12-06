using Nemocnice.domain.Entities;  
using System.Collections.Generic;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class OrdinaceInit
    {
        public IList<Ordinace> GetOrdinace()
        {
            return new List<Ordinace>
            {
                new Ordinace { OrdinaceID = 1, Nazev = "Ordinace pro dosp�l�" },
                new Ordinace { OrdinaceID = 2, Nazev = "D d�tsk� ordinace" },
                new Ordinace { OrdinaceID = 3, Nazev = "Ordinace pro psychiatrii" }  
                
            };
        }
    }
}