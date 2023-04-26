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

        public SpaceXApiService(HttpClient apiClient, ILogger<SpaceXApiService> logger, IOptions<UrlsConfig> urls)
        {
            _apiClient = apiClient;
            _logger = logger;
            _urls = urls.Value;
        }

        public async Task<PaginatedList<Launch>> GetLaunches(GetAllLaunchesQuery query)
        {
            var uri = _urls.SpaceXBaseUrl + _urls.LaunchApi;
            var response = await _apiClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var ordersDraftResponse = await response.Content.ReadAsStringAsync();

            var launches = JsonSerializer.Deserialize<List<Launch>>(ordersDraftResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return new PaginatedList<Launch>(launches, 0, 0, 0);
        }
    }
}