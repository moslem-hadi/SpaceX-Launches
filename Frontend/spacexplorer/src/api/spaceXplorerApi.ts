import { LaunchModel } from '../models/LaunchModel';
import PaginatedListModel from '../models/PaginatedListModel';
import axiosClient from './axiosClient';

const spaceXplorerApi = {
  getLaunches: (page: number, pageSize: number) => {
    const url = `launches?pageNumber=${page}&pageSize=${pageSize}`;
    return axiosClient.get<PaginatedListModel<LaunchModel>>(url);
  },

  getLaunch: (flightNumber: number) => {
    const url = `launches/${flightNumber}`;
    return axiosClient.get<LaunchModel>(url);
  },
};

export default spaceXplorerApi;
