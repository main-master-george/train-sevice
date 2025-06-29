namespace CourseCompletionModule.Application.Dtos.Outgoing;

public class CourseCompletionDto
{
    public Guid CourseId { get; set; }
    
    public Guid UserId { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public bool Used { get; set; }
}