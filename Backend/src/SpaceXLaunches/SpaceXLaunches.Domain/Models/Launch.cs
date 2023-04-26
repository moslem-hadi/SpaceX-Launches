using System.Text.Json.Serialization;

namespace SpaceXLaunches.Domain.Models;

//Version 3 model
//ToDo: convert to record
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

}
