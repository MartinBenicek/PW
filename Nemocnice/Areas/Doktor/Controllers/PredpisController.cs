using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Nemocnice.application.Abstractions;
using System.Security.Claims;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor))]
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
        public IActionResult Index()
        {
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var predpisy = _predpisService.SelectForDoctor(doctorId);
            return View(predpisy);
        }
    }
}
