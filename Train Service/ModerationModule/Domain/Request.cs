namespace ModerationModule.Domain;

public class Request
{
    public Guid Id { get; set; }
    
    public Guid CourseId { get; set; }
    
    public Status Status { get; set; }
}