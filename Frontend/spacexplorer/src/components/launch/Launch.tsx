import { LaunchModel } from '../../models/LaunchModel';
import Moment from 'moment';
import YoutubeLinkComponent from './links/YoutubeLink';
import WikipediaLinkComponent from './links/WikipediaLink';
import DetailLinkComponent from './links/DetailLink';

type MyChildProps = {
  item: LaunchModel;
};
const LaunchComponent = ({ item }: MyChildProps) => {
  return (
    <div className="timeline-event">
      <div className="flight">
        <label className="timeline-event-icon"></label>
        <div className="timeline-event-copy">
          <p className="timeline-event-thumbnail">
            Flight: {item.flightNumber} |{' '}
            {Moment(item.launchDateUtc).format('YYYY MMM d')}
          </p>
          <h3>{item.missionName}</h3>
          <h4>
            {item.rocket?.rocketName} | {item.rocket?.rocketType}
          </h4>
          {item.launchSuccess ? (
            <span className="status success">Success</span>
          ) : (
            <>
              <span className="status failed">Failed</span>
              <span className="failed-reason">
                {item.launchFailureDetails?.reason}
              </span>
            </>
          )}

          {item.details ? (
            <p className="details">
              <strong>Details:</strong>
              <br />
              {item.details}
            </p>
          ) : (
            ''
          )}

          <div className="links">
            <DetailLinkComponent flightNumber={item.flightNumber} />
            <YoutubeLinkComponent link={item.links?.videoLink} />
            <WikipediaLinkComponent link={item.links?.wikipedia} />
          </div>
        </div>
      </div>
      <img
        className="flight-image"
        alt={item.missionName}
        src={item.mainImage}
      />
    </div>
  );
};
export default LaunchComponent;
