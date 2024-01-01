using BankingBackend.Application.Common.Models;
using BankingBackend.Application.Common.Queries;
using BankingBackend.Domain.Common;
using System.Linq.Expressions;

namespace BankingBackend.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void CreateRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        Task<T?> Get(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken,
            bool asNoTracking,
            params Expression<Func<T, object>>[] includeProperties);

        Task<List<T>> GetOrdered(
    Expression<Func<T, bool>> predicate,
    string sortingOrders,
    Dictionary<string, Expression<Func<T, object>>> orderPredicates,
    CancellationToken cancellationToken,
    params Expression<Func<T, object>>[] includeProperties);

        Task<List<T>> GetFiltered(
            Dictionary<Expression<Func<T, bool>>, bool> filterPredicates,
            CancellationToken cancellationToken,
            params Expression<Func<T, object>>[] includeProperties);

        Task<List<T>> GetAll(CancellationToken cancellationToken, params Expression<Func<T, object>>[] includeProperties);

        Task<List<T>> GetWhere(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken,
            params Expression<Func<T, object>>[] includeProperties);

        Task<(List<T>, PaginationModel)> GetFilteredAndOrderedPage(
        PaginationQuery pagination,
        Dictionary<Expression<Func<T, bool>>, bool> filterPredicates,
        Dictionary<string, Expression<Func<T, object>>> orderPredicates,
        CancellationToken cancellationToken,
        params Expression<Func<T, object>>[] includeProperties);
    }
}
