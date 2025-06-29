using CourseCompletionModule.Domain;

namespace CourseCompletionModule.Application.Repositories;

public interface IUserCourseRepository
{
    Task<bool> FindByIdAsync(Guid courseId, Guid userId);

    Task<IReadOnlyCollection<UserCourse>> GetPurchasedAsync(Guid userId, int page, int pageSize);
    
    Task<UserCourse> CreateAsync(UserCourse userCourse);
}