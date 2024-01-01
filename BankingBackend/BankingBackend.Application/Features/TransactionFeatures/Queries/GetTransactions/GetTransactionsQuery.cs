using BankingBackend.Application.Common.Queries;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransactions
{
    public record GetTransactionsQuery(int Page = 0, int PageSize = 20, string SortingOrders = "", List<Guid>? CategoryIds = null)
        : PaginationQuery(Page, PageSize, SortingOrders), IRequest<GetTransactionsQueryResponse>;
}
