namespace Backend.Database.Entities;

public class Hyphenation
{
    public Guid HyphenationId { get; set; } = Guid.CreateVersion7();

    public required List<string> Parts { get; set; }
    
    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}