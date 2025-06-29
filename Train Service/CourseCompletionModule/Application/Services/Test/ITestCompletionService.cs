using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Test;

public interface ITestCompletionService
{
    Task<Result<IReadOnlyCollection<TestCompletionDto>, Error>> GetByPageIdAsync(Guid pageId, Guid userId);

    Task<Result<bool, Error>> AppendAsync(Guid userId, Guid testId);
}