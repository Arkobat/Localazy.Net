using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class ResultResponse<T>
{
    [JsonPropertyName("result")] public T Id { get; set; } = default!;
}