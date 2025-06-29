namespace ModerationModule.Application.Dtos.Outgoing;

public class ResponseDto
{
    public Guid Id { get; set; }
    
    public Guid RequestId { get; set; }
    
    public string Message { get; set; }
}