namespace SpaceXLaunches.WebApi.Controllers;

public class LaunchesController : ApiControllerBase
{
    private ISender Mediator;
    public LaunchesController(ISender mediator)
    {
        Mediator = mediator;
    }
    [HttpGet]
    public async Task<PaginatedList<LaunchDto>> GetAll([FromQuery] GetAllLaunchesQuery query, CancellationToken cancellationToken)
    {
        return await Mediator.Send(query, cancellationToken);
    }

    [HttpGet("{flightNumber}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LaunchDto>> GetByFlightNumber(int flightNumber, CancellationToken cancellationToken)
    {
        var launch = await Mediator.Send(new GetOneLaunchQuery(flightNumber), cancellationToken);
        if (launch is null)
            return NotFound();

        return Ok(launch);
    }

    [HttpGet("Next")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LaunchDto>> GetNextLaunch(CancellationToken cancellationToken)
    {
        var launch = await Mediator.Send(new GetNextLaunchQuery(), cancellationToken);
        if (launch is null)
            return NotFound();
        return Ok(launch);
    }
}
