namespace CourseManagementModule.Application.Dtos.Outgoing;

public class TestPointDto
{
    public Guid Id { get; set; }

    public string Text { get; set; }
    
    public bool IsValid { get; set; }
}