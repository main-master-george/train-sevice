using Common.Errors;
using Common.Results;

namespace CourseCompletionModule.Application.Services.TestCheck;

public interface ITestCheckingService
{
    Task<Result<bool, Error>> IsCorrect(Guid testId, Guid correctPointId);
}