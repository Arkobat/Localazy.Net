using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class ScreenshotResponse
{
    /// <summary>
    /// Localazy identifier of a screenshot.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// The URL the screenshot is publicly available at.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    /// <summary>
    /// Custom screenshot description.
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; } = null!;

    /// <summary>
    /// Identifiers of keys assigned to a screenshot.
    /// </summary>
    [JsonPropertyName("phrases")]
    public List<string> Phrases { get; set; } = null!;

    /// <summary>
    /// A list of tags the screenshot is tagged with.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = null!;

    /// <summary>
    /// Data from the OCR reader. Only returned if the project belongs to an organization having the Autopilot or higher tier active.
    /// </summary>
    [JsonPropertyName("ocrData")]
    public string OcrData { get; set; } = null!;

    /// <summary>
    /// A key-value structure containing custom screenshot metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = null!;
}