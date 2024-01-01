using BankingBackend.Application.Repositories;
using FluentMigrator;

namespace BankingBackend.Persistence.Migrations.TransactionsCategories
{
    [Migration(202312211027)]
    public class _01_SeedDefaultTransactionCategories : BaseMigration
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public _01_SeedDefaultTransactionCategories(ITransactionCategoryRepository transactionCategoryRepository, IUnitOfWork unitOfWork)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public override void Up()
        {
            _transactionCategoryRepository.CreateRange(DefaultTransactionCategories.GetAll());

            _unitOfWork.Save(CancellationToken.None).GetAwaiter().GetResult();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
