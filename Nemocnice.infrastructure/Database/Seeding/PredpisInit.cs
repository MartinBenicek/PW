using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class PredpisInit
    {
        public IList<Predpis> GetPredpis()
        {
            IList<Predpis> predpis = new List<Predpis>();

            predpis.Add(new Predpis() { Id = 1, TypLeku = "tableta", NazevLeku = "Cotrimoxazol", CasPodani = "Ráno a večer", LekarskaZpravaID = 1 });
            predpis.Add(new Predpis() { Id = 2, TypLeku = "kapky", NazevLeku = "Nasivin", CasPodani = "3x denně", LekarskaZpravaID = 2 });
            predpis.Add(new Predpis() { Id = 3, TypLeku = "mast", NazevLeku = "Bepanthen", CasPodani = "3x denně", LekarskaZpravaID = 2 });

            return predpis;
        }
    }
}