using MediatR;
using Application.DTOs.OutwardTransactions;

namespace Application.CQRS.OutwardTransactions.Queries.GetOutwardTransactionDetail
{
    public class GetOutwardTransactionDetailQuery : IRequest<OutwardTransactionDto>
    {
        public required int Id { get; set; }
    }
}