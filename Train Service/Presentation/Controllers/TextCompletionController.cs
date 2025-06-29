using CourseCompletionModule.Application.Services.Text;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/texts/completion")]
public class TextCompletionController : ControllerBase
{
    private readonly ITextCompletionService _textCompletionService;

    public TextCompletionController(ITextCompletionService textCompletionService) =>
        _textCompletionService =
            textCompletionService ?? throw new ArgumentNullException(nameof(textCompletionService));

    [HttpGet("by-page/{id}")]
    public async Task<IActionResult> GetByPageIdAsync(Guid id)
    {
        var result = await _textCompletionService.GetByPageIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}