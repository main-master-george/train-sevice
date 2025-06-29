using Common.Errors;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace CourseManagementModule.Application.Services.Text;

public interface ITextService
{
    Task<Result<TextDto, Error>> GetByIdAsync(Guid id);

    Task<Result<IReadOnlyCollection<TextDto>, Error>> GetByPageIdAsync(Guid id);

    Task<Result<TextDto, Error>> CreateAsync(CreationTextDto creationTextDto);

    Task<Result<TextDto, Error>> DeleteByIdAsync(Guid id);
}