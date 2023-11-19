using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class LinkResponse
{
    /// <summary>
    /// Array of links. See “Link Object” below.
    /// </summary>
    [JsonPropertyName("links")]
    public List<Link> Links { get; set; } = null!;

    /// <summary>
    /// Next is the paging key. The field is not contained if there are no more pages.
    /// </summary>
    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class Link
{
    /// <summary>
    /// Id of the key in Localazy.
    /// </summary>
    [JsonPropertyName("keyId")]
    public string KeyId { get; set; } = null!;

    /// <summary>
    /// Id of the project in Localazy the target key comes from. The cross-project linking is not available yet.
    /// </summary>
    [JsonPropertyName("linkedProjectId")]
    public string LinkedProjectId { get; set; } = null!;

    /// <summary>
    /// Id of the target key it is linked to.
    /// </summary>
    [JsonPropertyName("linkedKeyId")]
    public string LinkedKeyId { get; set; } = null!;
}