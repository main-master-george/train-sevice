using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Services.Text;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/texts")]
public class TextController : ControllerBase
{
    private readonly ITextService _textService;

    public TextController(ITextService textService) =>
        _textService = textService ?? throw new ArgumentNullException(nameof(textService));
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _textService.GetByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpGet("by-page/{id}")]
    public async Task<IActionResult> GetByPageIdAsync(Guid id)
    {
        var result = await _textService.GetByPageIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreationTextDto creationTextDto)
    {
        var result = await _textService.CreateAsync(creationTextDto);

        if (result.IsSuccess) return Created(result.Value!.Number.ToString(), result.Value);

        return BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id)
    {
        var result = await _textService.DeleteByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}