using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
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

        [HttpGet]
        public IActionResult Create() //Stále NEFUNGUJE správně
        {
            return View(new KartaLekarskaZprava());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KartaLekarskaZprava viewModel)
        {
            if (ModelState.IsValid)
            {
                var lekarskaZprava = new LekarskaZprava
                {
                    Zprava = viewModel.LekarskaZprava.Zprava,
                    Datum = viewModel.LekarskaZprava.Datum ?? DateTime.Now,
                    KartaID = viewModel.Karta.KartaId
                };

                _context.LekarskaZprava.Add(lekarskaZprava);
                _context.SaveChanges();
                return RedirectToAction(nameof(Select));
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var zprava = _context.LekarskaZprava.FirstOrDefault(lz => lz.Id == id);
            if (zprava == null)
            {
                return NotFound();
            }

            var viewModel = new KartaLekarskaZprava
            {
                LekarskaZprava = new LekarskaZpravaViewModel
                {
                    LekarskaZpravaId = zprava.Id,
                    Zprava = zprava.Zprava,
                    Datum = zprava.Datum
                },
                Karta = new KartaViewModel
                {
                    KartaId = zprava.KartaID
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KartaLekarskaZprava viewModel)
        {
            if (id != viewModel.LekarskaZprava.LekarskaZpravaId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var zprava = _context.LekarskaZprava.FirstOrDefault(lz => lz.Id == id);
                    if (zprava == null)
                    {
                        return NotFound();
                    }

                    zprava.Zprava = viewModel.LekarskaZprava.Zprava;
                    zprava.Datum = viewModel.LekarskaZprava.Datum ?? DateTime.MinValue;
                    zprava.KartaID = viewModel.Karta.KartaId;

                    _context.LekarskaZprava.Update(zprava);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Select));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred while updating the record: {ex.Message}");
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var zprava = _context.LekarskaZprava.FirstOrDefault(lz => lz.Id == id);

            if (zprava != null)
            {
                _context.LekarskaZprava.Remove(zprava);
                _context.SaveChanges();

                return RedirectToAction(nameof(Select));
            }

            return NotFound();
        }
    }
}
