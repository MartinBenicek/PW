using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor))]
    public class PredpisController : Controller
    {
        NemocniceDbContext _context;

        public PredpisController(NemocniceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var viewModel = _context.Predpis.ToList();

            return View(viewModel);
        }
    }
}
