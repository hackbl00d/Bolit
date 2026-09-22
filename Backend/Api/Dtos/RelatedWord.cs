using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class RelatedWord : WordRef
{
    public Guid RelatedWordId { get; set; } = Guid.CreateVersion7();
}