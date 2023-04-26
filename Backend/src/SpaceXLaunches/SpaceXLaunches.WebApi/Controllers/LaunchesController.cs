using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.Domain.Models;

namespace SpaceXLaunches.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchesController : ApiControllerBase
    {
        //TODO: Use DTO
        [HttpGet]
        public async Task<PaginatedList<Launch>> GetAll([FromQuery]GetAllLaunchesQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
