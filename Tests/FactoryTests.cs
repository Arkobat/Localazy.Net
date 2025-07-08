namespace Tests;

public class FactoryTests : TestBase
{
    [Test]
    public async Task CanLoadProjects()
    {
        var apiKey = Environment.GetEnvironmentVariable("LOCALAZY_API_KEY");
        var service = LocalazyFactory.CreateService(apiKey);
        var projects = await service.ListProjects();
        
        Assert.That(projects, Is.Not.Empty, "No projects found");
    }
}