namespace CourseManagementModule.Application.Dtos.Incoming;

public class CreationModuleDto
{
    public Guid CourseId { get; set; }
    
    public int Number { get; set; }
    
    public string Header { get; set; }
    
    public string Description { get; set; }
}