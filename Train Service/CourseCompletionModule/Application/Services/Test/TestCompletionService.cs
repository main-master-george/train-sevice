using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Errors;
using CourseCompletionModule.Application.Repositories;
using CourseCompletionModule.Domain;

namespace CourseCompletionModule.Application.Services.Test;

public class TestCompletionService : ITestCompletionService
{
    private readonly ITestIntegrationService _integrationService;
    private readonly IUserTestRepository _userTestRepository;
    
    public TestCompletionService(ITestIntegrationService integrationService, IUserTestRepository userTestRepository)
    {
        _integrationService = integrationService ?? throw new ArgumentNullException(nameof(integrationService));
        _userTestRepository = userTestRepository ?? throw new ArgumentNullException(nameof(userTestRepository));
    }

    public async Task<Result<IReadOnlyCollection<TestCompletionDto>, Error>> GetByPageIdAsync(Guid pageId, Guid userId)
    {
        try
        {
            var tests = await _integrationService.GetByPageIdAsync(pageId);

            if (!tests.IsSuccess) return tests.Error!;

            var result = tests.Value!.ToList();

            foreach (var test in result)
            {
                var isResolved = await _userTestRepository.FindByIdAsync(test.Id, userId);

                test.IsResolved = isResolved;
            }

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<bool, Error>> AppendAsync(Guid userId, Guid testId)
    {
        try
        {
            var userTest = new UserTest()
            {
                UserId = userId,
                TestId = testId
            };

            var created = await _userTestRepository.CreateAsync(userTest);

            return true;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}