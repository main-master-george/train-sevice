using CourseManagementModule.Application.Repositories;
using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseManagement;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CourseRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    
    public async Task<IReadOnlyCollection<Course>> GetAsync(int page, int pageSize)
    {
        if (page < 0) throw new ArgumentOutOfRangeException(nameof(page), "Page must be non-negative.");
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize), "PageSize must be greater than zero.");

        return await _applicationDbContext
            .Courses
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Course> GetByIdAsync(Guid id) =>
        await _applicationDbContext
            .Courses
            .FirstAsync(c => c.Id == id);

    public async Task<Course> CreateAsync(Course course)
    {
        await _applicationDbContext
            .Courses
            .AddAsync(course);

        await _applicationDbContext
            .SaveChangesAsync();

        return course;
    }

    public async Task<Course> UpdateAsync(Course course)
    {
        _applicationDbContext
            .Courses
            .Update(course);

        await _applicationDbContext
            .SaveChangesAsync();

        return course;
    }

    public async Task<Course> DeleteByIdAsync(Guid id)
    {
        var course = await _applicationDbContext
            .Courses
            .FirstAsync(c => c.Id == id);

        _applicationDbContext
            .Courses
            .Remove(course);

        await _applicationDbContext
            .SaveChangesAsync();

        return course;
    }
}