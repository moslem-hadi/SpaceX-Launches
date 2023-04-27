using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SpaceXLaunches.Application.Common;
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
    private readonly IMemoryCache _memoryCache;

    public GetOneLaunchQueryHandler(ILaunchService launchService, IMemoryCache memoryCache)
    {
        _launchService = launchService;
        _memoryCache = memoryCache;
    }

    public async Task<LaunchDto?> Handle(GetOneLaunchQuery request, CancellationToken cancellationToken)
    {

        if (!_memoryCache.TryGetValue(CacheKeys.SingleLaunch(request.FlightNumber), out LaunchDto? launchData))
        {
            launchData = await _launchService.GetOneLaunch(request.FlightNumber, cancellationToken);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));

            _memoryCache.Set(CacheKeys.SingleLaunch(request.FlightNumber), launchData, cacheEntryOptions);
        }

        return launchData;
    }
}
