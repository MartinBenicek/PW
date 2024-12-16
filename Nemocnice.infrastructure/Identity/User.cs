using Microsoft.AspNetCore.Identity;
using Nemocnice.domain.Entities.Interfaces;

namespace Nemocnice.infrastructure.Identity
{
    public class User : IdentityUser<int>, IUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
    }
}
