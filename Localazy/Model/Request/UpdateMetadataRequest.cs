using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

public class UpdateMetadataRequest
{
    /// <summary>
    /// Custom comment for a screenshot.
    ///</summary>
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    /// <summary>
    ///	Add tags. Adding has priority over removing. It cannot be used together with <see cref="Tags"/>.
    ///</summary>
    [JsonPropertyName("addTags")]
    public List<string>? AddTags { get; set; }

    /// <summary>
    ///	Remove tags. Adding has priority over removing. It cannot be used together with <see cref="Tags"/>.
    ///</summary>
    [JsonPropertyName("removeTags")]
    public List<string>? RemoveTags { get; set; }

    /// <summary>
    ///Replace tags with the current value. Cannot be used together with <see cref="AddTags"/> or/and <see cref="RemoveTags"/>.
    ///</summary>
    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    /// <summary>
    /// Adds keys. Adding has priority over removing. It cannot be used together with <see cref="Phrases"/>.
    /// </summary>
    [JsonPropertyName("addPhrases")]
    public List<string>? AddPhrases { get; set; }

    /// <summary>
    /// Removes keys. Adding has priority over removing. Cannot be used together with <see cref="Phrases"/>.
    /// </summary>
    [JsonPropertyName("removePhrases")]
    public List<string>? RemovePhrases { get; set; }

    /// <summary>
    /// Replace phrases with the current value. Cannot be used together with <see cref="AddPhrases"/> or/and <see cref="RemovePhrases"/>.
    /// </summary>
    [JsonPropertyName("phrases")]
    public List<string>? Phrases { get; set; }

    /// <summary>
    /// Add metadata. Adding has priority over removing. It cannot be used together with <see cref="Metadata"/>.
    /// </summary>
    [JsonPropertyName("addMetadata")]
    public Dictionary<string, string>? AddMetadata { get; set; }

    /// <summary>
    /// Remove metadata. Adding has priority over removing. It cannot be used together with <see cref="Metadata"/>.
    /// </summary>
    [JsonPropertyName("removeMetadata")]
    public List<string>? RemoveMetadata { get; set; }

    /// <summary>
    /// Replace metadata with the current value. Cannot be used together with <see cref="AddMetadata"/> or/and <see cref="RemoveMetadata"/>.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }
}