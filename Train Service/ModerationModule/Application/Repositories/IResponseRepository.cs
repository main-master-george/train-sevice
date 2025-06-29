using ModerationModule.Domain;

namespace ModerationModule.Application.Repositories;

public interface IResponseRepository
{
    Task<Response> GetByRequestIdAsync(Guid requestId);

    Task<Response> CreateAsync(Response response);
}