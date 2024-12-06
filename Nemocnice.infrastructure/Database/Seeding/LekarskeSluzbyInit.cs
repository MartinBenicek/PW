using Nemocnice.domain.Entities;  
using System.Collections.Generic;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class LekarskeSluzbyInit
    {
        public IList<LekarskaSluzba> GetLekarskeSluzby()
        {
            IList<LekarskaSluzba> lekarskeSluzby = new List<LekarskaSluzba>
            {
                new LekarskaSluzba
                {
                    LSID = 1,
                    Ukon = "Vyšetøení oèí",
                    Vystaveni = "Kompletní vyšetøení zraku",
                    Ockovani = "Žádné",
                    Datum = new DateTime(2024, 1, 10),
                    OrdinaceID = 1  
                },
                new LekarskaSluzba
                {
                    LSID = 2,
                    Ukon = "Oèkování",
                    Vystaveni = "Oèkování proti chøipce",
                    Ockovani = "Ano",
                    Datum = new DateTime(2024, 1, 15),
                    OrdinaceID = 1   
                }  
                
            };

            return lekarskeSluzby;
        }
    }
}