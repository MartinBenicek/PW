using Nemocnice.application.Abstraction;
using Nemocnice.application.ViewModels;

public class PacientService : IPacientService
{
    ILekarskeSluzbyService _lekarskeSluzbyService;
    IOrdinaceService _ordinaceService;
    ILekarskaZpravaService _lekarskaZpravaService;
    IPredpisService _predpisService;

    public PacientService(ILekarskeSluzbyService lekarskeSluzbyService, IOrdinaceService ordinaceService, ILekarskaZpravaService lekarskaZprava, IPredpisService predpisService)
    {
        _lekarskeSluzbyService = lekarskeSluzbyService;
        _ordinaceService = ordinaceService;
        _lekarskaZpravaService = lekarskaZprava;
        _predpisService = predpisService;
    }

    public LekarskaOrdinaceViewModel GetLekarskaOrdinaceViewModel()
    {
        var ordinaces = _ordinaceService.Select();
        var lekarskeSluzby = _lekarskeSluzbyService.Select();
        var lekarskeZpravy = _lekarskaZpravaService.Select();
        var predpisy = _predpisService.Select();

        var lekarskaEvidences = lekarskeSluzby.Select(sluzba => new LekarskaEvidenceViewModel
        {
            LekarskeSluzbies = new List<LekarskeSluzbyViewModel>
        {
            new LekarskeSluzbyViewModel
            {
                Id = sluzba.Id,
                Ukon = sluzba.Ukon,
                Ockovani = sluzba.Ockovani,
                Vysetreni = sluzba.Vysetreni,
                Datum = sluzba.Datum
            }
        },
            LekarskaZpravas = lekarskeZpravy
                .Where(z => z.LekarskeSluzbyID == sluzba.Id) // Ensure relationships are set up in your models.
                .Select(z => new LekarskaZpravaViewModel
                {
                    Id = z.Id,
                    Datum = z.Datum,
                    Zprava = z.Zprava
                }).ToList(),
            Prepises = predpisy
                .Where(p => p.LekarskeSluzbyID == sluzba.Id)
                .Select(p => new PredpisViewModel
                {
                    Id = p.Id,
                    TypLeku = p.TypLeku,
                    NazevLeku = p.NazevLeku,
                    CasPodani = p.CasPodani
                }).ToList()
        }).ToList();

        return new LekarskaOrdinaceViewModel
        {
            Ordinaces = (IList<OrdinaceViewModel>)ordinaces,
            LekarskaEvidences = lekarskaEvidences
        };
    }
}