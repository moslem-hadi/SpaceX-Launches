using Microsoft.Extensions.Configuration;
using Serilog;
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

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(); 
        services.AddControllers();
        services.Configure<UrlsConfig>(configuration.GetSection("Urls"));
        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices();
        
         
        return services;
    }

    public static void AddLogging(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
          .ReadFrom.Configuration(builder.Configuration)
          .Enrich.FromLogContext()
          .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
    }
}
