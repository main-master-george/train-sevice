using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Page;

public interface IPageIntegrationService
{
    Task<Result<IReadOnlyCollection<PageCompletionDto>, Error>> GetByModuleIdAsync(Guid id);
}