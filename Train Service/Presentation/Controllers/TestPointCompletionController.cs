using CourseCompletionModule.Application.Services.TestPoint;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/test-points/completion")]
public class TestPointCompletionController : ControllerBase
{
    private readonly ITestPointCompletionService _pointCompletionService;

    public TestPointCompletionController(ITestPointCompletionService pointCompletionService) =>
        _pointCompletionService =
            pointCompletionService ?? throw new ArgumentNullException(nameof(pointCompletionService));

    [HttpGet("by-test/{id}")]
    public async Task<IActionResult> GetByTestIdAsync(Guid id)
    {
        var result = await _pointCompletionService
            .GetByTestIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}