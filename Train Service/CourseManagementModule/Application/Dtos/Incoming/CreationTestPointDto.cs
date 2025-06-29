namespace CourseManagementModule.Application.Dtos.Incoming;

public class CreationTestPointDto
{
    public Guid PageId { get; set; }
    
    public string Text { get; set; }
    
    public bool IsValid { get; set; }
}