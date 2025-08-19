using MediatR;
using Application.DTOs.Items;
using System.Collections.Generic;

namespace Application.CQRS.Items.Queries.GetItemsList
{
    public class GetItemsListQuery : IRequest<IReadOnlyList<ItemDto>>
    {

    }
}