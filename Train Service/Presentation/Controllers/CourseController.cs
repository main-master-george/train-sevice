using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Services.Course;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/courses")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService) =>
        _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));

    [HttpGet]
    public async Task<IActionResult> GetAsync(int page, int pageSize)
    {
        var result = await _courseService.GetAsync(page, pageSize);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _courseService.GetByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreationCourseDto creationCourseDto)
    {
        var result = await _courseService.CreateAsync(creationCourseDto);

        if (result.IsSuccess) return Created(result.Value!.Id.ToString(), result.Value);

        return BadRequest(result.Error);
    }

    [HttpPut("{id}/visibility")]
    public async Task<IActionResult> ChangeCourseVisibilityAsync(Guid id, bool isVisible)
    {
        var result = await _courseService.ChangeCourseVisibilityAsync(id, isVisible);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id)
    {
        var result = await _courseService.DeleteByIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}