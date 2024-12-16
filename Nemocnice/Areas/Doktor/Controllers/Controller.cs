using Microsoft.AspNetCore.Mvc;

namespace Nemocnice.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    public class DoktorController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
