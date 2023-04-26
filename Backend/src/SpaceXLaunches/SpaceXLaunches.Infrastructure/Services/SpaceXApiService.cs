using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.Domain.Models;
using SpaceXLaunches.Infrastructure.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpaceXLaunches.Infrastructure.Services
{
    public class SpaceXApiService : ILaunchService
    {
        private readonly HttpClient _apiClient;
        private readonly ILogger<SpaceXApiService> _logger;
        private readonly UrlsConfig _urls;
        private const string totalCountHeaderKey = "spacex-api-count";

        public SpaceXApiService(HttpClient apiClient, ILogger<SpaceXApiService> logger, IOptions<UrlsConfig> urls)
        {
            _apiClient = apiClient;
            _logger = logger;
            _urls = urls.Value;
        }

        public async Task<PaginatedList<Launch>> GetLaunches(GetAllLaunchesQuery query)
        {
            var uri = $"{_urls.SpaceXBaseUrl}{_urls.LaunchApi}?limit={query.PageSize}&offset={query.PageSize * (query.PageNumber - 1)}";

            var response = await _apiClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var launches = JsonSerializer.Deserialize<List<Launch>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            int.TryParse(response.Headers.GetValues(totalCountHeaderKey)?.FirstOrDefault(), out int totalCount);
            return new PaginatedList<Launch>(launches, totalCount, query.PageNumber, query.PageSize);
        }
    }
}