using Microsoft.EntityFrameworkCore;
using Nemocnice.infrastructure.Database;
using Nemocnice.application.Abstraction;
using Nemocnice.application.Implementation;
using Microsoft.AspNetCore.Identity;
using Nemocnice.infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.40");
builder.Services.AddDbContext<NemocniceDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));


builder.Services.AddIdentity<User, Role>()
     .AddEntityFrameworkStores<NemocniceDbContext>()
     .AddDefaultTokenProviders();

//registrace služeb aplikaèní vrstvy
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<ILekarskeSluzbyService, LekarskeSluzbyAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Testovací komentáø pro GIT

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
