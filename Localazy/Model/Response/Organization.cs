using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class Organization
{
    [JsonPropertyName("availableKeys")] public int AvailableKeys { get; set; }

    [JsonPropertyName("usedKeys")] public int UsedKeys { get; set; }

    [JsonPropertyName("figma")] public bool Figma { get; set; }

    [JsonPropertyName("connectedApps")] public bool ConnectedApps { get; set; }

    [JsonPropertyName("releaseTags")] public bool ReleaseTags { get; set; }

    [JsonPropertyName("formatConversions")]
    public bool FormatConversions { get; set; }

    [JsonPropertyName("screenshots")] public bool Screenshots { get; set; }

    [JsonPropertyName("additionalMt")] public bool AdditionalMt { get; set; }

    [JsonPropertyName("mtPretranslate")] public bool MtPreTranslate { get; set; }

    [JsonPropertyName("webhooks")] public bool Webhooks { get; set; }
}