using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

/// <summary>
/// Represents a request to import content (strings and translations) to a Localazy project.
/// </summary>
public class ImportContentRequest
{
    /// <summary>
    /// Gets or sets a value indicating whether to import all translations to go through the review process.
    /// Useful when you are unsure about their quality and want to do an extra check.
    /// </summary>
    /// <value><c>true</c> to import as new translations for review; otherwise, <c>false</c>.</value>
    [JsonPropertyName("importAsNew")]
    public bool ImportAsNew { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to import all translations and set them as the current version.
    /// By default, Localazy doesn't overwrite existing current translations and lets you decide through the review process.
    /// </summary>
    /// <value><c>true</c> to force current version; otherwise, <c>false</c>.</value>
    [JsonPropertyName("forceCurrent")]
    public bool ForceCurrent { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to filter out translations that are the same as the source language content.
    /// </summary>
    /// <value><c>true</c> to filter source duplicates; otherwise, <c>false</c>. Default is <c>true</c>.</value>
    [JsonPropertyName("filterSource")]
    public bool FilterSource { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to overwrite the source language even if there are changes in Localazy.
    /// Useful for workflows where source of truth is outside the platform.
    /// </summary>
    /// <value><c>true</c> to force source overwrite; otherwise, <c>false</c>.</value>
    [JsonPropertyName("forceSource")]
    public bool ForceSource { get; set; }

    /// <summary>
    /// Gets or sets the list of files and strings to be imported.
    /// </summary>
    /// <value>A list of <see cref="ImportFile"/> objects containing the content to import.</value>
    [JsonPropertyName("files")]
    public required List<ImportFile> Files { get; set; } = null!;
}

/// <summary>
/// Represents a file to be imported with its metadata and content.
/// </summary>
public class ImportFile
{
    /// <summary>
    /// Gets or sets the name of the file. This field is required.
    /// </summary>
    /// <value>The file name.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the path to the file without the file name.
    /// </summary>
    /// <value>The file path, or <c>null</c> if not specified.</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Gets or sets the optional module specification.
    /// </summary>
    /// <value>The module name, or <c>null</c> if not specified.</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("module")]
    public string? Module { get; set; }

    /// <summary>
    /// Gets or sets the optional library specification.
    /// </summary>
    /// <value>The library name, or <c>null</c> if not specified.</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("library")]
    public string? Library { get; set; }

    /// <summary>
    /// Gets or sets the optional build type.
    /// </summary>
    /// <value>The build type, or <c>null</c> if not specified.</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("buildType")]
    public string? BuildType { get; set; }

    /// <summary>
    /// Gets or sets the optional product flavors.
    /// </summary>
    /// <value>A list of product flavors, or <c>null</c> if not specified.</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productFlavors")]
    public List<object>? ProductFlavors { get; set; }

    /// <summary>
    /// Gets or sets the content of the file - strings to be imported.
    /// </summary>
    /// <value>An <see cref="ImportContent"/> object containing the file content.</value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content")]
    public ImportContent Content { get; set; } = null!;
}

/// <summary>
/// Represents the content structure for importing strings and translations.
/// </summary>
public class ImportContent
{
    /// <summary>
    /// Gets or sets the name of the file format to be used to publish strings.
    /// See /import/formats for all options.
    /// </summary>
    /// <value>The file format type. Default is "api".</value>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "api";

    /// <summary>
    /// Gets or sets the plural type to be used for encoding plurals in the output file.
    /// Available options depend on the type. See /import/formats for details.
    /// </summary>
    /// <value>The plural type, or <c>null</c> if not specified.</value>
    [JsonPropertyName("plural")]
    public string? Plural { get; set; } 

    /// <summary>
    /// Gets or sets the defines how to encode string arrays. Available options depend on the type. See /import/formats for details.
    /// </summary>
    /// <value>The array encoding type, or <c>null</c> if not specified.</value>
    [JsonPropertyName("array")]
    public string? Array { get; set; } 

    /// <summary>
    /// Gets or sets the defines how to transform structured keys for formats into plain string ones for a format that dosn't support structured keys.
    /// Available options depend on the type. See /import/formats for details.
    /// </summary>
    /// <value>The key transformer, or <c>null</c> if not specified.</value>
    [JsonPropertyName("keyTransformer")]
    public string? KeyTransformer { get; set; } 

    /// <summary>
    /// Gets or sets the key-value map of additional parameters that may be necessary for array, plural and keyTransformer. See /import/formats for details.
    /// </summary>
    /// <value>A dictionary of additional parameters, or <c>null</c> if not specified.</value>
    [JsonPropertyName("params")]
    public Dictionary<string, string>? Params { get; set; }

    /// <summary>
    /// Gets or sets the list of additional features for the given type. Available options depend on the type. See Localazy CLI documentation for available formats and their features.
    /// </summary>
    /// <value>A list of feature strings, or <c>null</c> if not specified.</value>
    [JsonPropertyName("features")]
    public List<string>? Features { get; set; }

    /// <summary>
    /// Gets or sets the strings in the given language to be imported.
    /// </summary>
    /// <value>A dictionary representing the language object, or <c>null</c> if not specified.</value>
    [JsonExtensionData]
    public Dictionary<string, object> LanguageMap { get; set; } = null!;
    //public required Dictionary<string, ImportLanguage> LanguageMap { get; set; } = null!;
}

/// <summary>
/// Represents a language object containing messages for import.
/// </summary>
public class ImportLanguage
{
    /// <summary>
    /// Gets or sets the dictionary of messages for the language.
    /// </summary>
    /// <value>A dictionary where the key is the message identifier and the value is the message content.</value>
    [JsonExtensionData] public Dictionary<string, object> Messages { get; set; } = null!;
}