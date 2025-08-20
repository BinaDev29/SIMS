using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading.Tasks;
using System.Threading;
using Application.DTOs.OutwardTransactions.Validators; // New using
using System.Linq; // New using

namespace Application.CQRS.OutwardTransactions.Commands.CreateOutwardTransaction
{
    public class CreateOutwardTransactionCommandHandler : IRequestHandler<CreateOutwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IOutwardTransactionRepository _outwardTransactionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateOutwardTransactionCommandHandler(IOutwardTransactionRepository outwardTransactionRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOutwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // 1. የዳታ ማረጋገጫ (Validation)
            var validator = new CreateOutwardTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OutwardTransactionDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var outwardTransaction = _mapper.Map<OutwardTransaction>(request.OutwardTransactionDto);

            var itemToUpdate = await _itemRepository.GetByIdAsync(request.OutwardTransactionDto.ItemId, cancellationToken);

            if (itemToUpdate == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            if (itemToUpdate.StockQuantity < request.OutwardTransactionDto.Quantity)
            {
                response.Success = false;
                response.Message = "Insufficient stock.";
                return response;
            }

            itemToUpdate.StockQuantity -= request.OutwardTransactionDto.Quantity;

            // pass cancellationToken
            await _outwardTransactionRepository.AddAsync(outwardTransaction, cancellationToken);
            await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Outward Transaction and Item Stock Updated Successfully";
            response.Id = outwardTransaction.Id;

            return response;
        }
    }
}