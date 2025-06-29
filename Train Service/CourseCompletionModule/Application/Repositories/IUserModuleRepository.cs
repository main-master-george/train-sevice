using CourseCompletionModule.Domain;

namespace CourseCompletionModule.Application.Repositories;

public interface IUserModuleRepository
{
    Task<bool> FindByIdAsync(Guid moduleId, Guid userId);

    Task<IReadOnlyCollection<UserModule>> CreateAsync(IReadOnlyCollection<UserModule> userModules);
}