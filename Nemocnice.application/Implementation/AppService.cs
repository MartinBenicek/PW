using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.application.Abstraction;
using Nemocnice.domain;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
    public class PacientAppService : IPacientAppService
    {
        NemocniceDbContext _nemocniceDbContext;


        public PacientAppService(NemocniceDbContext nemocniceDbContext)
        {
            _nemocniceDbContext = nemocniceDbContext;
        }

        public IList<User> Select()
        {
            return _nemocniceDbContext.User.ToList();
        }
        public void Create(User pacient)
        {
            _nemocniceDbContext.User.Add(pacient);
            _nemocniceDbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            bool deleted = false;
            User? pacient
                = _nemocniceDbContext.User.FirstOrDefault(prod => prod.Id == id);
            if (pacient != null)
            {
                _nemocniceDbContext.User.Remove(pacient);
                _nemocniceDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }
    }
}
