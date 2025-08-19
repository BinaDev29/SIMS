using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.ReturnTransactions.Commands.UpdateReturnTransaction
{
    public class UpdateReturnTransactionCommandHandler : IRequestHandler<UpdateReturnTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<ReturnTransaction> _returnTransactionRepository;
        private readonly IMapper _mapper;

        public UpdateReturnTransactionCommandHandler(IGenericRepository<ReturnTransaction> returnTransactionRepository, IMapper mapper)
        {
            _returnTransactionRepository = returnTransactionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateReturnTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var returnTransactionToUpdate = await _returnTransactionRepository.GetByIdAsync(request.ReturnTransactionDto.Id);

            if (returnTransactionToUpdate == null)
            {
                response.Success = false;
                response.Message = "Return Transaction not found.";
                return response;
            }

            _mapper.Map(request.ReturnTransactionDto, returnTransactionToUpdate);
            await _returnTransactionRepository.UpdateAsync(returnTransactionToUpdate);

            response.Success = true;
            response.Message = "Return Transaction Updated Successfully";
            return response;
        }
    }
}