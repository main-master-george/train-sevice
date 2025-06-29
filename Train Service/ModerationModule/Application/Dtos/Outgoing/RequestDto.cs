namespace ModerationModule.Application.Dtos.Outgoing;

public class RequestDto
{
    public Guid Id { get; set; }
    
    public Guid CourseId { get; set; }
    
    public string Status { get; set; }
}