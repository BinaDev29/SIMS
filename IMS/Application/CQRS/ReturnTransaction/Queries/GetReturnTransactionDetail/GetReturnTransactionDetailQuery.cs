using MediatR;
using Application.DTOs.ReturnTransactions;

namespace Application.CQRS.ReturnTransactions.Queries.GetReturnTransactionDetail
{
    public class GetReturnTransactionDetailQuery : IRequest<ReturnTransactionDto>
    {
        public required int Id { get; set; }
    }
}