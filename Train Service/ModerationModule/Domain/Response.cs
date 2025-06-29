namespace ModerationModule.Domain;

public class Response
{
    public Guid Id { get; set; }
    
    public Guid RequestId { get; set; }
    
    public string Message { get; set; }
}