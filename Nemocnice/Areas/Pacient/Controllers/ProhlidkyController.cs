using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Pacient")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor) + ", " + nameof(Roles.Pacient))]
    public class ProhlidkyController : Controller
    {
        private readonly IProhlidkyService _prohlidkyService;

        public ProhlidkyController(IProhlidkyService prohlidkyService)
        {
            _prohlidkyService = prohlidkyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var prohlidky = _prohlidkyService.SelectForUser(userId);
            return View(prohlidky);
        }
    }
}
