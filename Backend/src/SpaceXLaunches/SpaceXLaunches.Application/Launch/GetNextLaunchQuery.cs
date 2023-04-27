using Microsoft.Extensions.Caching.Memory;

namespace SpaceXLaunches.Application.Queries;

public record GetNextLaunchQuery : IRequest<LaunchDto?>
{
}

public class GetNextLaunchQueryHandler : IRequestHandler<GetNextLaunchQuery, LaunchDto?>
{
    private const int cacheExpirationMinutes = 1;
    private readonly ILaunchService _launchService;
    private readonly IMemoryCache _memoryCache;

    public GetNextLaunchQueryHandler(ILaunchService launchService, IMemoryCache memoryCache)
    {
        _launchService = launchService;
        _memoryCache = memoryCache;
    }

    public async Task<LaunchDto?> Handle(GetNextLaunchQuery request, CancellationToken cancellationToken)
    {

        if (!_memoryCache.TryGetValue(CacheKeys.NextLaunch, out LaunchDto? launchData))
        {
            launchData = await _launchService.GetNextLaunch(cancellationToken);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes));

            _memoryCache.Set(CacheKeys.NextLaunch, launchData, cacheEntryOptions);
        }

        return launchData;
    }
}
