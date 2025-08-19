using MediatR;
using Application.DTOs.InwardTransactions;
using Application.Responses;

namespace Application.CQRS.InwardTransactions.Commands.UpdateInwardTransaction
{
    public class UpdateInwardTransactionCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateInwardTransactionDto InwardTransactionDto { get; set; }
    }
}