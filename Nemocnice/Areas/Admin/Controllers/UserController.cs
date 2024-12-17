using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.infrastructure.Identity;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class UserController : Controller
    {
        IUserAppService _userAppService;

        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager, IUserAppService userAppService)
        {
            _userManager = userManager;
            _userAppService = userAppService;
        }
        public IActionResult Select()
        {
            IList<User> user = _userAppService.Select();
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Použití UserManager pro vytvoření uživatele
                var result = await _userManager.CreateAsync(user, "DefaultPassword123!");

                if (result.Succeeded)
                {
                    // Vše je v pořádku, přesměrujeme na seznam uživatelů
                    return RedirectToAction(nameof(UserController.Select));
                }
                else
                {
                    // Přidání chyb do ModelState pro zobrazení uživateli
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(user); // Vrácení formuláře v případě chyby
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _userAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(UserController.Select));
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Získání uživatele podle ID
            var user = _userAppService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user); 
        }

        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            if (ModelState.IsValid)
            {
                // Získání existujícího uživatele z databáze
                var existingUser = _userAppService.GetById(updatedUser.Id);

                if (existingUser == null)
                {
                    return NotFound(); 
                }

                // Aktualizace vlastností uživatele
                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.Email = updatedUser.Email;
                existingUser.UserName = updatedUser.UserName;
                existingUser.PhoneNumber = updatedUser.PhoneNumber;

                // Zavolání služby pro uložení změn
                bool result = _userAppService.Edit(existingUser);

                if (result)
                {
                    return RedirectToAction(nameof(Select));
                }
                else
                {
                    ModelState.AddModelError("", "Update failed. Please try again.");
                }
            }

            return View(updatedUser); // Vrátit formulář s chybami
        }

    }
}
