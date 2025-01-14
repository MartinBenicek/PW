using Nemocnice.application.ViewModels;
using Nemocnice.infrastructure.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.Abstraction
{
    public interface IAccountService
    {
        Task<bool> Login(LoginViewModel vm);
        Task Logout();
        Task<string[]> Register(RegisterViewModel vm, params Roles[] roles);
        Task CreateKartaForUser(int userId);
    }
}
