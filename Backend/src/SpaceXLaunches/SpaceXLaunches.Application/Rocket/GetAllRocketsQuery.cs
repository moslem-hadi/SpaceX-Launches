namespace SpaceXLaunches.Application.Queries;

public record GetAllRocketsQuery : PagedQuery, IRequest<PaginatedList<RocketDto>>
{
}

public class GetAllRocketsQueryHandler : IRequestHandler<GetAllRocketsQuery, PaginatedList<RocketDto>>
{
    private readonly ILaunchService _launchService;
    public GetAllRocketsQueryHandler(ILaunchService launchService)
    {
        _launchService = launchService;
    }
    public async Task<PaginatedList<RocketDto>> Handle(GetAllRocketsQuery request, CancellationToken cancellationToken)
    {
        return await _launchService.GetRocketsAsync(request, cancellationToken);
    }
}