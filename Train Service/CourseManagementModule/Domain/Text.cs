namespace CourseManagementModule.Domain;

public class Text
{
    public Guid Id { get; set; }
    
    public Guid PageId { get; set; }
    
    public int Number { get; set; }
    
    public string Data { get; set; }
}