using MediatR;
using Application.Responses;

namespace Application.CQRS.OutwardTransactions.Commands.DeleteOutwardTransaction
{
    public class DeleteOutwardTransactionCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}