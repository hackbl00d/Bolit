using System.Text.Json.Serialization;

namespace BolitApi.Dtos;

public class TranslationDto
{
    [JsonPropertyName("lang_code")] 
    public string LangCode { get; set; }
    
    [JsonPropertyName("lang")]
    public string Lang { get; set; }
    
    [JsonPropertyName("word")] 
    public string Word { get; set; }
    
    [JsonPropertyName("sense")]
    public string? Sense { get; set; }
    
    [JsonPropertyName("tags")] 
    public List<string>? Tags { get; set; }
}