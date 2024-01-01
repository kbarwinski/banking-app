using BankingBackend.Application.Repositories;
using FluentMigrator;

namespace BankingBackend.Persistence.Migrations.Transactions
{
    [Migration(202312211028)]
    public class _01_SeedExampleTransactions : BaseMigration
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public _01_SeedExampleTransactions(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public override void Up()
        {
            _transactionRepository.CreateRange(ExampleTransactions.GetAll());

            _unitOfWork.Save(CancellationToken.None).GetAwaiter().GetResult();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
