using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class KartaInit
    {
        public IList<Karta> GetKartas()
        {
            IList<Karta> kartas = new List<Karta>();

            kartas.Add(new Karta() { Id = 1, PacientID = 1, LekarskeSluzbyID = 1 });
            kartas.Add(new Karta() { Id = 2, PacientID = 2, LekarskeSluzbyID = 2 });
            
            return kartas;
        }
    }
}