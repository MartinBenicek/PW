﻿using Microsoft.AspNetCore.Mvc;
using Nemocnice.application.Abstraction;
using Nemocnice.infrastructure.Identity;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}