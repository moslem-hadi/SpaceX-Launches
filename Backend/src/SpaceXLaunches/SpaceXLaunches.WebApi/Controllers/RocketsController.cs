namespace SpaceXLaunches.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RocketsController : ControllerBase
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
