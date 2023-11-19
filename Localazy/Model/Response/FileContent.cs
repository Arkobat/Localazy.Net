using System.Text.Json.Serialization;
using Localazy.Util;

namespace Localazy.Model.Response;

public class FileContent
{
    /// <summary>
    /// Array of keys contained in the file in given language. See “Key Object” below.
    /// </summary>
    [JsonPropertyName("keys")]
    public List<FileKey> Keys { get; set; } = null!;

    /// <summary>
    /// Next is the paging key. The field is not contained if there are no more pages.
    /// </summary>
    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class FileKey
{
    /// <summary>
    /// Unique Id of the key in Localazy.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// Aray of key components. For nested keys it contains the separate levels. For simple string keys it contains just one item.
    /// </summary>
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

    public string DottedKeyPath()
    {
        return string.Join(".", Key);
    }
}

public abstract class KeyValue
{
    public virtual string SingleValue()
    {
        throw new InvalidCastException();
    }

    public virtual List<string> MultiValue()
    {
        throw new InvalidCastException();
    }

    public virtual Dictionary<string, string> KeyedValue()
    {
        throw new InvalidCastException();
    }
}

public class SingleKeyValue : KeyValue
{
    [JsonPropertyName("value")] public string Value { get; set; } = null!;

    public override string SingleValue()
    {
        return Value;
    }
}

public class MultiKeyValue : KeyValue
{
    [JsonPropertyName("value")] public List<string> Value { get; set; } = null!;

    public override List<string> MultiValue()
    {
        return Value;
    }
}

public class KeyedKeyValue : KeyValue
{
    [JsonPropertyName("value")] public Dictionary<string, string> Value { get; set; } = null!;

    public override Dictionary<string, string> KeyedValue()
    {
        return Value;
    }
}