import { Rocket } from '../../models/LaunchModel';
type MyChildProps = {
  rocket: Rocket;
};
const RocketComponent = ({ rocket }: MyChildProps) => {
  return (
    <div className="rocket">
      <div className="card">
        <img src={rocket.flickrImages[0]} className="img" />

        <div className=" p-3 text-center mt-2">
          <h4>{rocket.rocketName}</h4>
          <p className="country">{rocket.country}</p>
        </div>
        <div className=" p-3 stats mt-2">
          <div className="d-flex justify-content-between">
            <span>Company</span>
            <span>{rocket.company}</span>
          </div>
          <div className="d-flex justify-content-between">
            <span>Cost per launch</span>
            <span>
              {rocket.costPerLaunch.toLocaleString('en-US', {
                style: 'currency',
                currency: 'USD',
                minimumFractionDigits: 0,
              })}
            </span>
          </div>
          <div className="d-flex justify-content-between">
            <span>Success rate</span>
            <span>{rocket.successRatePct}</span>
          </div>
        </div>
        <a className="wiki" href={rocket.wikipedia} target="_blank">
          Wikipedia
        </a>
      </div>
    </div>
  );
};
export default RocketComponent;
