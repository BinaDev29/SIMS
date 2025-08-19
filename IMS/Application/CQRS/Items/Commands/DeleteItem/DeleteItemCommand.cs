using MediatR;
using Application.Responses; // Changed to Responses

namespace Application.CQRS.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest<BaseCommandResponse> // Changed to BaseCommandResponse
    {
        public int Id { get; set; }
    }
}