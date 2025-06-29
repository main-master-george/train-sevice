using Common.Errors;
using Common.Results;
using UserManagementModule.Application.Dtos.Outgoing;
using UserManagementModule.Application.Errors;
using UserManagementModule.Application.Repositories;

namespace UserManagementModule.Application.Services;

public class UserManagementService : IUserManagementService
{
    private readonly IUserManagementRepository _userRepository;

    public UserManagementService(IUserManagementRepository userRepository) =>
        _userRepository = userRepository ?? throw new ArgumentNullException();

    public async Task<Result<UserDto, Error>> GetByUserNameAsync(string username)
    {
        try
        {
            return await _userRepository.GetByUserNameAsync(username);
        }
        catch (Exception e)
        {
            return UserServiceErrors.NotFoundError();
        }
    }

    public async Task<Result<IReadOnlyCollection<UserDto>, Error>> GetAsync(int page, int pageSize)
    {
        try
        {
             IReadOnlyCollection<UserDto> users = await _userRepository
                 .GetAsync(page, pageSize);

             return new Result<IReadOnlyCollection<UserDto>, Error>(users);
        }
        catch (Exception e)
        {
            return UserServiceErrors.NotFoundError();
        }
    }
}