using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Queries;

namespace SpaceXLaunches.Application.Common.Interfaces;

public interface ILaunchService
{
    Task<PaginatedList<LaunchDto>> GetLaunches(GetAllLaunchesQuery query, CancellationToken cancellationToken);
    Task<LaunchDto?> GetOneLaunch(int flightNumber, CancellationToken cancellationToken);

}