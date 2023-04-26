import axiosClient from "./axiosClient";

const spaceXplorerApi = {
    getLaunches: (page:number, pageSize:number) => {
        const url = `launches?page=${page}&pageSize=${pageSize}`;
        return axiosClient.get(url);
    },
}

export default spaceXplorerApi;