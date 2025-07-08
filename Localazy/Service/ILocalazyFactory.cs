namespace Localazy.Service;

public interface ILocalazyFactory
{
    ILocalazyService CreateService(string apiKey);
}