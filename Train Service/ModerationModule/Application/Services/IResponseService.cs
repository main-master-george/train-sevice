using Common.Errors;
using Common.Results;
using ModerationModule.Application.Dtos.Incoming;
using ModerationModule.Application.Dtos.Outgoing;

namespace ModerationModule.Application.Services;

public interface IResponseService
{
    Task<Result<ResponseDto, Error>> GetByRequestIdAsync(Guid id);

    Task<Result<ResponseDto, Error>> CreateAsync(CreationResponseDto creationResponseDto);
}