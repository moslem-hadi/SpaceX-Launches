export interface LaunchModel {
  flightNumber: number;
  missionName: string;
  launchYear: string;
  launchDateUnix: number;
  launchDateUtc: string;
  launchDateLocal: string;
  rocket: Rocket;
  launchSite: LaunchSite;
  launchSuccess: boolean;
  launchFailureDetails: LaunchFailureDetails;
  links: Links;
  details: string;
  upcoming: boolean;
  mainImage: string;
}

export interface Rocket {
  rocketId: string;
  rocketName: string;
  rocketType: string;
}

export interface LaunchSite {
  siteId: string;
  siteName: string;
  siteNameLong: string;
}

export interface LaunchFailureDetails {
  time: number;
  reason: string;
}

export interface Links {
  missionPatch: string;
  missionPatchSmall: string;
  redditCampaign: string;
  redditLaunch: string;
  redditRecovery: string;
  redditMedia: string;
  presskit: string;
  articleLink: string;
  wikipedia: string;
  videoLink: string;
  youtubeId: string;
  flickrImages: string[];
}
