using MediatR;
using Application.Responses;

namespace Application.CQRS.InwardTransactions.Commands.DeleteInwardTransaction
{
    public class DeleteInwardTransactionCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}