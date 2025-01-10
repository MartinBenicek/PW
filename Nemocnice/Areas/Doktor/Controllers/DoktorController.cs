using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor))]
    public class DoktorController : Controller
    {
        private readonly IDoktorService _doktorService;


        public DoktorController(IDoktorService doktorService)
        {
            _doktorService = doktorService;
        }

        public IActionResult Select()
        {
            LekarskeSluzbyViewModels viewModel = _doktorService.GetLekarskeSluzbyViewModel();

            return View(viewModel);
        }
    }
}
