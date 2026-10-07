using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class SynonymDto
{
    [JsonPropertyName("word")]
    public string Word { get; set; }
    
    [JsonPropertyName("raw_tags")]
    public List<string>? RawTags  { get; set; }
}