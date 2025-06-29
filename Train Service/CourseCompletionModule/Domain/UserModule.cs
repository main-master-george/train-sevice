namespace CourseCompletionModule.Domain;

public class UserModule
{
    public Guid UserId { get; set; }
    
    public Guid ModuleId { get; set; }

    public bool IsOpen { get; set; }
}