using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class DictionaryEntryDto
{
    public Guid DictEntryId { get; set; } = Guid.CreateVersion7();
    
    [JsonPropertyName("word")] 
    public string Word { get; set; }
    
    [JsonPropertyName("lang_code")] 
    public string LangCode { get; set; }
    
    [JsonPropertyName("lang")]
    public string Lang  { get; set; }
    
    [JsonPropertyName("pos")] 
    public string Pos { get; set; }
    
    [JsonPropertyName("pos_title")] 
    public string PosTitle { get; set; }
    
    [JsonPropertyName("senses")] 
    public List<SenseDto>? Senses { get; set; }
    
    [JsonPropertyName("categories")] 
    public List<string>? Categories { get; set; }
    
    [JsonPropertyName("translations")] 
    public List<TranslationDto>? Translations { get; set; }
    
    [JsonPropertyName("synonyms")]
    public List<SynonymDto>? Synonyms { get; set; }
    
    [JsonPropertyName("derived")] 
    public List<WordRef>? DerivedWords { get; set; }
    
    [JsonPropertyName("related")] 
    public List<WordRef>? RelatedWords { get; set; }
    
    [JsonPropertyName("proverbs")] 
    public List<ProverbDto>? Proverbs  { get; set; }
}