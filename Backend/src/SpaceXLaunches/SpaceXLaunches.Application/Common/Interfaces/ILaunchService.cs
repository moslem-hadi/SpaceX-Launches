using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXLaunches.Application.Common.Interfaces;

public interface ILaunchService
{
    Task<PaginatedList<Launch>> GetLaunches(GetAllLaunchesQuery query);

}