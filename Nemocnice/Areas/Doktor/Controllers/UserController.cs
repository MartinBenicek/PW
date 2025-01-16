using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = nameof(Roles.Doktor))]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            var pacients = _userAppService.GetPacientsWithKarta();
            return View(pacients);
        }
    }
}
