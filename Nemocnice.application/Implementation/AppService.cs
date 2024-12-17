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

namespace Nemocnice.application.Implementation
{
    public class UserAppService : IUserAppService
    {
        NemocniceDbContext _nemocniceDbContext;


        public UserAppService(NemocniceDbContext nemocniceDbContext)
        {
            _nemocniceDbContext = nemocniceDbContext;
        }

        public IList<User> Select()
        {
            return _nemocniceDbContext.Users.ToList();
        }
        public void Create(User user)
        {
            _nemocniceDbContext.Users.Add(user);
            _nemocniceDbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            bool deleted = false;
            User? pacient
                = _nemocniceDbContext.Users.FirstOrDefault(prod => prod.Id == id);
            if (pacient != null)
            {
                _nemocniceDbContext.Users.Remove(pacient);
                _nemocniceDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        public User GetById(int id)
        {
            return _nemocniceDbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool Edit(User updatedUser)
        {
            bool edited = false;
            User? pacient
                = _nemocniceDbContext.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (pacient != null)
            {
                pacient.FirstName = updatedUser.FirstName;
                pacient.LastName = updatedUser.LastName;
                pacient.Email = updatedUser.Email;
                pacient.PhoneNumber = updatedUser.PhoneNumber;
                pacient.UserName = updatedUser.UserName;
                _nemocniceDbContext.SaveChanges();
                edited = true;
            }
            return edited;
        }
    }
}
