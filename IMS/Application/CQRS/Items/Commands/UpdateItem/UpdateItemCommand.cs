using MediatR;
using Application.DTOs.Items;
using Application.Responses; // Changed to Responses

namespace Application.CQRS.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest<BaseCommandResponse> // Changed to BaseCommandResponse
    {
        public required UpdateItemDto ItemDto { get; set; }
    }
}