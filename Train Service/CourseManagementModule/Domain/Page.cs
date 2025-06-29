namespace CourseManagementModule.Domain;

public class Page
{
    public Guid Id { get; set; }
    
    public Guid ModuleId { get; set; }
    
    public int Number { get; set; }
}