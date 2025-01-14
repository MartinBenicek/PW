using Nemocnice.application.Abstractions;
using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using Nemocnice.infrastructure.Database;
using Nemocnice.infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Identity;
using Nemocnice.application.Abstraction;
using Nemocnice.infrastructure.Identity;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IKartaService _kartaService;

    public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IKartaService kartaService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _kartaService = kartaService;
    }

    public async Task<string[]> Register(RegisterViewModel vm, params Roles[] roles)
    {
        var user = new User
        {
            UserName = vm.Username,
            Email = vm.Email,
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            PhoneNumber = vm.Phone
        };

        var result = await _userManager.CreateAsync(user, vm.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, roles.Select(r => r.ToString()));
            await CreateKartaForUser(user.Id);
            return null;
        }

        return result.Errors.Select(e => e.Description).ToArray();
    }

    public async Task<bool> Login(LoginViewModel vm)
    {
        var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);
        return result.Succeeded;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task CreateKartaForUser(int userId)
    {
        var karta = new Karta
        {
            PacientID = userId
        };

        await _kartaService.CreateKarta(karta);
    }
}
