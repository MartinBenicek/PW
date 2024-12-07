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
    }
}
