using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

/// <summary>
/// Represents a file in a Localazy project with its metadata and properties.
/// </summary>
public class ProjectFile
{
    /// <summary>
    /// Gets or sets the unique identifier of the file.
    /// </summary>
    /// <value>The file's unique identifier.</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the type of the file. Please refer to file formats documentation.
    /// Value "complex" is used for complex files.
    /// </summary>
    /// <value>The file type identifier.</value>
    [JsonPropertyName("type")]
    public required string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    /// <value>The file name.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the stored path to the file. Optional and only available if provided.
    /// </summary>
    /// <value>The file path, or <c>null</c> if not specified.</value>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Gets or sets the module the file belongs to. Optional and only available if provided.
    /// </summary>
    /// <value>The module name, or <c>null</c> if not specified.</value>
    [JsonPropertyName("module")]
    public string? Module { get; set; }

    /// <summary>
    /// Gets or sets a list of associated product flavours. Optional and only available if provided.
    /// </summary>
    /// <value>A list of product flavour identifiers, or <c>null</c> if not specified.</value>
    [JsonPropertyName("productFlavors")]
    public List<string>? ProductFlavors { get; set; }

    /// <summary>
    /// Gets or sets a build type the file is associated with. Optional and only available if provided.
    /// </summary>
    /// <value>The build type identifier, or <c>null</c> if not specified.</value>
    [JsonPropertyName("buildType")]
    public string? BuildType { get; set; }
}