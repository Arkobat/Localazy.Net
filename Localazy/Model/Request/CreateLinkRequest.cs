using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

public class CreateLinkRequest
{
    /// <summary>
    /// Id of the target key.
    /// </summary>
    [JsonPropertyName("keyId")]
    public required string KeyId { get; set; }

    /// <summary>
    /// Id or slug of the target project.
    /// If omitted, the current project is used instead.
    /// The user invoking the request must have at least the reviewer role in the target project.
    /// </summary>
    [JsonPropertyName("project")]
    public required string Project { get; set; }
}