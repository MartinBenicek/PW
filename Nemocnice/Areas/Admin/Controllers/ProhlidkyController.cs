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
            return View(new ProhlidkyViewModel
            {
                Karta = new KartaViewModel(),
                Ordinace = new OrdinaceViewModel(),
                LekarskeSluzby = new LekarskeSluzbyViewModel()
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProhlidkyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel); // Vrátí zpět formulář s chybami
            }

            try
            {
                var lekarskeSluzby = new LekarskeSluzby
                {
                    KartaID = viewModel.Karta.KartaId,
                    OrdinaceID = viewModel.Ordinace.OrdinaceId,
                    Ukon = viewModel.LekarskeSluzby.Ukon,
                    Vysetreni = viewModel.LekarskeSluzby.Vysetreni,
                    Ockovani = viewModel.LekarskeSluzby.Ockovani,
                    Datum = viewModel.LekarskeSluzby.Datum
                };

                _context.LekarskeSluzby.Add(lekarskeSluzby);
                _context.SaveChanges();
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Chyba při zpracování dat: {ex.Message}");
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sluzba = (from karta in _context.Karta
                          join sluzby in _context.LekarskeSluzby on karta.Id equals sluzby.KartaID
                          join ordinace in _context.Ordinace on sluzby.OrdinaceID equals ordinace.Id
                          where sluzby.Id == id
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
                          }).FirstOrDefault();

            if (sluzba == null)
            {
                return NotFound();
            }

            return View(sluzba);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProhlidkyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var sluzba = _context.LekarskeSluzby.FirstOrDefault(lz => lz.Id == viewModel.LekarskeSluzby.LekarskeSluzbyId);

            if (sluzba == null)
            {
                ModelState.AddModelError("", "Záznam nebyl nalezen.");
                return View(viewModel);
            }

            try
            {
                sluzba.Ukon = viewModel.LekarskeSluzby.Ukon;
                sluzba.Vysetreni = viewModel.LekarskeSluzby.Vysetreni;
                sluzba.Ockovani = viewModel.LekarskeSluzby.Ockovani;
                sluzba.Datum = viewModel.LekarskeSluzby.Datum;
                sluzba.KartaID = viewModel.Karta.KartaId;
                sluzba.OrdinaceID = viewModel.Ordinace.OrdinaceId;

                _context.LekarskeSluzby.Update(sluzba);
                _context.SaveChanges();

                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Chyba při aktualizaci záznamu: {ex.Message}");
                return View(viewModel);
            }
        }

    }
}
