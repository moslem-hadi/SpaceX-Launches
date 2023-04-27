using SpaceXLaunches.Application.Common.Mappings;
using SpaceXLaunches.Domain.Models; 

namespace SpaceXLaunches.Application.Queries;
public class LaunchDto : IMapFrom<Launch>
{
    public int FlightNumber { get; set; }

    public string MissionName { get; set; }

    public string LaunchYear { get; set; }

    public int LaunchDateUnix { get; set; }

    public DateTime LaunchDateUtc { get; set; }

    public DateTime LaunchDateLocal { get; set; }

    public RocketDto Rocket { get; set; }

    public LaunchSiteDto LaunchSite { get; set; }

    public bool? LaunchSuccess { get; set; }

    public LaunchFailureDetailsDto LaunchFailureDetails { get; set; }

    public LinksDto Links { get; set; }

    public string Details { get; set; }

    public bool? Upcoming { get; set; }

    public string? MainImage => Links?.MissionPatchSmall;

}
public class LaunchFailureDetailsDto: IMapFrom<LaunchFailureDetails>
{
    public int Time { get; set; }

    public string Reason { get; set; }
}
public class LaunchSiteDto:IMapFrom<LaunchSite>
{
    public string SiteId { get; set; }

    public string SiteName { get; set; }

    public string SiteNameLong { get; set; }
}

public class LinksDto:IMapFrom<Links>
{
    public string MissionPatch { get; set; }

    public string MissionPatchSmall { get; set; }

    public object RedditCampaign { get; set; }

    public object RedditLaunch { get; set; }

    public object RedditRecovery { get; set; }

    public object RedditMedia { get; set; }

    public object Presskit { get; set; }

    public string ArticleLink { get; set; }

    public string Wikipedia { get; set; }

    public string VideoLink { get; set; }

    public string YoutubeId { get; set; }

    public List<object> FlickrImages { get; set; }
}
public class RocketDto: IMapFrom<Rocket>
{
    public string RocketId { get; set; }

    public string RocketName { get; set; }

    public string RocketType { get; set; }
}