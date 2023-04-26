using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXLaunches.Infrastructure.Services
{
    public class SpaceXApiService : ILaunchService
    {
        public Task<PaginatedList<Launch>> GetLaunches(GetAllLaunchesQuery query)
        {
            throw new NotImplementedException();
        }
    }
}