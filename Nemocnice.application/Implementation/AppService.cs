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
    }
}
