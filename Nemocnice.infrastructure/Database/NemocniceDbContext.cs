using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Identity;
using Nemocnice.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity;

namespace Nemocnice.infrastructure.Database
{
    public class NemocniceDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Karta> Karta { get; set; }
        public DbSet<LekarskeSluzby> LekarskeSluzby { get; set; }
        public DbSet<Ordinace> Ordinace { get; set; }
        public NemocniceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoleInit rolesInit = new RoleInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesAMC());

            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            User manager = userInit.GetDoktor();

            modelBuilder.Entity<User>().HasData(admin, manager);

            UserRoleInit userRolesInit = new UserRoleInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> managerUserRoles = userRolesInit.GetRolesForManager();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);

            KartaInit kartasInit = new KartaInit();
            modelBuilder.Entity<Karta>().HasData(kartasInit.GetKartas());

            OrdinaceInit ordinaceInit = new OrdinaceInit();
            modelBuilder.Entity<Ordinace>().HasData(ordinaceInit.GetOrdinaces());

            LekarskeSluzbyInit lekarskeSluzbyInit = new LekarskeSluzbyInit();
            modelBuilder.Entity<LekarskeSluzby>().HasData(lekarskeSluzbyInit.GetLekarskeSluzby());
        }
    }

}
