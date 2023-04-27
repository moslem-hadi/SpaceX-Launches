import { LaunchModel } from '../models/LaunchModel';
import PaginatedListModel from '../models/PaginatedListModel';
import axiosClient from './axiosClient';

const spaceXplorerApi = {
  getLaunches: (page: number, pageSize: number) => {
    const url = `launches?page=${page}&pageSize=${pageSize}`;
    return axiosClient.get<PaginatedListModel<LaunchModel>>(url);
  },
};

export default spaceXplorerApi;
