using ModerationModule.Domain;

namespace ModerationModule.Application.Repositories;

public interface IRequestRepository
{
    Task<IReadOnlyCollection<Request>> GetAsync(int page, int pageSize);

    Task<Request> GetByIdAsync(Guid id);

    Task<IReadOnlyCollection<Request>> GetByCourseIdAsync(Guid id);

    Task<Request> CreateAsync(Request request);

    Task<Request> UpdateAsync(Request request);
}