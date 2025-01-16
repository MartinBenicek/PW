using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Pacient.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor))]
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
        public IActionResult Index()
        {
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var prohlidky = _prohlidkyService.SelectForDoctor(doctorId);
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
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Property: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }
                return View(viewModel); // Vrátí zpět formulář s chybami
            }

            try
            {
                _prohlidkyService.CreateProhlidka(viewModel);
                return RedirectToAction(nameof(Index)); // Přesměrování na stránku pro doktora
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while creating prohlidka: {ex.Message}");
                ModelState.AddModelError("", $"Chyba při zpracování dat: {ex.Message}");
                return View(viewModel);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _prohlidkyService.GetProhlidkaById(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProhlidkyViewModel viewModel)
        {
            if (id != viewModel.LekarskeSluzby.LekarskeSluzbyId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _prohlidkyService.UpdateProhlidka(viewModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Došlo k chybě při aktualizaci záznamu: {ex.Message}");
                }
            }

            return View(viewModel);
        }
    }
}