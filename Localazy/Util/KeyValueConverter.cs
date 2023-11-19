using System.Text.Json;
using System.Text.Json.Serialization;
using Localazy.Model.Response;

namespace Localazy.Util;

public class KeyValueConverter : JsonConverter<KeyValue>
{
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