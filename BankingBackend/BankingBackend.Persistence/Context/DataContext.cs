using BankingBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingBackend.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        #endregion
    }
}
