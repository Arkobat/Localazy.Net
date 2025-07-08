global using NUnit.Framework;
using Localazy;
using Localazy.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public abstract class TestBase
{
    protected ServiceProvider ServiceProvider { get; private set; } = null!;
    protected ILocalazyService LocalazyService { get; private set; } = null!;

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