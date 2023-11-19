using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class Language
{
    /// <summary>
    /// Internal identifier of the language on Localazy.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Locale code.
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = null!;

    /// <summary>
    /// English name of the language / locale.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Number of active keys.
    /// </summary>
    [JsonPropertyName("active")]
    public int Active { get; set; }

    /// <summary>
    /// Number of keys waiting for review.
    /// </summary>
    [JsonPropertyName("review")]
    public int Review { get; set; }

    /// <summary>
    /// Number of keys with approved version/translation.
    /// </summary>
    [JsonPropertyName("current")]
    public int Current { get; set; }

    /// <summary>
    /// Number of keys that are already translated (but may not be approved yet).
    /// </summary>
    [JsonPropertyName("translated")]
    public int Translated { get; set; }

    /// <summary>
    /// Number of keys in the source changed state.
    /// </summary>
    [JsonPropertyName("sourceChanged")]
    public int SourceChanged { get; set; }

    /// <summary>
    /// Number of keys in the need review state.
    /// </summary>
    [JsonPropertyName("needImprovement")]
    public int NeedImprovement { get; set; }
}