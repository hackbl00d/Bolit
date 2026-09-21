namespace BolitApi.Database.Entities;

public class DerivedWord : WordRef
{
    public Guid DerivedWordId { get; set; } = Guid.CreateVersion7();

    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}