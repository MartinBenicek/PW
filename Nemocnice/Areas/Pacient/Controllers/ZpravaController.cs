using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Pacient.Controllers
{
    [Area("Pacient")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor) + ", " + nameof(Roles.Pacient))]
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