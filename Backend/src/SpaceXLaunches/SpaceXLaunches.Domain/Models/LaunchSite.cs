using System.Text.Json.Serialization;

namespace SpaceXLaunches.Domain.Models;

public class LaunchSite
{
    [JsonPropertyName("site_id")]
    public string? SiteId { get; set; }

    [JsonPropertyName("site_name")]
    public string? SiteName { get; set; }

    [JsonPropertyName("site_name_long")]
    public string? SiteNameLong { get; set; }
}
