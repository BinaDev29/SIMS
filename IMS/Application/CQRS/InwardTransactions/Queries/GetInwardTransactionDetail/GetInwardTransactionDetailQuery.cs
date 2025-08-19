using MediatR;
using Application.DTOs.InwardTransactions;

namespace Application.CQRS.InwardTransactions.Queries.GetInwardTransactionDetail
{
    public class GetInwardTransactionDetailQuery : IRequest<InwardTransactionDto>
    {
        public required int Id { get; set; }
    }
}