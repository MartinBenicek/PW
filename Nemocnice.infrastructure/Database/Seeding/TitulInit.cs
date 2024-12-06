using Nemocnice.domain;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class TitulInit
    {
        public IList<Titul> GetTituls()
        {
            IList<Titul> tituls = new List<Titul>();

            tituls.Add(new Titul() { Id = 1, titul = "MUDr" });

            return tituls;
        }
    }
}