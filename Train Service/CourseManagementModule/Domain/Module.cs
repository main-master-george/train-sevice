namespace CourseManagementModule.Domain;

public class Module
{
    public Guid Id { get; set; }
    
    public Guid CourseId { get; set; }
    
    public int Number { get; set; }
    
    public string Header { get; set; }
    
    public string Description { get; set; }
}