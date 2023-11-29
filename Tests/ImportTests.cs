using Localazy.Model.Request;
using Localazy.Model.Response;

namespace Tests;

public class ImportTests : TestBase
{
    private Project _project = null!;
    private const string FileName = "testFile.json";

    protected override async Task PostSetup()
    {
        _project = (await LocalazyService.ListProjects()).Single();
    }

    [Test]
    public async Task CanListFileTypes()
    {
        var availableFileTypes = await LocalazyService.ListAvailableFileTypes();
        Assert.That(availableFileTypes, Has.Count.GreaterThanOrEqualTo(30));

        var jsonType = availableFileTypes.FirstOrDefault(t => t.Name == "JSON");
        Assert.That(jsonType, Is.Not.Null);
    }

    [Test]
    public async Task ValidateImport()
    {
        var files = await LocalazyService.ListFilesInProject(_project.Id);
        Assert.That(files.Count(f => f.Name == FileName), Is.EqualTo(0));

        await TestImport();
        await TestUpdate();
        await TestDelete();
    }

    private async Task TestImport()
    {
        await ImportToProject("en", ("greeting.hello", "Hello World!"), ("greeting.goodbye", "Goodbye World!"));

        await Task.Delay(TimeSpan.FromSeconds(1));
        var files = await LocalazyService.ListFilesInProject(_project.Id);
        Assert.That(files.Count(f => f.Name == FileName), Is.EqualTo(1));
        var file = files.Single(f => f.Name == FileName);
        var fileId = file.Id;

        var fileContent = await LocalazyService.ListFileContent(_project.Id, fileId, "en");
        Assert.That(fileContent.Keys, Has.Count.EqualTo(2));

        var message = fileContent.Keys.First();
        Assert.Multiple(() =>
        {
            Assert.That(message.Key, Has.Count.EqualTo(1));
            Assert.That(message.Key.Single(), Is.EqualTo("greeting.hello"));
            Assert.That(message.Value.SingleValue(), Is.EqualTo("Hello World!"));
        });

        message = fileContent.Keys.Skip(1).First();
        Assert.Multiple(() =>
        {
            Assert.That(message.Key, Has.Count.EqualTo(1));
            Assert.That(message.Key.Single(), Is.EqualTo("greeting.goodbye"));
            Assert.That(message.Value.SingleValue(), Is.EqualTo("Goodbye World!"));
        });
    }

    private async Task ImportToProject(string language, params (string, string)[] values)
    {
        await LocalazyService.ImportContentToProject(_project.Id, new ImportContentRequest
        {
            Files = new List<ImportFile>()
            {
                new()
                {
                    Name = FileName,
                    Content = new ImportContent()
                    {
                        LanguageMap = new Dictionary<string, object>
                        {
                            {
                                language, new ImportLanguage()
                                {
                                    Messages = new Dictionary<string, object>(values.ToDictionary(
                                        k => k.Item1,
                                        v => v.Item2 as object)
                                    )
                                }
                            }
                        }
                    }
                }
            }
        });
    }

    private async Task TestUpdate()
    {
        const string key = "greeting.hello";
        var files = await LocalazyService.ListFilesInProject(_project.Id);
        var file = files.Single(f => f.Name == FileName);
        var fileContent = await LocalazyService.ListFileContent(_project.Id, file.Id, "en");

        var oldKey = fileContent.Keys.Single(message => message.Key.Single() == key);
        Assert.Multiple(() =>
        {
            Assert.That(oldKey.Key, Has.Count.EqualTo(1));
            Assert.That(oldKey.Key.Single(), Is.EqualTo("greeting.hello"));
            Assert.That(oldKey.Value.SingleValue(), Is.EqualTo("Hello World!"));
        });

        await ImportToProject("en", (key, "Good day World!"));
        fileContent = await LocalazyService.ListFileContent(_project.Id, file.Id, "en");
        var updatedKey = fileContent.Keys.Single(message => message.Key.Single() == key);

        Assert.Multiple(() =>
        {
            Assert.That(updatedKey.Key, Has.Count.EqualTo(1));
            Assert.That(updatedKey.Key.Single(), Is.EqualTo(key));
            Assert.That(updatedKey.Value.SingleValue(), Is.EqualTo("Good day World!"));
        });
    }

    private async Task TestDelete()
    {
    }

    /// <summary>
    /// If there for some reason is a test file left behind after test, this should remove it.
    /// This will enforce a test only can fail once, with that being the reason.
    /// </summary>
    [TearDown]
    public async Task CleanupTestFile()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        var files = await LocalazyService.ListFilesInProject(_project.Id);
        var file = files.SingleOrDefault(f => f.Name == FileName);
        if (file is null) return;
        var fileContent = await LocalazyService.ListFileContent(_project.Id, file.Id, "en");

        foreach (var message in fileContent.Keys)
        {
            await LocalazyService.DeleteSourceKey(_project.Id, message.Id);
        }
    }
}