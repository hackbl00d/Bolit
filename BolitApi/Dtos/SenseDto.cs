using System.Text.Json.Serialization;

namespace BolitApi.Dtos;

public class SenseDto
{
    [JsonPropertyName("glosses")] 
    public List<string>? Glosses { get; set; }
    
    [JsonPropertyName("raw_tags")]
    public List<string>? RawTags { get; set; }
}