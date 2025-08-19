using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.OutwardTransactions.Commands.DeleteOutwardTransaction
{
    public class DeleteOutwardTransactionCommandHandler : IRequestHandler<DeleteOutwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<OutwardTransaction> _outwardTransactionRepository;

        public DeleteOutwardTransactionCommandHandler(IGenericRepository<OutwardTransaction> outwardTransactionRepository)
        {
            _outwardTransactionRepository = outwardTransactionRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteOutwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var outwardTransactionToDelete = await _outwardTransactionRepository.GetByIdAsync(request.Id);

            if (outwardTransactionToDelete == null)
            {
                response.Success = false;
                response.Message = "Outward Transaction not found.";
                return response;
            }

            await _outwardTransactionRepository.DeleteAsync(outwardTransactionToDelete);

            response.Success = true;
            response.Message = "Outward Transaction Deleted Successfully";
            return response;
        }
    }
}