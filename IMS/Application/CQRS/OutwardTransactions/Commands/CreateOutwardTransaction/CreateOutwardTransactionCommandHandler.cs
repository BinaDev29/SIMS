using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading.Tasks;
using System.Threading;

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
            var outwardTransaction = _mapper.Map<OutwardTransaction>(request.OutwardTransactionDto);

            // የእቃውን stock መጠን ለመቀነስ ኮዱን እንጨምራለን።
            var itemToUpdate = await _itemRepository.GetByIdAsync(request.OutwardTransactionDto.ItemId);

            if (itemToUpdate == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            // የእቃው StockQuantity ከሚወጣው መጠን ያነሰ ከሆነ ስህተት እንመዘግባለን
            if (itemToUpdate.StockQuantity < request.OutwardTransactionDto.Quantity)
            {
                response.Success = false;
                response.Message = "Insufficient stock.";
                return response;
            }

            // የstock መጠኑን ይቀንሳል።
            itemToUpdate.StockQuantity -= request.OutwardTransactionDto.Quantity;

            await _outwardTransactionRepository.AddAsync(outwardTransaction);
            await _itemRepository.UpdateAsync(itemToUpdate);

            response.Success = true;
            response.Message = "Outward Transaction and Item Stock Updated Successfully";
            response.Id = outwardTransaction.Id;

            return response;
        }
    }
}