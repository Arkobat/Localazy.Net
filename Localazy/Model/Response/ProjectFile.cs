using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class ProjectFile
{
    /// <summary>
    /// Unique identifier of the file.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; } = null!;

    /// <summary>
    /// Type of the file; please refer to file formats.
    /// Value complex is used for complex files described above.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; } = null!;

    /// <summary>
    /// Name of the file.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; } = null!;

    /// <summary>
    /// Stored path to the file. Optional and only available if provided.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// The module the file belongs to. Optional and only available if provided.
    /// </summary>
    [JsonPropertyName("module")]
    public string? Module { get; set; }

    /// <summary>
    /// A list of associated product flavours. Optional and only available if provided.
    /// </summary>
    [JsonPropertyName("productFlavors")]
    public List<string>? ProductFlavors { get; set; }

    /// <summary>
    /// A build type the file is associated with. Optional and only available if provided.
    /// </summary>
    [JsonPropertyName("buildType")]
    public string? BuildType { get; set; }
}