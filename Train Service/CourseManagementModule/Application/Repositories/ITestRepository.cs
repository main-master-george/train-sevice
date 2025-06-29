using CourseManagementModule.Domain;

namespace CourseManagementModule.Application.Repositories;

public interface ITestRepository
{
    Task<Test> GetByIdAsync(Guid id);

    Task<IReadOnlyCollection<Test>> GetByPageIdAsync(Guid id);

    Task<Test> CreateAsync(Test test);

    Task<Test> DeleteByIdAsync(Guid id);
}