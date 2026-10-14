namespace Backend.Database.Entities;

public class Form
{
    public Guid FormId { get; set; } = Guid.CreateVersion7();

    public string Text { get; set; }

    public List<string> Tags { get; set; }

    public List<string>? RawTags { get; set; }

    public string? Source { get; set; }
    
    public Guid EntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}