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
        private readonly ILekarskeSluzbyService _lekarskeSluzbyService;

        public DoktorController(ILekarskeSluzbyService lekarskeSluzbyService)
        {
            _lekarskeSluzbyService = lekarskeSluzbyService;
        }

        public IActionResult Select()
        {
            // Získání dat
            var lekarskeSluzby = _lekarskeSluzbyService.Select();

            // Příprava ViewModelu
            var viewModel = new 
            {
                LekarskeSluzby = lekarskeSluzby,
                Ordinace = new List<Ordinace>()
            };

            // Předání ViewModelu do View
            return View(viewModel);
        }
    }
}
