namespace Localazy.Model;

public class LocalazyException : Exception
{
    public int Code { get; }
    public string Error { get; }

    internal LocalazyException(LocalazyError error) : base(error.Message)
    {
        Code = error.Code;
        Error = error.Error;
    }
}