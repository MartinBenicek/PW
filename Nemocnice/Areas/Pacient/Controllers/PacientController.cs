using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Pacient")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor) + ", " + nameof(Roles.Pacient))]
    public class PacientController : Controller
    {
        private readonly IDoktorService _doktorService;


        public PacientController(IDoktorService doktorService)
        {
            _doktorService = doktorService;
        }

        public IActionResult Select()
        {
            var viewModel = _doktorService.GetLekarskaOrdinaceViewModel();

            return View(viewModel);
        }
    }
}
