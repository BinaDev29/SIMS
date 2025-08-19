using MediatR;
using Application.Contracts;
using Application.Responses; // Changed to Responses
using Application.Exceptions;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, BaseCommandResponse> // Changed to BaseCommandResponse
    {
        private readonly IGenericRepository<Item> _itemRepository;

        public DeleteItemCommandHandler(IGenericRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken) // Changed to BaseCommandResponse
        {
            var response = new BaseCommandResponse(); // Changed to BaseCommandResponse
            var itemToDelete = await _itemRepository.GetByIdAsync(request.Id);

            if (itemToDelete == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            await _itemRepository.DeleteAsync(itemToDelete);

            response.Success = true;
            response.Message = "Item Deleted Successfully";

            return response;
        }
    }
}