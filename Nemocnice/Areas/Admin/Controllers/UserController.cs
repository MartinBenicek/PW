using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity;
using Nemocnice.infrastructure.Identity.Enums;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class UserController : Controller
    {

        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Select()
        {
            List<UserViewModel> users = _userAppService.GetUsersWithKarta();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userAppService.Create(model);
                if (result)
                {
                    return RedirectToAction(nameof(Select));
                }
                ModelState.AddModelError(string.Empty, "Failed to create user.");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _userAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Select));
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _userAppService.GetEditViewModel(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userAppService.Update(id, model);
                if (result)
                {
                    return RedirectToAction(nameof(Select));
                }
                ModelState.AddModelError(string.Empty, "Failed to update user.");
            }
            return View(model);
        }

    }
}
