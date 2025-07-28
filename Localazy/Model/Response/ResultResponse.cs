using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

/// <summary>
/// Generic response wrapper containing a result of type T.
/// </summary>
/// <typeparam name="T">The type of the result.</typeparam>
public class ResultResponse<T>
{
    /// <summary>
    /// Gets or sets the result value.
    /// </summary>
    [JsonPropertyName("result")] public T Id { get; set; } = default!;
}