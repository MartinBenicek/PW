using Microsoft.AspNetCore.Mvc;
using Nemocnice.domain;
using Nemocnice.application.Abstraction;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PacientController : Controller
    {

        IPacientAppService _pacientAppService;

        public PacientController(IPacientAppService pacientAppService)
        {
            _pacientAppService = pacientAppService;
        }
        public IActionResult Select()
        {
            IList<Pacient> pacient = _pacientAppService.Select();
            return View(pacient);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pacient pacient)
        {
            _pacientAppService.Create(pacient);
            return RedirectToAction(nameof(PacientController.Select));
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _pacientAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(PacientController.Select));
            }
            else
                return NotFound();
        }
    }
}
