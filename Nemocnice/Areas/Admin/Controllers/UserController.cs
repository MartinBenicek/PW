using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.infrastructure.Identity;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doktor))]
    public class UserController : Controller
    {
        IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
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
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {

                // Save the user using the application service
                _userAppService.Create(user);

                return RedirectToAction(nameof(UserController.Select));
            }
            return View(user);
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
                existingUser.PhoneNumber = updatedUser.PhoneNumber;

                // Zavolání služby pro uložení změn
                bool result = _userAppService.Edit(existingUser);

                if (result)
                {
                    return RedirectToAction(nameof(Select)); // Zpět na seznam
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
