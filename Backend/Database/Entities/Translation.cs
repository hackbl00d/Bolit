namespace Backend.Database.Entities;

public class Translation
{
    public Guid TranslationId { get; set; } = Guid.CreateVersion7();
    
    public string Word { get; set; } = string.Empty;
    
    public string LangCode { get; set; } = string.Empty;
    
    public string Lang { get; set; } = string.Empty;
    
    public string? Sense { get; set; }
    
    public List<string> Tags { get; set; } = new();

    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}