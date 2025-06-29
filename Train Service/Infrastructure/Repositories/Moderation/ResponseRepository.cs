using Microsoft.EntityFrameworkCore;
using ModerationModule.Application.Repositories;
using ModerationModule.Domain;

namespace Infrastructure.Repositories.Moderation;

public class ResponseRepository : IResponseRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ResponseRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ??
                                throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<Response> GetByRequestIdAsync(Guid requestId) => await _applicationDbContext
        .Responses
        .FirstAsync(r => r.RequestId == requestId);

    public async Task<Response> CreateAsync(Response response)
    {
        await _applicationDbContext
            .Responses
            .AddAsync(response);

        await _applicationDbContext
            .SaveChangesAsync();

        return response;
    }
}