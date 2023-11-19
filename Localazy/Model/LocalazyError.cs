using System.Text.Json.Serialization;

namespace Localazy.Model;

internal class LocalazyError
{
    [JsonPropertyName("success")] public bool Success { get; set; }
    [JsonPropertyName("code")] public int Code { get; set; }
    [JsonPropertyName("message")] public string Message { get; set; } = null!;
    [JsonPropertyName("error")] public string Error { get; set; } = null!;
}