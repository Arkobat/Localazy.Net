using System.Text.Json;
using System.Text.Json.Serialization;
using Localazy.Model.Response;

namespace Localazy.Util;

/// <summary>
/// JSON converter for handling different types of key values (single, multi, and keyed values) in Localazy responses.
/// </summary>
public class KeyValueConverter : JsonConverter<KeyValue>
{
    /// <summary>
    /// Reads and converts JSON to a <see cref="KeyValue"/> object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">The type to convert to.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>A <see cref="KeyValue"/> object representing the JSON data.</returns>
    /// <exception cref="NotImplementedException">Thrown when object type conversion is not yet implemented.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when an unsupported JSON token type is encountered.</exception>
    public override KeyValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String) return new SingleKeyValue {Value = reader.GetString()!};

        if (reader.TokenType == JsonTokenType.StartArray)
        {
            var values = new List<string>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray) break;
                values.Add(reader.GetString()!);
            }

            return new MultiKeyValue {Value = values};
        }

        if (reader.TokenType == JsonTokenType.StartObject) throw new NotImplementedException();


        throw new ArgumentOutOfRangeException(nameof(reader.TokenType));
    }

    /// <summary>
    /// Writes a <see cref="KeyValue"/> object to JSON.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The <see cref="KeyValue"/> to serialize.</param>
    /// <param name="options">The serializer options.</param>
    /// <exception cref="NotImplementedException">Thrown as this method is not yet implemented.</exception>
    public override void Write(Utf8JsonWriter writer, KeyValue value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case SingleKeyValue skv:
                JsonSerializer.Serialize(writer, skv, options);
                break;
            case MultiKeyValue mkv:
                JsonSerializer.Serialize(writer, mkv, options);
                break;
            case KeyedKeyValue kkv:
                JsonSerializer.Serialize(writer, kkv, options);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}