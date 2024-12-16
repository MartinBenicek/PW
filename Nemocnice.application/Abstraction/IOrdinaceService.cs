using Nemocnice.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.Abstraction
{
    public interface IOrdinaceService
    {
        IList<Ordinace> Select();
        void Create(Ordinace ordinace);
        bool Delete(int id);
    }
}