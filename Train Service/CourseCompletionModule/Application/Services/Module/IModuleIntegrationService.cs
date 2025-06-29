using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Module;

public interface IModuleIntegrationService
{
    Task<Result<IReadOnlyCollection<ModuleCompletionDto>, Error>> GetByCourseIdAsync(Guid id);
}