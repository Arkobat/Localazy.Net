using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

/// <summary>
/// Represents a request to create a new project in Localazy.
/// </summary>
public class CreateProjectRequest
{
    /// <summary>
    /// Gets or sets the name of the project.
    /// </summary>
    /// <value>The project name. This field is required.</value>
    [JsonPropertyName("name")] public required string Name { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the unique slug identifier for the project.
    /// </summary>
    /// <value>The project slug. If not provided, it will be auto-generated from the name.</value>
    [JsonPropertyName("slug")] public string? Slug { get; set; }
    
    /// <summary>
    /// Gets or sets the project description.
    /// </summary>
    /// <value>A description of the project's purpose or content.</value>
    [JsonPropertyName("description")] public string? Description { get; set; }
    
    /// <summary>
    /// Gets or sets the source language code for the project.
    /// </summary>
    /// <value>The language code in format: ll-Scrp-RR (e.g., "en-US").</value>
    [JsonPropertyName("sourceLanguage")] public string? SourceLanguage { get; set; }
    
    /// <summary>
    /// Gets or sets the project type.
    /// </summary>
    /// <value>The type of project (e.g., "web", "mobile", "desktop").</value>
    [JsonPropertyName("type")] public string? Type { get; set; }
    
    /// <summary>
    /// Gets or sets the tone of the project for translation context.
    /// </summary>
    /// <value>The tone description to help translators understand the context.</value>
    [JsonPropertyName("tone")] public string? Tone { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether to use shared translation memory.
    /// </summary>
    /// <value><c>true</c> to use shared translation memory; otherwise, <c>false</c>. Default is <c>true</c>.</value>
    [JsonPropertyName("useShareTM")] public bool UseShareTM { get; set; } = true;
}