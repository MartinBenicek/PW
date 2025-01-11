using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Nemocnice.Areas.Pacient.Controllers
{
    [Area("Pacient")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor) + ", " + nameof(Roles.Pacient))]
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
            var viewModel = _context.Predpis
           .GroupBy(p => p.LekarskaZpravaID)
           .Select(group => group.OrderByDescending(p => p.Id).First())
           .ToList();

            return View(viewModel);
        }
    }
}
