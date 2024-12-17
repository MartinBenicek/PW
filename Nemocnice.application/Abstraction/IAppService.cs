using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.infrastructure.Identity;

namespace Nemocnice.application.Abstraction
{
    public interface IUserAppService
    {
        IList<User> Select();
        void Create(User user);
        bool Delete(int id);
        User GetById(int id);
        bool Edit(User user);
    }
}
