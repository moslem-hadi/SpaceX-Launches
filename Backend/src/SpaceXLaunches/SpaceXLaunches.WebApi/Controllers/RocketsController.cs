namespace SpaceXLaunches.WebApi.Controllers;

public class RocketsController : ApiControllerBase
{

    private ISender? Mediator;

    public RocketsController(ISender? mediator)
    {
        Mediator = mediator;
    }
    [HttpGet]
    public async Task<PaginatedList<RocketDto>> GetAll([FromQuery] GetAllRocketsQuery query, CancellationToken cancellationToken)
    {
        return await Mediator.Send(query, cancellationToken);
    }
     
}
