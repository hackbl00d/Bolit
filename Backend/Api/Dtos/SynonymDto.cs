using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class SynonymDto
{
    public Guid SynonymId { get; set; } = Guid.CreateVersion7();
    
    [JsonPropertyName("word")]
    public string Word { get; set; }
    
    [JsonPropertyName("raw_tags")]
    public List<string>? RawTags  { get; set; }
}