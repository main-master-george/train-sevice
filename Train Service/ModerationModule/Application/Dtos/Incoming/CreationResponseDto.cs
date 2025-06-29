namespace ModerationModule.Application.Dtos.Incoming;

public class CreationResponseDto
{
    public Guid RequestId { get; set; }
    
    public string Message { get; set; }
}