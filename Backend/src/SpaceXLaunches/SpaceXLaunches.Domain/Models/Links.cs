using System.Text.Json.Serialization;

namespace SpaceXLaunches.Domain.Models;

public class Links
{
    [JsonPropertyName("mission_patch")]
    public string MissionPatch { get; set; }

    [JsonPropertyName("mission_patch_small")]
    public string MissionPatchSmall { get; set; }

    [JsonPropertyName("reddit_campaign")]
    public object RedditCampaign { get; set; }

    [JsonPropertyName("reddit_launch")]
    public object RedditLaunch { get; set; }

    [JsonPropertyName("reddit_recovery")]
    public object RedditRecovery { get; set; }

    [JsonPropertyName("reddit_media")]
    public object RedditMedia { get; set; }

    [JsonPropertyName("presskit")]
    public object Presskit { get; set; }

    [JsonPropertyName("article_link")]
    public string ArticleLink { get; set; }

    [JsonPropertyName("wikipedia")]
    public string Wikipedia { get; set; }

    [JsonPropertyName("video_link")]
    public string VideoLink { get; set; }

    [JsonPropertyName("youtube_id")]
    public string YoutubeId { get; set; }

    [JsonPropertyName("flickr_images")]
    public List<object> FlickrImages { get; set; }
}
