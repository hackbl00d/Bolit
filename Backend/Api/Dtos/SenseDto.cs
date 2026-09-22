using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class SenseDto
{
    public Guid SenseId { get; set; } = Guid.CreateVersion7();
    
    [JsonPropertyName("glosses")] 
    public List<string>? Glosses { get; set; }
    
    [JsonPropertyName("raw_tags")]
    public List<string>? RawTags { get; set; }
}