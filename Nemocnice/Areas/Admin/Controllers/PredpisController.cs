using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class PredpisController : Controller
    {
        private readonly IPredpisService _predpisService;

        public PredpisController(IPredpisService predpisService)
        {
            _predpisService = predpisService;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var viewModel = _predpisService.GetPredpisy();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new LekarskaZpravaPredpisViewModel
            {
                Predpis = new PredpisViewModel(),
                LekarskaZprava = new LekarskaZpravaViewModel()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LekarskaZpravaPredpisViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _predpisService.CreatePredpis(viewModel.Predpis);
                return RedirectToAction(nameof(Select));
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var predpis = _predpisService.GetPredpisById(id);
            if (predpis == null)
            {
                return NotFound();
            }

            var viewModel = new LekarskaZpravaPredpisViewModel
            {
                Predpis = predpis,
                LekarskaZprava = new LekarskaZpravaViewModel
                {
                    LekarskaZpravaId = predpis.LekarskaZpravaId
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LekarskaZpravaPredpisViewModel viewModel)
        {
            if (id != viewModel.Predpis.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _predpisService.UpdatePredpis(viewModel.Predpis);
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
            _predpisService.DeletePredpis(id);
            return RedirectToAction(nameof(Select));
        }
    }
}