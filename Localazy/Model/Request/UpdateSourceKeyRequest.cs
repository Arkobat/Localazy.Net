using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

public class UpdateSourceKeyRequest
{
    /// <summary>
    /// Set to 0 or greater to mark the key as deprecated in the corresponding version; set to -1 to mark the key as not deprecated.
    /// </summary>
    [JsonPropertyName("deprecated")]
    public int Deprecated { get; set; } = -1;

    /// <summary>
    /// Set to true to mark the key as hidden for translation in Localazy.
    /// </summary>
    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    /// <summary>
    /// Provide custom comment for translators.
    /// </summary>
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    /// <summary>
    /// Change the limit of translation length or set to -1 to disable it.
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = -1;
}