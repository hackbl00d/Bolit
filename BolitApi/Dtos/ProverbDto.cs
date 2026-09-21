using System.Text.Json.Serialization;

namespace BolitApi.Dtos;

public class ProverbDto
{
    [JsonPropertyName("word")] 
    public string Word { get; set; }
    
    [JsonPropertyName("sense")]
    public string? Sense  { get; set; }
}