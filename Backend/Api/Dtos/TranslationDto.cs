using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class TranslationDto
{
    public Guid TranslationId { get; set; } = Guid.CreateVersion7();
    
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