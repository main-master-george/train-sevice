using Microsoft.EntityFrameworkCore;
using ModerationModule.Application.Repositories;
using ModerationModule.Domain;

namespace Infrastructure.Repositories.Moderation;

public class RequestRepository : IRequestRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public RequestRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? 
                                throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<IReadOnlyCollection<Request>> GetAsync(int page, int pageSize) => await _applicationDbContext
            .Requests
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();

    public async Task<Request> GetByIdAsync(Guid id) => await _applicationDbContext
        .Requests
        .FirstAsync(r => r.Id == id);

    public async Task<IReadOnlyCollection<Request>> GetByCourseIdAsync(Guid id) => await _applicationDbContext
        .Requests
        .Where(r => r.CourseId == id)
        .ToListAsync();

    public async Task<Request> CreateAsync(Request request)
    {
        await _applicationDbContext
            .Requests
            .AddAsync(request);

        await _applicationDbContext
            .SaveChangesAsync();

        return request;
    }

    public async Task<Request> UpdateAsync(Request request)
    {
        _applicationDbContext
            .Requests
            .Update(request);

        await _applicationDbContext
            .SaveChangesAsync();

        return request;
    }
}