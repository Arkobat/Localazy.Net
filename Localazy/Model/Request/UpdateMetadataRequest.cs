using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

/// <summary>
/// Represents a request to update metadata for screenshots or other resources in Localazy.
/// </summary>
public class UpdateMetadataRequest
{
    /// <summary>
    /// Gets or sets a custom comment for a screenshot.
    /// </summary>
    /// <value>The comment text, or <c>null</c> if no comment is provided.</value>
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    /// <summary>
    /// Gets or sets tags to add. Adding has priority over removing. 
    /// Cannot be used together with <see cref="Tags"/>.
    /// </summary>
    /// <value>A list of tags to add, or <c>null</c> if no tags are being added.</value>
    [JsonPropertyName("addTags")]
    public List<string>? AddTags { get; set; }

    /// <summary>
    /// Gets or sets tags to remove. Adding has priority over removing. 
    /// Cannot be used together with <see cref="Tags"/>.
    /// </summary>
    /// <value>A list of tags to remove, or <c>null</c> if no tags are being removed.</value>
    [JsonPropertyName("removeTags")]
    public List<string>? RemoveTags { get; set; }

    /// <summary>
    /// Gets or sets tags to replace the current value with. 
    /// Cannot be used together with <see cref="AddTags"/> or <see cref="RemoveTags"/>.
    /// </summary>
    /// <value>A list of tags to replace all existing tags, or <c>null</c> if not replacing tags.</value>
    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    /// <summary>
    /// Gets or sets keys to add. Adding has priority over removing. 
    /// Cannot be used together with <see cref="Phrases"/>.
    /// </summary>
    /// <value>A list of keys to add, or <c>null</c> if no keys are being added.</value>
    [JsonPropertyName("addPhrases")]
    public List<string>? AddPhrases { get; set; }

    /// <summary>
    /// Gets or sets keys to remove. Adding has priority over removing. 
    /// Cannot be used together with <see cref="Phrases"/>.
    /// </summary>
    /// <value>A list of keys to remove, or <c>null</c> if no keys are being removed.</value>
    [JsonPropertyName("removePhrases")]
    public List<string>? RemovePhrases { get; set; }

    /// <summary>
    /// Gets or sets phrases to replace the current value with. 
    /// Cannot be used together with <see cref="AddPhrases"/> or <see cref="RemovePhrases"/>.
    /// </summary>
    /// <value>A list of phrases to replace all existing phrases, or <c>null</c> if not replacing phrases.</value>
    [JsonPropertyName("phrases")]
    public List<string>? Phrases { get; set; }

    /// <summary>
    /// Gets or sets metadata to add. Adding has priority over removing. 
    /// Cannot be used together with <see cref="Metadata"/>.
    /// </summary>
    /// <value>A dictionary of metadata to add, or <c>null</c> if no metadata is being added.</value>
    [JsonPropertyName("addMetadata")]
    public Dictionary<string, string>? AddMetadata { get; set; }

    /// <summary>
    /// Gets or sets metadata keys to remove. Adding has priority over removing. 
    /// Cannot be used together with <see cref="Metadata"/>.
    /// </summary>
    /// <value>A list of metadata keys to remove, or <c>null</c> if no metadata keys are being removed.</value>
    [JsonPropertyName("removeMetadata")]
    public List<string>? RemoveMetadata { get; set; }

    /// <summary>
    /// Gets or sets metadata to replace the current value with. 
    /// Cannot be used together with <see cref="AddMetadata"/> or <see cref="RemoveMetadata"/>.
    /// </summary>
    /// <value>A dictionary of metadata to replace all existing metadata, or <c>null</c> if not replacing metadata.</value>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }
}