using Common.Errors;
using Common.Mappers;
using Common.Results;
using ModerationModule.Application.Dtos.Incoming;
using ModerationModule.Application.Dtos.Outgoing;
using ModerationModule.Application.Errors;
using ModerationModule.Application.Repositories;
using ModerationModule.Domain;

namespace ModerationModule.Application.Services;

public class ResponseService : IResponseService
{
    private readonly IResponseRepository _responseRepository;
    private readonly ICustomMapper _mapper;


    public ResponseService(IResponseRepository responseRepository, ICustomMapper mapper)
    {
        _responseRepository = responseRepository ?? throw new ArgumentNullException(nameof(responseRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<ResponseDto, Error>> GetByRequestIdAsync(Guid id)
    {
        try
        {
            var response = await _responseRepository.GetByRequestIdAsync(id);

            var result = _mapper.Map<Response, ResponseDto>(response);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<ResponseDto, Error>> CreateAsync(CreationResponseDto creationResponseDto)
    {
        try
        {
            var response = _mapper.Map<CreationResponseDto, Response>(creationResponseDto);

            var created = await _responseRepository.CreateAsync(response);

            var result = _mapper.Map<Response, ResponseDto>(created);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}