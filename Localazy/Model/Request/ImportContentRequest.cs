using System.Text.Json.Serialization;

namespace Localazy.Model.Request;

public class ImportContentRequest
{
    /// <summary>
    /// Import all translations to go through the review process. Useful when you are unsure about their quality and want to do an extra check.
    /// </summary>
    [JsonPropertyName("importAsNew")]
    public bool ImportAsNew { get; set; }

    /// <summary>
    /// Import all translations and set them as the current version. By default, Localazy doesn’t overwrite existing current translations and lets you decide through the review process.
    /// </summary>
    [JsonPropertyName("forceCurrent")]
    public bool ForceCurrent { get; set; }

    /// <summary>
    /// Do not import translations that are the same as the source language content.
    /// </summary>
    [JsonPropertyName("filterSource")]
    public bool FilterSource { get; set; } = true;

    /// <summary>
    /// Overwrite the source language even if there are some changes in Localazy. Useful for workflows where source of truth is outside the platform.
    /// </summary>
    [JsonPropertyName("forceSource")]
    public bool ForceSource { get; set; }

    /// <summary>
    /// The structure of files and strings to be imported. See <see cref="ImportFile"/>.
    /// </summary>
    [JsonPropertyName("files")]
    public required List<ImportFile> Files { get; set; } = null!;
}

public class ImportFile
{
    /// <summary>
    /// The file name is required.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; } = null!;

    /// <summary>
    /// The path to the file without the file name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Optional module specification.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("module")]
    public string? Module { get; set; }


    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("library")]
    public string? Library { get; set; }

    /// <summary>
    /// Optional build type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("buildType")]
    public string? BuildType { get; set; }

    /// <summary>
    /// Optional product flavors.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productFlavors")]
    public List<object>? ProductFlavors { get; set; }

    /// <summary>
    /// Content of the file - strings to be imported. See <see cref="ImportContent"/>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content")]
    public ImportContent Content { get; set; } = null!;
}

public class ImportContent
{
    /// <summary>
    /// Name of the file format to be used to publish strings.
    /// See /import/formats for all options.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "api";

    /// <summary>
    /// Plural type to be used for encoding plurals in the output file.
    /// Available options depend on the type. See /import/formats below.
    /// </summary>
    [JsonPropertyName("plural")]
    public string? Plural { get; set; } 

    /// <summary>
    /// Defines how to encode string arrays. Available options depend on the type. See /import/formats below.
    /// </summary>
    [JsonPropertyName("array")]
    public string? Array { get; set; } 

    /// <summary>
    /// Defines how to transform structured keys for formats into plain string ones for a format that dosn't support structured keys.
    /// Available options depend on the type. See /import/formats below.
    /// </summary>
    [JsonPropertyName("keyTransformer")]
    public string? KeyTransformer { get; set; } 

    /// <summary>
    /// Key-value map of additional parameters that may be necessary for array, plural and keyTransformer. See /import/formats below.
    /// </summary>
    [JsonPropertyName("params")]
    public Dictionary<string, string>? Params { get; set; }

    /// <summary>
    /// 	List of additional features for the given type. Available options depend on the type. See Localazy CLI documentation for available formats and their features.
    /// </summary>
    [JsonPropertyName("features")]
    public List<string>? Features { get; set; }

    /// <summary>
    /// Strings in the given language to be imported. See “Language Object” below.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object> LanguageMap { get; set; } = null!;
    //public required Dictionary<string, ImportLanguage> LanguageMap { get; set; } = null!;
}

public class ImportLanguage
{
    [JsonExtensionData] public Dictionary<string, object> Messages { get; set; } = null!;
}