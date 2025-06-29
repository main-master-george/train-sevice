using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementModule.Application.Services;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IUserManagementService _userService;

    public UserController(IUserManagementService userService) =>
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));

    [HttpGet("{username}")]
    [Authorize]
    public async Task<IActionResult> GetByUserName(string username)
    {
        var currentUserName = User.Identity?.Name;

        var isAdmin = User.IsInRole("Admin");

        if (!isAdmin && currentUserName != username)
        {
            return Forbid();
        }
        
        var result = await _userService.GetByUserNameAsync(username);
        
        if (result.IsSuccess) return Ok(result.Value);

        if (result.Error!.Code == 404) return NotFound(result.Error);

        return BadRequest(result.Error);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Get(int page, int pageSize)
    {
        var result = await _userService.GetAsync(page, pageSize);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result);
    }
}