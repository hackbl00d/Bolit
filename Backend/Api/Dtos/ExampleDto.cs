using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class ExampleDto
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("bold_text_offsets")]
    public List<List<int>> BoldTextOffsets { get; set; }
    
    [JsonPropertyName("translation")] 
    public string Translation { get; set; }
    
    [JsonPropertyName("ref")]
    public string Reference { get; set; }
}