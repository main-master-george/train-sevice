using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Errors;
using CourseCompletionModule.Application.Services.Test;
using CourseCompletionModule.Application.Services.TestPoint;

namespace CourseCompletionModule.Application.Services.TestCheck;

public class TestCheckingService : ITestCheckingService
{
    private readonly ITestPointCompletionService _pointCompletionService;

    public TestCheckingService(ITestPointCompletionService pointCompletionService, ITestCompletionService testCompletionService) =>
        _pointCompletionService = pointCompletionService ?? throw new ArgumentNullException(nameof(pointCompletionService));

    public async Task<Result<bool, Error>> IsCorrect(Guid testId, Guid correctPointId)
    {
        try
        {
            var isCorrect = await _pointCompletionService.GetCorrectAnswerIdByTestIdAsync(testId);

            if (!isCorrect.IsSuccess) return isCorrect.Error!;

            return isCorrect.Value == correctPointId;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}