namespace Tests;

public class ProjectsTests : TestBase
{

    [Test]
    public async Task CanFindSdkProject()
    {
        var projects = await LocalazyService.ListProjects();
        
        Assert.That(projects, Has.Count.EqualTo(1));

        var project = projects.Single();
        Assert.That(project.Name, Is.EqualTo("C#-SDK"));
        Assert.That(project.Organization, Is.Null);
        Assert.That(project.Languages, Is.Null);
    }
    
    [Test]
    public async Task CanLoadOrganization()
    {
        var projects = await LocalazyService.ListProjects(organization: true);
        var project = projects.Single();
        
        Assert.That(project.Name, Is.EqualTo("C#-SDK"));
        Assert.That(project.Organization, Is.Not.Null);
        Assert.That(project.Languages, Is.Null);
    }
    
    [Test]
    public async Task CanLoadLanguages()
    {
        var projects = await LocalazyService.ListProjects(languages: true);
        var project = projects.Single();
        
        Assert.That(project.Name, Is.EqualTo("C#-SDK"));
        Assert.That(project.Organization, Is.Null);
        Assert.That(project.Languages, Is.Not.Null);
    }
}