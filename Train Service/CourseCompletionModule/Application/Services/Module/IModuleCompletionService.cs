using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Module;

public interface IModuleCompletionService
{
    Task<Result<IReadOnlyCollection<ModuleCompletionDto>, Error>> GetByCourseIdAsync(Guid courseId, Guid userId);

    Task<Result<bool, Error>> AppendAsync(IEnumerable<Guid> moduleIds, Guid userId);
}