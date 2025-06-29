using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Services.Page;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/pages")]
public class PageController : ControllerBase
{
    private readonly IPageService _pageService;

    public PageController(IPageService pageService) =>
        _pageService = pageService ?? throw new ArgumentNullException(nameof(pageService));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _pageService.GetByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
    
    [HttpGet("by-module/{id}")]
    public async Task<IActionResult> GetByModuleIdAsync(Guid id)
    {
        var result = await _pageService.GetByModuleIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreationPageDto creationPageDto)
    {
        var result = await _pageService.CreateAsync(creationPageDto);

        if (result.IsSuccess) return Created(result.Value!.Id.ToString(), result.Value);

        return BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id)
    {
        var result = await _pageService.DeleteByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}