using MediatR;
using Application.Responses;

namespace Application.CQRS.ReturnTransactions.Commands.DeleteReturnTransaction
{
    public class DeleteReturnTransactionCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}