namespace CourseManagementModule.Application.Dtos.Incoming;

public class CreationTestDto
{
    public Guid PageId { get; set; }
    
    public int Number { get; set; }

    public string Text { get; set; }
    
    public decimal Value { get; set; }
}