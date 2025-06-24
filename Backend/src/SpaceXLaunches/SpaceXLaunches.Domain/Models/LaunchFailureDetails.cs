using System.Text.Json.Serialization;

namespace SpaceXLaunches.Domain.Models;

public class LaunchFailureDetails
{
    [JsonPropertyName("time")]
    public int Time { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}
