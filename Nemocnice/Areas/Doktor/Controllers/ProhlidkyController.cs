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
    }
}
