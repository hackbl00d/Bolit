namespace Backend.Database.Entities;

public class Sound
{
    public Guid SoundId { get; set; } = Guid.CreateVersion7();

    public required string IPA { get; set; }
    
    public int DictionaryEntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}