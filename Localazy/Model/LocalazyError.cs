using System.Text.Json.Serialization;

namespace Localazy.Model;

/// <summary>
/// Represents an error response from the Localazy API.
/// </summary>
internal class LocalazyError
{
    /// <summary>
    /// Gets or sets a value indicating whether the API operation was successful.
    /// </summary>
    /// <value><c>true</c> if the operation was successful; otherwise, <c>false</c>.</value>
    [JsonPropertyName("success")] public bool Success { get; set; }
    
    /// <summary>
    /// Gets or sets the error code returned by the API.
    /// </summary>
    /// <value>The numeric error code.</value>
    [JsonPropertyName("code")] public int Code { get; set; }
    
    /// <summary>
    /// Gets or sets the human-readable error message.
    /// </summary>
    /// <value>The error message string.</value>
    [JsonPropertyName("message")] public string Message { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the error type or category.
    /// </summary>
    /// <value>The error type string.</value>
    [JsonPropertyName("error")] public string Error { get; set; } = null!;
}