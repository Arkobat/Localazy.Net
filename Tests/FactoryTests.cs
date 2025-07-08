using Localazy.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class FactoryTests : TestBase
{
    [Test]
    public async Task CanLoadProjects()
    {
        var factory = ServiceProvider.GetRequiredService<ILocalazyFactory>();
        var apiKey = Environment.GetEnvironmentVariable("LOCALAZY_API_KEY");
        var service = factory.CreateService(apiKey!);
        var projects = await service.ListProjects();
        
        Assert.That(projects, Is.Not.Empty, "No projects found");
    }
}