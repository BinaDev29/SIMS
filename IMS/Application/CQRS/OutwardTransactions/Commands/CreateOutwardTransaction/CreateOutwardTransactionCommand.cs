using MediatR;
using Application.DTOs.OutwardTransactions;
using Application.Responses;

namespace Application.CQRS.OutwardTransactions.Commands.CreateOutwardTransaction
{
    public class CreateOutwardTransactionCommand : IRequest<BaseCommandResponse>
    {
        public required CreateOutwardTransactionDto OutwardTransactionDto { get; set; }
    }
}