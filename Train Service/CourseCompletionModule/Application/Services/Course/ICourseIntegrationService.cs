using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Course;

public interface ICourseIntegrationService
{
    Task<Result<IReadOnlyCollection<CourseBaseDto>, Error>> GetAsync(int page, int pageSize);

    Task<Result<CourseBaseDto, Error>> GetByIdAsync(Guid id);
}