using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
    public class LekarskaZpravaService : ILekarskaZpravaService
    {
        private readonly NemocniceDbContext _NemocniceDbContext;
        public LekarskaZpravaService(NemocniceDbContext NemocniceDbContext)
        {
            _NemocniceDbContext = NemocniceDbContext;
        }

        public IList<LekarskaZprava> Select()
        {
            return _NemocniceDbContext.LekarskaZprava.ToList();
        }
    }
}
