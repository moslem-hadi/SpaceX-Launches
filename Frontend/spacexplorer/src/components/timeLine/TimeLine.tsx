import { useEffect, useState } from 'react';
import spaceXplorerApi from '../../api/spaceXplorerApi';
import LaunchComponent from '../launch/Launch';
import { LaunchModel } from '../../models/LaunchModel';
import PaginatedListModel from '../../models/PaginatedListModel';
import { AxiosResponse } from 'axios';

const TimeLineComponent = () => {
  const [items, setItems] = useState([] as LaunchModel[]);

  useEffect(() => {
    const getList = async () => {
      let response: any = await spaceXplorerApi.getLaunches(1, 10);

      setItems(response.items);
    };
    getList();
  }, []);

  return items?.length ? (
    <ul className="timeline">
      {items.map((item, i) => (
        <LaunchComponent key={i} item={item} />
      ))}
    </ul>
  ) : (
    <p>LOADING</p>
  );
};
export default TimeLineComponent;
