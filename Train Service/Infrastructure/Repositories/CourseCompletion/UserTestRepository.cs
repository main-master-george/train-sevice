using CourseCompletionModule.Application.Repositories;
using CourseCompletionModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseCompletion;

public class UserTestRepository : IUserTestRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserTestRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<bool> FindByIdAsync(Guid testId, Guid userId)
    {
        var userTest = await _applicationDbContext
            .UserTests
            .FirstOrDefaultAsync(ut => ut.TestId == testId && ut.UserId == userId);

        return userTest is not null;
    }

    public async Task<UserTest> CreateAsync(UserTest userTest)
    {
        await _applicationDbContext
            .UserTests
            .AddAsync(userTest);

        await _applicationDbContext
            .SaveChangesAsync();

        return userTest;
    }
}