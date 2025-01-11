using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ZpravaController : Controller
    {
        private readonly NemocniceDbContext _context;

        public ZpravaController(NemocniceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var viewModel = _context.LekarskaZprava.ToList();
            return View(viewModel);
        }
    }
}