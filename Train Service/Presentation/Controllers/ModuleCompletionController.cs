using CourseCompletionModule.Application.Services.Module;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/modules/completion")]
public class ModuleCompletionController : ControllerBase
{
    private readonly IModuleCompletionService _service;

    public ModuleCompletionController(IModuleCompletionService service) =>
        _service = service ?? throw new ArgumentNullException(nameof(service));

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetByCourseIdAsync(Guid courseId, [FromQuery] Guid userId)
    {
        var result = await _service.GetByCourseIdAsync(courseId, userId);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> AppendAsync([FromQuery] Guid userId, IEnumerable<Guid> moduleIds)
    {
        var result = await _service.AppendAsync(moduleIds, userId);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}