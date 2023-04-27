using System.Text.Json.Serialization;

namespace SpaceXLaunches.Domain.Models;

public class Rocket
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("rocket_id")]
    public string RocketId { get; set; }

    [JsonPropertyName("rocket_name")]
    public string RocketName { get; set; }

    [JsonPropertyName("rocket_type")]
    public string RocketType { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("cost_per_launch")]
    public int CostPerLaunch { get; set; }

    [JsonPropertyName("success_rate_pct")]
    public int SuccessRatePct { get; set; }

    [JsonPropertyName("first_flight")]
    public string FirstFlight { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    [JsonPropertyName("flickr_images")]
    public List<string> FlickrImages { get; set; }

    [JsonPropertyName("wikipedia")]
    public string Wikipedia { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}