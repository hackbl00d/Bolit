using System.Text.Json.Serialization;

namespace BolitApi.Dtos;

public class WordRef
{
    [JsonPropertyName("word")]
    public string? Word { get; set; }
    
    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}