using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nemocnice.domain;

namespace Nemocnice.infrastructure
{
    public class NemocniceDbContext : DbContext
    {
        
        public NemocniceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<User> User { get; set; }
    }
}
