using MediatR;
using Application.DTOs.OutwardTransactions;
using System.Collections.Generic;

namespace Application.CQRS.OutwardTransactions.Queries.GetOutwardTransactionsList
{
    public class GetOutwardTransactionsListQuery : IRequest<IReadOnlyList<OutwardTransactionDto>>
    {

    }
}