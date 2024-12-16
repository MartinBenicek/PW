using Microsoft.AspNetCore.Identity;
using Nemocnice.application.Abstraction;
using Nemocnice.infrastructure.Identity;
using System.Security.Claims;

namespace Nemocnice.application.Implementation
{
    public class SecurityIdentityService : ISecurityService
    {
        UserManager<User> userManager;
        public SecurityIdentityService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public Task<User> FindUserByEmail(string email)
        {
            return userManager.FindByEmailAsync(email);
        }
        public Task<User> FindUserByUsername(string username)
        {
            return userManager.FindByNameAsync(username);
        }
        public Task<IList<string>> GetUserRoles(User user)
        {
            return userManager.GetRolesAsync(user);
        }
        public Task<User> GetCurrentUser(ClaimsPrincipal principal)
        {
            return userManager.GetUserAsync(principal);
        }
    }
}
