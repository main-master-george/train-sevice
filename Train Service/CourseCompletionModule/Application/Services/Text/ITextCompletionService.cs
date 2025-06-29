using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;

namespace CourseCompletionModule.Application.Services.Text;

public interface ITextCompletionService
{
    Task<Result<IReadOnlyCollection<TextCompletionDto>, Error>> GetByPageIdAsync(Guid id);
}