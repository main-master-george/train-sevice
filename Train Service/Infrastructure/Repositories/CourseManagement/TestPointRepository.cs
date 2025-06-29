using CourseManagementModule.Application.Repositories;
using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseManagement;

public class TestPointRepository : ITestPointRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TestPointRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<TestPoint> GetByIdAsync(Guid id) =>
        await _applicationDbContext
            .TestPoints
            .FirstAsync(p => p.Id == id);

    public async Task<IReadOnlyCollection<TestPoint>> GetByTestIdAsync(Guid id) =>
        await _applicationDbContext
            .TestPoints
            .Where(p => p.TestId == id)
            .ToListAsync();

    public async Task<TestPoint> CreateAsync(TestPoint testPoint)
    { 
        await _applicationDbContext
            .TestPoints
            .AddAsync(testPoint);

        await _applicationDbContext
            .SaveChangesAsync();

        return testPoint;
    }

    public async Task<TestPoint> DeleteByIdAsync(Guid id)
    {
        var point = await _applicationDbContext
            .TestPoints
            .FirstAsync(p => p.Id == id);

        _applicationDbContext
            .TestPoints
            .Remove(point);

        await _applicationDbContext
            .SaveChangesAsync();

        return point;
    }
}