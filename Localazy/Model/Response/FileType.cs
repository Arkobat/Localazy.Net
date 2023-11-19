using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class FileType
{
    /// <summary>
    /// Type of the file that can be used in content.type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Name of the type.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Indicates whether the type supports plain strings.
    /// </summary>
    [JsonPropertyName("supportStrings")]
    public bool SupportStrings { get; set; }

    /// <summary>
    /// Indicates whether the type supports plurals.
    /// </summary>
    [JsonPropertyName("supportPlurals")]
    public bool SupportPlurals { get; set; }

    /// <summary>
    /// Indicates whether the type supports string arrays.
    /// </summary>
    [JsonPropertyName("supportArrays")]
    public bool SupportArrays { get; set; }

    /// <summary>
    /// Indicates whether the type supports structured/nested keys.
    /// </summary>
    [JsonPropertyName("supportStructuredKeys")]
    public bool SupportStructuredKeys { get; set; }

    /// <summary>
    /// The list of available types for encoding plurals. Some of the types have requiredParams that must be provided.
    /// </summary>
    [JsonPropertyName("plurals")]
    public List<FilePlural>? Plurals { get; set; }

    /// <summary>
    /// The list of available types for encoding string arrays. Some of the types have requiredParams that must be provided.
    /// </summary>
    [JsonPropertyName("arrays")]
    public List<FileArray>? Arrays { get; set; }

    /// <summary>
    /// The list of available methods for converting structured/nested keys to plain ones.
    /// </summary>
    [JsonPropertyName("keyTransformers")]
    public List<FileKeyTransformer>? KeyTransformers { get; set; }
}

public class FilePlural
{
    [JsonPropertyName("type")] public string Type { get; set; } = null!;
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("isDefault")] public bool IsDefault { get; set; }
    [JsonPropertyName("requiredParams")] public List<FileRequiredParam>? RequiredParams { get; set; }
}

public class FileRequiredParam
{
    [JsonPropertyName("type")] public string Type { get; set; } = null!;
    [JsonPropertyName("description")] public string Description { get; set; } = null!;
}

public class FileArray
{
    [JsonPropertyName("type")] public string Type { get; set; } = null!;
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("isDefault")] public bool IsDefault { get; set; }
}

public class FileKeyTransformer
{
    [JsonPropertyName("type")] public string Type { get; set; } = null!;
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("isDefault")] public bool IsDefault { get; set; }
}