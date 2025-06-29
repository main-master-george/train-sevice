using Common.Errors;
using Common.Mappers;
using Common.Results;
using ModerationModule.Application.Dtos.Incoming;
using ModerationModule.Application.Dtos.Outgoing;
using ModerationModule.Application.Errors;
using ModerationModule.Application.Repositories;
using ModerationModule.Domain;

namespace ModerationModule.Application.Services;

public class RequestService : IRequestService
{
    private readonly IRequestRepository _requestRepository;
    private readonly ICustomMapper _mapper;

    public RequestService(IRequestRepository requestRepository, ICustomMapper mapper)
    {
        _requestRepository = requestRepository ?? throw new ArgumentNullException(nameof(requestRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<IReadOnlyCollection<RequestDto>, Error>> GetAsync(int page, int pageSize)
    {
        try
        {
            var requests = await _requestRepository.GetAsync(page, pageSize);

            var result = requests
                .Select(r => _mapper.Map<Request, RequestDto>(r))
                .ToList()
                .AsReadOnly();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<IReadOnlyCollection<RequestDto>, Error>> GetByCourseIdAsync(Guid id)
    {
        try
        {
            var requests = await _requestRepository.GetByCourseIdAsync(id);

            var result = requests
                .Select(r => _mapper.Map<Request, RequestDto>(r))
                .ToList()
                .AsReadOnly();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<RequestDto, Error>> CreateAsync(CreationRequestDto creationRequestDto)
    {
        try
        {
            var request = _mapper.Map<CreationRequestDto, Request>(creationRequestDto);

            var created = await _requestRepository.CreateAsync(request);

            var result = _mapper.Map<Request, RequestDto>(created);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<RequestDto, Error>> UpdateStatusAsync(Guid id, string status)
    {
        try
        {
            var request = await _requestRepository.GetByIdAsync(id);

            request.Status = Enum.Parse<Status>(status);

            var updated = await _requestRepository.UpdateAsync(request);

            var result = _mapper.Map<Request, RequestDto>(updated);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}