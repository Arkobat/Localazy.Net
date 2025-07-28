using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

/// <summary>
/// Represents a request to update properties of a source key in a Localazy project.
/// </summary>
public class UpdateSourceKeyRequest
{
    /// <summary>
    /// Gets or sets the deprecation version for the key.
    /// Set to 0 or greater to mark the key as deprecated in the corresponding version; set to -1 to mark the key as not deprecated.
    /// </summary>
    /// <value>The deprecation version number, or -1 if not deprecated. Default is -1.</value>
    [JsonPropertyName("deprecated")]
    public int Deprecated { get; set; } = -1;

    /// <summary>
    /// Gets or sets a value indicating whether the key should be hidden for translation in Localazy.
    /// </summary>
    /// <value><c>true</c> to hide the key from translation; otherwise, <c>false</c>.</value>
    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    /// <summary>
    /// Gets or sets a custom comment for translators to provide context or instructions.
    /// </summary>
    /// <value>The comment text, or <c>null</c> if no comment is provided.</value>
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    /// <summary>
    /// Gets or sets the character limit for translations of this key.
    /// Set to a positive number to limit translation length, or -1 to disable the limit.
    /// </summary>
    /// <value>The character limit, or -1 if no limit is set. Default is -1.</value>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = -1;
}