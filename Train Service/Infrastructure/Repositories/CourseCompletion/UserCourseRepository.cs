using CourseCompletionModule.Application.Repositories;
using CourseCompletionModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseCompletion;

public class UserCourseRepository : IUserCourseRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserCourseRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    
    public async Task<bool> FindByIdAsync(Guid courseId, Guid userId)
    {
        var userCourse = await _applicationDbContext
            .UserCourses
            .FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CourseId == courseId);

        return userCourse is not null;
    }

    public async Task<IReadOnlyCollection<UserCourse>> GetPurchasedAsync(Guid userId, int page, int pageSize)
    {
        var purchased = await _applicationDbContext
            .UserCourses
            .Where(uc => uc.UserId == userId)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return purchased;
    }

    public async Task<UserCourse> CreateAsync(UserCourse userCourse)
    {
        await _applicationDbContext
            .UserCourses
            .AddAsync(userCourse);

        await _applicationDbContext
            .SaveChangesAsync();

        return userCourse;
    }
}