using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Pacient.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor))]
    public class ProhlidkyController : Controller
    {
        private readonly NemocniceDbContext _context;

        public ProhlidkyController(NemocniceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var prohlidky = (from karta in _context.Karta
                             join sluzby in _context.LekarskeSluzby on karta.Id equals sluzby.KartaID
                             join ordinace in _context.Ordinace on sluzby.OrdinaceID equals ordinace.Id
                             select new ProhlidkyViewModel
                             {
                                 Karta = new KartaViewModel
                                 {
                                     KartaId = karta.Id,
                                     PacientId = karta.PacientID
                                 },
                                 LekarskeSluzby = new LekarskeSluzbyViewModel
                                 {
                                     LekarskeSluzbyId = sluzby.Id,
                                     Ukon = sluzby.Ukon,
                                     Vysetreni = sluzby.Vysetreni,
                                     Ockovani = sluzby.Ockovani,
                                     Datum = sluzby.Datum
                                 },
                                 Ordinace = new OrdinaceViewModel
                                 {
                                     OrdinaceId = ordinace.Id,
                                     Budova = ordinace.Budova,
                                     Mistnost = ordinace.Mistnost,
                                     DoktorId = ordinace.DoktorID
                                 }
                             }).ToList();

            return View(prohlidky);
        }
    }
}
