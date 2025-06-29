using UserManagementModule.Application.Dtos.Outgoing;

namespace UserManagementModule.Application.Repositories;

public interface IUserManagementRepository
{
    Task<UserDto> GetByUserNameAsync(string username);

    Task<IReadOnlyCollection<UserDto>> GetAsync(int page = 0, int pageSize = 10);
}