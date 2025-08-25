// Application/CQRS/ReturnTransactions/Commands/UpdateReturnTransaction/UpdateReturnTransactionCommandHandler.cs
using Application.Responses;
using Application.Contracts;
using Application.DTOs.ReturnTransactions.Validators;
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.ReturnTransactions.Commands.UpdateReturnTransaction
{
    public class UpdateReturnTransactionCommandHandler : IRequestHandler<UpdateReturnTransactionCommand, BaseCommandResponse>
    {
        private readonly IReturnTransactionRepository _returnTransactionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateReturnTransactionCommandHandler(IReturnTransactionRepository returnTransactionRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _returnTransactionRepository = returnTransactionRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateReturnTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateReturnTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReturnTransactionDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var returnTransactionToUpdate = await _returnTransactionRepository.GetByIdAsync(request.ReturnTransactionDto.Id, cancellationToken);

            if (returnTransactionToUpdate == null)
            {
                response.Success = false;
                response.Message = "Return Transaction not found.";
                return response;
            }

            var itemToUpdate = await _itemRepository.GetByIdAsync(returnTransactionToUpdate.ItemId, cancellationToken);
            if (itemToUpdate != null)
            {
                itemToUpdate.StockQuantity -= returnTransactionToUpdate.Quantity;
                itemToUpdate.StockQuantity += request.ReturnTransactionDto.Quantity;
            }

            _mapper.Map(request.ReturnTransactionDto, returnTransactionToUpdate);
            await _returnTransactionRepository.UpdateAsync(returnTransactionToUpdate, cancellationToken);
            await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Return Transaction Updated Successfully";
            return response;
        }
    }
}