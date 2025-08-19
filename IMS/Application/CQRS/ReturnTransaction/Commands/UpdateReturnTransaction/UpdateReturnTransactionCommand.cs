using MediatR;
using Application.DTOs.ReturnTransactions;
using Application.Responses;

namespace Application.CQRS.ReturnTransactions.Commands.UpdateReturnTransaction
{
    public class UpdateReturnTransactionCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateReturnTransactionDto ReturnTransactionDto { get; set; }
    }
}