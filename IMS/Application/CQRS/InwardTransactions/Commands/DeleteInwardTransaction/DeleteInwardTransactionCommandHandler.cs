using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.InwardTransactions.Commands.DeleteInwardTransaction
{
    public class DeleteInwardTransactionCommandHandler : IRequestHandler<DeleteInwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IInwardTransactionRepository _inwardTransactionRepository;
        private readonly IItemRepository _itemRepository;

        public DeleteInwardTransactionCommandHandler(IInwardTransactionRepository inwardTransactionRepository, IItemRepository itemRepository)
        {
            _inwardTransactionRepository = inwardTransactionRepository;
            _itemRepository = itemRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteInwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var inwardTransactionToDelete = await _inwardTransactionRepository.GetByIdAsync(request.Id, cancellationToken);

            if (inwardTransactionToDelete == null)
            {
                response.Success = false;
                response.Message = "Inward Transaction not found.";
                return response;
            }

            var itemToUpdate = await _itemRepository.GetByIdAsync(inwardTransactionToDelete.ItemId, cancellationToken);
            if (itemToUpdate != null)
            {
                itemToUpdate.StockQuantity -= inwardTransactionToDelete.QuantityReceived;
                await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);
            }

            await _inwardTransactionRepository.DeleteAsync(inwardTransactionToDelete, cancellationToken);

            response.Success = true;
            response.Message = "Inward Transaction Deleted Successfully";
            return response;
        }
    }
}