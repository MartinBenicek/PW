using Nemocnice.domain.Entities;

namespace Nemocnice.application.Abstraction
{
    public interface ILekarskeSluzbyService
    {
        IList<LekarskeSluzby> Select();
        void Create(LekarskeSluzby lekarskeSluzby);
        bool Delete(int id);

    }
}
