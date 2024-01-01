using BankingBackend.Application.Common.Models;

namespace BankingBackend.Application.Common.Queries
{
    public abstract class BasePaginationResponse<T>
    {
        public List<T> Result { get; set; }
        public PaginationModel Pagination { get; set; }
    }
}
