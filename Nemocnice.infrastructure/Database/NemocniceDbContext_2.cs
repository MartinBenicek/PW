public class NemocniceDbContext : DbContext
{
	public NemocniceDbContext(DbContextOptions<NemocniceDbContext> dbContextOptions) : base(dbContextOptions)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		var adminInit = new AdminInit();
		modelBuilder.Entity<Admin>().HasData(adminInit.GetAdmins());

		var roleInit = new RoleInit();
		var roles = roleInit.GetRoles();
		modelBuilder.Entity<Role>().HasData(roles);

		var titleInit = new TitleInit();
		var tituly = titleInit.GetTitles();
		modelBuilder.Entity<Titul>().HasData(tituly);

		var userInit = new UserInit();  
		var users = userInit.GetUsers();  
		modelBuilder.Entity<User>().HasData(users);

		var doctorInit = new DoktorInit();
		var doktori = doctorInit.GetDoktors(tituly, roles, users);
		modelBuilder.Entity<Doktor>().HasData(doktori);

		var patientInit = new PacientInit();
		modelBuilder.Entity<Pacient>().HasData(patientInit.GetPacients());

		var officeInit = new OfficeInit();
		modelBuilder.Entity<Ordinace>().HasData(officeInit.GetOffices());

		var kartaInit = new KartaInit();
		modelBuilder.Entity<Karta>().HasData(kartaInit.GetKartas());

		var lekarskeSluzbyInit = new LekarskeSluzbyInit();
		modelBuilder.Entity<LekarskaSluzba>().HasData(lekarskeSluzbyInit.GetLekarskeSluzby());
	}
}