using Infrastructure.Dtos.Incoming;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementModule.Domain;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly EmailService _emailService;

    public AuthController(AuthService authService, EmailService emailService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
    }

    [HttpPost("admins")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminsRegister(RegisterDto registerDto)
    {
        var codeAccepted = await _emailService.IsCodeAccepted(registerDto.Email, registerDto.Code);

        if (!codeAccepted) return BadRequest(new {message = "Invalid confirmation code"});
        
        var result = await _authService.CreateUserAsync(registerDto, Role.Admin, codeAccepted);

        if (result.Succeeded) return Ok(result);

        return BadRequest(result);
    }

    [HttpPost("moderators")]
    [Authorize(Roles = "Admin, Moder")]
    public async Task<IActionResult> ModeratorsRegister(RegisterDto registerDto)
    {
        var codeAccepted = await _emailService.IsCodeAccepted(registerDto.Email, registerDto.Code);

        if (!codeAccepted) return BadRequest(new {message = "Invalid confirmation code"});

        var result = await _authService.CreateUserAsync(registerDto, Role.Moder, codeAccepted);

        if (result.Succeeded) return Ok(result);

        return BadRequest(result);
    }

    [HttpPost("creators")]
    public async Task<IActionResult> CreatorRegister(RegisterDto registerDto)
    {
        var codeAccepted = await _emailService.IsCodeAccepted(registerDto.Email, registerDto.Code);

        if (!codeAccepted) return BadRequest(new {message = "Invalid confirmation code"});

        var result = await _authService.CreateUserAsync(registerDto, Role.Creator, codeAccepted);

        if (result.Succeeded) return Ok(result);

        return BadRequest(result);
    }

    [HttpPost("users")]
    public async Task<IActionResult> UsersRegister(RegisterDto registerDto)
    {
        var codeAccepted = await _emailService.IsCodeAccepted(registerDto.Email, registerDto.Code);

        if (!codeAccepted) return BadRequest(new {message = "Invalid confirmation code"});

        var result = await _authService.CreateUserAsync(registerDto, Role.User, codeAccepted);

        if (result.Succeeded) return Ok(result);

        return BadRequest(result);
    }

    [HttpPost("confirm")]
    public async Task<IActionResult> ConfirmEmail(string email)
    {
        await _emailService.SendConfirmationCodeAsync(email);
        
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto);

        if (result.Succeeded)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task Logout() => await _authService.LogoutAsync();
}