namespace Backend.Database.Entities;

public class WordRef
{
    public required string Word { get; set; }
    
    public List<string>? Tags { get; set; }
}