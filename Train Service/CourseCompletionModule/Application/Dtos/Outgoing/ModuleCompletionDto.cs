namespace CourseCompletionModule.Application.Dtos.Outgoing;

public class ModuleCompletionDto
{
    public Guid Id { get; set; }

    public int Number { get; set; }
    
    public string Header { get; set; }
    
    public string Description { get; set; }
    
    public bool IsPurchased { get; set; }
}