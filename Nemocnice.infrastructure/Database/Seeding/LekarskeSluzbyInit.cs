using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class LekarskeSluzbyInit
    {
        public IList<LekarskeSluzby> GetLekarskeSluzby()
        {
            IList<LekarskeSluzby> lekarskeSluzby = new List<LekarskeSluzby>();

            lekarskeSluzby.Add(new LekarskeSluzby() { Id = 1, Ockovani = "", Vysetreni = "Slepé støevo", Ukon = "Vyšetøení", Datum = DateTime.ParseExact("10-02-2025 1400", "dd-MM-yyyy HHmm", System.Globalization.CultureInfo.InvariantCulture), KartaID = 1, OrdinaceID = 1 });
            lekarskeSluzby.Add(new LekarskeSluzby() { Id = 2, Ockovani = "Encefalitida", Vysetreni = "", Ukon = "Oèkování", Datum = DateTime.ParseExact("25-04-2025 1200", "dd-MM-yyyy HHmm", System.Globalization.CultureInfo.InvariantCulture), KartaID = 3, OrdinaceID = 2 });
            lekarskeSluzby.Add(new LekarskeSluzby() { Id = 3, Ockovani = "", Vysetreni = "Zlomená noha", Ukon = "Vyšetøení", Datum = DateTime.ParseExact("05-05-2025 1600", "dd-MM-yyyy HHmm", System.Globalization.CultureInfo.InvariantCulture), KartaID = 3, OrdinaceID = 3 });

            return lekarskeSluzby;
        }
    }
}
