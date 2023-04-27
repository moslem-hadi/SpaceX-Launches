import { useEffect, useState } from 'react';
import { LaunchModel, Rocket } from '../models/LaunchModel';
import { toast } from 'react-toastify';
import spaceXplorerApi from '../api/spaceXplorerApi';
import { useParams } from 'react-router-dom';
import LoadingComponent from '../components/loading/Loading';
import YoutubeLinkComponent from '../components/launch/links/YoutubeLink';
import WikipediaLinkComponent from '../components/launch/links/WikipediaLink';
import Moment from 'moment';
import RocketComponent from '../components/rockets/Rocket';

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
          <RocketComponent key={i} rocket={rocket} />
        ))}
      </div>
    </div>
  );
};

export default RocketsPage;
