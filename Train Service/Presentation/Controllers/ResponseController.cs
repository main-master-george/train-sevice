using Microsoft.AspNetCore.Mvc;
using ModerationModule.Application.Dtos.Incoming;
using ModerationModule.Application.Services;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/responses")]
public class ResponseController : ControllerBase
{
    private readonly IResponseService _responseService;

    public ResponseController(IResponseService responseService) =>
        _responseService = responseService ?? 
                           throw new ArgumentNullException(nameof(responseService));

    [HttpGet("by-request/{id}")]
    public async Task<ActionResult> GetByRequestIdAsync([FromQuery] Guid id)
    {
        var result = await _responseService.GetByRequestIdAsync(id);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(CreationResponseDto creationResponseDto)
    {
        var result = await _responseService.CreateAsync(creationResponseDto);

        if (result.IsSuccess) return Ok(result.Value);

        return BadRequest(result.Error);
    }
}