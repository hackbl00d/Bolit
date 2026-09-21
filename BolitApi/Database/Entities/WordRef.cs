namespace BolitApi.Database.Entities;

public class WordRef
{
    public string Word { get; set; }
    
    public List<string>? Tags { get; set; }
}