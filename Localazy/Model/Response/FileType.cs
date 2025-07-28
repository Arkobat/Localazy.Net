using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

/// <summary>
/// Represents a file type supported by Localazy for importing and exporting content.
/// </summary>
public class FileType
{
    /// <summary>
    /// Gets or sets the type identifier that can be used in content.type.
    /// </summary>
    /// <value>The file type identifier.</value>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the human-readable name of the file type.
    /// </summary>
    /// <value>The display name of the file type.</value>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether the file type supports plain strings.
    /// </summary>
    /// <value><c>true</c> if the type supports plain strings; otherwise, <c>false</c>.</value>
    [JsonPropertyName("supportStrings")]
    public bool SupportStrings { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the file type supports plurals.
    /// </summary>
    /// <value><c>true</c> if the type supports plurals; otherwise, <c>false</c>.</value>
    [JsonPropertyName("supportPlurals")]
    public bool SupportPlurals { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the file type supports string arrays.
    /// </summary>
    /// <value><c>true</c> if the type supports string arrays; otherwise, <c>false</c>.</value>
    [JsonPropertyName("supportArrays")]
    public bool SupportArrays { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the file type supports structured/nested keys.
    /// </summary>
    /// <value><c>true</c> if the type supports structured keys; otherwise, <c>false</c>.</value>
    [JsonPropertyName("supportStructuredKeys")]
    public bool SupportStructuredKeys { get; set; }

    /// <summary>
    /// Gets or sets the list of available types for encoding plurals. 
    /// Some types have required parameters that must be provided.
    /// </summary>
    /// <value>A list of <see cref="FilePlural"/> objects, or <c>null</c> if plurals are not supported.</value>
    [JsonPropertyName("plurals")]
    public List<FilePlural>? Plurals { get; set; }

    /// <summary>
    /// Gets or sets the list of available types for encoding string arrays. 
    /// Some types have required parameters that must be provided.
    /// </summary>
    /// <value>A list of <see cref="FileArray"/> objects, or <c>null</c> if arrays are not supported.</value>
    [JsonPropertyName("arrays")]
    public List<FileArray>? Arrays { get; set; }

    /// <summary>
    /// Gets or sets the list of available methods for converting structured/nested keys to plain ones.
    /// </summary>
    /// <value>A list of <see cref="FileKeyTransformer"/> objects, or <c>null</c> if key transformation is not supported.</value>
    [JsonPropertyName("keyTransformers")]
    public List<FileKeyTransformer>? KeyTransformers { get; set; }
}

/// <summary>
/// Represents plural form configuration for a file type.
/// </summary>
public class FilePlural
{
    /// <summary>
    /// Gets or sets the type of the plural form.
    /// </summary>
    [JsonPropertyName("type")] public string Type { get; set; } = null!;
    /// <summary>
    /// Gets or sets the name of the plural form.
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    /// <summary>
    /// Gets or sets a value indicating whether this is the default plural form.
    /// </summary>
    [JsonPropertyName("isDefault")] public bool IsDefault { get; set; }
    /// <summary>
    /// Gets or sets the list of required parameters for this plural form.
    /// </summary>
    [JsonPropertyName("requiredParams")] public List<FileRequiredParam>? RequiredParams { get; set; }
}

/// <summary>
/// Represents a required parameter for file operations.
/// </summary>
public class FileRequiredParam
{
    /// <summary>
    /// Gets or sets the type of the required parameter.
    /// </summary>
    [JsonPropertyName("type")] public string Type { get; set; } = null!;
    /// <summary>
    /// Gets or sets the description of the required parameter.
    /// </summary>
    [JsonPropertyName("description")] public string Description { get; set; } = null!;
}

/// <summary>
/// Represents array configuration for a file type.
/// </summary>
public class FileArray
{
    /// <summary>
    /// Gets or sets the type of the array.
    /// </summary>
    [JsonPropertyName("type")] public string Type { get; set; } = null!;
    /// <summary>
    /// Gets or sets the name of the array.
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    /// <summary>
    /// Gets or sets a value indicating whether this is the default array configuration.
    /// </summary>
    [JsonPropertyName("isDefault")] public bool IsDefault { get; set; }
}

/// <summary>
/// Represents key transformation configuration for a file type.
/// </summary>
public class FileKeyTransformer
{
    /// <summary>
    /// Gets or sets the type of the key transformer.
    /// </summary>
    [JsonPropertyName("type")] public string Type { get; set; } = null!;
    /// <summary>
    /// Gets or sets the name of the key transformer.
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    /// <summary>
    /// Gets or sets a value indicating whether this is the default key transformer.
    /// </summary>
    [JsonPropertyName("isDefault")] public bool IsDefault { get; set; }
}