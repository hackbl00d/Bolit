namespace BolitApi.Database.Entities;

public class RelatedWord : WordRef
{
    public Guid RelatedWordId { get; set; } = Guid.CreateVersion7();

    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}