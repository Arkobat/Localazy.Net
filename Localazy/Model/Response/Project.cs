using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class CreateProjectResponse
{
    /// <summary>
    /// ID of the newly created project.
    /// </summary>
    [JsonPropertyName("projectId")]
    public string ProjectId { get; set; } = null!;
}

public class Project
{
    /// <summary>
    /// Unique project identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// Identifier of the organization the project belongs to.
    /// </summary>
    [JsonPropertyName("orgId")]
    public string OrgId { get; set; } = null!;

    /// <summary>
    /// Project name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Project slug. (Can be used instead of id in requests where projectId is required)
    /// </summary>
    [JsonPropertyName("slug")]
    public string Slug { get; set; } = null!;

    /// <summary>
    /// Full URL to the project image or empty string if there is no image available.
    /// </summary>
    [JsonPropertyName("image")]
    public string Image { get; set; } = null!;

    /// <summary>
    /// Full URL to the project on Localazy.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    /// <summary>
    /// Project description.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Project type; one of public, private and restricted.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Project tone; one of not_specified, formal and informal.
    /// </summary>
    [JsonPropertyName("tone")]
    public string Tone { get; set; } = null!;

    /// <summary>
    /// Role of the current user accessing API (based on the token); one of none, translator, trusted_translator, reviewer, manager, owner and developer.
    /// </summary>
    [JsonPropertyName("role")]
    public string Role { get; set; } = null!;

    /// <summary>
    /// The identifier of the source language of the project.
    /// </summary>
    [JsonPropertyName("sourceLanguage")]
    public int SourceLanguage { get; set; }

    /// <summary>
    /// List of enabled features and available source keys. Only available if the organization query parameter is set to true.
    /// </summary>
    [JsonPropertyName("organization")]
    public Organization? Organization { get; set; }

    /// <summary>
    /// List of all languages and their current state. Only available if the languages query parameter is set to true. See <see cref="Language"/> Object.
    /// </summary>
    [JsonPropertyName("languages")]
    public List<Language>? Languages { get; set; }
}