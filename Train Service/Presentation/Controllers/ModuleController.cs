using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Services.Module;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/module")]
public class ModuleController : ControllerBase
{
    private readonly IModuleService _moduleService;

    public ModuleController(IModuleService moduleService) =>
        _moduleService = moduleService ?? throw new ArgumentNullException(nameof(moduleService));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _moduleService.GetByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
    
    [HttpGet("by-course/{id}")]
    public async Task<IActionResult> GetByCourseIdAsync(Guid id)
    {
        var result = await _moduleService.GetByCourseIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreationModuleDto creationModuleDto)
    {
        var result = await _moduleService.CreateAsync(creationModuleDto);

        if (result.IsSuccess) return Created(result.Value!.Id.ToString(), result.Value);

        return BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id)
    {
        var result = await _moduleService.DeleteByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}