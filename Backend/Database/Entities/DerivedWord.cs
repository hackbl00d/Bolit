namespace Backend.Database.Entities;

public class DerivedWord : WordRef
{
    public Guid DerivedWordId { get; set; } = Guid.CreateVersion7();
    
    public Guid EntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}