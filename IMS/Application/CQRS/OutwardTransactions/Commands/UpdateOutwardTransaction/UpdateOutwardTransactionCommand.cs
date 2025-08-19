using MediatR;
using Application.DTOs.OutwardTransactions;
using Application.Responses;

namespace Application.CQRS.OutwardTransactions.Commands.UpdateOutwardTransaction
{
    public class UpdateOutwardTransactionCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateOutwardTransactionDto OutwardTransactionDto { get; set; }
    }
}