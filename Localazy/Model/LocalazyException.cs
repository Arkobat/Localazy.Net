namespace Localazy.Model;

/// <summary>
/// Represents errors that occur during Localazy API operations.
/// </summary>
public class LocalazyException : Exception
{
    /// <summary>
    /// Gets the error code returned by the Localazy API.
    /// </summary>
    /// <value>The numeric error code.</value>
    public int Code { get; }
    
    /// <summary>
    /// Gets the error type or category returned by the Localazy API.
    /// </summary>
    /// <value>The error type string.</value>
    public string Error { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocalazyException"/> class with error details from the API.
    /// </summary>
    /// <param name="error">The <see cref="LocalazyError"/> containing the error details from the API response.</param>
    internal LocalazyException(LocalazyError error) : base(error.Message)
    {
        Code = error.Code;
        Error = error.Error;
    }
}