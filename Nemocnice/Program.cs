using Microsoft.EntityFrameworkCore;
using Nemocnice.infrastructure.Database;
using Nemocnice.application.Abstraction;
using Nemocnice.application.Implementation;
using Microsoft.AspNetCore.Identity;
using Nemocnice.infrastructure.Identity;
using Nemocnice.application.Abstractions;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Pøidání logování
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.40");
builder.Services.AddDbContext<NemocniceDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));


builder.Services.AddIdentity<User, Role>()
     .AddEntityFrameworkStores<NemocniceDbContext>()
     .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.User.RequireUniqueEmail = true;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login";
    options.LogoutPath = "/Security/Account/Logout";
    options.SlidingExpiration = true;
});

builder.Services.AddScoped<IProhlidkyService, ProhlidkyService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<ILekarskeSluzbyService, LekarskeSluzbyAppService>();
builder.Services.AddScoped<IKartaService, KartaAppService>();
builder.Services.AddScoped<IOrdinaceService, OrdinaceAppService>();
builder.Services.AddScoped<IZpravaService, ZpravaService>();
builder.Services.AddScoped<IPredpisService, PredpisService>();
builder.Services.AddScoped<ILekarskaZpravaService, LekarskaZpravaService>();
builder.Services.AddScoped<IAccountService, AccountIdentityService>();
builder.Services.AddScoped<ISecurityService, SecurityIdentityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


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
