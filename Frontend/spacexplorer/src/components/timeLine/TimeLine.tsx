import { useEffect, useState } from 'react';
import spaceXplorerApi from '../../api/spaceXplorerApi';
import LaunchComponent from '../launch/Launch';
import { LaunchModel } from '../../models/LaunchModel';
import PaginatedListModel from '../../models/PaginatedListModel';
import { AxiosResponse } from 'axios';
import InfiniteScroll from 'react-infinite-scroll-component';
import LoadingComponent from '../loading/Loading';

const TimeLineComponent = () => {
  const [items, setItems] = useState([] as LaunchModel[]);
  const [pageNumber, setPageNumber] = useState(1);
  const [hasNextPage, setHasNextPage] = useState(true);

  useEffect(() => {
    getList();
  }, []);

  const getList = async () => {
    let response: any = await spaceXplorerApi.getLaunches(pageNumber, 10);
    setHasNextPage(response.hasNextPage);
    setItems([...items, ...response.items]);
    setPageNumber(pageNumber + 1);
  };

  const fetchMoreData = () => {
    getList();
  };

  return items?.length ? (
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
  ) : (
    <LoadingComponent />
  );
};

export default TimeLineComponent;
