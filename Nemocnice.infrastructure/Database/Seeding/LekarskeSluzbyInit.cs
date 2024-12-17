using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class LekarskeSluzbyInit
    {
        public IList<LekarskeSluzby> GetLekarskeSluzby()
        {
            IList<LekarskeSluzby> lekarskeSluzby = new List<LekarskeSluzby>();

            lekarskeSluzby.Add(new LekarskeSluzby() { Id = 1, Ockovani = "", Vysetreni = "Slepé støevo", Ukon = "Vyšetøení", KartaID = 1, OrdinaceID = 1 });
            lekarskeSluzby.Add(new LekarskeSluzby() { Id = 2, Ockovani = "Encefalitida", Vysetreni = "", Ukon = "Oèkování", KartaID = 1, OrdinaceID = 2 });
            lekarskeSluzby.Add(new LekarskeSluzby() { Id = 3, Ockovani = "", Vysetreni = "Zlomená noha", Ukon = "Vyšetøení", KartaID = 2, OrdinaceID = 3 });

            return lekarskeSluzby;
        }
    }
}
