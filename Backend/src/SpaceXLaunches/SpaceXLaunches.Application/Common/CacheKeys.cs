namespace SpaceXLaunches.Application.Common;

internal static class CacheKeys
{
    public const string Launches = "Launches";
    public const string NextLaunch = "NextLaunch";
    public static string SingleLaunch(int flightNumber) => $"SingleLaunch-{flightNumber}";
}