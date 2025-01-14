using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
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
        public IActionResult Create()
        {
            return View(new KartaLekarskaZprava());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KartaLekarskaZprava viewModel)
        {
            if (ModelState.IsValid)
            {
                _zpravaService.CreateZprava(viewModel);
                return RedirectToAction(nameof(Select));
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
            _zpravaService.DeleteZprava(id);
            return RedirectToAction(nameof(Select));
        }
    }
}