using CourseManagementModule.Domain;

namespace CourseManagementModule.Application.Repositories;

public interface ITestPointRepository
{
    Task<TestPoint> GetByIdAsync(Guid id);

    Task<IReadOnlyCollection<TestPoint>> GetByTestIdAsync(Guid id);

    Task<TestPoint> CreateAsync(TestPoint testPoint);

    Task<TestPoint> DeleteByIdAsync(Guid id);
}