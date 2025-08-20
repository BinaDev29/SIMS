using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading.Tasks;
using System.Threading;
using Application.DTOs.InwardTransactions.Validators; // New using
using System.Linq; // New using

namespace Application.CQRS.InwardTransactions.Commands.CreateInwardTransaction
{
    public class CreateInwardTransactionCommandHandler : IRequestHandler<CreateInwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IInwardTransactionRepository _inwardTransactionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateInwardTransactionCommandHandler(IInwardTransactionRepository inwardTransactionRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _inwardTransactionRepository = inwardTransactionRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Add validation here
            var validator = new CreateInwardTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InwardTransactionDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var inwardTransaction = _mapper.Map<InwardTransaction>(request.InwardTransactionDto);

            var itemToUpdate = await _itemRepository.GetByIdAsync(request.InwardTransactionDto.ItemId, cancellationToken);
           

            if (itemToUpdate == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            itemToUpdate.StockQuantity += request.InwardTransactionDto.Quantity;

            await _inwardTransactionRepository.AddAsync(inwardTransaction, cancellationToken);
            await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Inward Transaction and Item Stock Updated Successfully";
            response.Id = inwardTransaction.Id;

            return response;
        }
    }
}