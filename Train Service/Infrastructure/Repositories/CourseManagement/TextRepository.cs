using CourseManagementModule.Application.Repositories;
using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseManagement;

public class TextRepository : ITextRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TextRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<Text> GetByIdAsync(Guid id) =>
        await _applicationDbContext
            .Texts
            .FirstAsync(t => t.Id == id);

    public async Task<IReadOnlyCollection<Text>> GetByPageIdAsync(Guid id) =>
        await _applicationDbContext
            .Texts
            .Where(t => t.PageId == id)
            .ToListAsync();

    public async Task<Text> CreateAsync(Text text)
    {
        await _applicationDbContext
            .Texts
            .AddAsync(text);

        await _applicationDbContext
            .SaveChangesAsync();

        return text;
    }

    public async Task<Text> DeleteByIdAsync(Guid id)
    {
        var text = await _applicationDbContext
            .Texts
            .FirstAsync(t => t.Id == id);

        _applicationDbContext
            .Texts
            .Remove(text);

        await _applicationDbContext
            .SaveChangesAsync();

        return text;
    }
}