using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Nemocnice.application.Abstractions;
using System.Security.Claims;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor))]
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
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var zpravy = _zpravaService.SelectForDoctor(doctorId);
            return View(zpravy);
        }
    }
}