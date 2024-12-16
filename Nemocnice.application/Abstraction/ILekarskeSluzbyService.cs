using Nemocnice.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.Abstraction
{
    public interface ILekarskeSluzbyService
    {
        IList<LekarskeSluzby> Select();
        void Create(LekarskeSluzby lekarskeSluzby);
        bool Delete(int id);

    }
}
