using Microsoft.Extensions.Configuration;
using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Infrastructure.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ILaunchService, SpaceXApiService>();
        return services;
    }
}
