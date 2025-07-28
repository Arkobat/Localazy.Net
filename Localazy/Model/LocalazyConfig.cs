namespace Localazy.Model;

/// <summary>
/// Configuration class for the Localazy SDK containing authentication and setup information.
/// </summary>
public class LocalazyConfig
{
    /// <summary>
    /// Gets or sets the API key used for authenticating requests to the Localazy API.
    /// </summary>
    /// <value>The API key string. Must not be null or empty.</value>
    public string ApiKey { get; set; } = null!;
}