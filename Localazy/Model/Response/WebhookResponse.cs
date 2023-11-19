using System.Text.Json.Serialization;

namespace Localazy.Model.Response;

public class WebhookResponse
{
    [JsonPropertyName("items")] public List<WebhookItem> Items { get; set; } = null!;
}

public class WebhookItem
{
    /// <summary>
    /// Allows to enabled/disable the webhook.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Custom ID that is passed when the webhook is invoked. Empty by default.
    /// </summary>
    [JsonPropertyName("customId")]
    public string CustomId { get; set; } = null!;

    /// <summary>
    /// Description of the webhook. Empty by default.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// URL to be invoked on the webhook event.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    /// <summary>
    /// The list of event types to invoke this webhook for.
    /// </summary>
    [JsonPropertyName("events")]
    public List<string> Events { get; set; } = null!;
}