using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ProhlidkyController : Controller
    {
        private readonly IProhlidkyService _prohlidkyService;

        public ProhlidkyController(IProhlidkyService prohlidkyService)
        {
            _prohlidkyService = prohlidkyService;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var prohlidky = _prohlidkyService.GetProhlidky();
            return View(prohlidky);
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
                return View(viewModel);
            }

            try
            {
                _prohlidkyService.CreateProhlidka(viewModel);
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
            var sluzba = _prohlidkyService.GetProhlidkaById(id);
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

            try
            {
                _prohlidkyService.UpdateProhlidka(viewModel);
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Chyba při aktualizaci záznamu: {ex.Message}");
                return View(viewModel);
            }
        }

        public IActionResult Delete(int id)
        {
            _prohlidkyService.DeleteProhlidka(id);
            return RedirectToAction(nameof(Select));
        }
    }
}