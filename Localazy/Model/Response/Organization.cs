using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

/// <summary>
/// Represents organization information including features and usage statistics.
/// </summary>
public class Organization
{
    /// <summary>
    /// Gets or sets the number of available keys for the organization.
    /// </summary>
    [JsonPropertyName("availableKeys")] public int AvailableKeys { get; set; }

    /// <summary>
    /// Gets or sets the number of used keys by the organization.
    /// </summary>
    [JsonPropertyName("usedKeys")] public int UsedKeys { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether Figma integration is available.
    /// </summary>
    [JsonPropertyName("figma")] public bool Figma { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether connected apps feature is available.
    /// </summary>
    [JsonPropertyName("connectedApps")] public bool ConnectedApps { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether release tags feature is available.
    /// </summary>
    [JsonPropertyName("releaseTags")] public bool ReleaseTags { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether format conversions feature is available.
    /// </summary>
    [JsonPropertyName("formatConversions")]
    public bool FormatConversions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether screenshots feature is available.
    /// </summary>
    [JsonPropertyName("screenshots")] public bool Screenshots { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether additional machine translation is available.
    /// </summary>
    [JsonPropertyName("additionalMt")] public bool AdditionalMt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether machine translation pre-translate is available.
    /// </summary>
    [JsonPropertyName("mtPretranslate")] public bool MtPreTranslate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether webhooks feature is available.
    /// </summary>
    [JsonPropertyName("webhooks")] public bool Webhooks { get; set; }
}