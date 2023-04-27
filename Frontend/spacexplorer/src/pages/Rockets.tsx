import { useEffect, useState } from 'react';
import { LaunchModel, Rocket } from '../models/LaunchModel';
import { toast } from 'react-toastify';
import spaceXplorerApi from '../api/spaceXplorerApi';
import { useParams } from 'react-router-dom';
import LoadingComponent from '../components/loading/Loading';
import YoutubeLinkComponent from '../components/launch/links/YoutubeLink';
import WikipediaLinkComponent from '../components/launch/links/WikipediaLink';
import Moment from 'moment';

const RocketsPage = (props: any) => {
  const [rockets, setRockets] = useState([] as Rocket[]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    getRockets();
  }, []);

  const getRockets = async () => {
    try {
      setLoading(true);
      let response: any = await spaceXplorerApi.getRockets(1, 100);
      setRockets(response.items);
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
      <h1 className="flight-title"> Rockets </h1>
      <div className="rockets">
        {rockets.map((rocket, i) => (
          <div className="rocket" key={i}>
            <div className="card">
              <img src={rocket.flickrImages[0]} className="img" />

              <div className=" p-3 text-center mt-2">
                <h4>{rocket.rocketName}</h4>
                <p className="mt-0 text-black-50">{rocket.country}</p>
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
        ))}
      </div>
    </div>
  );
};

export default RocketsPage;
