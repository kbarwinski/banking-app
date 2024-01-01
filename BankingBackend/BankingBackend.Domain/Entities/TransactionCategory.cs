using BankingBackend.Domain.Common;

namespace BankingBackend.Domain.Entities
{
    public class TransactionCategory : BaseEntity
    {
        public string Name { get; set; }
        public bool IsIncomeCategory { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
