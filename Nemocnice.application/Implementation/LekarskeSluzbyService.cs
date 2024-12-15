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
    public class LekarskeSluzbyService
    {
        public class LekarskeSluzbyAppService : ILekarskeSluzbyService
        {
            NemocniceDbContext _NemocniceDbContext;
            public LekarskeSluzbyAppService(NemocniceDbContext NemocniceDbContext)
            {
                _NemocniceDbContext = NemocniceDbContext;
            }

            public IList<LekarskeSluzby> Select()
            {
                return _NemocniceDbContext.LekarskeSluzby.ToList();
            }
        }
    }
}
