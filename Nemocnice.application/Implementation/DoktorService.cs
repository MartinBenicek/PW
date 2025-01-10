using Nemocnice.application.Abstraction;
using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using System.Linq;

namespace Nemocnice.application.Implementation
{
    public class DoktorService : IDoktorService
    {
        private readonly ILekarskeSluzbyService _lekarskeSluzbyService;
        private readonly IOrdinaceService _ordinaceService;

        public DoktorService(ILekarskeSluzbyService lekarskeSluzbyService, IOrdinaceService ordinaceService)
        {
            _lekarskeSluzbyService = lekarskeSluzbyService;
            _ordinaceService = ordinaceService;
        }

        public LekarskeSluzbyViewModels GetLekarskeSluzbyViewModel()
        {
            var lekarskeSluzby = _lekarskeSluzbyService.Select();
            var ordinace = _ordinaceService.Select();

            var viewModels = lekarskeSluzby.Select(ls => new LekarskeSluzbyViewModel
            {
                Id = ls.Id,
                Ukon = ls.Ukon,
                Ockovani = ls.Ockovani,
                Vysetreni = ls.Vysetreni,
                Datum = ls.Datum,
                Budova = ordinace.FirstOrDefault(o => o.Id == ls.OrdinaceID)?.Budova ?? "N/A",
                Mistnost = ordinace.FirstOrDefault(o => o.Id == ls.OrdinaceID)?.Mistnost ?? "N/A"
            }).ToList();

            return new LekarskeSluzbyViewModels
            {
                LekarskeSluzby = viewModels
            };
        }
    }
}