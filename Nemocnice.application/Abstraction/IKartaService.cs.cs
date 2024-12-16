using Nemocnice.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.Abstraction
{
    public interface IKartaService
    {
        IList<Karta> Select();
        void Create(Karta karta);
        bool Delete(int id);
    }
}
