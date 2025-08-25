using Application.Responses; // Namespace corrected
using Application.Contracts;
using Application.DTOs.ReturnTransactions.Validators; // New using for validation
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Linq; // New using for validation
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.ReturnTransactions.Commands.CreateReturnTransaction
{
    public class CreateReturnTransactionCommandHandler : IRequestHandler<CreateReturnTransactionCommand, BaseCommandResponse>
    {
        private readonly IReturnTransactionRepository _returnTransactionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateReturnTransactionCommandHandler(IReturnTransactionRepository returnTransactionRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _returnTransactionRepository = returnTransactionRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateReturnTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Add validation
            var validator = new CreateReturnTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReturnTransactionDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var returnTransaction = _mapper.Map<ReturnTransaction>(request.ReturnTransactionDto);

            // የእቃውን stock መጠን ለመጨመር ኮዱን እንጨምራለን።
            var itemToUpdate = await _itemRepository.GetByIdAsync(request.ReturnTransactionDto.ItemId, cancellationToken);

            if (itemToUpdate == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            // የstock መጠኑን ይጨምራል።
            itemToUpdate.StockQuantity += request.ReturnTransactionDto.Quantity;

            await _returnTransactionRepository.AddAsync(returnTransaction, cancellationToken);
            await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Return Transaction and Item Stock Updated Successfully";
            response.Id = returnTransaction.Id;

            return response;
        }
    }
}