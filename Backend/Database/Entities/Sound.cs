namespace Backend.Database.Entities;

public class Sound
{
    public Guid SoundId { get; set; } = Guid.CreateVersion7();

    public required string Ipa { get; set; }
    
    public Guid EntryId { get; set; }
    
    public Entry Entry { get; set; } = null!;
}