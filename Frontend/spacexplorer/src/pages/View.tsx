import { useEffect, useState } from 'react';
import { LaunchModel } from '../models/LaunchModel';
import { toast } from 'react-toastify';
import spaceXplorerApi from '../api/spaceXplorerApi';
import { useParams } from 'react-router-dom';
import LoadingComponent from '../components/loading/Loading';
import YoutubeLinkComponent from '../components/launch/links/YoutubeLink';
import WikipediaLinkComponent from '../components/launch/links/WikipediaLink';
import Moment from 'moment';

const ViewPage = (props: any) => {
  const [launch, setLaunchModel] = useState({} as LaunchModel);
  const [loading, setLoading] = useState(false);
  const flightNumber = useParams().flightNumber as string;

  useEffect(() => {
    getLaunch();
  }, []);

  const getLaunch = async () => {
    try {
      setLoading(true);
      let response: any = await spaceXplorerApi.getLaunch(
        parseInt(flightNumber)
      );
      setLaunchModel(response);
    } catch {
      toast.error('Sorry :( An error occurred while loading the data.');
    } finally {
      setLoading(false);
    }
  };

  return loading ? (
    <LoadingComponent />
  ) : (
    <div className="container">
      <h1 className="flight-title"> Flight: {launch.flightNumber} </h1>

      <div className="timeline-event">
        <div className="flight">
          <label className="timeline-event-icon"></label>
          <div className="timeline-event-copy">
            <p className="timeline-event-thumbnail">
              {Moment(launch.launchDateUtc).format('YYYY MMM d')}
            </p>
            <h3>{launch.missionName}</h3>
            <h4>
              {launch.rocket?.rocketName} | {launch.rocket?.rocketType}
            </h4>
            {launch.launchSuccess ? (
              <span className="status success">Success</span>
            ) : (
              <>
                <span className="status failed">Failed</span>
                <span className="failed-reason">
                  {launch.launchFailureDetails?.reason}
                </span>
              </>
            )}

            {launch.details ? (
              <p className="details">
                <strong>Details:</strong>
                <br />
                {launch.details}
              </p>
            ) : (
              ''
            )}

            <div className="links">
              <YoutubeLinkComponent link={launch.links?.videoLink} />
              <WikipediaLinkComponent link={launch.links?.wikipedia} />
            </div>
          </div>
        </div>
        <img
          className="flight-image"
          alt={launch.missionName}
          src={launch.mainImage}
        />
      </div>
    </div>
  );
};

export default ViewPage;
