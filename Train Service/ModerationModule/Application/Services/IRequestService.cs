using Common.Errors;
using Common.Results;
using ModerationModule.Application.Dtos.Incoming;
using ModerationModule.Application.Dtos.Outgoing;
using ModerationModule.Domain;

namespace ModerationModule.Application.Services;

public interface IRequestService
{
    Task<Result<IReadOnlyCollection<RequestDto>, Error>> GetAsync(int page, int pageSize);
    
    Task<Result<IReadOnlyCollection<RequestDto>, Error>> GetByCourseIdAsync(Guid id);

    Task<Result<RequestDto, Error>> CreateAsync(CreationRequestDto creationRequestDto);

    Task<Result<RequestDto, Error>> UpdateStatusAsync(Guid id, string status);
}