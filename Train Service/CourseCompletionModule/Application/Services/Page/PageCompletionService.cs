using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Errors;

namespace CourseCompletionModule.Application.Services.Page;

public class PageCompletionService : IPageCompletionService
{
    private readonly IPageIntegrationService _integrationService;

    public PageCompletionService(IPageIntegrationService integrationService) =>
        _integrationService = integrationService ?? throw new ArgumentNullException(nameof(integrationService));

    public async Task<Result<IReadOnlyCollection<PageCompletionDto>, Error>> GetByModuleIdAsync(Guid id)
    {
        try
        {
            return await _integrationService.GetByModuleIdAsync(id);
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}