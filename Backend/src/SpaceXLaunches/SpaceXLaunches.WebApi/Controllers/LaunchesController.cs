using Microsoft.AspNetCore.Mvc;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.Domain.Models;

namespace SpaceXLaunches.WebApi.Controllers;

public class LaunchesController : ApiControllerBase
{
    //TODO: Use DTO instead of Domain models
    [HttpGet]
    public async Task<PaginatedList<LaunchDto>> GetAll([FromQuery]GetAllLaunchesQuery query)
    {
        return await Mediator.Send(query);
    }
}
