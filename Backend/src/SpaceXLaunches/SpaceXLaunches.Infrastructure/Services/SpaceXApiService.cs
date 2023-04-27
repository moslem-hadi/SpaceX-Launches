using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly.Retry;
using Polly;
using SpaceXLaunches.Application.Common.Exceptions;
using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.Domain.Models;
using SpaceXLaunches.Infrastructure.Configs;
using System.Text.Json;
using SpaceXLaunches.Application.Dtos;

namespace SpaceXLaunches.Infrastructure.Services
{
    public class SpaceXApiService : ILaunchService
    {
        private const int httpClientTimeoutSeconds = 5;
        private const string totalCountHeaderKey = "spacex-api-count";

        private readonly HttpClient _apiClient;
        private readonly ILogger<SpaceXApiService> _logger;
        private readonly UrlsConfig _urls;
        private readonly IMapper _mapper;

        public SpaceXApiService(HttpClient apiClient, ILogger<SpaceXApiService> logger, IOptions<UrlsConfig> urls, IMapper mapper)
        {
            _apiClient = apiClient;
            _logger = logger;
            _urls = urls.Value;
            _mapper = mapper;
            _apiClient.Timeout = TimeSpan.FromSeconds(httpClientTimeoutSeconds);
        }

        public async Task<PaginatedList<LaunchDto>> GetLaunches(GetAllLaunchesQuery query, CancellationToken cancellationToken)
        {
            int totalCount = 0;
            var result = new List<LaunchDto>();
            await CreatePolicy().ExecuteAsync(async () =>
            {
                var uri = $"{_urls.SpaceXBaseUrl}{_urls.LaunchApi}?limit={query.PageSize}&offset={query.PageSize * (query.PageNumber - 1)}";
                var response = await _apiClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var launches = JsonSerializer.Deserialize<List<Launch>>(responseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                int.TryParse(response.Headers.GetValues(totalCountHeaderKey)?.FirstOrDefault(), out totalCount);
                result = _mapper.Map<List<LaunchDto>>(launches);
            });
            return new PaginatedList<LaunchDto>(result, totalCount, query.PageNumber, query.PageSize);
        }

        public async Task<LaunchDto?> GetOneLaunch(int flightNumber, CancellationToken cancellationToken)
        {
            try
            {
                var uri = $"{_urls.SpaceXBaseUrl}{_urls.LaunchApi}/{flightNumber}";
                var response = await _apiClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();

                var launch = JsonSerializer.Deserialize<Launch>(responseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return _mapper.Map<LaunchDto>(launch);
            }
            catch(Exception ex ) when (ex.Message.Contains("404"))
            {
                throw new NotFoundException();
            }
            catch
            {
                throw new AppException();
            }
        }

        public async Task<PaginatedList<RocketDto>> GetRockets(GetAllRocketsQuery query, CancellationToken cancellationToken)
        {
            int totalCount = 0;
            var result = new List<RocketDto>();
            await CreatePolicy().ExecuteAsync(async () =>
            {
                var uri = $"{_urls.SpaceXBaseUrl}{_urls.RocketApi}?limit={query.PageSize}&offset={query.PageSize * (query.PageNumber - 1)}";
                var response = await _apiClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var launches = JsonSerializer.Deserialize<List<Rocket>>(responseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                int.TryParse(response.Headers.GetValues(totalCountHeaderKey)?.FirstOrDefault(), out totalCount);
                result = _mapper.Map<List<RocketDto>>(launches);
            });
            return new PaginatedList<RocketDto>(result, totalCount, query.PageNumber, query.PageSize);

        }

        private AsyncRetryPolicy CreatePolicy(int retries = 3)
        {
            return Policy.Handle<Exception>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(2),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        _logger.LogWarning(exception, "Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }
    }
}