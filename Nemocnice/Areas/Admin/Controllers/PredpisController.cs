using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
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
            var data = _context.Predpis.Include(p => p.LekarskaZprava)
                .Select(p => new LekarskaZpravaPredpisViewModel
                {
                    Predpis = new PredpisViewModel
                    {
                        Id = p.Id,
                        TypLeku = p.TypLeku,
                        NazevLeku = p.NazevLeku,
                        CasPodani = p.CasPodani,
                        LekarskaZpravaId = p.LekarskaZpravaID
                    },
                    LekarskaZprava = new LekarskaZpravaViewModel
                    {
                        LekarskaZpravaId = p.LekarskaZprava.Id,
                        Datum = p.LekarskaZprava.Datum,
                        Zprava = p.LekarskaZprava.Zprava,
                        KartaId = p.LekarskaZprava.KartaID
                    }
                }).ToList();

            return View(data); // Pass the correctly typed data to the view
        }


        public IActionResult Delete(int id)
        {
            var predpis = _context.Predpis.FirstOrDefault(lz => lz.Id == id);

            if (predpis != null)
            {
                _context.Predpis.Remove(predpis);
                _context.SaveChanges();

                return RedirectToAction(nameof(Select));
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new LekarskaZpravaPredpisViewModel());
        }

        [HttpPost]
        public IActionResult Create(LekarskaZpravaPredpisViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Validate the LekarskaZpravaId
                var isLekarskaZpravaValid = _context.LekarskaZprava.Any(lz => lz.Id == viewModel.Predpis.LekarskaZpravaId);
                if (!isLekarskaZpravaValid)
                {
                    ModelState.AddModelError("Predpis.LekarskaZpravaId", "Invalid LekarskaZpravaId.");
                    return View(viewModel);
                }

                var predpis = new Predpis
                {
                    LekarskaZpravaID = viewModel.Predpis.LekarskaZpravaId,
                    TypLeku = viewModel.Predpis.TypLeku,
                    NazevLeku = viewModel.Predpis.NazevLeku,
                    CasPodani = viewModel.Predpis.CasPodani
                };

                _context.Predpis.Add(predpis);
                _context.SaveChanges();
                return RedirectToAction(nameof(Select));
                
                
            }

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var predpis = _context.Predpis
                .Include(p => p.LekarskaZprava)
                .FirstOrDefault(p => p.Id == id);

            if (predpis == null)
            {
                return NotFound();
            }

            var viewModel = new LekarskaZpravaPredpisViewModel
            {
                Predpis = new PredpisViewModel
                {
                    Id = predpis.Id,
                    TypLeku = predpis.TypLeku,
                    NazevLeku = predpis.NazevLeku,
                    CasPodani = predpis.CasPodani,
                    LekarskaZpravaId = predpis.LekarskaZpravaID
                },
                LekarskaZprava = new LekarskaZpravaViewModel
                {
                    LekarskaZpravaId = predpis.LekarskaZpravaID,
                    Zprava = predpis.LekarskaZprava?.Zprava,
                    Datum = predpis.LekarskaZprava?.Datum,
                    KartaId = predpis.LekarskaZprava?.KartaID ?? 0
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(LekarskaZpravaPredpisViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var predpis = _context.Predpis
                    .Include(p => p.LekarskaZprava)
                    .FirstOrDefault(p => p.Id == viewModel.Predpis.Id);

                if (predpis == null)
                {
                    return NotFound();
                }

                predpis.TypLeku = viewModel.Predpis.TypLeku;
                predpis.NazevLeku = viewModel.Predpis.NazevLeku;
                predpis.CasPodani = viewModel.Predpis.CasPodani;


                _context.SaveChanges();

                return RedirectToAction(nameof(Select));
                
                
            }

            return View(viewModel);
        }



    }
}
