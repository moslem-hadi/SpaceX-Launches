import { useEffect, useState } from 'react';
import spaceXplorerApi from '../../api/spaceXplorerApi';
import LaunchComponent from '../launch/Launch';
import { LaunchModel } from '../../models/LaunchModel';
import InfiniteScroll from 'react-infinite-scroll-component';
import LoadingComponent from '../loading/Loading';

import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const TimeLineComponent = () => {
  const [items, setItems] = useState([] as LaunchModel[]);
  const [pageNumber, setPageNumber] = useState(1);
  const [hasNextPage, setHasNextPage] = useState(true);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getList();
  }, []);

  const getList = async () => {
    try {
      let response: any = await spaceXplorerApi.getLaunches(pageNumber, 10);
      setHasNextPage(response.hasNextPage);
      setItems([...items, ...response.items]);
      setPageNumber(pageNumber + 1);
      setLoading(false);
    } catch {
      setLoading(false);
      errorHappened();
    }
  };

  const fetchMoreData = () => {
    try {
      getList();
    } catch {
      errorHappened();
    }
  };

  const errorHappened = () =>
    toast.error('Sorry :( An error occurred while loading the data.');

  return loading ? (
    <LoadingComponent />
  ) : (
    <InfiniteScroll
      dataLength={items.length}
      next={fetchMoreData}
      hasMore={hasNextPage}
      loader=<LoadingComponent />
    >
      <div className="timeline">
        {items.map((item, i) => (
          <LaunchComponent key={i} item={item} />
        ))}
      </div>
    </InfiniteScroll>
  );
};

export default TimeLineComponent;
