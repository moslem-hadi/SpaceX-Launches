using AutoMapper;
using MediatR;
using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Domain.Models;
using System.ComponentModel;

namespace SpaceXLaunches.Application.Queries;

public record GetAllLaunchesQuery : IRequest<PaginatedList<LaunchDto>>
{
    [DefaultValue(1)]
    public int PageNumber { get; init; } = 1;

    [DefaultValue(10)]
    public int PageSize { get; init; } = 10;
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
        return await _launchService.GetLaunches(request);
    }
}