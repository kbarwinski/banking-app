using BankingBackend.Application.Repositories;
using BankingBackend.Domain.Entities;
using BankingBackend.Persistence.Context;

namespace BankingBackend.Persistence.Repositories
{
    public class TransactionCategoryRepository : BaseRepository<TransactionCategory>, ITransactionCategoryRepository
    {
        public TransactionCategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
