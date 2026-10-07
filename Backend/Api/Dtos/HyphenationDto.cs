using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class HyphenationDto
{
    [JsonPropertyName("parts")]
    public List<string> Parts { get; set; }
}