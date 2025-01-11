using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
    public class PredpisAppService : IPredpisService
    {
        private readonly NemocniceDbContext _NemocniceDbContext;
        public PredpisAppService(NemocniceDbContext NemocniceDbContext)
        {
            _NemocniceDbContext = NemocniceDbContext;
        }

        public IList<Predpis> Select()
        {
            return _NemocniceDbContext.Predpis.ToList();
        }
    }
}
