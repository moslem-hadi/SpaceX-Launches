using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXLaunches.Domain.Models
{
    public class Launch
    {
        public int FlightNumber { get; set; }
        public string MissionName { get; set; }
        public List<object> MissionId { get; set; }
        public bool Upcoming { get; set; }
        public string LaunchYear { get; set; }
        public int LaunchDateUnix { get; set; }
        public DateTime LaunchDateUtc { get; set; }
        public DateTime LaunchDateLocal { get; set; }
        public bool IsTentative { get; set; }
        public string TentativeMaxPrecision { get; set; }
        public bool Tbd { get; set; }
        public int LaunchWindow { get; set; }
        public Rocket Rocket { get; set; }
        public List<object> Ships { get; set; }
        public Telemetry Telemetry { get; set; }
        public LaunchSite LaunchSite { get; set; }
        public bool LaunchSuccess { get; set; }
        public LaunchFailureDetails LaunchFailureDetails { get; set; }
        public Links Links { get; set; }
        public string Details { get; set; }
        public DateTime StaticFireDateUtc { get; set; }
        public int StaticFireDateUnix { get; set; }
        public Timeline Timeline { get; set; }
        public object Crew { get; set; }
    }

    public class Core
    {
        public string CoreSerial { get; set; }
        public int Flight { get; set; }
        public object Block { get; set; }
        public bool Gridfins { get; set; }
        public bool Legs { get; set; }
        public bool Reused { get; set; }
        public object LandSuccess { get; set; }
        public bool LandingIntent { get; set; }
        public object LandingType { get; set; }
        public object LandingVehicle { get; set; }
    }

    public class Fairings
    {
        public bool Reused { get; set; }
        public bool RecoveryAttempt { get; set; }
        public bool Recovered { get; set; }
        public object Ship { get; set; }
    }

    public class FirstStage
    {
        public List<Core> Cores { get; set; }
    }

    public class LaunchFailureDetails
    {
        public int Time { get; set; }
        public object Altitude { get; set; }
        public string Reason { get; set; }
    }

    public class LaunchSite
    {
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteNameLong { get; set; }
    }

    public class Links
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

    public class OrbitParams
    {
        public string ReferenceSystem { get; set; }
        public string Regime { get; set; }
        public object Longitude { get; set; }
        public object SemiMajorAxisKm { get; set; }
        public object Eccentricity { get; set; }
        public int PeriapsisKm { get; set; }
        public int ApoapsisKm { get; set; }
        public int InclinationDeg { get; set; }
        public object PeriodMin { get; set; }
        public object LifespanYears { get; set; }
        public object Epoch { get; set; }
        public object MeanMotion { get; set; }
        public object Raan { get; set; }
        public object ArgOfPericenter { get; set; }
        public object MeanAnomaly { get; set; }
    }

    public class Payload
    {
        public string PayloadId { get; set; }
        public List<object> NoradId { get; set; }
        public bool Reused { get; set; }
        public List<string> Customers { get; set; }
        public string Nationality { get; set; }
        public string Manufacturer { get; set; }
        public string PayloadType { get; set; }
        public int PayloadMassKg { get; set; }
        public int PayloadMassLbs { get; set; }
        public string Orbit { get; set; }
        public OrbitParams OrbitParams { get; set; }
    }

    public class Rocket
    {
        public string RocketId { get; set; }
        public string RocketName { get; set; }
        public string RocketType { get; set; }
        public FirstStage FirstStage { get; set; }
        public SecondStage SecondStage { get; set; }
        public Fairings Fairings { get; set; }
    }
    public class SecondStage
    {
        public int Block { get; set; }
        public List<Payload> Payloads { get; set; }
    }

    public class Telemetry
    {
        public object FlightClub { get; set; }
    }

    public class Timeline
    {
        public int WebcastLiftoff { get; set; }
    }



}