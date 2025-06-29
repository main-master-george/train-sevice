using Common.Mappers;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagementModule.Application.Dtos.Outgoing;
using UserManagementModule.Application.Repositories;

namespace Infrastructure.Repositories;

public class UserManagementRepository : IUserManagementRepository
{
    private readonly UserManager<UserModel> _userManager;
    private readonly ICustomMapper _mapper;
    
    public UserManagementRepository(UserManager<UserModel> userManager,
        ICustomMapper mapper)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UserDto> GetByUserNameAsync(string username)
    {
        var user = await _userManager
            .Users
            .FirstAsync(u => u.UserName == username);

        var role = await _userManager
            .GetRolesAsync(user);
        
        var userDto = _mapper.Map<UserModel, UserDto>(user);

        userDto.Role = role.Last();

        return userDto;
    }

    public async Task<IReadOnlyCollection<UserDto>> GetAsync(int page = 0, int pageSize = 10)
    {
        if (page < 0) throw new ArgumentOutOfRangeException(nameof(page), "Page must be non-negative.");
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize), "PageSize must be greater than zero.");

        var users = (await _userManager
                .Users
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync())
            .Select(user => 
                new Tuple<UserDto, string>(_mapper.Map<UserModel, UserDto>(user), _userManager.GetRolesAsync(user).Result.Last()))
            .ToList();

        foreach (var user in users)
        {
            user.Item1.Role = user.Item2;
        }
        
        return users
            .Select(user => user.Item1)
            .ToList();
    }
}