namespace BankingBackend.Application.Repositories
{
    public interface IUnitOfWork
    {
        public Task Save(CancellationToken cancellationToken);
    }
}
