using CourseCompletionModule.Application.Repositories;
using CourseCompletionModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseCompletion;

public class UserModuleRepository : IUserModuleRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserModuleRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<bool> FindByIdAsync(Guid moduleId, Guid userId)
    {
        var userModule = await _applicationDbContext
            .UserModules
            .FirstOrDefaultAsync(um => um.ModuleId == moduleId && um.UserId == userId);

        return userModule is not null;
    }

    public async Task<IReadOnlyCollection<UserModule>> CreateAsync(IReadOnlyCollection<UserModule> userModules)
    {
        await _applicationDbContext
            .UserModules
            .AddRangeAsync(userModules);

        await _applicationDbContext
            .SaveChangesAsync();

        return userModules;
    }
}