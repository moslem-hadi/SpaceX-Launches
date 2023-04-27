using System.ComponentModel;

namespace SpaceXLaunches.Application.Dtos;

public record PagedQuery
{
    [DefaultValue(1)]
    public int PageNumber { get; init; } = 1;

    [DefaultValue(10)]
    public int PageSize { get; init; } = 10;
}