using Nemocnice.application.Abstraction;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;

namespace Nemocnice.application.Implementation
{
    public class LekarskeSluzbyAppService : ILekarskeSluzbyService
    {
        private readonly NemocniceDbContext _NemocniceDbContext;

        public LekarskeSluzbyAppService(NemocniceDbContext NemocniceDbContext)
        {
            _NemocniceDbContext = NemocniceDbContext;
        }

        public IList<LekarskeSluzby> Select()
        {
            //_NemocniceDbContext.LekarskeSluzby.Include - Select / select many
            return _NemocniceDbContext.LekarskeSluzby.ToList();
        }

        public void Create(LekarskeSluzby lekarskeSluzby)
        {
            _NemocniceDbContext.LekarskeSluzby.Add(lekarskeSluzby);
            _NemocniceDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            LekarskeSluzby? lekarskeSluzby = _NemocniceDbContext.LekarskeSluzby.Find(id);

            if (lekarskeSluzby != null)
            {
                _NemocniceDbContext.LekarskeSluzby.Remove(lekarskeSluzby);
                _NemocniceDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }
    }
}
