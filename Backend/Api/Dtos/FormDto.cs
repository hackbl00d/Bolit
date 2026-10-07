using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class FormDto
{
    [JsonPropertyName("form")]
    public string Text { get; set; }
    
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }
    
    [JsonPropertyName("raw_tags")]
    public List<string> RawTags { get; set; }
    
    [JsonPropertyName("source")]
    public string Source { get; set; }
}