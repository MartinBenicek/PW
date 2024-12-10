﻿using Microsoft.AspNetCore.Mvc;
using Nemocnice.domain;
using Nemocnice.application.Abstraction;

namespace Nemocnice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        IUserAppService _userAppService;

        public UserController(IUserAppService pacientAppService)
        {
            _userAppService = pacientAppService;
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
            _userAppService.Create(user);
            return RedirectToAction(nameof(UserController.Select));
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
