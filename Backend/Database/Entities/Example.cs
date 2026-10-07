namespace Backend.Database.Entities;

public class Example
{
    public Guid ExampleId { get; set; } = Guid.CreateVersion7();

    public required string Text { get; set; }

    public required List<List<int>> BoldTextOffsets { get; set; }

    public required string Translation { get; set; }

    public required string Reference { get; set; }
    
    public int SenseId { get; set; }
    
    public Sense Sense { get; set; } = null!;
}