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
                    Ukon = "Vy�et�en� o��",
                    Vystaveni = "Kompletn� vy�et�en� zraku",
                    Ockovani = "��dn�",
                    Datum = new DateTime(2024, 1, 10),
                    OrdinaceID = 1  
                },
                new LekarskaSluzba
                {
                    LSID = 2,
                    Ukon = "O�kov�n�",
                    Vystaveni = "O�kov�n� proti ch�ipce",
                    Ockovani = "Ano",
                    Datum = new DateTime(2024, 1, 15),
                    OrdinaceID = 1   
                }  
                
            };

            return lekarskeSluzby;
        }
    }
}