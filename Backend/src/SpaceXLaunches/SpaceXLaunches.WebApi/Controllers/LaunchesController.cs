﻿using Microsoft.AspNetCore.Mvc;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.Domain.Models;

namespace SpaceXLaunches.WebApi.Controllers;

public class LaunchesController : ApiControllerBase
{
    [HttpGet]
    public async Task<PaginatedList<LaunchDto>> GetAll([FromQuery] GetAllLaunchesQuery query, CancellationToken cancellationToken)
    {
        return await Mediator.Send(query, cancellationToken);
    }

    [HttpGet("{flightNumber}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaunchDto>> GetByFlightNumber(int flightNumber, CancellationToken cancellationToken)
    {
        var launch = await Mediator.Send(new GetOneLaunchQuery(flightNumber), cancellationToken);
        if (launch is null)
            return NotFound();

        return Ok(launch);
    }
}
