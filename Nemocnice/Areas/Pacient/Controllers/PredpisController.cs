using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Pacient.Controllers
{
    [Area("Pacient")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor) + ", " + nameof(Roles.Pacient))]
    public class PredpisController : Controller
    {
        NemocniceDbContext _context;

        public PredpisController(NemocniceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var viewModel = (from karta in _context.Karta
                             join lekarskaZprava in _context.LekarskaZprava on karta.Id equals lekarskaZprava.KartaID
                             join predpis in _context.Predpis on lekarskaZprava.Id equals predpis.LekarskaZpravaID
                             select new KartaPredpisViewModel
                             {
                                 Karta = new KartaViewModel
                                 {
                                     KartaId = karta.Id,
                                     PacientId = karta.PacientID
                                 },
                                 Predpis = new PredpisViewModel
                                 {
                                     Id = predpis.Id,
                                     TypLeku = predpis.TypLeku,
                                     NazevLeku = predpis.NazevLeku,
                                     CasPodani = predpis.CasPodani
                                 }
                             })
                             .GroupBy(x => x.Karta.KartaId)
                             .Select(group => group.OrderByDescending(x => x.Predpis.Id).First())
                             .ToList();

            return View(viewModel);
        }
    }
}
