using System.Text.Json.Serialization;
using Localazy.Util;

namespace Localazy.Model.Response;

/// <summary>
/// Represents the content of a file with its keys and translations in a specific language.
/// </summary>
public class FileContent
{
    /// <summary>
    /// Gets or sets the array of keys contained in the file for the given language.
    /// </summary>
    /// <value>A list of <see cref="FileKey"/> objects representing the translation keys.</value>
    [JsonPropertyName("keys")]
    public List<FileKey> Keys { get; set; } = null!;

    /// <summary>
    /// Gets or sets the paging key for retrieving the next page of results.
    /// This field is not present if there are no more pages.
    /// </summary>
    /// <value>The paging token for the next page, or <c>null</c> if this is the last page.</value>
    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

/// <summary>
/// Represents a translation key with its metadata and content.
/// </summary>
public class FileKey
{
    /// <summary>
    /// Gets or sets the unique identifier of the key in Localazy.
    /// </summary>
    /// <value>The unique key identifier.</value>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the array of key components. 
    /// For nested keys it contains the separate levels. For simple string keys it contains just one item.
    /// </summary>
    /// <value>A list of key component strings representing the key path.</value>
    [JsonPropertyName("key")]
    public List<string> Key { get; set; } = null!;

    /// <summary>
    /// Value represents the translation. It can be either string, array or object for plurals.
    /// </summary>
    [JsonPropertyName("value")]
    [JsonConverter(typeof(KeyValueConverter))]
    public KeyValue Value { get; set; } = null!;

    /// <summary>
    /// Unique identifier of the current version of the translation.
    /// It can be used to determine whether the translation has changed from the last time.
    /// Useful for two-way synchronization.
    /// </summary>
    [JsonPropertyName("vid")]
    public long? Vid { get; set; }

    /// <summary>
    /// Whether the string is hidden from translation interface. (enabled by extra_info param)
    /// </summary>
    [JsonPropertyName("hidden")]
    public bool? Hidden { get; set; }

    /// <summary>
    /// Whether the string is deprecated. (enabled by extra_info param)
    /// </summary>
    [JsonPropertyName("deprecated")]
    public int? Deprecated { get; set; }

    /// <summary>
    /// Translation length limit for this key. (enabled by extra_info param)
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Translation note for context. (enabled by extra_info param)
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; } = null!;

    /// <summary>
    /// Returns the dotted key path for the FileKey instance, 
    /// which is a string representation of the key components joined by dots.
    /// </summary>
    /// <returns>A string representing the dotted key path.</returns>
    public string DottedKeyPath()
    {
        return string.Join(".", Key);
    }
}

/// <summary>
/// Abstract base class for representing different types of key values.
/// </summary>
public abstract class KeyValue
{
    /// <summary>
    /// Gets the single string value. Override in derived classes that support single values.
    /// </summary>
    /// <returns>The single string value.</returns>
    /// <exception cref="InvalidCastException">Thrown when the key value type doesn't support single values.</exception>
    public virtual string SingleValue()
    {
        throw new InvalidCastException();
    }

    /// <summary>
    /// Gets the multiple string values. Override in derived classes that support multiple values.
    /// </summary>
    /// <returns>The list of string values.</returns>
    /// <exception cref="InvalidCastException">Thrown when the key value type doesn't support multiple values.</exception>
    public virtual List<string> MultiValue()
    {
        throw new InvalidCastException();
    }

    /// <summary>
    /// Gets the key-value dictionary. Override in derived classes that support keyed values.
    /// </summary>
    /// <returns>The dictionary of key-value pairs.</returns>
    /// <exception cref="InvalidCastException">Thrown when the key value type doesn't support keyed values.</exception>
    public virtual Dictionary<string, string> KeyedValue()
    {
        throw new InvalidCastException();
    }
}

/// <summary>
/// Represents a key value that contains a single string value.
/// </summary>
public class SingleKeyValue : KeyValue
{
    /// <summary>
    /// Gets or sets the single string value.
    /// </summary>
    [JsonPropertyName("value")] public string Value { get; set; } = null!;

    /// <summary>
    /// Gets the single string value.
    /// </summary>
    /// <returns>The single string value.</returns>
    public override string SingleValue()
    {
        return Value;
    }
}

/// <summary>
/// Represents a key value that contains multiple string values.
/// </summary>
public class MultiKeyValue : KeyValue
{
    /// <summary>
    /// Gets or sets the list of string values.
    /// </summary>
    [JsonPropertyName("value")] public List<string> Value { get; set; } = null!;

    /// <summary>
    /// Gets the multiple string values.
    /// </summary>
    /// <returns>The list of string values.</returns>
    public override List<string> MultiValue()
    {
        return Value;
    }
}

/// <summary>
/// Represents a key value that contains a dictionary of key-value pairs.
/// </summary>
public class KeyedKeyValue : KeyValue
{
    /// <summary>
    /// Gets or sets the dictionary of key-value pairs.
    /// </summary>
    [JsonPropertyName("value")] public Dictionary<string, string> Value { get; set; } = null!;

    /// <summary>
    /// Gets the key-value dictionary.
    /// </summary>
    /// <returns>The dictionary of key-value pairs.</returns>
    public override Dictionary<string, string> KeyedValue()
    {
        return Value;
    }
}