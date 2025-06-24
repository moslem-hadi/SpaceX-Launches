using SpaceXLaunches.Application.Queries;

namespace SpaceXLaunches.Application.Common.Interfaces;

public interface ILaunchService
{
    Task<PaginatedList<LaunchDto>> GetLaunchesAsync(GetAllLaunchesQuery query, CancellationToken cancellationToken);
    Task<LaunchDto?> GetOneLaunchAsync(int flightNumber, CancellationToken cancellationToken);
    Task<LaunchDto?> GetNextLaunchAsync(CancellationToken cancellationToken);
    Task<PaginatedList<RocketDto>> GetRocketsAsync(GetAllRocketsQuery query, CancellationToken cancellationToken);

}