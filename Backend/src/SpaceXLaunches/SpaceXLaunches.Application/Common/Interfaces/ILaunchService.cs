using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Dtos;
using SpaceXLaunches.Application.Queries;

namespace SpaceXLaunches.Application.Common.Interfaces;

public interface ILaunchService
{
    Task<PaginatedList<LaunchDto>> GetLaunches(GetAllLaunchesQuery query, CancellationToken cancellationToken);
    Task<LaunchDto?> GetOneLaunch(int flightNumber, CancellationToken cancellationToken);


    //This has to be inside another service/interface. but I'm not going to do it now!!
    Task<PaginatedList<RocketDto>> GetRockets(GetAllRocketsQuery query, CancellationToken cancellationToken);

}