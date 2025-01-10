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
        public DbSet<Predpis> Predpis { get; set; }
        public DbSet<LekarskaZprava> LekarskaZprava{ get; set; }
        public NemocniceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            KartaInit kartasInit = new KartaInit();
            modelBuilder.Entity<Karta>().HasData(kartasInit.GetKartas());

            OrdinaceInit ordinaceInit = new OrdinaceInit();
            modelBuilder.Entity<Ordinace>().HasData(ordinaceInit.GetOrdinaces());

            LekarskeSluzbyInit lekarskeSluzbyInit = new LekarskeSluzbyInit();
            modelBuilder.Entity<LekarskeSluzby>().HasData(lekarskeSluzbyInit.GetLekarskeSluzby());

            LekarskaZpravaInit lekarskaZpravaInit = new LekarskaZpravaInit();
            modelBuilder.Entity<LekarskaZprava>().HasData(lekarskaZpravaInit.GetLekarskaZprava());

            PredpisInit predpisInit = new PredpisInit();
            modelBuilder.Entity<Predpis>().HasData(predpisInit.GetPredpis());

            RoleInit rolesInit = new RoleInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesAMC());

            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            User manager = userInit.GetDoktor();

            modelBuilder.Entity<User>().HasData(admin, manager);

            UserRoleInit userRoleInit = new UserRoleInit();
            List<IdentityUserRole<int>> adminUserRole = userRoleInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> DoktorUserRole = userRoleInit.GetRolesForDoktor();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoleInit.GetRolesForAdmin());
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoleInit.GetRolesForDoktor());
        }
    }

}
