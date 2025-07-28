using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

/// <summary>
/// Response containing glossary information.
/// </summary>
public class GlossaryResponse
{
    /// <summary>
    /// Gets or sets the glossary data.
    /// </summary>
    [JsonPropertyName("glossaries")] public Glossary Glossary { get; set; } = null!;
}

/// <summary>
/// Represents a glossary containing terms and their translations.
/// </summary>
public class Glossary
{
    /// <summary>
    /// Id of the glossary term.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// Description of the glossary term.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Whether the term should be translated or left as is.
    /// </summary>
    [JsonPropertyName("translateTerm")]
    public bool TranslateTerm { get; set; }

    /// <summary>
    /// Wheter the term is case sensitive or not.
    /// </summary>
    [JsonPropertyName("caseSensitive")]
    public bool CaseSensitive { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("exactMatch")]
    public bool ExactMatch { get; set; }

    /// <summary>
    /// Contains an array of the term and it’s translations. See “Term Object” below.
    /// </summary>
    [JsonPropertyName("term")]
    public List<GlossaryTerm> Term { get; set; } = null!;
}

/// <summary>
/// Represents a single glossary term with its language and value.
/// </summary>
public class GlossaryTerm
{
    /// <summary>
    /// Language code in which the term is used.
    /// Use source language if not translatable.
    /// </summary>
    [JsonPropertyName("lang")]
    public string Lang { get; set; } = null!;

    /// <summary>
    /// The value of the glossary term.
    /// </summary>
    [JsonPropertyName("term")]
    public string Term { get; set; } = null!;
}