namespace SpaceXLaunches.WebApi.Controllers;

public class RocketsController : ApiControllerBase
{
    [HttpGet]
    public async Task<PaginatedList<RocketDto>> GetAll([FromQuery] GetAllRocketsQuery query, CancellationToken cancellationToken)
    {
        return await Mediator.Send(query, cancellationToken);
    }
     
}
