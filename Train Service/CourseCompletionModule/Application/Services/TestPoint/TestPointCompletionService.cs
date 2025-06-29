using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Errors;

namespace CourseCompletionModule.Application.Services.TestPoint;

public class TestPointCompletionService : ITestPointCompletionService
{
    private readonly ITestPointIntegrationService _integrationService;

    public TestPointCompletionService(ITestPointIntegrationService integrationService) =>
        _integrationService = integrationService ?? throw new ArgumentNullException(nameof(integrationService));

    public async Task<Result<IReadOnlyCollection<TestPointCompletionDto>, Error>> GetByTestIdAsync(Guid id)
    {
        try
        {
            return await _integrationService.GetByTestIdAsync(id);
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<Guid, Error>> GetCorrectAnswerIdByTestIdAsync(Guid id)
    {
        try
        {
            return await _integrationService.GetCorrectAnswerIdByTestIdAsync(id);
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}