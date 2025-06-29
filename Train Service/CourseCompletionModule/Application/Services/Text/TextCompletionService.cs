using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Errors;

namespace CourseCompletionModule.Application.Services.Text;

public class TextCompletionService : ITextCompletionService
{
    private readonly ITextIntegrationService _integrationService;


    public TextCompletionService(ITextIntegrationService integrationService) =>
        _integrationService = integrationService ?? throw new ArgumentNullException(nameof(integrationService));

    public async Task<Result<IReadOnlyCollection<TextCompletionDto>, Error>> GetByPageIdAsync(Guid id)
    {
        try
        {
            return await _integrationService.GetByPageIdAsync(id);
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}