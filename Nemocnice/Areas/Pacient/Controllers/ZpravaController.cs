using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Pacient.Controllers
{
    [Area("Pacient")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor) + ", " + nameof(Roles.Pacient))]
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
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var zpravy = _zpravaService.SelectForUser(userId);
            return View(zpravy);
        }
    }
}