using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.OutwardTransactions.Commands.DeleteOutwardTransaction
{
    public class DeleteOutwardTransactionCommandHandler : IRequestHandler<DeleteOutwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IOutwardTransactionRepository _outwardTransactionRepository;
        private readonly IItemRepository _itemRepository; // Added IItemRepository

        public DeleteOutwardTransactionCommandHandler(IOutwardTransactionRepository outwardTransactionRepository, IItemRepository itemRepository) // Added IItemRepository to constructor
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _itemRepository = itemRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteOutwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var outwardTransactionToDelete = await _outwardTransactionRepository.GetByIdAsync(request.Id, cancellationToken);

            if (outwardTransactionToDelete == null)
            {
                response.Success = false;
                response.Message = "Outward Transaction not found.";
                return response;
            }

            // Adjust stock quantity by adding back the delivered quantity
            var itemToUpdate = await _itemRepository.GetByIdAsync(outwardTransactionToDelete.ItemId, cancellationToken);
            if (itemToUpdate != null)
            {
                itemToUpdate.StockQuantity += outwardTransactionToDelete.QuantityDelivered;
                await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);
            }

            await _outwardTransactionRepository.DeleteAsync(outwardTransactionToDelete, cancellationToken);

            response.Success = true;
            response.Message = "Outward Transaction Deleted Successfully";
            return response;
        }
    }
}