using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Services.TestPoint;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/test-points")]
public class TestPointController : ControllerBase
{
    private readonly ITestPointService _testPointService;

    public TestPointController(ITestPointService testPointService) =>
        _testPointService = testPointService ?? throw new ArgumentNullException(nameof(testPointService));
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _testPointService.GetByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpGet("by-test/{id}")]
    public async Task<IActionResult> GetByTestIdAsync(Guid id)
    {
        var result = await _testPointService.GetByTestIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreationTestPointDto creationTestPointDto)
    {
        var result = await _testPointService.CreateAsync(creationTestPointDto);

        if (result.IsSuccess) return Created(result.Value!.Id.ToString(), result.Value);

        return BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id)
    {
        var result = await _testPointService.DeleteByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}