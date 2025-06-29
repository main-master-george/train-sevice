using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Text;

public interface ITextIntegrationService
{
    Task<Result<IReadOnlyCollection<TextCompletionDto>, Error>> GetByPageIdAsync(Guid id);
}