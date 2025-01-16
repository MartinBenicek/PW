using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.application.Abstraction;
using Nemocnice.infrastructure.Identity;
using Nemocnice.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Nemocnice.domain.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity.Enums;
using Nemocnice.domain.Entities;

namespace Nemocnice.application.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<User> _userManager;
        private readonly NemocniceDbContext _context;


        public UserAppService(UserManager<User> userManager, NemocniceDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<User> Select()
        {
            return _userManager.Users.ToList();
        }
        public bool Create(RegisterViewModel model)
        {
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Phone
            };

            var result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Pacient").Wait();

                var karta = new Karta
                {
                    PacientID = user.Id
                };
                _context.Karta.Add(karta);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
        public bool Delete(int id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user == null) return false;

            var result = _userManager.DeleteAsync(user).Result;
            return result.Succeeded;
        }

        public RegisterViewModel GetEditViewModel(int id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user == null) return null;

            return new RegisterViewModel
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
        }

        public bool Update(int id, RegisterViewModel model)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user == null) return false;

            user.UserName = model.Username;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.Phone;

            var result = _userManager.UpdateAsync(user).Result;
            return result.Succeeded;
        }

        public List<UserViewModel> GetUsersWithKarta()
        {
            return _context.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                KartaId = _context.Karta.Where(k => k.PacientID == u.Id).Select(k => (int?)k.Id).FirstOrDefault()
            }).ToList();
        }
    }
}
