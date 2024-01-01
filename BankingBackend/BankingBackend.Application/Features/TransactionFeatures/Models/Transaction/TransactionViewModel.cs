namespace BankingBackend.Application.Features.TransactionFeatures.Models.Transaction
{
    public class TransactionViewModel : TransactionBaseModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
