using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Test;

public interface ITestIntegrationService
{
    Task<Result<IReadOnlyCollection<TestCompletionDto>, Error>> GetByPageIdAsync(Guid id);
}