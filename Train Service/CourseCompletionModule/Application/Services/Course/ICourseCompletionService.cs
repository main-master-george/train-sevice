using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Course;

public interface ICourseCompletionService
{
    Task<Result<IReadOnlyCollection<CourseBaseDto>, Error>> GetNotPurchasedAsync(Guid userId, int page, int pageSize);
    
    Task<Result<IReadOnlyCollection<CourseCompletionDto>, Error>> GetPurchasedAsync(Guid userId, int page, int pageSize);
    
    Task<Result<bool, Error>> AppendAsync(Guid courseId, Guid userId);
}