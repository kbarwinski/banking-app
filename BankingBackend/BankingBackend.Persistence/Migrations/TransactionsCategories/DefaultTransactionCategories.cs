using BankingBackend.Domain.Entities;

namespace BankingBackend.Persistence.Migrations.TransactionsCategories
{
    public static class DefaultTransactionCategories
    {
        public static TransactionCategory Salary { get; } = new TransactionCategory
        {
            Id = new Guid("1f4e1af0-a1f7-4b7d-9d36-ea1111111111"),
            IsIncomeCategory = true,
            Name = "Wynagrodzenie"
        };

        public static TransactionCategory OtherIncome { get; } = new TransactionCategory
        {
            Id = new Guid("2c5e2bf1-b10c-4cda-9d37-ea2222222222"),
            IsIncomeCategory = true,
            Name = "Inny przychód"
        };

        public static TransactionCategory Bills { get; } = new TransactionCategory
        {
            Id = new Guid("3d6f3cf2-c20d-49e8-9d38-ea3333333333"),
            IsIncomeCategory = false,
            Name = "Rachunki"
        };

        public static TransactionCategory Commodities { get; } = new TransactionCategory
        {
            Id = new Guid("4e7f4df3-d30e-5ff9-9d39-ea4444444444"),
            IsIncomeCategory = false,
            Name = "Zakupy codzienne"
        };

        public static TransactionCategory Entertainment { get; } = new TransactionCategory
        {
            Id = new Guid("5f8e5ef4-e30f-60aa-9d40-ea5555555555"),
            IsIncomeCategory = false,
            Name = "Rozrywka"
        };

        public static List<TransactionCategory> GetAll()
        {
            return new List<TransactionCategory>
            {
                    Salary,
                    OtherIncome,
                    Bills,
                    Commodities,
                    Entertainment
            };
        }
    }

}
