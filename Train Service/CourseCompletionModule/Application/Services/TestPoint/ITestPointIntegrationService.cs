using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.TestPoint;

public interface ITestPointIntegrationService
{
    Task<Result<IReadOnlyCollection<TestPointCompletionDto>, Error>> GetByTestIdAsync(Guid id);
    
    Task<Result<Guid, Error>> GetCorrectAnswerIdByTestIdAsync(Guid id);
}