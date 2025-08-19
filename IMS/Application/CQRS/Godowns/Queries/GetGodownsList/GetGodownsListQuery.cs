using MediatR;
using Application.DTOs.Godowns;
using System.Collections.Generic;

namespace Application.CQRS.Godowns.Queries.GetGodownsList
{
    public class GetGodownsListQuery : IRequest<IReadOnlyList<GodownDto>>
    {

    }
}