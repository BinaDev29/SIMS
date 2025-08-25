using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Item> _itemRepository;

        public DeleteItemCommandHandler(IGenericRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var itemToDelete = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);

            if (itemToDelete == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);

            response.Success = true;
            response.Message = "Item Deleted Successfully";

            return response;
        }
    }
}