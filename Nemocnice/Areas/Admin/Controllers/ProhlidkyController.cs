using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity.Enums;
using Microsoft.Extensions.Logging;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ProhlidkyController : Controller
    {
        private readonly IProhlidkyService _prohlidkyService;
        private readonly ILogger<ProhlidkyController> _logger;

        public ProhlidkyController(IProhlidkyService prohlidkyService, ILogger<ProhlidkyController> logger)
        {
            _prohlidkyService = prohlidkyService;
            _logger = logger;
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
                _logger.LogWarning("ModelState is not valid");
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        _logger.LogWarning($"Property: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }
                return View(viewModel); // Vrátí zpět formulář s chybami
            }

            try
            {
                _logger.LogInformation("Calling CreateProhlidka in ProhlidkyService");
                _prohlidkyService.CreateProhlidka(viewModel);
                _logger.LogInformation("CreateProhlidka called successfully");
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while creating prohlidka");
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