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

        public IList<Pacient> Select()
        {
            return _nemocniceDbContext.Pacient.ToList();
        }
        public void Create(Pacient pacient)
        {
            _nemocniceDbContext.Pacient.Add(pacient);
            _nemocniceDbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            bool deleted = false;
            Pacient? pacient
                = _nemocniceDbContext.Pacient.FirstOrDefault(prod => prod.Id == id);
            if (pacient != null)
            {
                _nemocniceDbContext.Pacient.Remove(pacient);
                _nemocniceDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }
    }
}
