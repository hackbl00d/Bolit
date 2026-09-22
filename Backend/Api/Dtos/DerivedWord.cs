using System.Text.Json.Serialization;

namespace Backend.Api.Dtos;

public class DerivedWord : WordRef
{
    public Guid DerivedWordId { get; set; } = Guid.CreateVersion7();
}