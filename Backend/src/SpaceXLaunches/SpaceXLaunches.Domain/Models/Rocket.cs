using System.Text.Json.Serialization;

namespace SpaceXLaunches.Domain.Models;

public class Rocket
{
    [JsonPropertyName("rocket_id")]
    public string RocketId { get; set; }

    [JsonPropertyName("rocket_name")]
    public string RocketName { get; set; }

    [JsonPropertyName("rocket_type")]
    public string RocketType { get; set; }
}