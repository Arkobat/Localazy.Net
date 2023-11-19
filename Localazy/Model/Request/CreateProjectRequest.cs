using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

public class CreateProjectRequest
{
    [JsonPropertyName("name")] public required string Name { get; set; } = null!;
    [JsonPropertyName("slug")] public string? Slug { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("sourceLanguage")] public string? SourceLanguage { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("tone")] public string? Tone { get; set; }
    [JsonPropertyName("useShareTM")] public bool UseShareTM { get; set; } = true;
}