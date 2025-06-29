namespace CourseCompletionModule.Application.Dtos.Outgoing;

public class TestCompletionDto
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public string Text { get; set; }
    
    public decimal Value { get; set; }
    
    public bool IsResolved { get; set; }
}