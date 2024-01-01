using BankingBackend.Application.Features.TransactionCategoryFeatures.Models;

namespace BankingBackend.Application.Features.TransactionFeatures.Models.Transaction
{
    public class TransactionBaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionCategoryModel Category { get; set; }
        public DateTimeOffset OccuredAt { get; set; }
    }
}
