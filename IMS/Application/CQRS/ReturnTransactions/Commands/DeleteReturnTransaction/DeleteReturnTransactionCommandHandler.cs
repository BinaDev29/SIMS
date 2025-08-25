// Application/CQRS/ReturnTransactions/Commands/DeleteReturnTransaction/DeleteReturnTransactionCommandHandler.cs
using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.ReturnTransactions.Commands.DeleteReturnTransaction
{
    public class DeleteReturnTransactionCommandHandler : IRequestHandler<DeleteReturnTransactionCommand, BaseCommandResponse>
    {
        private readonly IReturnTransactionRepository _returnTransactionRepository;
        private readonly IItemRepository _itemRepository;

        public DeleteReturnTransactionCommandHandler(IReturnTransactionRepository returnTransactionRepository, IItemRepository itemRepository)
        {
            _returnTransactionRepository = returnTransactionRepository;
            _itemRepository = itemRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteReturnTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var returnTransactionToDelete = await _returnTransactionRepository.GetByIdAsync(request.Id, cancellationToken);

            if (returnTransactionToDelete == null)
            {
                response.Success = false;
                response.Message = "Return Transaction not found.";
                return response;
            }

            var itemToUpdate = await _itemRepository.GetByIdAsync(returnTransactionToDelete.ItemId, cancellationToken);
            if (itemToUpdate != null)
            {
                itemToUpdate.StockQuantity -= returnTransactionToDelete.Quantity;
                await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);
            }

            await _returnTransactionRepository.DeleteAsync(returnTransactionToDelete, cancellationToken);

            response.Success = true;
            response.Message = "Return Transaction Deleted Successfully";
            return response;
        }
    }
}