using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.domain.Entities;

namespace Nemocnice.application.Abstraction
{
    public interface IUserAppService
    {
        IList<User> Select();
        void Create(User user);
        bool Delete(int id);
    }
}
