using Nemocnice.domain.Entities;

namespace Nemocnice.Infrastructure.Database.Seeding
{
    internal class LekarskaZpravaInit
    {
        public IList<LekarskaZprava> GetLekarskaZprava()
        {
            IList<LekarskaZprava> lekarskaZprava = new List<LekarskaZprava>();

            lekarskaZprava.Add(new LekarskaZprava() { Id = 1, Zprava = "Pacient vykazuje známky zlepšení, doporučeno pokračovat v současné léčbě, kontrola za 14 dní.", Datum = DateTime.ParseExact("10-02-2025 1400", "dd-MM-yyyy HHmm", System.Globalization.CultureInfo.InvariantCulture), LekarskeSluzbyID = 1 });
            lekarskaZprava.Add(new LekarskaZprava() { Id = 2, Zprava = "Pacientovi doporučeny Nasivin nosní kapky pro zmírnění ucpaného nosu. Aplikovat 1–2 kapky do každé nosní dírky maximálně 3× denně po dobu maximálně 7 dní. ", Datum = DateTime.ParseExact("10-02-2025 1400", "dd-MM-yyyy HHmm", System.Globalization.CultureInfo.InvariantCulture), LekarskeSluzbyID = 2 });
            lekarskaZprava.Add(new LekarskaZprava() { Id = 3, Zprava = "Pacientovi doporučen Bepanthen hojivý krém na podrážděnou nebo suchou pokožku. Aplikovat tenkou vrstvu na postižené místo 2–3× denně dle potřeby.", Datum = DateTime.ParseExact("10-02-2025 1400", "dd-MM-yyyy HHmm", System.Globalization.CultureInfo.InvariantCulture), LekarskeSluzbyID = 3 });

            return lekarskaZprava;
        }
    }
}