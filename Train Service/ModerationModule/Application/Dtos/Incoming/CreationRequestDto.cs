namespace ModerationModule.Application.Dtos.Incoming;

public class CreationRequestDto
{
    public Guid CourseId { get; set; }
    
    public string Status { get; set; }
}