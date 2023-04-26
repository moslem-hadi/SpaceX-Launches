using AutoMapper;
using MediatR;
using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Domain.Models;

namespace SpaceXLaunches.Application.Queries;

public record GetAllLaunchesQuery : IRequest<PaginatedList<Launch>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetAllLaunchesQueryHandler : IRequestHandler<GetAllLaunchesQuery, PaginatedList<Launch>>
{
    private readonly ILaunchService _launchService;
    private readonly IMapper _mapper;

    public GetAllLaunchesQueryHandler(ILaunchService launchService, IMapper mapper)
    {
        _launchService = launchService;
        _mapper = mapper;
    }

    public async Task<PaginatedList<Launch>> Handle(GetAllLaunchesQuery request, CancellationToken cancellationToken)
    {
        return await _launchService.GetLaunches(request);
    }
}