using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
    public class KartaService
    {
        public class KartaAppService : IKartaService
        {
            NemocniceDbContext _NemocniceDbContext;
            public KartaAppService(NemocniceDbContext NemocniceDbContext)
            {
                _NemocniceDbContext = NemocniceDbContext;
            }

            public IList<Karta> Select()
            {
                return _NemocniceDbContext.Karta.ToList();
            }
        }
    }
}