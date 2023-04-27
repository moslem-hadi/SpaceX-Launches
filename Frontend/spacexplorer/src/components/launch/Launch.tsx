import { LaunchModel } from '../../models/LaunchModel';

type MyChildProps = {
  item: LaunchModel;
};
const LaunchComponent = ({ item }: MyChildProps) => {
  return (
    <li className="timeline-event">
      <div>
        <label className="timeline-event-icon"></label>
        <div className="timeline-event-copy">
          <p className="timeline-event-thumbnail">
            {item.flightNumber} - FalconSat
          </p>
          <h3>{item.missionName}</h3>
          <h4>merlin engine failure</h4>
          <p>
            <strong>Details</strong>
            <br />
            Engine failure at 33 seconds and loss of vehicle
          </p>
        </div>
      </div>
      <img className="flight-image" alt="..." src={item.mainImage} />
    </li>
  );
};
export default LaunchComponent;
