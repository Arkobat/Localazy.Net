using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

/// <summary>
/// Response containing metadata URLs for release tags.
/// </summary>
public class MetadataResponse
{
    /// <summary>
    /// Gets or sets the list of metadata URLs.
    /// </summary>
    [JsonPropertyName("metadataUrls")] public List<Metadata> MetadataUrls { get; set; } = null!;
}

/// <summary>
/// Represents metadata information for a release tag.
/// </summary>
public class Metadata
{
    /// <summary>
    /// Internal ID of the given release tag.
    /// </summary>
    [JsonPropertyName("tagId")]
    public string TagId { get; set; } = null!;

    /// <summary>
    /// The name of the release tag.
    /// </summary>
    [JsonPropertyName("tagName")]
    public string TagName { get; set; } = null!;

    /// <summary>
    /// URL of the metadata file.
    /// </summary>
    [JsonPropertyName("metadataUrl")]
    public string MetadataUrl { get; set; } = null!;
}