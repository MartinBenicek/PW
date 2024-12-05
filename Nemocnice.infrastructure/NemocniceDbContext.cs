using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nemocnice.domain;

namespace Nemocnice.infrastructure
{
    public class NemocniceDbContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<LekarskeSluzby> LekarskeSluzby { get; set; }
        public DbSet<Ordinace> Ordinace{ get; set; }
        public DbSet<Pacient> Pacient { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Titul> Titul { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public NemocniceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

    }
}
