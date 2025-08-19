using MediatR;
using Application.DTOs.ReturnTransactions;
using System.Collections.Generic;

namespace Application.CQRS.ReturnTransactions.Queries.GetReturnTransactionsList
{
    public class GetReturnTransactionsListQuery : IRequest<IReadOnlyList<ReturnTransactionDto>>
    {

    }
}