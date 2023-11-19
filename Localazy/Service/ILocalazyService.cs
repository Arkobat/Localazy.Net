using Localazy.Model.Request;
using Localazy.Model.Response;

namespace Localazy.Service;

public interface ILocalazyService
{
    #region Projects

    /// <summary>
    /// List projects accessible with the current token scope.
    /// </summary>
    /// <param name="organization">Add information about the owning organization.</param>
    /// <param name="languages">Add information about languages.</param>
    /// <returns><see cref="CreateProjectResponse"/></returns>
    public Task<List<Project>> ListProjects(bool organization = false, bool languages = false);

    /// <summary>
    /// Creates a new project inside the given organization.
    /// </summary>
    /// <param name="request"><see cref="CreateProjectRequest"/></param>
    /// <returns>Returns ID of the newly created project.</returns>
    public Task<CreateProjectResponse> CreateProject(CreateProjectRequest request);

    #endregion

    #region Import

    /// <summary>
    /// Import any supported file format to the selected project including the translations.
    /// </summary>
    /// <param name="projectId">{projectId} - Your project id or slug. Use the value from projects endpoint</param>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<ResultResponse<string>> ImportContentToProject(string projectId, ImportContentRequest request);

    /// <summary>
    /// Returns a list of available file types for importing strings, including their parameters.
    /// </summary>
    /// <returns></returns>
    public Task<List<FileType>> ListAvailableFileTypes();

    #endregion

    #region Files

    /// <summary>
    /// Returns list of files in the project with all available parameters.
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <returns></returns>
    public Task<List<ProjectFile>> ListFilesInProject(string projectId);

    /// <summary>
    /// Returns a list of keys and their translations in language {lang} from file {fileId}.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="fileId"></param>
    /// <param name="languageCode">Locale code must be in the format: ll-Scrp-RR.</param>
    /// <param name="deprecated">Include also deprecated keys.</param>
    /// <param name="limit">Number of keys to be returned in a single call (max 1000). Default 1000.</param>
    /// <param name="next">Return next page. Used for paging large data.</param>
    /// <param name="extraInfo">Return additional information about keys including hidden,limit,depecated and comment attributes.</param>
    /// <param name="noContent">Do not return the actual content/translation of the key.</param>
    /// <returns></returns>
    public Task<FileContent> ListFileContent(string projectId, string fileId, string languageCode,
        bool deprecated = true, int limit = 1000, string? next = null, bool extraInfo = true, bool noContent = true);

    /// <summary>
    /// Download the selected file {fileId} in a language {language}.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="fileId"></param>
    /// <param name="language"></param>
    /// <returns></returns>
    public Task<Stream> DownloadFile(string projectId, string fileId, string language);

    #endregion

    #region Source Keys

    /// <summary>
    /// Remove source key from a project.
    /// </summary>
    /// <param name="projectId">Your project id or slug. Use the value from projects endpoint.</param>
    /// <param name="keyId">ID of the key you’d like to remove.</param>
    /// <returns></returns>
    public Task<ResultResponse<bool>> DeleteSourceKey(string projectId, string keyId);

    /// <summary>
    /// Update source key properties (one of hidden, deprecated, character limit and comment for translators) for a key.
    /// </summary>
    /// <param name="projectId">Your project id or slug. Use the value from projects endpoint.</param>
    /// <param name="keyId">ID of the key you’d like to modify.</param>
    /// <param name="request"><see cref="UpdateSourceKeyRequest"/></param>
    /// <returns></returns>
    public Task<ResultResponse<bool>> UpdateSourceKey(string projectId, string keyId, UpdateSourceKeyRequest request);

    #endregion

    #region Duplicates

    /// <summary>
    /// Lists all existing links.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="limit">Number of links to be returned in a single call (max 1000). Default 1000.</param>
    /// <param name="next">Used for paging long lists.</param>
    /// <returns></returns>
    public Task<LinkResponse> ListLinks(string projectId, int limit = 1000, string? next = null);

    /// <summary>
    /// Create a new link from keyId to the key specified in the request body.
    /// It’s not possible to create a link to a key that is already linked to another one.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="keyId">Id of the target key.</param>
    /// <param name="request"><see cref="CreateLinkRequest"/></param>
    /// <returns></returns>
    public Task<ResultResponse<bool>> CreateLinks(string projectId, string keyId, CreateLinkRequest request);

    /// <summary>
    /// Remove the link for keyId if it exists.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="keyId">Id of the target key.</param>
    /// <returns></returns>
    public Task<ResultResponse<bool>> RemoveLinks(string projectId, string keyId);

    #endregion

    #region Glossary

    /// <summary>
    /// Returns all glossary terms for the given project.
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <returns></returns>
    public Task<List<GlossaryResponse>> ListAllGlossaryItems(string projectId);

    /// <summary>
    /// Retrieve a single glossary term for the given project specified by {id}.
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Glossary> GetGlossaryItem(string projectId, string id);

    /// <summary>
    /// Delete a glossary term specified by {id}.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ResultResponse<bool>> DeleteGlossaryItem(string projectId, string id);

