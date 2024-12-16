using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{

    public class KartaAppService : IKartaService
    {
        private readonly NemocniceDbContext _NemocniceDbContext;
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