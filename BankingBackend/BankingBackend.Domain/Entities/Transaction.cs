using BankingBackend.Domain.Common;

namespace BankingBackend.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        public virtual TransactionCategory Category { get; set; }
        public DateTimeOffset OccuredAt { get; set; }
    }
}
