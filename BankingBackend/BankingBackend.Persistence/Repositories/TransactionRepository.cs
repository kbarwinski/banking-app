using BankingBackend.Application.Repositories;
using BankingBackend.Domain.Entities;
using BankingBackend.Persistence.Context;

namespace BankingBackend.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DataContext context) : base(context)
        {
        }
    }
}
