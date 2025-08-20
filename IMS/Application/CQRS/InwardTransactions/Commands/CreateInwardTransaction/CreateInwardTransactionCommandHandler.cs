using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading.Tasks;
using System.Threading;

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
            var inwardTransaction = _mapper.Map<InwardTransaction>(request.InwardTransactionDto);

            var itemToUpdate = await _itemRepository.GetByIdAsync(request.InwardTransactionDto.ItemId);

            if (itemToUpdate == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            itemToUpdate.StockQuantity += request.InwardTransactionDto.Quantity;

            await _inwardTransactionRepository.AddAsync(inwardTransaction);
            await _itemRepository.UpdateAsync(itemToUpdate);

            response.Success = true;
            response.Message = "Inward Transaction and Item Stock Updated Successfully";
            response.Id = inwardTransaction.Id;

            return response;
        }
    }
}