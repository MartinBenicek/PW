using Nemocnice.domain;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class OrdinaceInit
    {
        public IList<Ordinace> GetOrdinaces()
        {
            IList<Ordinace> ordinaces = new List<Ordinace>();

            ordinaces.Add(new Ordinace() { Id = 1, Budova = "A1", Mistnost = "1/4", DoktorID = 1 });
            ordinaces.Add(new Ordinace() { Id = 2, Budova = "B1", Mistnost = "2/3", DoktorID = 1 });
            ordinaces.Add(new Ordinace() { Id = 3, Budova = "C1", Mistnost = "2/1", DoktorID = 1 });

            return ordinaces;
        }
    }
}
