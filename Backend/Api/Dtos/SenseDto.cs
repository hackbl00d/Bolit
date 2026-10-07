using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class SenseDto
{
    [JsonPropertyName("glosses")] 
    public List<string>? Glosses { get; set; }
    
    [JsonPropertyName("examples")]
    public List<ExampleDto>? Examples { get; set; }
    
    [JsonPropertyName("raw_tags")]
    public List<string>? RawTags { get; set; }
}