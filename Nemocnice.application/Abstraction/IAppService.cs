using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.domain;

namespace Nemocnice.application.Abstraction
{
    public interface IPacientAppService
    {
        IList<Pacient> Select();
        void Create(Pacient pacient);
        bool Delete(int id);
    }
}
