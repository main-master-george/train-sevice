using CourseManagementModule.Application.Repositories;
using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseManagement;

public class PageRepository : IPageRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public PageRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<Page> GetByIdAsync(Guid id) =>
        await _applicationDbContext
            .Pages
            .FirstAsync(p => p.Id == id);

    public async Task<IReadOnlyCollection<Page>> GetByModuleIdAsync(Guid id) =>
        await _applicationDbContext
            .Pages
            .Where(p => p.ModuleId == id)
            .ToListAsync();

    public async Task<Page> CreateAsync(Page page)
    {
        await _applicationDbContext
            .Pages
            .AddAsync(page);

        await _applicationDbContext
            .SaveChangesAsync();

        return page;
    }

    public async Task<Page> DeleteByIdAsync(Guid id)
    {
        var page = await _applicationDbContext
            .Pages
            .FirstAsync(c => c.Id == id);

        _applicationDbContext
            .Pages
            .Remove(page);

        await _applicationDbContext
            .SaveChangesAsync();

        return page;
    }
}