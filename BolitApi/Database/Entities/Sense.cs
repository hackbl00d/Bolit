namespace BolitApi.Database.Entities;

public class Sense
{
    public Guid SenseId { get; set; } = Guid.CreateVersion7();
    
    public List<string> Glosses { get; set; } = new();
    
    public List<string> RawTags { get; set; } = new();
    
    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}