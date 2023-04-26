using System.Text.Json.Serialization;

namespace SpaceXLaunches.Domain.Models;

//Version 3 model
public class Launch
{
    [JsonPropertyName("flight_number")]
    public int FlightNumber { get; set; }

    [JsonPropertyName("mission_name")]
    public string MissionName { get; set; }


    [JsonPropertyName("launch_year")]
    public string LaunchYear { get; set; }

    [JsonPropertyName("launch_date_unix")]
    public int LaunchDateUnix { get; set; }

    [JsonPropertyName("launch_date_utc")]
    public DateTime LaunchDateUtc { get; set; }

    [JsonPropertyName("launch_date_local")]
    public DateTime LaunchDateLocal { get; set; }

    [JsonPropertyName("rocket")]
    public Rocket Rocket { get; set; }

    [JsonPropertyName("launch_site")]
    public LaunchSite LaunchSite { get; set; }

    [JsonPropertyName("launch_success")]
    public bool LaunchSuccess { get; set; }

    [JsonPropertyName("launch_failure_details")]
    public LaunchFailureDetails LaunchFailureDetails { get; set; }

    [JsonPropertyName("links")]
    public Links Links { get; set; }

    [JsonPropertyName("details")]
    public string Details { get; set; }

    [JsonPropertyName("upcoming")]
    public bool Upcoming { get; set; }

    [JsonPropertyName("crew")]
    public object Crew { get; set; }
}
public class LaunchFailureDetails
{
    [JsonPropertyName("time")]
    public int Time { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }
}

public class LaunchSite
{
    [JsonPropertyName("site_id")]
    public string SiteId { get; set; }

    [JsonPropertyName("site_name")]
    public string SiteName { get; set; }

    [JsonPropertyName("site_name_long")]
    public string SiteNameLong { get; set; }
}

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
public class Rocket
{
    [JsonPropertyName("rocket_id")]
    public string RocketId { get; set; }

    [JsonPropertyName("rocket_name")]
    public string RocketName { get; set; }

    [JsonPropertyName("rocket_type")]
    public string RocketType { get; set; }
}