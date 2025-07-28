namespace Localazy.Service;

/// <summary>
/// Factory interface for creating instances of <see cref="ILocalazyService"/>.
/// </summary>
public interface ILocalazyFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="ILocalazyService"/> with the specified API key.
    /// </summary>
    /// <param name="apiKey">The Localazy API key for authentication.</param>
    /// <returns>A new instance of <see cref="ILocalazyService"/> configured with the provided API key.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="apiKey"/> is null or empty.</exception>
    ILocalazyService CreateService(string apiKey);
}