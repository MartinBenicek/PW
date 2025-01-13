﻿using Microsoft.AspNetCore.Authorization;
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
            var viewModel = (from karta in _context.Karta
                             join lekarskaZprava in _context.LekarskaZprava on karta.Id equals lekarskaZprava.KartaID
                             select new KartaLekarskaZprava
                             {
                                 Karta = new KartaViewModel
                                 {
                                     KartaId = karta.Id,
                                     PacientId = karta.PacientID
                                 },
                                 LekarskaZprava = new LekarskaZpravaViewModel
                                 {
                                     LekarskaZpravaId = lekarskaZprava.Id,
                                     Zprava = lekarskaZprava.Zprava,
                                     Datum = lekarskaZprava.Datum
                                 }
                             })
                             .ToList();
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var zprava = _context.LekarskaZprava.FirstOrDefault(lz => lz.Id == id);

            if (zprava != null)
            {
                _context.LekarskaZprava.Remove(zprava);
                _context.SaveChanges();

                return RedirectToAction(nameof(Select));
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LekarskaZprava lekarskaZprava)
        {
            if (ModelState.IsValid)
            {
                _context.LekarskaZprava.Add(lekarskaZprava);
                _context.SaveChanges();
                return RedirectToAction(nameof(Select));
            }

            return View(lekarskaZprava);
        }

    }
}