using Microsoft.Extensions.Configuration;
using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Infrastructure.Configs;
using SpaceXLaunches.Infrastructure.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        return services;
    }
}
