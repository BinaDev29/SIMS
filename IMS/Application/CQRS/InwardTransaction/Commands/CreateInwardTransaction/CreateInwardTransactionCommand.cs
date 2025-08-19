using MediatR;
using Application.DTOs.InwardTransactions;
using Application.Responses;

namespace Application.CQRS.InwardTransactions.Commands.CreateInwardTransaction
{
    public class CreateInwardTransactionCommand : IRequest<BaseCommandResponse>
    {
        public required CreateInwardTransactionDto InwardTransactionDto { get; set; }
    }
}