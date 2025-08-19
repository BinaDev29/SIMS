using MediatR;
using Application.DTOs.Items;
using Application.Responses; // Changed to Responses

namespace Application.CQRS.Items.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<BaseCommandResponse> // Changed to BaseCommandResponse
    {
        public required CreateItemDto ItemDto { get; set; }
    }
}