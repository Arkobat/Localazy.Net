using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class MetadataResponse
{
    [JsonPropertyName("metadataUrls")] public List<Metadata> MetadataUrls { get; set; } = null!;
}

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