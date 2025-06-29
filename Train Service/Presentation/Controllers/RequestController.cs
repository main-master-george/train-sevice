using Microsoft.AspNetCore.Mvc;
using ModerationModule.Application.Dtos.Incoming;
using ModerationModule.Application.Services;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/requests")]
public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService) =>
        _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));

    [HttpGet]
    public async Task<ActionResult> GetAsync(int page, int pageSize)
    {
        var result = await _requestService.GetAsync(page, pageSize);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpGet("by-course/{id}")]
    public async Task<ActionResult> GetByCourseIdAsync([FromQuery] Guid id)
    {
        var result = await _requestService.GetByCourseIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(CreationRequestDto creationRequestDto)
    {
        var result = await _requestService.CreateAsync(creationRequestDto);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStatusAsync([FromQuery] Guid id, string status)
    {
        var result = await _requestService.UpdateStatusAsync(id, status);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}