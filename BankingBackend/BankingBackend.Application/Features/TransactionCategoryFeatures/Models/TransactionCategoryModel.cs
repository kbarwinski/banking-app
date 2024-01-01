namespace BankingBackend.Application.Features.TransactionCategoryFeatures.Models
{
    public class TransactionCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsIncomeCategory { get; set; }
    }
}
    