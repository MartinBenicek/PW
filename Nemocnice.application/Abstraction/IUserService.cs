using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity;

namespace Nemocnice.application.Abstraction
{
    public interface IUserAppService
    {
        IList<User> Select();
        bool Create(RegisterViewModel model);
        bool Update(int id, RegisterViewModel model);
        bool Delete(int id);
        RegisterViewModel GetEditViewModel(int id);
    }
}
