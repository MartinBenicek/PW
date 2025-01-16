using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class OrdinaceInit
    {
        public IList<Ordinace> GetOrdinaces()
        {
            IList<Ordinace> ordinaces = new List<Ordinace>();

            ordinaces.Add(new Ordinace() { Id = 1, Budova = "A1", Mistnost = "1/4", DoktorID = 1, ImageSrc = "\\img\\ordinace\\ordinace A1.jpg" });
            ordinaces.Add(new Ordinace() { Id = 2, Budova = "B1", Mistnost = "2/3", DoktorID = 2, ImageSrc = "\\img\\ordinace\\ordinace B1.jpg" });
            ordinaces.Add(new Ordinace() { Id = 3, Budova = "C1", Mistnost = "2/1", DoktorID = 2, ImageSrc = "\\img\\ordinace\\ordinace C1.jpg" });

            return ordinaces;
        }
    }
}
