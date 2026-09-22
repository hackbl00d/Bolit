using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class WordRef
{
    public Guid WordRefId { get; set; } = Guid.CreateVersion7();
    
    [JsonPropertyName("word")]
    public string? Word { get; set; }
    
    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}