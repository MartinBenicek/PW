using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Pacient.Controllers
{
    [Area("Pacient")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor) + ", " + nameof(Roles.Pacient))]
    public class ZpravaController : Controller
    {
        private readonly NemocniceDbContext _context;

        public ZpravaController(NemocniceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var viewModel = (from karta in _context.Karta
                             join lekarskaZprava in _context.LekarskaZprava on karta.Id equals lekarskaZprava.KartaID
                             select new KartaLekarskaZprava
                             {
                                 Karta = new KartaViewModel
                                 {
                                     KartaId = karta.Id,
                                     PacientId = karta.PacientID
                                 },
                                 LekarskaZprava = new LekarskaZpravaViewModel
                                 {
                                     LekarskaZpravaId = lekarskaZprava.Id,
                                     Zprava = lekarskaZprava.Zprava,
                                     Datum = lekarskaZprava.Datum
                                 }
                             })
                             .ToList();
            return View(viewModel);
        }
    }
}