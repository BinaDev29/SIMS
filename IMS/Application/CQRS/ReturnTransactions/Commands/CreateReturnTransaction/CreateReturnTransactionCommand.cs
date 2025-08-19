using MediatR;
using Application.DTOs.ReturnTransactions;
using Application.Responses;

namespace Application.CQRS.ReturnTransactions.Commands.CreateReturnTransaction
{
    public class CreateReturnTransactionCommand : IRequest<BaseCommandResponse>
    {
        public required CreateReturnTransactionDto ReturnTransactionDto { get; set; }
    }
}