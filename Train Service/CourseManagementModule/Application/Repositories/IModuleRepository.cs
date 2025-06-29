using CourseManagementModule.Domain;

namespace CourseManagementModule.Application.Repositories;

public interface IModuleRepository
{
    Task<Module> GetByIdAsync(Guid id);

    Task<IReadOnlyCollection<Module>> GetByCourseIdAsync(Guid id);

    Task<Module> CreateAsync(Module module);

    Task<Module> DeleteByIdAsync(Guid id);
}