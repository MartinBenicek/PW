using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
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

        public IActionResult Delete(int id)
        {
            var sluzba = _context.LekarskeSluzby.FirstOrDefault(lz => lz.Id == id);

            if (sluzba != null)
            {
                _context.LekarskeSluzby.Remove(sluzba);
                _context.SaveChanges();

                return RedirectToAction(nameof(Select));
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProhlidkyViewModel());
        }


        [HttpPost]
        public IActionResult Create(ProhlidkyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var lekarskeSluzby = new LekarskeSluzby
                {
                    KartaID = viewModel.Karta.KartaId,
                    Ukon = viewModel.LekarskeSluzby.Ukon,
                    Vysetreni = viewModel.LekarskeSluzby.Vysetreni,
                    Ockovani = viewModel.LekarskeSluzby.Ockovani,
                    Datum = viewModel.LekarskeSluzby.Datum,
                    OrdinaceID = viewModel.Ordinace.OrdinaceId
                };

                _context.LekarskeSluzby.Add(lekarskeSluzby);
                _context.SaveChanges();
                return RedirectToAction(nameof(Select));
            }

            return View(viewModel);
        }
    }
}
