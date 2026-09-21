namespace BolitApi.Database.Entities;

public class Entry
{
    public Guid EntryId { get; set; } = Guid.CreateVersion7();
    
    public string Word { get; set; } = string.Empty;
    
    public string LangCode { get; set; } = string.Empty;
    
    public string Lang { get; set; } = string.Empty;
    
    public string Pos { get; set; } = string.Empty;
    
    public string PosTitle { get; set; } = string.Empty;

    public List<string> Categories { get; set; } = new();

    public List<Sense> Senses { get; set; } = new();
    
    public List<Translation> Translations { get; set; } = new();
    
    public List<Synonym> Synonyms { get; set; } = new();
    
    public List<DerivedWord> DerivedWords { get; set; } = new();
    
    public List<RelatedWord> RelatedWords { get; set; } = new();
    
    public List<Proverb> Proverbs { get; set; } = new();
}