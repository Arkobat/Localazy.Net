using Localazy.Model.Request;
using Localazy.Model.Response;

namespace Localazy.Service;

internal class LocalazyService : ILocalazyService
{
    private readonly HttpWrapper _httpWrapper;

    public LocalazyService(HttpWrapper httpWrapper)
    {
        _httpWrapper = httpWrapper;
    }

    #region Projects

    public async Task<List<Project>> ListProjects(bool organization = false, bool languages = false)
    {
        return await _httpWrapper
            .GetRequest("projects")
            .AddQueryParameter(nameof(organization), organization.ToString())
            .AddQueryParameter(nameof(languages), languages.ToString())
            .Get<List<Project>>();
    }

    public async Task<CreateProjectResponse> CreateProject(CreateProjectRequest request)
    {
        return await _httpWrapper
            .GetRequest("projects")
            .Post<CreateProjectResponse>(request);
    }

    #endregion

    #region Import

    public async Task<ResultResponse<string>> ImportContentToProject(string projectId, ImportContentRequest request)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/import")
            .Post<ResultResponse<string>>(request);
    }

    public async Task<List<FileType>> ListAvailableFileTypes()
    {
        return await _httpWrapper
            .GetRequest("import/formats")
            .Get<List<FileType>>();
    }

    #endregion

    #region Files

    public async Task<List<ProjectFile>> ListFilesInProject(string projectId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/files")
            .Get<List<ProjectFile>>();
    }

    public async Task<FileContent> ListFileContent(string projectId, string fileId, string languageCode,
        bool deprecated = true, int limit = 1000, string? next = null, bool extraInfo = true, bool noContent = true)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/files/{fileId}/keys/{languageCode}")
            .AddQueryParameter(nameof(deprecated), deprecated.ToString())
            .AddQueryParameter(nameof(limit), limit.ToString())
            .AddOptionalQueryParameter(nameof(next), next)
            .AddQueryParameter(nameof(extraInfo), extraInfo.ToString())
            .AddQueryParameter(nameof(noContent), noContent.ToString())
            .Get<FileContent>();
    }

    public async Task<Stream> DownloadFile(string projectId, string fileId, string language)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/files/{fileId}/keys/{language}")
            .GetStream();
    }

    #endregion

    #region Source Keys

    public async Task<ResultResponse<bool>> DeleteSourceKey(string projectId, string keyId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/keys/{keyId}")
            .Delete<ResultResponse<bool>>();
    }

    public async Task<ResultResponse<bool>> UpdateSourceKey(string projectId, string keyId,
        UpdateSourceKeyRequest request)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/keys/{keyId}")
            .Put<ResultResponse<bool>>(request);
    }

    #endregion

    #region Duplicates

    public async Task<LinkResponse> ListLinks(string projectId, int limit = 1000, string? next = null)
    {
        return await _httpWrapper
            .GetRequest($"/projects/{projectId}/links")
            .AddQueryParameter(nameof(limit), limit.ToString())
            .AddOptionalQueryParameter(nameof(next), next)
            .Get<LinkResponse>();
    }

    public async Task<ResultResponse<bool>> CreateLinks(string projectId, string keyId, CreateLinkRequest request)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/links/{keyId}")
            .Post<ResultResponse<bool>>(request);
    }

    public async Task<ResultResponse<bool>> RemoveLinks(string projectId, string keyId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/links/{keyId}")
            .Delete<ResultResponse<bool>>();
    }

    #endregion

    #region Glosasry

    public async Task<List<GlossaryResponse>> ListAllGlossaryItems(string projectId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/glossary")
            .Get<List<GlossaryResponse>>();
    }

    public async Task<Glossary> GetGlossaryItem(string projectId, string id)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/glossary/{id}")
            .Get<Glossary>();
    }

    public async Task<ResultResponse<bool>> DeleteGlossaryItem(string projectId, string id)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/glossary/{id}")
            .Delete<ResultResponse<bool>>();
    }

    public async Task<ResultResponse<string>> CreateGlossaryItem(string projectId, Glossary request)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/glossary")
            .Post<ResultResponse<string>>(request);
    }

    public async Task<ResultResponse<bool>> UpdateGlossaryItem(string projectId, string id, Glossary request)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/glossary/{id}")
            .Put<ResultResponse<bool>>(request);
    }

    #endregion

    #region Webhooks

    public async Task<WebhookResponse> ListWebhooksConfiguration(string projectId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/webhooks")
            .Get<WebhookResponse>();
    }

    public async Task<ResultResponse<bool>> UpdateWebhooksConfiguration(string projectId, WebhookResponse request)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/webhooks")
            .Post<ResultResponse<bool>>(request);
    }

    #endregion

    #region Screenshots

    public async Task<List<ScreenshotResponse>> ListScreenshots(string projectId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/screenshots")
            .Get<List<ScreenshotResponse>>();
    }

    public async Task<List<string>> ListScreenshotsTags(string projectId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/screenshots/tags")
            .Get<List<string>>();
    }

    public async Task<ResultResponse<string>> CreateScreenshotFromFile(string projectId, string filePath)
    {
        var imageBytes = await File.ReadAllBytesAsync(filePath);
        var base64String = Convert.ToBase64String(imageBytes);

        return await _httpWrapper
            .GetRequest($"projects/{projectId}/screenshots")
            .PostRaw<ResultResponse<string>>(base64String);
    }

    public async Task<ResultResponse<string>> CreateScreenshotFromStream(string projectId, Stream image)
    {
        using var memoryStream = new MemoryStream();
        await image.CopyToAsync(memoryStream);
        var bytes = memoryStream.ToArray();
        var base64String = Convert.ToBase64String(bytes);

        return await _httpWrapper
            .GetRequest($"projects/{projectId}/screenshots")
            .PostRaw<ResultResponse<string>>(base64String);
    }

    public async Task<ResultResponse<bool>> UpdateScreenshotFromFile(string projectId, string screenshotId,
        string filePath)
    {
        var imageBytes = await File.ReadAllBytesAsync(filePath);
        var base64String = Convert.ToBase64String(imageBytes);

        return await _httpWrapper
            .GetRequest($"projects/{projectId}/screenshots")
            .PostRaw<ResultResponse<bool>>(base64String);
    }

    public async Task<ResultResponse<bool>> UpdateScreenshotFromStream(string projectId, string screenshotId,
        Stream image)
    {
        using var memoryStream = new MemoryStream();
        await image.CopyToAsync(memoryStream);
        var bytes = memoryStream.ToArray();
        var base64String = Convert.ToBase64String(bytes);

        return await _httpWrapper
            .GetRequest($"projects/{projectId}/screenshots")
            .PostRaw<ResultResponse<bool>>(base64String);
    }

    public async Task<ResultResponse<bool>> UpdateScreenshotMetadata(string projectId, string screenshotId,
        UpdateMetadataRequest request)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/screenshots/{screenshotId}")
            .Put<ResultResponse<bool>>(request);
    }

    public async Task<ResultResponse<bool>> DeleteScreenshot(string projectId, string screenshotId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/screenshots/{screenshotId}")
            .Delete<ResultResponse<bool>>();
    }

    #endregion

    #region CDN

    public async Task<MetadataResponse> ListMetadataFiles(string projectId)
    {
        return await _httpWrapper
            .GetRequest($"projects/{projectId}/cdn")
            .Get<MetadataResponse>();
    }

    #endregion
}