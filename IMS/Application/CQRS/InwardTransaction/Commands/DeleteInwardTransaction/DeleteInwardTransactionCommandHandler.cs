using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.InwardTransactions.Commands.DeleteInwardTransaction
{
    public class DeleteInwardTransactionCommandHandler : IRequestHandler<DeleteInwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<InwardTransaction> _inwardTransactionRepository;

        public DeleteInwardTransactionCommandHandler(IGenericRepository<InwardTransaction> inwardTransactionRepository)
        {
            _inwardTransactionRepository = inwardTransactionRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteInwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var inwardTransactionToDelete = await _inwardTransactionRepository.GetByIdAsync(request.Id);

            if (inwardTransactionToDelete == null)
            {
                response.Success = false;
                response.Message = "Inward Transaction not found.";
                return response;
            }

            await _inwardTransactionRepository.DeleteAsync(inwardTransactionToDelete);

            response.Success = true;
            response.Message = "Inward Transaction Deleted Successfully";
            return response;
        }
    }
}