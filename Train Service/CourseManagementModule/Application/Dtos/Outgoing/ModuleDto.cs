namespace CourseManagementModule.Application.Dtos.Outgoing;

public class ModuleDto
{
    public Guid Id { get; set; }

    public int Number { get; set; }
    
    public string Header { get; set; }
    
    public string Description { get; set; }
}