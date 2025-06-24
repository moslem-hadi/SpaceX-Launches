namespace SpaceXLaunches.Application.Queries;

public record GetAllLaunchesQuery : PagedQuery, IRequest<PaginatedList<LaunchDto>>
{
}

public class GetAllLaunchesQueryHandler : IRequestHandler<GetAllLaunchesQuery, PaginatedList<LaunchDto>>
{
    private readonly ILaunchService _launchService;

    public GetAllLaunchesQueryHandler(ILaunchService launchService )
    {
        _launchService = launchService;
    }

    public async Task<PaginatedList<LaunchDto>> Handle(GetAllLaunchesQuery request, CancellationToken cancellationToken)
    {
        return await _launchService.GetLaunchesAsync(request, cancellationToken);
    }
}