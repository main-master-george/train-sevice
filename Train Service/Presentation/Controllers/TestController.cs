using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Services.Test;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/tests")]
public class TestController : ControllerBase
{
    private readonly ITestService _testService;

    public TestController(ITestService testService) =>
        _testService = testService ?? throw new ArgumentNullException(nameof(testService));
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _testService.GetByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpGet("by-page/{id}")]
    public async Task<IActionResult> GetByPageIdAsync(Guid id)
    {
        var result = await _testService.GetByPageIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreationTestDto creationTestDto)
    {
        var result = await _testService.CreateAsync(creationTestDto);

        if (result.IsSuccess) return Created(result.Value!.Id.ToString(), result.Value);

        return BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id)
    {
        var result = await _testService.DeleteByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}