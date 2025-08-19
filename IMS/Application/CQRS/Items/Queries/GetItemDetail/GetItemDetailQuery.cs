using MediatR;
using Application.DTOs.Items;

namespace Application.CQRS.Items.Queries.GetItemDetail
{
    public class GetItemDetailQuery : IRequest<ItemDto>
    {
        public required int Id { get; set; }
    }
}