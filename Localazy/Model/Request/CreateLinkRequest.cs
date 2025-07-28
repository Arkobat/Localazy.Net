using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

/// <summary>
/// Represents a request to create a link between translation keys in Localazy projects.
/// </summary>
public class CreateLinkRequest
{
    /// <summary>
    /// Gets or sets the ID of the target key to link to.
    /// </summary>
    /// <value>The target key identifier.</value>
    [JsonPropertyName("keyId")]
    public required string KeyId { get; set; }

    /// <summary>
    /// Gets or sets the ID or slug of the target project.
    /// If omitted, the current project is used instead.
    /// The user invoking the request must have at least the reviewer role in the target project.
    /// </summary>
    /// <value>The target project identifier or slug.</value>
    [JsonPropertyName("project")]
    public required string Project { get; set; }
}