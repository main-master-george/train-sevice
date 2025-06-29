using CourseCompletionModule.Application.Services.Test;
using CourseCompletionModule.Application.Services.TestCheck;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/test/completion")]
public class TestCompletionController : ControllerBase
{
    private readonly ITestCheckingService _testCheckingService;
    private readonly ITestCompletionService _testCompletionService;


    public TestCompletionController(ITestCheckingService testCheckingService, ITestCompletionService testCompletionService)
    {
        _testCheckingService = testCheckingService ?? throw new ArgumentNullException(nameof(testCheckingService));
        _testCompletionService = testCompletionService ?? throw new ArgumentNullException(nameof(testCompletionService));
    }

    [HttpGet("by-page/{pageId}")]
    public async Task<IActionResult> GetByPageIdAsync(Guid pageId, [FromQuery] Guid userId)
    {
        var result = await _testCompletionService.GetByPageIdAsync(pageId, userId);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> AppendAsync([FromQuery] Guid userId, [FromQuery] Guid testId, Guid correctPointId)
    {
        var isCorrect = await _testCheckingService.IsCorrect(testId, correctPointId);

        switch (isCorrect)
        {
            case {IsSuccess: true, Value: true}:
            {
                var result = await _testCompletionService.AppendAsync(userId, testId);

                if (result.IsSuccess) return Ok(result.Value);

                return BadRequest(result.Error);
            }
            case {IsSuccess: true, Value: false}:
                return Ok(isCorrect.Value);
            default:
                return BadRequest(isCorrect.Error);
        }
    }
}