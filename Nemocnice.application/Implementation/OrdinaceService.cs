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
    public class OrdinaceService
    {
        public class OrdinaceAppService : IOrdinaceService
        {
            NemocniceDbContext _NemocniceDbContext;
            public OrdinaceAppService(NemocniceDbContext NemocniceDbContext)
            {
                _NemocniceDbContext = NemocniceDbContext;
            }

            public IList<Ordinace> Select()
            {
                return _NemocniceDbContext.Ordinace.ToList();
            }
        }
    }
}
