using Application.Responses;
using Application.Contracts;
using Application.DTOs.OutwardTransactions.Validators;
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.OutwardTransactions.Commands.UpdateOutwardTransaction
{
    public class UpdateOutwardTransactionCommandHandler : IRequestHandler<UpdateOutwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IOutwardTransactionRepository _outwardTransactionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateOutwardTransactionCommandHandler(IOutwardTransactionRepository outwardTransactionRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateOutwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Add validation
            var validator = new UpdateOutwardTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OutwardTransactionDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation Failed";
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var outwardTransactionToUpdate = await _outwardTransactionRepository.GetByIdAsync(request.OutwardTransactionDto.Id, cancellationToken);

            if (outwardTransactionToUpdate == null)
            {
                response.Success = false;
                response.Message = "Outward Transaction not found.";
                return response;
            }

            // Correct stock quantity of the item
            var itemToUpdate = await _itemRepository.GetByIdAsync(outwardTransactionToUpdate.ItemId, cancellationToken);

            if (itemToUpdate != null)
            {
                // Revert the stock for the old transaction quantity
                itemToUpdate.StockQuantity += outwardTransactionToUpdate.QuantityDelivered;

                // Check for sufficient stock for the new quantity
                if (itemToUpdate.StockQuantity < request.OutwardTransactionDto.QuantityDelivered)
                {
                    response.Success = false;
                    response.Message = "Insufficient stock to update transaction.";
                    return response;
                }

                // Subtract the new quantity
                itemToUpdate.StockQuantity -= request.OutwardTransactionDto.QuantityDelivered;

                _mapper.Map(request.OutwardTransactionDto, outwardTransactionToUpdate);

                await _outwardTransactionRepository.UpdateAsync(outwardTransactionToUpdate, cancellationToken);
                await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);
            }
            else
            {
                response.Success = false;
                response.Message = "Associated item not found for the transaction.";
                return response;
            }

            response.Success = true;
            response.Message = "Outward Transaction Updated Successfully";
            return response;
        }
    }
}