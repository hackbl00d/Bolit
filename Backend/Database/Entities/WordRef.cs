namespace Backend.Database.Entities;

public class WordRef
{
    public Guid WordRefId { get; set; } = Guid.CreateVersion7();

    public required string Word { get; set; }
    
    public List<string>? Tags { get; set; }
    
    public int EntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}