using CourseManagementModule.Domain;

namespace CourseManagementModule.Application.Repositories;

public interface IPageRepository
{
    Task<Page> GetByIdAsync(Guid id);

    Task<IReadOnlyCollection<Page>> GetByModuleIdAsync(Guid id);

    Task<Page> CreateAsync(Page page);

    Task<Page> DeleteByIdAsync(Guid id);
}