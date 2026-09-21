namespace BolitApi.Database.Entities;

public class Synonym
{
    public Guid SynonymId { get; set; } = Guid.CreateVersion7();
    
    public string Word { get; set; } = string.Empty;
    
    public List<string> RawTags { get; set; } = new();

    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}