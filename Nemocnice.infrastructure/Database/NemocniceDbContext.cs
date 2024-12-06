using Microsoft.EntityFrameworkCore;
using Nemocnice.domain;
using Nemocnice.Infrastructure.Database.Seeding;

namespace Nemocnice.infrastructure.Database
{
    public class NemocniceDbContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<LekarskeSluzby> LekarskeSluzby { get; set; }
        public DbSet<Ordinace> Ordinace { get; set; }
        public DbSet<Pacient> Pacient { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Titul> Titul { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public NemocniceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userInit = new UserInit();
            modelBuilder.Entity<User>().HasData(userInit.GetUsers());

            var rolesInit = new RoleInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRoles());

            var userRolesInit = new UserRoleInit();
            modelBuilder.Entity<UserRole>().HasData(userRolesInit.GetUserRoles());

            var titulsInit = new TitulInit();
            modelBuilder.Entity<Titul>().HasData(titulsInit.GetTituls());

            var pacientsInit = new PacientInit();
            modelBuilder.Entity<Pacient>().HasData(pacientsInit.GetPacients());

            var doktorsInit = new DoktorInit();
            modelBuilder.Entity<Doktor>().HasData(doktorsInit.GetDoktors());

            var adminsInit = new AdminInit();
            modelBuilder.Entity<Admin>().HasData(adminsInit.GetAdmins());

            var kartasInit = new KartaInit();
            modelBuilder.Entity<Karta>().HasData(kartasInit.GetKartas());

            var ordinaceInit = new OrdinaceInit();
            modelBuilder.Entity<Ordinace>().HasData(ordinaceInit.GetOrdinaces());

            var lekarskeSluzbyInit = new LekarskeSluzbyInit();
            modelBuilder.Entity<LekarskeSluzby>().HasData(lekarskeSluzbyInit.GetLekarskeSluzby());
        }
    }

}
