namespace BankingBackend.Application.Common.Queries
{
    public record PaginationQuery(int Page, int PageSize, string SortingOrders);
}
