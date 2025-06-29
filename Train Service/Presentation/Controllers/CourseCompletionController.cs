using CourseCompletionModule.Application.Services.Course;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/courses/completion")]
public class CourseCompletionController : ControllerBase
{
    private readonly ICourseCompletionService _service;

    public CourseCompletionController(ICourseCompletionService service) =>
        _service = service ?? throw new ArgumentNullException(nameof(service));
    
    [HttpGet("{userId}/not-purchased")]
    public async Task<IActionResult> GetNotPurchasedAsync(Guid userId, int page = 0, int pageSize = 10)
    {
        var result = await _service.GetNotPurchasedAsync(userId, page, pageSize);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
    
    [HttpGet("{userId}/purchased")]
    public async Task<IActionResult> GetPurchasedAsync(Guid userId, int page = 0, int pageSize = 10)
    {
        var result = await _service.GetPurchasedAsync(userId, page, pageSize);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
    
    [HttpPost("append")]
    public async Task<IActionResult> AppendAsync([FromQuery] Guid courseId, [FromQuery] Guid userId)
    {
        var result = await _service.AppendAsync(courseId, userId);

        if (result.IsSuccess) return Ok(result);

        return BadRequest(result.Error);
    }
}