using CourseCompletionModule.Domain;

namespace CourseCompletionModule.Application.Repositories;

public interface IUserTestRepository
{
    Task<bool> FindByIdAsync(Guid testId, Guid userId);

    Task<UserTest> CreateAsync(UserTest userTest);
}