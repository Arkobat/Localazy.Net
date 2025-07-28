using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

/// <summary>
/// Represents a language in a Localazy project with translation statistics.
/// </summary>
public class Language
{
    /// <summary>
    /// Gets or sets the internal identifier of the language on Localazy.
    /// </summary>
    /// <value>The unique language identifier.</value>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the locale code in format: ll-Scrp-RR.
    /// </summary>
    /// <value>The ISO language/locale code (e.g., "en-US", "de-DE").</value>
    [JsonPropertyName("code")]
    public string Code { get; set; } = null!;

    /// <summary>
    /// Gets or sets the English name of the language/locale.
    /// </summary>
    /// <value>The display name of the language in English.</value>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the number of active translation keys in this language.
    /// </summary>
    /// <value>The count of active keys.</value>
    [JsonPropertyName("active")]
    public int Active { get; set; }

    /// <summary>
    /// Gets or sets the number of keys waiting for review.
    /// </summary>
    /// <value>The count of keys pending review.</value>
    [JsonPropertyName("review")]
    public int Review { get; set; }

    /// <summary>
    /// Gets or sets the number of keys with approved version/translation.
    /// </summary>
    /// <value>The count of keys that have an approved translation.</value>
    [JsonPropertyName("current")]
    public int Current { get; set; }

    /// <summary>
    /// Gets or sets the number of keys that are already translated (but may not be approved yet).
    /// </summary>
    /// <value>The count of translated keys.</value>
    [JsonPropertyName("translated")]
    public int Translated { get; set; }

    /// <summary>
    /// Gets or sets the number of keys in the source changed state.
    /// </summary>
    /// <value>The count of keys whose source text has changed.</value>
    [JsonPropertyName("sourceChanged")]
    public int SourceChanged { get; set; }

    /// <summary>
    /// Gets or sets the number of keys in the need review state.
    /// </summary>
    /// <value>The count of keys that need improvement or review.</value>
    [JsonPropertyName("needImprovement")]
    public int NeedImprovement { get; set; }
}