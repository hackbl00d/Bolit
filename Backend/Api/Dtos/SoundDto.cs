using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class SoundDto
{
    [JsonPropertyName("ipa")]
    public string Ipa { get; set; }
}