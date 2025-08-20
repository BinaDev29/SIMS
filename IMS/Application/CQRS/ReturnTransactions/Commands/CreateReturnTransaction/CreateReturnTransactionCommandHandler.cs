using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading.Tasks;
using System.Threading;

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
            var returnTransaction = _mapper.Map<ReturnTransaction>(request.ReturnTransactionDto);

            // የእቃውን stock መጠን ለመጨመር ኮዱን እንጨምራለን።
            var itemToUpdate = await _itemRepository.GetByIdAsync(request.ReturnTransactionDto.ItemId);

            if (itemToUpdate == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            // የstock መጠኑን ይጨምራል።
            itemToUpdate.StockQuantity += request.ReturnTransactionDto.Quantity;

            await _returnTransactionRepository.AddAsync(returnTransaction);
            await _itemRepository.UpdateAsync(itemToUpdate);

            response.Success = true;
            response.Message = "Return Transaction and Item Stock Updated Successfully";
            response.Id = returnTransaction.Id;

            return response;
        }
    }
}