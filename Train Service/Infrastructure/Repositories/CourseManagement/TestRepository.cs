using CourseManagementModule.Application.Repositories;
using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseManagement;

public class TestRepository : ITestRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TestRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<Test> GetByIdAsync(Guid id) =>
        await _applicationDbContext
            .Tests
            .FirstAsync(t => t.Id == id);

    public async Task<IReadOnlyCollection<Test>> GetByPageIdAsync(Guid id) =>
        await _applicationDbContext
            .Tests
            .Where(t => t.PageId == id)
            .ToListAsync();

    public async Task<Test> CreateAsync(Test test)
    {
        await _applicationDbContext
            .Tests
            .AddAsync(test);

        await _applicationDbContext
            .SaveChangesAsync();

        return test;
    }

    public async Task<Test> DeleteByIdAsync(Guid id)
    {
        var test = await _applicationDbContext
            .Tests
            .FirstAsync(t => t.Id == id);

        _applicationDbContext
            .Tests
            .Remove(test);

        await _applicationDbContext
            .SaveChangesAsync();

        return test;
    }
}