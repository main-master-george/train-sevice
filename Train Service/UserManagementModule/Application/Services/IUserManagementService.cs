using Common.Errors;
using Common.Results;
using UserManagementModule.Application.Dtos.Outgoing;

namespace UserManagementModule.Application.Services;

public interface IUserManagementService
{
    Task<Result<UserDto, Error>> GetByUserNameAsync(string username);

    Task<Result<IReadOnlyCollection<UserDto>, Error>> GetAsync(int page, int pageSize);
}