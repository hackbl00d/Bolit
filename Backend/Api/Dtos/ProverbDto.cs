using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class ProverbDto
{
    [JsonPropertyName("word")] 
    public string Phrase { get; set; }
    
    [JsonPropertyName("sense")]
    public string? Sense  { get; set; }
}