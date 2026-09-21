namespace BolitApi.Database.Entities;

public class Proverb
{
    public Guid ProverbId { get; set; } = Guid.CreateVersion7();

    public string Phrase { get; set; } = string.Empty;
    
    public string? Sense { get; set; }

    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}