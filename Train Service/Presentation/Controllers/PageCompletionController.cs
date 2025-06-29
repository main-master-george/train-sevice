using CourseCompletionModule.Application.Services.Page;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/pages/completion")]
public class PageCompletionController : ControllerBase
{
    private readonly IPageCompletionService _service;

    public PageCompletionController(IPageCompletionService service) =>
        _service = service ?? throw new ArgumentNullException(nameof(service));

    [HttpGet("by-module/{id}")]
    public async Task<IActionResult> GetByModuleIdAsync(Guid id)
    {
        var result = await _service.GetByModuleIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}