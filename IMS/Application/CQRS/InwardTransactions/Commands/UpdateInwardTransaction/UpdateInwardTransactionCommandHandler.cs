using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.InwardTransactions.Commands.UpdateInwardTransaction
{
    public class UpdateInwardTransactionCommandHandler : IRequestHandler<UpdateInwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IInwardTransactionRepository _inwardTransactionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateInwardTransactionCommandHandler(IInwardTransactionRepository inwardTransactionRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _inwardTransactionRepository = inwardTransactionRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateInwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var inwardTransactionToUpdate = await _inwardTransactionRepository.GetByIdAsync(request.InwardTransactionDto.Id, cancellationToken);

            if (inwardTransactionToUpdate == null)
            {
                response.Success = false;
                response.Message = "Inward Transaction not found.";
                return response;
            }

            var oldQuantity = inwardTransactionToUpdate.QuantityReceived;

            _mapper.Map(request.InwardTransactionDto, inwardTransactionToUpdate);

            // Adjust stock quantity
            var itemToUpdate = await _itemRepository.GetByIdAsync(inwardTransactionToUpdate.ItemId, cancellationToken);
            if (itemToUpdate != null)
            {
                var newQuantity = inwardTransactionToUpdate.QuantityReceived;
                itemToUpdate.StockQuantity += (newQuantity - oldQuantity);
                await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);
            }

            await _inwardTransactionRepository.UpdateAsync(inwardTransactionToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Inward Transaction Updated Successfully";
            return response;
        }
    }
}