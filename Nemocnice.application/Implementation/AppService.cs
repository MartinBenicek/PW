using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.application.Abstraction;
using Nemocnice.infrastructure.Identity;
using Nemocnice.infrastructure.Database;

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
    }
}
