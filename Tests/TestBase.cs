global using NUnit.Framework;
using Localazy;
using Localazy.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public abstract class TestBase
{
    public ServiceProvider ServiceProvider { get; private set; } = null!;
    public ILocalazyService LocalazyService { get; private set; } = null!;
    public ILocalazyFactory LocalazyFactory { get; private set; } = null!;

    [SetUp]
    public async Task Setup()
    {
        var apiKey = Environment.GetEnvironmentVariable("LOCALAZY_API_KEY");
        if (apiKey is null)
            throw new Exception("""
                No API key defined for tests
                Please define a LOCALAZY_API_KEY variable
                """);


        var services = new ServiceCollection()
            .AddLocalazySdk(apiKey)
            .BuildServiceProvider();

        ServiceProvider = services;
        LocalazyService = services.GetRequiredService<ILocalazyService>();
        LocalazyFactory = services.GetRequiredService<ILocalazyFactory>();

        await PostSetup();
    }

    protected virtual Task PostSetup()
    {
        return Task.CompletedTask;
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}