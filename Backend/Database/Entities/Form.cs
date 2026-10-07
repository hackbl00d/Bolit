namespace Backend.Database.Entities;

public class Form
{
    public Guid FormId { get; set; } = Guid.CreateVersion7();

    public required string Text { get; set; }

    public required List<string> Tags { get; set; }

    public List<string>? RawTags { get; set; }

    public required string Source { get; set; }
    
    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}