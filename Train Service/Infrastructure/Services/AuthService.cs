using Infrastructure.Dtos.Incoming;
using Infrastructure.Models;
using Infrastructure.Results;
using Microsoft.AspNetCore.Identity;
using UserManagementModule.Domain;

namespace Infrastructure.Services;

public class AuthService
{
    private readonly UserManager<UserModel> _userManager;
    private readonly SignInManager<UserModel> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _applicationDbContext;

    public AuthService(UserManager<UserModel> userManager,
        SignInManager<UserModel> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext applicationDbContext)
    {
        _userManager = userManager ?? throw new ArgumentNullException();
        _signInManager = signInManager ?? throw new ArgumentNullException();
        _roleManager = roleManager ?? throw new ArgumentNullException();
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException();
    }

    public async Task<IdentityResult> CreateUserAsync(RegisterDto registerDto, Role role, bool emailConfirmed)
    {
        var roleName = role.ToString();
        var roleExists = await _roleManager.RoleExistsAsync(roleName);

        if (!roleExists)
        {
            var createRoleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (!createRoleResult.Succeeded) return createRoleResult;
        }

        await using var transaction = await _applicationDbContext.Database.BeginTransactionAsync();
        try
        {
            var user = new UserModel {UserName = registerDto.Email, Email = registerDto.Email, EmailConfirmed = emailConfirmed };
            var createUserResult = await _userManager.CreateAsync(user, registerDto.Password);

            if (!createUserResult.Succeeded) return createUserResult;

            var addRoleResult = await _userManager.AddToRoleAsync(user, roleName);
            if (!addRoleResult.Succeeded) throw new Exception("Failed to assign role to user.");

            await transaction.CommitAsync();
            return IdentityResult.Success;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<SignInResult> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user is null) return SignInResult.Failed;

        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
        if (!result.Succeeded) return SignInResult.Failed;

        return result;
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();
}