    /// <summary>
    /// Adds a new term to glossary. There is a limit of 1000 glossary term per project.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<ResultResponse<string>> CreateGlossaryItem(string projectId, Glossary request);

    /// <summary>
    /// Update a glossary term specified by {id}.
    /// </summary>
    /// <param name="projectId"></param>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<ResultResponse<bool>> UpdateGlossaryItem(string projectId, string id, Glossary request);

    #endregion

    #region Webhooks

    /// <summary>
    /// Returns the webhooks configuration for the given project.
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <returns></returns>
    public Task<WebhookResponse> ListWebhooksConfiguration(string projectId);

    /// <summary>
    /// Store a new webhooks configuration for the project.
    /// <list type="bullet">
    ///   <listheader><description>Limitations</description></listheader>
    ///   <item><description>There can be max. 30 webhooks per project.</description></item>
    ///   <item><description>URL can be max. 1024 chars long.</description></item>
    ///   <item><description>There can be max. of 50 events per webhook.</description></item>
    ///   <item><description>Event can be max. 32 chars long.</description></item>
    /// </list>
    /// </summary>
    /// <param name="projectId">You can use project’s id or slug as {projectId}.</param>
    /// <param name="request"><see cref="WebhookResponse"/></param>
    /// <returns></returns>
    public Task<ResultResponse<bool>> UpdateWebhooksConfiguration(string projectId, WebhookResponse request);

    #endregion

    #region Screenshots

    /// <summary>
    /// Lists all screenshots in the project.
    /// </summary>
    /// <param name="projectId"></param>
    /// <returns></returns>
    public Task<List<ScreenshotResponse>> ListScreenshots(string projectId);

    /// <summary>
    /// Lists an array of all tags for the given project.
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <returns></returns>
    public Task<List<string>> ListScreenshotsTags(string projectId);

    /// <summary>
    /// Upload a new screenshot for the given project.
    /// <list type="bullet">
    ///   <listheader><description>Limitations</description></listheader>
    ///   <item><description>JPEG or PNG images are supported</description></item>
    ///   <item><description>The image must be larger or equal to 36x36</description></item>
    ///   <item><description>The image must be smaller or equal to 4096x4096</description></item>
    ///   <item><description>The image must be smaller than 5 MB</description></item>
    /// </list>
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <param name="filePath"></param>
    /// <returns>Identifier of the newly created screenshot.</returns>
    public Task<ResultResponse<string>> CreateScreenshotFromFile(string projectId, string filePath);

    /// <summary>
    /// <inheritdoc cref="CreateScreenshotFromFile"/>
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <param name="image"></param>
    /// <returns><inheritdoc cref="CreateScreenshotFromFile"/></returns>
    public Task<ResultResponse<string>> CreateScreenshotFromStream(string projectId, Stream image);

    /// <summary>
    /// <inheritdoc cref="CreateScreenshotFromFile"/>
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <param name="screenshotId"></param>
    /// <param name="filePath"></param>
    /// <returns>Success status of operation</returns>
    public Task<ResultResponse<bool>> UpdateScreenshotFromFile(string projectId, string screenshotId, string filePath);

    /// <summary>
    /// <inheritdoc cref="UpdateScreenshotFromFile"/>
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <param name="screenshotId"></param>
    /// <param name="image"></param>
    /// <returns><inheritdoc cref="UpdateScreenshotFromFile"/></returns>
    public Task<ResultResponse<bool>> UpdateScreenshotFromStream(string projectId, string screenshotId, Stream image);

    /// <summary>
    /// Change data of an existing screenshot for the given project.
    /// All fields are optional; if omitted, the corresponding property is not changed.
    /// Comment length is limited to 500 characters. If longer, only the first 500 characters are stored.
    /// Tag length is limited to 64 characters. If longer, it’s filtered out and not stored.
    /// Metadata key length is limited to 64 characters. If longer, it’s filtered out and not stored.
    /// Metadata value length is limited to 8k characters. If longer, it’s filtered out and not stored.
    /// Operated phrases must be from the same project.
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <param name="screenshotId">The id of the target screenshot</param>
    /// <param name="request">The metadata you wish to update</param>
    /// <returns>Success status of operation</returns>
    public Task<ResultResponse<bool>> UpdateScreenshotMetadata(string projectId, string screenshotId,
        UpdateMetadataRequest request);

    /// <summary>
    /// Delete a screenshot for the given project.
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <param name="screenshotId"></param>
    /// <returns>Success status of operation</returns>
    public Task<ResultResponse<bool>> DeleteScreenshot(string projectId, string screenshotId);

    #endregion

    #region CDN

    /// <summary>
    /// Returns metadata files for each of the published release tags available in the project.
    /// Download the metadata file to learn about the content available on CDN, supported languages, plural rules etc.
    /// </summary>
    /// <param name="projectId">Your project Id. Use the value from projects endpoint</param>
    /// <returns></returns>
    public Task<MetadataResponse> ListMetadataFiles(string projectId);

    #endregion
}