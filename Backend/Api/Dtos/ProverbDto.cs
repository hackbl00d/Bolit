using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class ProverbDto
{
    public Guid ProverbId { get; set; } = Guid.CreateVersion7();
    
    [JsonPropertyName("word")] 
    public string Word { get; set; }
    
    [JsonPropertyName("sense")]
    public string? Sense  { get; set; }
}