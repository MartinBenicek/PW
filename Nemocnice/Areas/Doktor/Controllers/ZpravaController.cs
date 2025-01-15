using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Nemocnice.application.Abstractions;
using System.Security.Claims;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor))]
    public class ZpravaController : Controller
    {
        private readonly IZpravaService _zpravaService;

        public ZpravaController(IZpravaService zpravaService)
        {
            _zpravaService = zpravaService;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var viewModel = _zpravaService.GetZpravy();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var zpravy = _zpravaService.SelectForDoctor(doctorId);
            return View(zpravy);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new KartaLekarskaZprava
            {
                Karta = new KartaViewModel(),
                LekarskaZprava = new LekarskaZpravaViewModel { Datum = DateTime.Now }
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KartaLekarskaZprava viewModel)
        {
            if (ModelState.IsValid)
            {
                _zpravaService.CreateZprava(viewModel);
                return RedirectToAction(nameof(Index)); // Přesměrování na stránku pro doktora
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _zpravaService.GetZpravaById(id);
            if (viewModel == null)
            {
                return NotFound();
            }

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
                    _zpravaService.UpdateZprava(viewModel);
                    return RedirectToAction(nameof(Index));
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
            _zpravaService.DeleteZprava(id);
            return RedirectToAction(nameof(Index));
        }
    }
}