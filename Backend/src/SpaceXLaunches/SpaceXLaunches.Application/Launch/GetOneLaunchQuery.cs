using AutoMapper;
using MediatR;
using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Domain.Models;
using System.ComponentModel;

namespace SpaceXLaunches.Application.Queries;

public record GetOneLaunchQuery : IRequest<LaunchDto?>
{
    public GetOneLaunchQuery(int flightNumber)
    {
        FlightNumber = flightNumber;
    }
    [DefaultValue(1)]
    public int FlightNumber { get; init; } = 1;
}

public class GetOneLaunchQueryHandler : IRequestHandler<GetOneLaunchQuery, LaunchDto?>
{
    private readonly ILaunchService _launchService;

    public GetOneLaunchQueryHandler(ILaunchService launchService )
    {
        _launchService = launchService;
    }

    public async Task<LaunchDto?> Handle(GetOneLaunchQuery request, CancellationToken cancellationToken)
    {
        return await _launchService.GetOneLaunch(request.FlightNumber);
    }
}