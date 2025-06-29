namespace CourseCompletionModule.Domain;

public class UserCourse
{
    public Guid UserId { get; set; }
    
    public Guid CourseId { get; set; }
    
    public DateTime StartDateTime { get; set; }
}