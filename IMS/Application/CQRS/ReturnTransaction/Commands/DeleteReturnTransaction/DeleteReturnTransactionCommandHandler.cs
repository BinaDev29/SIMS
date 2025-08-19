using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.ReturnTransactions.Commands.DeleteReturnTransaction
{
    public class DeleteReturnTransactionCommandHandler : IRequestHandler<DeleteReturnTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<ReturnTransaction> _returnTransactionRepository;

        public DeleteReturnTransactionCommandHandler(IGenericRepository<ReturnTransaction> returnTransactionRepository)
        {
            _returnTransactionRepository = returnTransactionRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteReturnTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var returnTransactionToDelete = await _returnTransactionRepository.GetByIdAsync(request.Id);

            if (returnTransactionToDelete == null)
            {
                response.Success = false;
                response.Message = "Return Transaction not found.";
                return response;
            }

            await _returnTransactionRepository.DeleteAsync(returnTransactionToDelete);

            response.Success = true;
            response.Message = "Return Transaction Deleted Successfully";
            return response;
        }
    }
}